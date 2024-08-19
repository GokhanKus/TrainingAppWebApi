using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepoConcretes;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[Route("api/body-measurement")]
	[ApiController]
	public class BodyMeasurementsController : ControllerBase
	{
		//henuz user login, jwt token veya cookie islemleri yapilmadigi icin userId manuel olarak biz verelim, ilerde dinamik olarak userId'i ClaimTypes.NameIdentifier ile alacagiz.
		static string johnDoeId = "a3058765-ecf0-403e-9d48-08b38d4888ab";
		static string janeDoeId = "8cee140a-65fd-495d-970b-5315a6f3e7b2";
		private readonly IBodyMeasurementService _bodyMeasurementService;
		private readonly UserManager<AppUser> _userManager;
		public BodyMeasurementsController(IBodyMeasurementService bodyMeasurementService, UserManager<AppUser> userManager)
		{
			_bodyMeasurementService = bodyMeasurementService;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBodyMeasurementsAsync()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı Id alınıyor
			var measurementWithUser = await _bodyMeasurementService.GetAllBodyMeasurementsByUserIdAsync(johnDoeId, false);
			return Ok(measurementWithUser);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneBodyMeasurementAsync([FromRoute] int id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı Id alınıyor

			//if (userId == null)
			//	return Unauthorized();

			// Route'dan gelen id'yi ve userId'yi kullanarak veri alıyoruz
			var measurementWithUser = await _bodyMeasurementService.GetOneBodyMeasurementByUserIdAsync(id, johnDoeId, false);

			if (measurementWithUser == null)
				return NotFound();

			return Ok(measurementWithUser);
		}

		[HttpPost]
		public async Task<IActionResult> AddBodyMeasurementAsync([FromBody] BodyMeasurementDtoForInsertion bodyMeasurementDto)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//if (userId == null)
			//	return Unauthorized();

			await _bodyMeasurementService.AddOneBodyMeasurementAsync(johnDoeId, bodyMeasurementDto);
			return Ok(bodyMeasurementDto);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBodyMeasurementAsync([FromBody] BodyMeasurementDtoForUpdate bodyMeasurementDto)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//if (userId == null)
			//	return Unauthorized();

			//bodyMeasurementDto.Id = id;
			await _bodyMeasurementService.UpdateOneBodyMeasurementAsync(johnDoeId, bodyMeasurementDto, true);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBodyMeasurementAsync([FromRoute] int id)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//if (userId == null)
			//	return Unauthorized();

			await _bodyMeasurementService.DeleteOneBodyMeasurementAsync(id, johnDoeId, false);
			return NoContent();
		}
	}
}
