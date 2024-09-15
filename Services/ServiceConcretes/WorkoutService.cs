using AutoMapper;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.UnitOfWork;
using Services.Exceptions;
using Services.ServiceContracts;
using System.Dynamic;

namespace Services.ServiceConcretes
{
	public sealed class WorkoutService : IWorkoutService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IDataShaper<Workout> _shaper;
		public WorkoutService(IUnitOfWork unitOfWork, IMapper mapper, IDataShaper<Workout> shaper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_shaper = shaper;
		}
		public async Task AddOneWorkoutAsync(string userId, WorkoutDtoForInsertion workoutDto)
		{
			var workout = _mapper.Map<Workout>(workoutDto);
			workout.UserId = userId;

			// WorkoutExercise entity'lerini mapleyip workout.WorkoutExercises listesine ekle
			var workoutExercises = _mapper.Map<List<WorkoutExercise>>(workoutDto.WorkoutExercises);

			// Bu entity'leri workout ile ilişkilendir
			foreach (var workoutExercise in workoutExercises)
			{
				workoutExercise.Workout = workout;  // Workout ile ilişkilendir
			}

			workout.WorkoutExercises = workoutExercises;

			// Workout'u repository'e ekle
			await _unitOfWork.WorkoutRepository.AddWorkoutAsync(userId, workout);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteOneWorkoutAsync(int id, string userId, bool trackChanges)
		{
			var existingWorkout = await GetOneWorkoutAndCheckExist(id, userId, trackChanges);
			_unitOfWork.WorkoutRepository.DeleteWorkout(userId, existingWorkout);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<IEnumerable<ExpandoObject>?> GetAllWorkoutByUserIdAsync(WorkoutParameters workoutParameters, string userId, bool trackChanges)
		{
			if (!workoutParameters.IsValid)
				throw new DurationOrCaloriesBurnedOutOfRangeBadRequestException();

			if (userId is null)
				throw new ArgumentNullException($"any workout could not found which is belong to the user with {userId}");

			var allWorkoutsOfUser = await _unitOfWork.WorkoutRepository.GetAllWorkoutsByUserIdAsync(workoutParameters, userId, trackChanges);
			var workoutDto = _mapper.Map<IEnumerable<Workout>>(allWorkoutsOfUser);
			var shapedData = _shaper.ShapeData(workoutDto, workoutParameters.Fields);
			return shapedData;
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
				throw new WorkoutNotFoundException("workoutWithExercise not found");

			return workoutWithExercise;
		}
		private async Task<Workout?> GetOneWorkoutAndCheckExist(int id, string userId, bool trackChanges)
		{
			var workout = await _unitOfWork.WorkoutRepository.GetOneWorkoutByUserIdAsync(id, userId, trackChanges);
			if (workout == null)
				throw new WorkoutNotFoundException("workout not found");
			return workout;
		}
	}
}
