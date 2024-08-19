namespace Entities.DTOs.WorkoutExercise
{
	//ilgili user workout'unu eklerken, o workout'un hangi egzersize ait oldugunu ve sets, reps, weight ya da distance parametrelerini de girsin
	//many to many relation between workout and exercise 
	public class WorkoutExerciseDtoForInsertion
	{
		public int ExerciseId { get; set; }
		public int Sets { get; set; }
		public int Reps { get; set; }
		public float? Weight { get; set; }
		public float? Distance { get; set; }
	}
}
