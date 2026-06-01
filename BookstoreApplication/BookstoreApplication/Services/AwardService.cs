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

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _awardRepository.GetByIdAsync(id);
        }

        public async Task<Award> AddAsync(Award award)
        {
            return await _awardRepository.AddAsync(award);
        }

        public async Task<Award?> UpdateAsync(int id, Award award)
        {
            var existing = await _awardRepository.GetByIdAsync(id);
            if (existing == null) return null;
            return await _awardRepository.UpdateAsync(award);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _awardRepository.DeleteAsync(id);
        }
    }
}