using BookstoreApplication.Exceptions;
using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;

        public AwardService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _awardRepository.GetAllAsync();
        }

        public async Task<Award> GetByIdAsync(int id)
        {
            var award = await _awardRepository.GetByIdAsync(id);
            if (award == null)
                throw new NotFoundException(id);
            return award;
        }

        public async Task<Award> AddAsync(Award award)
        {
            return await _awardRepository.AddAsync(award);
        }

        public async Task<Award> UpdateAsync(int id, Award award)
        {
            if (id != award.Id)
                throw new BadRequestException("Identifier value is invalid.");
            var existing = await _awardRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _awardRepository.UpdateAsync(award);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _awardRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _awardRepository.DeleteAsync(id);
        }
    }
}