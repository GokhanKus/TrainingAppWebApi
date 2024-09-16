using Entities.Enums;
using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.Extensions
{
	public static class ExerciseRepositoryExtension
	{
		public static IQueryable<Exercise> Search(this IQueryable<Exercise> exercises, string searchingTerm)
		{
			if (string.IsNullOrEmpty(searchingTerm))
				return exercises;

			searchingTerm = searchingTerm.ToLower();
			var filteredExercises = exercises.Where(e => e.Name!.ToLower().Contains(searchingTerm) || e.Description.ToLower().Contains(searchingTerm));
			return filteredExercises;
		}
		public static IQueryable<Exercise> FilterExerciseByDifficulty(this IQueryable<Exercise> exercises, DifficultyLevel? difficultyLevel)
		{
			if (difficultyLevel == null)
				return exercises; 

			var filteredExercises = exercises.Where(e => e.Difficulty == difficultyLevel);
			return filteredExercises;
		}
		public static IQueryable<Exercise> Sort(this IQueryable<Exercise> exercises, string? orderByQueryString)
		{
			if (string.IsNullOrEmpty(orderByQueryString))
				return exercises.OrderBy(b => b.Id);

			var orderQuery = OrderQueryBuilder.CreateOrderQuery<Exercise>(orderByQueryString);

			if (string.IsNullOrEmpty(orderQuery))
				return exercises.OrderBy(b => b.Id);

			return exercises.OrderBy(orderQuery);
		}
	}
}
