using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;

namespace Repositories.Context
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//config.cs'leri calistiralim migration alabilmek icin gerekli
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
			
		}
		public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
		public DbSet<Workout> Workouts { get; set; }
		public DbSet<WorkoutExercise> WorkoutExercises { get; set; }	
	}
}
