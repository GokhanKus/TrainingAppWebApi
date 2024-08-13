using Entities.BaseEntities;

namespace Entities.Models
{
	public class ExerciseCategory : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public ICollection<Exercise>? Exercises { get; set; }
	}
}
