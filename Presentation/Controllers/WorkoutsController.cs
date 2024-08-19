using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.RepoConcretes;

namespace Presentation.Controllers
{
	[Route("api/workouts")]
	[ApiController]
	public class WorkoutsController : ControllerBase
	{
		static string johnDoeId = "a3058765-ecf0-403e-9d48-08b38d4888ab";
		static string janeDoeId = "8cee140a-65fd-495d-970b-5315a6f3e7b2";
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
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı Id alınıyor
			var measurementWithUser = await _workoutService.GetAllWorkoutByUserIdAsync(johnDoeId, false);
			return Ok(measurementWithUser);
		}

		[HttpGet("{id:int}/basic")]
		public async Task<IActionResult> GetOneWorkoutAsync([FromRoute] int id)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı Id alınıyor
			//if (userId == null)
			//	return Unauthorized();

			var workout = await _workoutService.GetOneWorkoutByUserIdAsync(id, johnDoeId, false);

			if (workout == null)
				return NotFound();

			return Ok(workout);
		}
		[HttpGet("{id:int}/with-exercise")]
		public async Task<IActionResult> GetOneWorkoutWithExerciseAsync([FromRoute] int id)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Kullanıcı Id alınıyor
			//if (userId == null)
			//	return Unauthorized();

			var workoutWithExercise = await _workoutService.GetOneWorkoutWithExercises(id, johnDoeId);

			if (workoutWithExercise == null)
				return NotFound();

			return Ok(workoutWithExercise);
		}

		[HttpPost]
		public async Task<IActionResult> AddWorkoutAsync([FromBody] WorkoutDtoForInsertion workoutDto)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//if (userId == null)
			//	return Unauthorized();

			await _workoutService.AddOneWorkoutAsync(johnDoeId, workoutDto);
			return Ok(workoutDto);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWorkoutAsync([FromRoute] int id)
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//if (userId == null)
			//	return Unauthorized();

			await _workoutService.DeleteOneWorkoutAsync(id, johnDoeId, false);
			return NoContent();
		}
	}
}
