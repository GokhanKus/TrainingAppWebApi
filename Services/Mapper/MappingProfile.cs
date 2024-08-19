using AutoMapper;
using Entities.DTOs.BodyMeasurement;
using Entities.DTOs.Exercise;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;

namespace Services.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ExerciseDtoForUpdate, Exercise>().ReverseMap();
			CreateMap<ExerciseDtoForInsertion, Exercise>();

			CreateMap<ExerciseCategoryDtoForInsertion, ExerciseCategory>().ReverseMap();
			CreateMap<WorkoutDtoForUpdate, ExerciseCategory>();

			CreateMap<BodyMeasurementDtoForUpdate, BodyMeasurement>().ReverseMap();
			CreateMap<BodyMeasurementDtoForInsertion, BodyMeasurement>();

			CreateMap<WorkoutDtoForUpdate, Workout>().ReverseMap();
			CreateMap<WorkoutDtoForInsertion, Workout>();
		}
	}
}
