using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceConcretes;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[Authorize]
	[Route("api/workouts")]
	[ApiController]
	public class WorkoutsController : ControllerBase
	{
		private readonly IWorkoutService _workoutService;
		private readonly UserManager<AppUser> _userManager;
		public WorkoutsController(IWorkoutService workoutService, UserManager<AppUser> userManager)
		{
			_workoutService = workoutService;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllWorkoutsAsync()
		{
			var userId = GetUserId();
			var measurementWithUser = await _workoutService.GetAllWorkoutByUserIdAsync(userId, false);
			return Ok(measurementWithUser);
		}

		[HttpGet("{id:int}/basic")]
		public async Task<IActionResult> GetOneWorkoutAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var workout = await _workoutService.GetOneWorkoutByUserIdAsync(id, userId, false);

			if (workout == null)
				return NotFound();

			return Ok(workout);
		}

		[HttpGet("{id:int}/with-exercise")]
		public async Task<IActionResult> GetOneWorkoutWithExerciseAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var workoutWithExercise = await _workoutService.GetOneWorkoutWithExercises(id, userId);

			if (workoutWithExercise == null)
				return NotFound();

			return Ok(workoutWithExercise);
		}

		[HttpPost]
		public async Task<IActionResult> AddWorkoutAsync([FromBody] WorkoutDtoForInsertion workoutDto)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _workoutService.AddOneWorkoutAsync(userId, workoutDto);
			return Ok(workoutDto);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWorkoutAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			await _workoutService.DeleteOneWorkoutAsync(id, userId, false);
			return NoContent();
		}
		private string? GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
