using Entities.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ServiceFilter(typeof(LogFilterAttribute))]
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
		[ValidationFilter]
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
		[ValidationFilter]
		public async Task<IActionResult> Authenticate([FromBody] UserDtoForAuthentication userForAuthDto)
		{
			if (!await _auth.ValidateUser(userForAuthDto))
				return Unauthorized(); //401

			var tokenDto = await _auth.CreateToken(populateExpiry: true);
			return Ok(tokenDto);

			//[Authorize] olan Controllerlarimizda actionlara(metotlara) erisebilmek icin uretilen token ile postman'de authorization kısmında bearer token secerek erisilebilir
			//Postmande Controllerlarda orn Workout icin requestler.. Autherization kismina Tokeni ver, crud islemlerinde autherization kismina type: Inherit auth from parent
			//account post login icin postmande script yazildi, artik her login oldugumuzda gelen token otomatik olarak global accessTokene set ediliyor yani artik manuel olarak girmiyoruz
		}

		[HttpPost("refresh")]
		[ValidationFilter]
		public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
		{
			var tokenDtoToReturn = await _auth.RefreshToken(tokenDto);
			return Ok(tokenDtoToReturn);
			//Refresh Token
			//kurumsal firmalarda genellikle tokenlerin suresi 30 dk, 1 saat değil de 5 dk gibi kısa süreler de olur, cunku encode edilen bu tokenler decoder ile basit bir sekilde cozulecegi icin ve
			//kotu niyetli kisilerin bu tokeni alıp kullanabilecegi icin 5 dk gibi kısa sureli tokenler olusturulur ve refresh edilir refresh token bu yuzden kullanilir
			//ayrıca tokenlerin expiry olma (sona erme) süreleri vardır refresh token sayesinde sanki istemci hic kopmamis gibi yeni tokeniyle istek atmaya devam edebilir
			//hem guvenlık anlaminda hem de tokenin suresi bittiginde tekrar login olma zorunlulugu olmadan refresh token sayesinde isteklere devam edebilir
		}
	}
}
