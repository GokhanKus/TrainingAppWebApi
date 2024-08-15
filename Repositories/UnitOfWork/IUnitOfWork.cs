using Repositories.RepoConcretes;

namespace Repositories.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IBodyMeasurementRepository BodyMeasurementRepository { get; }
		IExerciseCategoryRepository ExerciseCategoryRepository { get; }
		IExerciseRepository ExerciseRepository { get; }
		IWorkoutRepository WorkoutRepository { get; }
		Task SaveChangesAsync();
	}
}
