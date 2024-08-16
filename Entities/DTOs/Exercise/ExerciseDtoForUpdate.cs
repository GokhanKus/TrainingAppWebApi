using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Exercise
{
	public record ExerciseDtoForUpdate : ExerciseDto
	{
        public int Id { get; set; }
    }
}
