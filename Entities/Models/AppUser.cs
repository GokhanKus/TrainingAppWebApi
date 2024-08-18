using Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
	//Microsoft Identity islemlerinden sonra userlar kullanilacak
	public class AppUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		// İlişkiler
		public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
		public ICollection<Workout>? Workouts { get; set; }
	}
}
