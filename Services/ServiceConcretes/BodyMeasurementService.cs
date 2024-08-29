using AutoMapper;
using Entities.DTOs.BodyMeasurement;
using Entities.Models;
using Repositories.UnitOfWork;
using Services.Exceptions;

namespace Services.ServiceConcretes
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
		public async Task<IEnumerable<BodyMeasurement>?> GetAllBodyMeasurementsByUserIdAsync(string userId, bool trackChanges)
		{
			if (userId is null)
				throw new ArgumentNullException($"any body measurement could not found which is belong to the user with {userId}");

			var allBodyMeasurementsOfUser = await _unitOfWork.BodyMeasurementRepository.GetAllBodyMeasurementsByUserIdAsync(userId, trackChanges);
			return allBodyMeasurementsOfUser;
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
