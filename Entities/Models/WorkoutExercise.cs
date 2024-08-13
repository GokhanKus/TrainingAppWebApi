using Entities.BaseEntities;

namespace Entities.Models
{
	public class WorkoutExercise
	{
		//public int Id { get; set; }
		//workout ve exercise arasindaki link table (baglanti tablosu) ara tablo 
		public int WorkoutId { get; set; }
		public Workout? Workout { get; set; }
		public int ExerciseId { get; set; }
		public Exercise? Exercise { get; set; }

		public int? Sets { get; set; }
		public int? Reps { get; set; }
		public float? Weight { get; set; }
		public float? Distance { get; set; }
	}
}
