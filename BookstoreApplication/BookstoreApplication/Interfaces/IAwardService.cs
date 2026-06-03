using BookstoreApplication.Models;

namespace BookstoreApplication.Interfaces
{
    public interface IAwardService
    {
        Task<List<Award>> GetAllAsync();
        Task<Award> GetByIdAsync(int id);
        Task<Award> AddAsync(Award award);
        Task<Award> UpdateAsync(int id, Award award);
        Task<bool> DeleteAsync(int id);
    }
}