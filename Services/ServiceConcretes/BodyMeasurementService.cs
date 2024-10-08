﻿using AutoMapper;
using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.UnitOfWork;
using Services.Exceptions;
using Services.ServiceContracts;
using System.Dynamic;

namespace Services.ServiceConcretes
{
	public sealed class BodyMeasurementService : IBodyMeasurementService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IDataShaper<BodyMeasurement> _shaper;
		public BodyMeasurementService(IUnitOfWork unitOfWork, IMapper mapper, IDataShaper<BodyMeasurement> shaper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_shaper = shaper;
		}
		public async Task<IEnumerable<ExpandoObject>?> GetAllBodyMeasurementsByUserIdAsync(BodyMeasurementParameters bodyMeasurementParameters, string userId, bool trackChanges)
		{
			if (!bodyMeasurementParameters.IsValid) 
				throw new WeightOutOfRangeBadRequestException();

			if (userId is null)
				throw new ArgumentNullException($"any body measurement could not found which is belong to the user with userId: {userId}");

			var bodyMeasurementsWithMetaData = await _unitOfWork.BodyMeasurementRepository
				.GetAllBodyMeasurementsByUserIdAsync(bodyMeasurementParameters, userId, trackChanges);

			var bodyMeasurementsDto = _mapper.Map<IEnumerable<BodyMeasurement>>(bodyMeasurementsWithMetaData);
			var shapedData = _shaper.ShapeData(bodyMeasurementsDto, bodyMeasurementParameters.Fields);
			return shapedData;
		}
		public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
		{
			var bodyMeasurement = await GetOneBodyMeasurementAndCheckExist(id, userId, trackChanges);
			return bodyMeasurement;
		}
		public async Task AddOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForInsertion bodyMeasurementDto)
		{
			var bodyMeasurement = _mapper.Map<BodyMeasurement>(bodyMeasurementDto);
			await _unitOfWork.BodyMeasurementRepository.AddOneBodyMeasurementAsync(userId, bodyMeasurement);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateOneBodyMeasurementAsync(string userId, BodyMeasurementDtoForUpdate bodyMeasurementDto, bool trackChanges)
		{
			var existingMeasurement = await GetOneBodyMeasurementAndCheckExist(bodyMeasurementDto.Id, userId, trackChanges);
			var bodyMeasurement = _mapper.Map(bodyMeasurementDto, existingMeasurement);

			//degisiklikler izlenirse (trackChanges == true)) Update() metodu cagirilmaz
			_unitOfWork.BodyMeasurementRepository.UpdateOneBodyMeasurement(userId, bodyMeasurement);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteOneBodyMeasurementAsync(int id, string userId, bool trackChanges)
		{
			var existingMeasurement = await GetOneBodyMeasurementAndCheckExist(id, userId, trackChanges);

			_unitOfWork.BodyMeasurementRepository.DeleteOneBodyMeasurement(userId, existingMeasurement);
			await _unitOfWork.SaveChangesAsync();
		}
		private async Task<BodyMeasurement?> GetOneBodyMeasurementAndCheckExist(int id, string userId, bool trackChanges)
		{
			var bodyMeasurement = await _unitOfWork.BodyMeasurementRepository.GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);
			if (bodyMeasurement == null)
				throw new BodyMeasurementNotFoundException(id);
			return bodyMeasurement;
		}
	}
}
