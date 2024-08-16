using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Exercise
{
	public abstract record ExerciseDto
	{
		public string? Name { get; init; }
		public string? Description { get; init; }
		public DifficultyLevel Difficulty { get; init; } // Enum türü
		public int CategoryId { get; init; }
	}
}
