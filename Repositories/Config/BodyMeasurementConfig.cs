using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
	public class BodyMeasurementConfig : IEntityTypeConfiguration<BodyMeasurement>
	{
		public void Configure(EntityTypeBuilder<BodyMeasurement> builder)
		{
			builder.HasOne(bm => bm.User)
			.WithMany(u => u.BodyMeasurements)
			.HasForeignKey(bm => bm.UserId)
			.OnDelete(DeleteBehavior.Cascade); //user silinirse user'a ait olan beden ölçüm bilgileri de silinsin

			// Date kolonu üzerinde bir indeks..
			// Bu kod, veritabanında BodyMeasurement tablosundaki weight kolonuna bir indeks ekler. Böylece, agirliga göre yapılan sorgular çok daha hızlı çalışır.
			builder.HasIndex(bm => bm.Weight);

			builder.HasData(
			new BodyMeasurement
			{
				Id = 1,
				Weight = 70,
				BodyFatPercentage = 15,
				MuscleMass = 35,
				WaistCircumference = 85,
				UserId = "a3058765-ecf0-403e-9d48-08b38d4888ab" //John Doe(admin)'nun workout'u 
			},
			new BodyMeasurement
			{
				Id = 2,
				Weight = 68,
				BodyFatPercentage = 16,
				MuscleMass = 34,
				WaistCircumference = 87,
				UserId = "a3058765-ecf0-403e-9d48-08b38d4888ab" //John Doe(admin)'nun workout'u 
			},
			new BodyMeasurement
			{
				Id = 3,
				Weight = 72,
				BodyFatPercentage = 14,
				MuscleMass = 36,
				WaistCircumference = 84,
				UserId = "8cee140a-65fd-495d-970b-5315a6f3e7b2" //Jane Doe(user)'nun workout'u
			},
			new BodyMeasurement
			{
				Id = 4,
				Weight = 71,
				BodyFatPercentage = 13.5f,
				MuscleMass = 35.5f,
				WaistCircumference = 83,
				UserId = "8cee140a-65fd-495d-970b-5315a6f3e7b2" //Jane Doe(user)'nun workout'u
			});
		}
	}
}
