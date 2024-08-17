﻿using AutoMapper;
using Entities.DTOs.ExerciseCategory;
using Entities.Models;
using Repositories.UnitOfWork;
using System.Text;

namespace Repositories.RepoConcretes
{
	public class ExerciseCategoryService : IExerciseCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ExerciseCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<ExerciseCategory> AddExerciseCategoryAsync(ExerciseCategoryDtoForInsertion exerciseCategoryDto)
		{
			var exerciseCategory = _mapper.Map<ExerciseCategory>(exerciseCategoryDto);
			await _unitOfWork.ExerciseCategoryRepository.AddOneExerciseCategory(exerciseCategory);
			await _unitOfWork.SaveChangesAsync();
			return exerciseCategory;
		}
		public async Task DeleteExerciseCategoryAsync(int id, bool trackChanges)
		{
			var exerciseCategory = await GetOneExerciseCategoryByIdAndCheckExist(id, trackChanges);
			_unitOfWork.ExerciseCategoryRepository.DeleteOneExerciseCategory(exerciseCategory);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<ExerciseCategory>> GetAllExercisesCategoriesAsync(bool trackChanges)
		{
			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository.GetAllExerciseCategoriesAsync(trackChanges);
			return exerciseCategory;
		}
		public async Task<ExerciseCategory?> GetOneExerciseCategoryByIdAsync(int id, bool trackChanges)
		{
			var exercise = await GetOneExerciseCategoryByIdAndCheckExist(id, trackChanges);
			if (exercise is not null)
				return exercise;
			throw new ArgumentNullException("exercise category you looked for couldn't found.");
		}
		public async Task<ExerciseCategory?> GetOneExerciseCategoryWithExercisesAsync(int id)
		{
			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository.GetOneExerciseCategoryWithExercisesAsync(id);
			if (exerciseCategory is not null)
				return exerciseCategory;
			throw new ArgumentNullException("exercise category you looked for couldn't found.");
		}
		public async Task UpdateExerciseCategoryAsync(ExerciseCategoryDtoForUpdate exerciseCategoryDto, bool trackChanges)
		{
			var entity = await GetOneExerciseCategoryByIdAndCheckExist(exerciseCategoryDto.Id, trackChanges);
			entity = _mapper.Map(exerciseCategoryDto, entity);

			//izlenen nesne(trackChanges = true ise) degisiklerden sonra Update() olmadan da dogrudan save edilebilir
			//_unitOfWork.ExerciseCategoryRepository.UpdateOneExerciseCategory(entity);
			await _unitOfWork.SaveChangesAsync();
		}
		private async Task<ExerciseCategory> GetOneExerciseCategoryByIdAndCheckExist(int id, bool trackChanges)
		{
			var exerciseCategory = await _unitOfWork.ExerciseCategoryRepository.GetOneExerciseCategoryByIdAsync(id, trackChanges);
			if (exerciseCategory is null)
				throw new ArgumentNullException("exercise category you looked for couldn't found.");
			return exerciseCategory;
		}
	}
}
