using AutoMapper;
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
			CreateMap<ExerciseCategoryDtoForUpdate, ExerciseCategory>();
		}
	}
}
