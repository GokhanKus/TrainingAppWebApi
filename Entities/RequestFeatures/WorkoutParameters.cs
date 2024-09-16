namespace Entities.RequestFeatures
{
	public class WorkoutParameters : RequestParameters
	{
		public uint MinDuration { get; set; }
		public uint MaxDuration { get; set; }
		public uint MinCaloriesBurned { get; set; }
		public uint MaxCaloriesBurned { get; set; }
		public bool IsValid => (MaxDuration >= MinDuration ) && (MaxCaloriesBurned >= MinCaloriesBurned );
        public WorkoutParameters()
        {
			OrderBy = "id";
        }
    }
}
