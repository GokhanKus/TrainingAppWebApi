using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.ServiceConcretes;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[Authorize]
	[ServiceFilter(typeof(LogFilterAttribute))]
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
		public async Task<IActionResult> GetAllBodyMeasurementsAsync([FromQuery] BodyMeasurementParameters bodyMeasurementParameters)//body-measurement?pageNumber=2&pageSize=10
		{
			var userId = GetUserId();
			var pagedResult = await _bodyMeasurementService.GetAllBodyMeasurementsByUserIdAsync(bodyMeasurementParameters, userId, false);
			//Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(pagedResult.metaData);
			return Ok(pagedResult);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneBodyMeasurementAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var measurementWithUser = await _bodyMeasurementService.GetOneBodyMeasurementByUserIdAsync(id, userId, false);
			return Ok(measurementWithUser);
		}

		[HttpPost]
		[ValidationFilter]
		public async Task<IActionResult> AddBodyMeasurementAsync([FromBody] BodyMeasurementDtoForInsertion bodyMeasurementDto)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _bodyMeasurementService.AddOneBodyMeasurementAsync(userId, bodyMeasurementDto);
			return Ok(bodyMeasurementDto);
		}

		[HttpPut]
		[ValidationFilter]
		public async Task<IActionResult> UpdateBodyMeasurementAsync([FromBody] BodyMeasurementDtoForUpdate bodyMeasurementDto)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			//trackChanges false yapip update metodunu calistirmaya karar verdim aksi taktirde rediscache duzgun calismiyordu
			await _bodyMeasurementService.UpdateOneBodyMeasurementAsync(userId, bodyMeasurementDto, false);
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
		private string GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
		}
	}
}
