using AutoMapper;
using Entities.DTOs.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.ServiceContracts;

namespace Services.ServiceConcretes
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		//private readonly IConfiguration _configuration;
		public AuthService(IMapper mapper, UserManager<AppUser> userManager)
		{
			_userManager = userManager;
			_mapper = mapper;
		}
		public async Task<IdentityResult> RegisterUser(UserDtoForRegistration userForRegistrationDto)
		{
			var user = _mapper.Map<AppUser>(userForRegistrationDto);

			var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password!);

			if (result.Succeeded)
				await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);

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
	}
}
