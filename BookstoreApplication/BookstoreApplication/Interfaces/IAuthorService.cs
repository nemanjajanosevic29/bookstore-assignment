using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<Author> UpdateAsync(int id, Author author);
        Task<bool> DeleteAsync(int id);
        Task<PaginatedList<AuthorDTO>> GetAllPaged(int page);
    }
}