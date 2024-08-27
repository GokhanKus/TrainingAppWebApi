using AutoMapper;
using Entities.DTOs.BodyMeasurement;
using Entities.DTOs.Exercise;
using Entities.DTOs.ExerciseCategory;
using Entities.DTOs.User;
using Entities.DTOs.WorkoutExercise;
using Entities.Models;

namespace Services.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ExerciseDtoForUpdate, Exercise>().ReverseMap();
			CreateMap<ExerciseDtoForInsertion, Exercise>();

			CreateMap<ExerciseCategoryDtoForUpdate, ExerciseCategory>().ReverseMap();
			CreateMap<ExerciseCategoryDtoForInsertion, ExerciseCategory>();

			CreateMap<WorkoutDtoForUpdate, ExerciseCategory>();
			CreateMap<WorkoutDtoForInsertion, Workout>();

			CreateMap<BodyMeasurementDtoForUpdate, BodyMeasurement>().ReverseMap();
			CreateMap<BodyMeasurementDtoForInsertion, BodyMeasurement>();

			//CreateMap<WorkoutDtoForUpdate, Workout>().ReverseMap();

			//CreateMap<WorkoutDtoForInsertion, Workout>()
			//	.ForMember(dest => dest.WorkoutExercises, opt => opt.MapFrom(src => src.WorkoutExercises));

			// WorkoutExerciseDtoForInsertion -> WorkoutExercise
			CreateMap<WorkoutExerciseDtoForInsertion, WorkoutExercise>();

			CreateMap<UserDtoForRegistration, AppUser>();
		}
	}
}
