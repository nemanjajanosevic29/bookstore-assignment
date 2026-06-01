using BookstoreApplication.Models;

namespace BookstoreApplication.Interfaces
{
    public interface IAwardRepository
    {
        Task<List<Award>> GetAllAsync();
        Task<Award?> GetByIdAsync(int id);
        Task<Award> AddAsync(Award award);
        Task<Award> UpdateAsync(Award award);
        Task<bool> DeleteAsync(int id);
    }
}