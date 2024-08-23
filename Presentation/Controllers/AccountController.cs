using Entities.DTOs.User;
using Microsoft.AspNetCore.Authorization;
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

		[HttpPost("register")]
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
		[Authorize(Roles = "Admin")]
		[HttpDelete("delete/{email}")]
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

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserDtoForAuthentication userForAuthDto)
		{
			if (!await _auth.ValidateUser(userForAuthDto))
				return Unauthorized(); //401

			var tokenDto = await _auth.CreateToken(populateExpiry: true);

			return Ok(new
			{
				Token = await _auth.CreateToken()
			});

			//[Authorize] olan Controllerlarimizda actionlara(metotlara) erisebilmek icin uretilen token ile postman'de authorization kısmında bearer token secerek erisilebilir
			//Postmande Controllerlarda orn Workout icin requestler.. Autherization kismina Tokeni ver, crud islemlerinde autherization kismina type: Inherit auth from parent
			//account post login icin postmande script yazildi, artik her login oldugumuzda gelen token otomatik olarak global accessTokene set ediliyor yani artik manuel olarak girmiyoruz
		}
	}
}
