using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class BodyMeasurementConfig : IEntityTypeConfiguration<BodyMeasurement>
	{
		public void Configure(EntityTypeBuilder<BodyMeasurement> builder)
		{
			// Date kolonu üzerinde bir indeks..
			// Bu kod, veritabanında BodyMeasurement tablosundaki Date ve weight kolonuna bir indeks ekler. Böylece, tarihe, agirliga göre yapılan sorgular çok daha hızlı çalışır.
			builder.HasIndex(bm => new { bm.Date, bm.Weight });

			builder.HasData(
		    new BodyMeasurement
		    {
			   Id = 1,
			   Date = DateTime.Now.AddMonths(-1),
			   Weight = 70,
			   BodyFatPercentage = 15,
			   MuscleMass = 35,
			   WaistCircumference = 85
		    },
		    new BodyMeasurement
		    {
			   Id = 2,
			   Date = DateTime.Now.AddMonths(-2),
			   Weight = 68,
			   BodyFatPercentage = 16,
			   MuscleMass = 34,
			   WaistCircumference = 87
		    },
			new BodyMeasurement
			{
				Id = 3,
				Date = DateTime.Now.AddDays(-3),
				Weight = 72,
				BodyFatPercentage = 14,
				MuscleMass = 36,
				WaistCircumference = 84
			},
			new BodyMeasurement
			{
				Id = 4,
				Date = DateTime.Now.AddDays(-10),
				Weight = 71,
				BodyFatPercentage = 13.5f,
				MuscleMass = 35.5f,
				WaistCircumference = 83
			});
		}
	}
}
