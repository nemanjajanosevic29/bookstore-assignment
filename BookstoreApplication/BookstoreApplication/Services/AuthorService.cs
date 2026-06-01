using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<Author> AddAsync(Author author)
        {
            return await _authorRepository.AddAsync(author);
        }

        public async Task<Author?> UpdateAsync(int id, Author author)
        {
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null) return null;
            return await _authorRepository.UpdateAsync(author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _authorRepository.DeleteAsync(id);
        }
    }
}