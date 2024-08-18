﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ExerciseCategory
{
	public sealed record ExerciseCategoryDtoForUpdate : ExerciseCategoryDto
	{
		public int Id { get; init; }
	}
}
