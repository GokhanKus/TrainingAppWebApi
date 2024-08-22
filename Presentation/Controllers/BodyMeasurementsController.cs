using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceConcretes;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[Authorize]
	[Route("api/body-measurement")]
	[ApiController]
	public class BodyMeasurementsController : ControllerBase
	{
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
			var userId = GetUserId();
			var measurementWithUser = await _bodyMeasurementService.GetAllBodyMeasurementsByUserIdAsync(userId, false);
			return Ok(measurementWithUser);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneBodyMeasurementAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var measurementWithUser = await _bodyMeasurementService.GetOneBodyMeasurementByUserIdAsync(id, userId, false);
			if (measurementWithUser == null)
				return NotFound();

			return Ok(measurementWithUser);
		}

		[HttpPost]
		public async Task<IActionResult> AddBodyMeasurementAsync([FromBody] BodyMeasurementDtoForInsertion bodyMeasurementDto)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _bodyMeasurementService.AddOneBodyMeasurementAsync(userId, bodyMeasurementDto);
			return Ok(bodyMeasurementDto);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBodyMeasurementAsync([FromBody] BodyMeasurementDtoForUpdate bodyMeasurementDto)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _bodyMeasurementService.UpdateOneBodyMeasurementAsync(userId, bodyMeasurementDto, true);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBodyMeasurementAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _bodyMeasurementService.DeleteOneBodyMeasurementAsync(id, userId, false);
			return NoContent();
		}
		private string? GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
