using Entities.BaseEntities;
using Entities.Enums;
using System.Text.Json.Serialization;

namespace Entities.Models
{
	public class Exercise : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public DifficultyLevel Difficulty { get; set; } // Enum türü
		public int CategoryId { get; set; }
		public ExerciseCategory? Category { get; set; }
		public ICollection<WorkoutExercise>? WorkoutExercises { get; set; }
	}
}
