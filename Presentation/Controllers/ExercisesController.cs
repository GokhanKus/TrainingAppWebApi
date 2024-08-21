using Entities.DTOs.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceConcretes;

namespace Presentation.Controllers
{
	[Route("api/exercises")]
	[ApiController]
	public class ExercisesController : ControllerBase
	{
		private readonly IExerciseService _exerciseService;

		public ExercisesController(IExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllExercisesAsync()
		{
			var exercises = await _exerciseService.GetAllExercisesAsync(false);
			return Ok(exercises);
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
		[HttpPut]
		public async Task<IActionResult> UpdateOneExerciseAsync([FromBody] ExerciseDtoForUpdate exerciseDto)
		{
			await _exerciseService.UpdateExerciseAsync(exerciseDto, true);
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
		[HttpPost]
		public async Task<IActionResult> CreateOneExerciseAsync([FromBody] ExerciseDtoForInsertion exerciseDto)
		{
			var newExercise = await _exerciseService.AddExerciseAsync(exerciseDto);
			return StatusCode(201, newExercise);
		}
	}
}
