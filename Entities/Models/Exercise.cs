using Entities.BaseEntities;

namespace Entities.Models
{
	public class Exercise : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int CategoryId { get; set; }
		public ExerciseCategory? Category { get; set; }
		public ICollection<WorkoutExercise>? WorkoutExercises { get; set; }
	}
}
