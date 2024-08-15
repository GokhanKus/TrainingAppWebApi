using Repositories.Context;
using Repositories.RepoConcretes;

namespace Repositories.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly RepositoryContext _context;
		private readonly IBodyMeasurementRepository _bodyMeasurementRepository;
		private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
		private readonly IExerciseRepository _exerciseRepository;
		private readonly IWorkoutRepository _workoutRepository;

		//ctor injection ile repolari enjekte ediyoruz
		public UnitOfWork(
			RepositoryContext context,
			IBodyMeasurementRepository bodyMeasurementRepository,
			IExerciseCategoryRepository exerciseCategoryRepository,
			IExerciseRepository exerciseRepository,
			IWorkoutRepository workoutRepository)
		{
			_context = context;
			_bodyMeasurementRepository = bodyMeasurementRepository;
			_exerciseCategoryRepository = exerciseCategoryRepository;
			_exerciseRepository = exerciseRepository;
			_workoutRepository = workoutRepository;
		}

		public IBodyMeasurementRepository BodyMeasurementRepository => _bodyMeasurementRepository;
		public IExerciseCategoryRepository ExerciseCategoryRepository => _exerciseCategoryRepository;
		public IExerciseRepository ExerciseRepository => _exerciseRepository;
		public IWorkoutRepository WorkoutRepository => _workoutRepository;
		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

		//bellek sizintilarini onlemek icin kullanilan kaynak temizleme mekanizmasi..
		public void Dispose() => _context.Dispose(); //bellek temizligi yapar ve aciksa db baglantisini kapatir
	}
}
