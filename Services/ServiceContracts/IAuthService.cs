﻿using Entities.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace Services.ServiceContracts
{
	public interface IAuthService
	{
		Task<IdentityResult> RegisterUser(UserDtoForRegistration userForRegistrationDto);
		Task<IdentityResult> DeleteUserByEmail(string email);
	}
}
