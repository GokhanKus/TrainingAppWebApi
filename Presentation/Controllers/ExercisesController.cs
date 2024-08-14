using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;

namespace Presentation.Controllers
{
	[Route("api/exercises")]
	[ApiController]
	public class ExercisesController : ControllerBase
	{
		private readonly RepositoryContext _context;
		public ExercisesController(RepositoryContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllExercises()
		{
			var exercises = _context.Exercises.ToList();
			return Ok(exercises);
		}
	}
}
