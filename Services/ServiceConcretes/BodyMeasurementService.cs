
using AutoMapper;
using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.UnitOfWork;
using System.Security.Claims;

namespace Repositories.RepoConcretes
{
	public sealed class BodyMeasurementService : IBodyMeasurementService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BodyMeasurementService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges)
		{
			if (userId is null)
				throw new ArgumentNullException($"any body measurement could not found which is belong to the user with {userId}");
			return await _unitOfWork.BodyMeasurementRepository.GetAllBodyMeasurementsByUserIdAsync(userId, trackChanges);
		}

		public async Task<BodyMeasurement?> GetOneBodyMeasurementByUserIdAsync(int id, string userId, bool trackChanges)
		{
			var bodyMeasurement = await _unitOfWork.BodyMeasurementRepository.GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);
			if (bodyMeasurement == null)
				throw new ArgumentNullException("BodyMeasurement not found");

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
			var existingMeasurement = await _unitOfWork.BodyMeasurementRepository.GetOneBodyMeasurementByUserIdAsync(bodyMeasurementDto.Id, userId, trackChanges);
			if (existingMeasurement == null)
				throw new ArgumentNullException("BodyMeasurement not found");

			_mapper.Map(bodyMeasurementDto, existingMeasurement);

			//degisiklikler izlenirse (trackChanges == true)) Update() metodu cagirilmaz
			//_unitOfWork.BodyMeasurementRepository.UpdateOneBodyMeasurement(userId, bodyMeasurement);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteOneBodyMeasurementAsync(int id, string userId, BodyMeasurement bodyMeasurement, bool trackChanges)
		{
			var existingMeasurement = await _unitOfWork.BodyMeasurementRepository
	   .GetOneBodyMeasurementByUserIdAsync(id, userId, trackChanges);

			if (existingMeasurement is null)
				throw new ArgumentNullException("BodyMeasurement not found");

			_unitOfWork.BodyMeasurementRepository.DeleteOneBodyMeasurement(userId, existingMeasurement);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
