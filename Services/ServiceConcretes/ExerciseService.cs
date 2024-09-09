using AutoMapper;
using Entities.DTOs.Exercise;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.UnitOfWork;
using Services.Exceptions;
using Services.ServiceContracts;
using System.Dynamic;

namespace Services.ServiceConcretes
{
	public sealed class ExerciseService : IExerciseService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IDataShaper<Exercise> _shaper;
		public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper, IDataShaper<Exercise> shaper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_shaper = shaper;
		}
		public async Task<Exercise> AddExerciseAsync(ExerciseDtoForInsertion exerciseDto)
		{
			var exercise = _mapper.Map<Exercise>(exerciseDto);
			await _unitOfWork.ExerciseRepository.AddOneExerciseAsync(exercise);
			await _unitOfWork.SaveChangesAsync();
			return exercise;
		}
		public async Task DeleteExerciseAsync(int id, bool trackChanges)
		{
			var exerciseToDelete = await GetOneExerciseByIdAndCheckExist(id, trackChanges);
			_unitOfWork.ExerciseRepository.DeleteOneExercise(exerciseToDelete);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<IEnumerable<ExpandoObject>?> GetAllExercisesAsync(ExerciseParameters exerciseParameters, bool trackChanges)
		{
			var exercises = await _unitOfWork.ExerciseRepository.GetAllExercisesAsync(exerciseParameters, trackChanges);
			var exercisesDto = _mapper.Map<IEnumerable<Exercise>>(exercises);
			var shapedData = _shaper.ShapeData(exercisesDto, exerciseParameters.Fields);
			return shapedData;
		}
		public async Task<Exercise> GetOneExerciseByIdAsync(int id, bool trackChanges)
		{
			var exercise = await GetOneExerciseByIdAndCheckExist(id, trackChanges);
			return exercise;
		}
		public async Task<Exercise> GetOneExerciseWithCategoryAsync(int id)
		{
			var exercise = await _unitOfWork.ExerciseRepository.GetOneExerciseWithCategoryAsync(id);
			if (exercise is not null)
				return exercise;
			throw new ExerciseNotFoundException(id);
		}
		public async Task UpdateExerciseAsync(ExerciseDtoForUpdate exerciseDto, bool trackChanges)
		{
			var entity = await GetOneExerciseByIdAndCheckExist(exerciseDto.Id, trackChanges);
			_mapper.Map(exerciseDto, entity);

			//izlenen nesne(trackChanges = true ise) degisiklerden sonra Update() olmadan da dogrudan save edilebilir
			//ama redis cache hata alıyorduk, o yuzden update metodu calissin
			_unitOfWork.ExerciseRepository.UpdateOneExercise(entity);
			await _unitOfWork.SaveChangesAsync();
		}
		private async Task<Exercise> GetOneExerciseByIdAndCheckExist(int id, bool trackChanges)
		{
			var exercise = await _unitOfWork.ExerciseRepository.GetOneExerciseByIdAsync(id, trackChanges);
			if (exercise is null)
				throw new ExerciseNotFoundException(id);
			return exercise;
		}
	}
}
