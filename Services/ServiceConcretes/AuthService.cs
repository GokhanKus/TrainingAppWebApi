using AutoMapper;
using Entities.DTOs.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ServiceContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.ServiceConcretes
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		private AppUser? _user;
		public AuthService(IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_mapper = mapper;
			_configuration = configuration;
		}
		public async Task<IdentityResult> RegisterUser(UserDtoForRegistration userForRegistrationDto)
		{
			var user = _mapper.Map<AppUser>(userForRegistrationDto);

			var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password!);

			if (result.Succeeded)
				await _userManager.AddToRoleAsync(user, "User");

			return result;
		}
		public async Task<IdentityResult> DeleteUserByEmail(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);

			if (user == null)
				throw new Exception("no users found");

			var result = await _userManager.DeleteAsync(user);
			return result;

		}
		public async Task<bool> ValidateUser(UserDtoForAuthentication userForAuthDto)
		{
			_user = await _userManager.FindByNameAsync(userForAuthDto.UserName!);
			var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthDto.Password!));

			//ilerde hata fırlatmak yerine logger ile kayit tutulabilir 
			if (!result)
				throw new Exception("Authentication failed. Wrong username or password.");

			return result;
		}
		public async Task<string> CreateToken()
		{
			var signinCredentials = GetSignInCredentials(); //kimlik bilgileri alindi
			var claims = await GetClaims();                 //claimsler alindi (rol, hak, iddia)
			var tokenOptions = GenerateTokenOptions(signinCredentials, claims);//token olusturma secenekleri generate edildi
			string jsonWebToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return jsonWebToken;
		}
		private SigningCredentials GetSignInCredentials()
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = jwtSettings["secretKey"];
			var key = Encoding.UTF8.GetBytes(secretKey);
			var secret = new SymmetricSecurityKey(key);
			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}
		private async Task<List<Claim>> GetClaims()
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,_user.UserName), // Kullanıcı adı eklendi
				 new Claim(ClaimTypes.NameIdentifier, _user.Id), // Kullanıcı ID'si eklendi //bu User.FindFirstValue(ClaimTypes.NameIdentifier); ile userId alabilmek icin gerekli
			};
			var roles = await _userManager.GetRolesAsync(_user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			return claims;
		}
		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");

			var tokenOptions = new JwtSecurityToken(
				issuer: jwtSettings["validIssuer"],
				audience: jwtSettings["validAudience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
				signingCredentials: signinCredentials);

			return tokenOptions;
		}

	}
}
