using Entities.BaseEntities;

namespace Entities.Models
{
	public class BodyMeasurement : BaseEntity
	{
		public float Weight { get; set; }
		public float BodyFatPercentage { get; set; }
		public float MuscleMass { get; set; }
		public float WaistCircumference { get; set; }
		public string? UserId { get; set; }
		public AppUser? User { get; set; }
	}
}
