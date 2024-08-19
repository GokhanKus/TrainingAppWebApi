using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ExerciseCategory
{
	public abstract record WorkoutDto
	{
		public int Duration { get; set; }
		public float TotalCaloriesBurned { get; set; }
		public string? Notes { get; set; }
	}
}
