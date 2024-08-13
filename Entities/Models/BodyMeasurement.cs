using Entities.BaseEntities;

namespace Entities.Models
{
	public class BodyMeasurement : BaseEntity
	{
		public DateTime Date { get; set; }
		public float Weight { get; set; }
		public float BodyFatPercentage { get; set; }
		public float MuscleMass { get; set; }
		public float WaistCircumference { get; set; }

		//Mic Identityden sonra eklenecek
		//public int UserId { get; set; }
		//public User User { get; set; }
	}
}
