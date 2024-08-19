
using AutoMapper;
using Entities.DTOs.Exercise;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Repositories.UnitOfWork;

namespace Repositories.RepoConcretes
{
	//workout eklerken ait oldugu exerciseyi de ekleyelim (ara tablo)
	//TODO: user eklendiginde ekleyecegiz
	public sealed class WorkoutService : IWorkoutService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public WorkoutService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task AddOneWorkoutAsync(string userId, WorkoutDtoForInsertion workoutDto)
		{
			var workout = _mapper.Map<Workout>(workoutDto);
			await _unitOfWork.WorkoutRepository.AddWorkoutAsync(userId, workout);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteOneWorkoutAsync(int id, string userId, bool trackChanges)
		{
			var existingWorkout = await GetOneWorkoutAndCheckExist(id, userId, trackChanges);
			_unitOfWork.WorkoutRepository.DeleteWorkout(userId, existingWorkout);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<IEnumerable<Workout>> GetAllWorkoutByUserIdAsync(string userId, bool trackChanges)
		{
			if (userId is null)
				throw new ArgumentNullException($"any workout could not found which is belong to the user with {userId}");

			var allWorkoutsOfUser = await _unitOfWork.WorkoutRepository.GetAllWorkoutsByUserIdAsync(userId, trackChanges);
			return allWorkoutsOfUser;
		}
		public async Task<Workout?> GetOneWorkoutByUserIdAsync(int id, string userId, bool trackChanges)
		{
			//id ve userId null kontrolu de yapilabilir
			var workout = await GetOneWorkoutAndCheckExist(id, userId, trackChanges);
			return workout;
		}
		public async Task<Workout?> GetOneWorkoutWithExercises(int id, string userId)
		{
			//id ve userId null kontrolu de yapilabilir
			var workoutWithExercise = await _unitOfWork.WorkoutRepository.GetOneWorkoutWithExercises(id, userId);

			if (workoutWithExercise == null)
				throw new ArgumentNullException("workoutWithExercise not found");

			return workoutWithExercise;
		}
		public async Task UpdateOneWorkoutAsync(string userId, WorkoutDtoForUpdate workoutDto, bool trackChanges)
		{
			var existingWorkout = await GetOneWorkoutAndCheckExist(workoutDto.Id, userId, trackChanges);
			_mapper.Map(workoutDto, existingWorkout);
			await _unitOfWork.SaveChangesAsync();
		}
		private async Task<Workout?> GetOneWorkoutAndCheckExist(int id, string userId, bool trackChanges)
		{
			var workout = await _unitOfWork.WorkoutRepository.GetOneWorkoutByUserIdAsync(id, userId, trackChanges);
			if (workout == null)
				throw new ArgumentNullException("workout not found");
			return workout;
		}
	}
}
