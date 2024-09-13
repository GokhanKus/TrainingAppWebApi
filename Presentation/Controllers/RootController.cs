using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api")]
	public class RootController : ControllerBase
	{
		private readonly LinkGenerator _linkGenerator;
		public RootController(LinkGenerator linkGenerator)
		{
			_linkGenerator = linkGenerator;
		}

		[HttpGet(Name = "GetRoot")]
		public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
		{
			if (mediaType.Contains("application/vnd.storeapp.apiroot"))
			{
				var list = new List<Link>
				{
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(GetRoot),new{}),
						Rel = "_self",
						Method = "GET"
					},

					//ExerciseCategoriesController
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(ExerciseCategoriesController.GetAllExerciseCategoriesAsync),new{}),
						Rel = "exercise-categories",
						Method = "GET"
					},
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(ExerciseCategoriesController.CreateOneExerciseCategoryAsync),new{}),
						Rel = "exercise-categories",
						Method = "POST"
					},

					//BodyMeasurementsController
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(BodyMeasurementsController.GetAllBodyMeasurementsAsync),new{}),
						Rel = "body-measurements",
						Method = "GET"
					},
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(BodyMeasurementsController.AddBodyMeasurementAsync),new{}),
						Rel = "body-measurements",
						Method = "POST"
					},

					//ExercisesController
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(ExercisesController.GetAllExercisesAsync),new{}),
						Rel = "exercises",
						Method = "GET"
					},
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(ExercisesController.CreateOneExerciseAsync),new{}),
						Rel = "exercises",
						Method = "POST"
					},

					//WorkoutsController
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(WorkoutsController.GetAllWorkoutsAsync),new{}),
						Rel = "workouts",
						Method = "GET"
					},
					new Link
					{
						Href = _linkGenerator.GetUriByName(HttpContext,nameof(WorkoutsController.AddWorkoutAsync),new{}),
						Rel = "workouts",
						Method = "POST"
					}
				};
				return Ok(list);
			}
			return NoContent();
		}
	}
}

/*
Bu dökümantasyon, API'nin genel kullanımını, API'ye erişim yöntemlerini, belirli isteklerin ve yanıtların nasıl yapılandırılacağını ve 
genel olarak API'nin nasıl çalıştığını açıklar.
*/