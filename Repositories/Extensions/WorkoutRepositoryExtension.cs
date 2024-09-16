using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.Extensions
{
	public static class WorkoutRepositoryExtension
	{
		public static IQueryable<Workout> FilterWorkoutByDuration(this IQueryable<Workout> workouts, uint? minDuration, uint? maxDuration)
		{
			if ((minDuration == 0 || minDuration is null) && (maxDuration == 0 || maxDuration is null))
				return workouts;

			var filteredWorkouts = workouts.Where(w => w.Duration > minDuration && w.Duration <= maxDuration);
			return filteredWorkouts;
		}
		public static IQueryable<Workout> FilterWorkoutByCaloriesBurned(this IQueryable<Workout> workouts, uint? minCaloriesBurned, uint? maxCaloriesBurned)
		{
			if ((minCaloriesBurned == 0 || minCaloriesBurned is null) && (maxCaloriesBurned == 0 || maxCaloriesBurned is null))
				return workouts;

			var filteredWorkouts = workouts.Where(w => w.Duration > minCaloriesBurned && w.Duration <= maxCaloriesBurned);
			return filteredWorkouts;
		}
		public static IQueryable<Workout> Sort(this IQueryable<Workout> workouts, string? orderByQueryString)
		{
			if (string.IsNullOrEmpty(orderByQueryString))
				return workouts.OrderBy(b => b.Id);

			var orderQuery = OrderQueryBuilder.CreateOrderQuery<Workout>(orderByQueryString);

			if (string.IsNullOrEmpty(orderQuery))
				return workouts.OrderBy(b => b.Id);

			return workouts.OrderBy(orderQuery);
		}
	}
}
