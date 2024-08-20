using Entities.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AccountController : ControllerBase
	{
		private readonly IAuthService _auth;
		public AccountController(IAuthService auth)
		{
			_auth = auth;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterUser([FromBody] UserDtoForRegistration userForRegistrationDto)
		{
			var result = await _auth.RegisterUser(userForRegistrationDto);
			if (!result.Succeeded)
			{
				foreach (var err in result.Errors)
				{
					ModelState.TryAddModelError(err.Code, err.Description);
				}
				return BadRequest(ModelState);
			}
			return StatusCode(201); //return Created();
		}

		[HttpDelete("{email}")]
		public async Task<IActionResult> DeleteUser([FromRoute] string email)
		{
			var result = await _auth.DeleteUserByEmail(email);
			if (!result.Succeeded)
			{
				foreach (var err in result.Errors)
				{
					ModelState.TryAddModelError(err.Code, err.Description);
				}
				return BadRequest(ModelState);
			}
			return StatusCode(201); //return Created();
		}
	}
}
