using Entities.Enums;

namespace Entities.RequestFeatures
{
	public class ExerciseParameters : RequestParameters
	{
        public string? SearchingTerm { get; set; }
        public DifficultyLevel? DifficultyLevel{ get; set; }
    }
}
