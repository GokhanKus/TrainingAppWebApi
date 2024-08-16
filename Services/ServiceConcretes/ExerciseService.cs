
using Entities.DTOs.Exercise;
using Entities.Models;
using Repositories.UnitOfWork;

namespace Repositories.RepoConcretes
{
	public class ExerciseService : IExerciseService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ExerciseService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Exercise> AddExerciseAsync(ExerciseDtoForInsertion exerciseDto)
		{
			//TODO: Auto mapper eklenecek
			var exercise = new Exercise
			{
				CategoryId = exerciseDto.CategoryId,
				Name = exerciseDto.Name,
				Description = exerciseDto.Description,
				Difficulty = exerciseDto.Difficulty
			};
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
		public async Task<IEnumerable<Exercise>> GetAllExercisesAsync(bool trackChanges)
		{
			var exercises = await _unitOfWork.ExerciseRepository.GetAllExercisesAsync(trackChanges);
			return exercises;
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
			throw new ArgumentNullException("exercise you looked for couldn't found.");
		}
		public async Task UpdateExerciseAsync(ExerciseDtoForUpdate exercise, bool trackChanges)
		{
			//TODO: Auto mapper eklenecek
			var entity = await GetOneExerciseByIdAndCheckExist(exercise.Id, trackChanges);
			entity.Name = exercise.Name;
			entity.Description = exercise.Description;
			entity.Difficulty = exercise.Difficulty;
			entity.CategoryId = exercise.CategoryId;

			//izlenen nesne degisiklerden sonra Update() olmadan da dogrudan save edilebilir
			//_unitOfWork.ExerciseRepository.UpdateOneExercise(entity);
			await _unitOfWork.SaveChangesAsync();
		}
		private async Task<Exercise> GetOneExerciseByIdAndCheckExist(int id, bool trackChanges)
		{
			var exerciseToDelete = await _unitOfWork.ExerciseRepository.GetOneExerciseByIdAsync(id, trackChanges);
			if (exerciseToDelete is null)
				throw new ArgumentNullException("exercise you looked for couldn't found.");
			return exerciseToDelete;
		}
	}
}
