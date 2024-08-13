using Entities.BaseEntities;

namespace Entities.Models
{
	public class Workout : BaseEntity
	{
		//public int UserId { get; set; }
		//public User User { get; set; }
		public DateTime Date { get; set; }
		public int Duration { get; set; }
		public float TotalCaloriesBurned { get; set; }
		public string? Notes { get; set; }
		public ICollection<WorkoutExercise>? WorkoutExercises { get; set; }
	}
}
