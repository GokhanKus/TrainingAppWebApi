using AutoMapper;
using Entities.DTOs.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ServiceContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
		public async Task<TokenDto> CreateToken(bool populateExpiry)
		{
			var signinCredentials = GetSignInCredentials(); //kimlik bilgileri alindi
			var claims = await GetClaims();                 //claimsler alindi (rol, hak, iddia)
			var tokenOptions = GenerateTokenOptions(signinCredentials, claims);//token olusturma secenekleri generate edildi

			var refreshToken = GenerateRefreshToken();
			_user.RefreshToken = refreshToken;

			if (populateExpiry)
				_user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

			await _userManager.UpdateAsync(_user);
			var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return new TokenDto
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
			//string jsonWebToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			//return jsonWebToken;
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())//masrafli is yapilacaksa using kullanilabilir
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
			//scope'tan cikinca ilgili kaynak serbest birakilir garbage collector
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
		private ClaimsPrincipal GetPrincipalFromExpiredToken(string token) //suresi gecmis olan tokendan bu ifadeyi alalim
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = jwtSettings["secretKey"];
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidateAudience = true,
				ValidIssuer = jwtSettings["validIssuer"], //tokenin üreticisi dagiticisi
				ValidAudience = jwtSettings["validAudience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;//degeri out parametresi ile belirleniyor

			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

			var jwtSecurityToken = securityToken as JwtSecurityToken; //securityToken'i JwtSecurityToken'e convert edelim, basarisiz olursa jwtSecurityToken null

			if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				throw new SecurityTokenException("Invalid Token");

			return principal;
		}

		public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
		{
			var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

			//dbde ilgili user var mi? onu alalim
			var user = await _userManager.FindByNameAsync(principal.Identity.Name);

			if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
				throw new Exception("Invalid client request. The tokenDto has some invalid values.");
			//throw new RefreshTokenBadRequestException(); ileride hata yonetimi eklenecek

			_user = user;
			return await CreateToken(populateExpiry: false);
		}
	}
}
