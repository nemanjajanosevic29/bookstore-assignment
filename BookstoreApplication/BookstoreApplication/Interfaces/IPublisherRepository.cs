using BookstoreApplication.Models;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);
        Task<Publisher> AddAsync(Publisher publisher);
        Task<Publisher> UpdateAsync(Publisher publisher);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Publisher>> GetAllSorted(int sortType);
        Task<List<SortTypeOption>> GetSortTypes();
    }
}