using Entities.DTOs.Exercise;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.ServiceConcretes;

namespace Presentation.Controllers
{
	[ServiceFilter(typeof(LogFilterAttribute))]
	[Route("api/exercises")]
	[ApiController]
	public class ExercisesController : ControllerBase
	{
		private readonly IExerciseService _exerciseService;

		public ExercisesController(IExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}

		[HttpHead]
		[HttpGet(Name = "GetAllExercisesAsync")]
		public async Task<IActionResult> GetAllExercisesAsync([FromQuery] ExerciseParameters exerciseParameters)
		{
			var pagedResult = await _exerciseService.GetAllExercisesAsync(exerciseParameters, false);
			//Response.Headers["X-Pagination"] = JsonConvert.SerializeObject(pagedResult.metaData);
			return Ok(pagedResult);
			//var exercises = await _exerciseService.GetAllExercisesAsync(false);
			//return Ok(exercises);
		}

		[HttpGet("{id:int}/basic")]
		public async Task<IActionResult> GetOneExerciseAsync([FromRoute] int id)
		{
			var exercise = await _exerciseService.GetOneExerciseByIdAsync(id, false);
			return Ok(exercise);
		}

		[HttpGet("{id:int}/with-category")]
		public async Task<IActionResult> GetOneExerciseWithCategoryAsync([FromRoute] int id)
		{
			var exercise = await _exerciseService.GetOneExerciseWithCategoryAsync(id);
			return Ok(exercise);
		}

		[Authorize(Roles = "Admin")]
		[ValidationFilter]
		[HttpPut]
		public async Task<IActionResult> UpdateOneExerciseAsync([FromBody] ExerciseDtoForUpdate exerciseDto)
		{
			//redis cache'te problem yasadik trackChanges false olsun update metoduna gitsin
			await _exerciseService.UpdateExerciseAsync(exerciseDto, false);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneExerciseAsync(int id)
		{
			await _exerciseService.DeleteExerciseAsync(id, false);
			return NoContent();
		}

		[Authorize(Roles = "Admin")]
		[ValidationFilter]
		[HttpPost(Name = "CreateOneExerciseAsync")]
		public async Task<IActionResult> CreateOneExerciseAsync([FromBody] ExerciseDtoForInsertion exerciseDto)
		{
			var newExercise = await _exerciseService.AddExerciseAsync(exerciseDto);
			return StatusCode(201, newExercise);
		}

		[HttpOptions]
		public IActionResult GetExerciseOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, HEAD, OPTIONS");
			return Ok();
		}
	}
}
