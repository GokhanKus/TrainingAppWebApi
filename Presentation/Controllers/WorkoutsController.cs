﻿using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.ServiceConcretes;
using System.Security.Claims;

namespace Presentation.Controllers
{
	[Authorize]
	[ServiceFilter(typeof(LogFilterAttribute))]
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

		[HttpHead]
		[HttpGet(Name = "GetAllWorkoutsAsync")]
		public async Task<IActionResult> GetAllWorkoutsAsync([FromQuery] WorkoutParameters workoutParameters)
		{
			var userId = GetUserId();
			if (userId is null)
				return Unauthorized();

			var measurementWithUser = await _workoutService.GetAllWorkoutByUserIdAsync(workoutParameters, userId, false);
			return Ok(measurementWithUser);
		}

		[HttpGet("{id:int}/basic")]
		public async Task<IActionResult> GetOneWorkoutAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var workout = await _workoutService.GetOneWorkoutByUserIdAsync(id, userId, false);
			return Ok(workout);
		}

		[HttpGet("{id:int}/with-exercise")]
		public async Task<IActionResult> GetOneWorkoutWithExerciseAsync([FromRoute] int id)
		{
			var userId = GetUserId();
			if (userId == null)
				return Unauthorized();

			var workoutWithExercise = await _workoutService.GetOneWorkoutWithExercises(id, userId);
			return Ok(workoutWithExercise);
		}

		[ValidationFilter]
		[HttpPost(Name = "AddWorkoutAsync")]
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

		[HttpOptions]
		public IActionResult GetWorkoutOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, DELETE, HEAD, OPTIONS");
			return Ok();
		}
	}
}
