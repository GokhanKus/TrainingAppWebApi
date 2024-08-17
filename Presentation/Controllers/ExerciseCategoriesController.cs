using Entities.DTOs.Exercise;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.RepoConcretes;

namespace Presentation.Controllers
{
	[Route("api/exercise-categories")]
	[ApiController]
	public class ExerciseCategoriesController : ControllerBase
	{
		private readonly IExerciseCategoryService _exerciseCategoryService;
		public ExerciseCategoriesController(IExerciseCategoryService exerciseCategoryService)
		{
			_exerciseCategoryService = exerciseCategoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllExerciseCategoriesAsync()
		{
			var exercises = await _exerciseCategoryService.GetAllExercisesCategoriesAsync(false);
			return Ok(exercises);
		}

		[HttpGet("{id:int}/basic")]
		public async Task<IActionResult> GetOneExerciseCategoryAsync([FromRoute] int id)
		{
			var exercise = await _exerciseCategoryService.GetOneExerciseCategoryByIdAsync(id, false);
			return Ok(exercise);
		}

		[HttpGet("{id:int}/with-exercises")]
		public async Task<IActionResult> GetOneExerciseCategoryWithExercisesAsync([FromRoute] int id)
		{
			var exercise = await _exerciseCategoryService.GetOneExerciseCategoryWithExercisesAsync(id);
			return Ok(exercise);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOneExerciseCategoryAsync([FromBody] ExerciseCategoryDtoForUpdate exerciseCategoryDto)
		{
			await _exerciseCategoryService.UpdateExerciseCategoryAsync(exerciseCategoryDto, true);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneExerciseCategoryAsync(int id)
		{
			await _exerciseCategoryService.DeleteExerciseCategoryAsync(id, false);
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateOneExerciseCategoryAsync([FromBody] ExerciseCategoryDtoForInsertion exerciseCategoryDto)
		{
			var newExercise = await _exerciseCategoryService.AddExerciseCategoryAsync(exerciseCategoryDto);
			return StatusCode(201, newExercise);
		}
	}
}
