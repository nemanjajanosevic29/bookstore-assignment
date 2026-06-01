using BookstoreApplication.Models;

namespace BookstoreApplication.Interfaces
{
    public interface IPublisherService
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);
        Task<Publisher> AddAsync(Publisher publisher);
        Task<Publisher?> UpdateAsync(int id, Publisher publisher);
        Task<bool> DeleteAsync(int id);
    }
}