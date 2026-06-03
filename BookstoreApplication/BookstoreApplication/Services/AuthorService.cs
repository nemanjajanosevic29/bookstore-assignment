using BookstoreApplication.Exceptions;
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

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new NotFoundException(id);
            return author;
        }

        public async Task<Author> AddAsync(Author author)
        {
            return await _authorRepository.AddAsync(author);
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            if (id != author.Id)
                throw new BadRequestException("Identifier value is invalid.");
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _authorRepository.UpdateAsync(author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _authorRepository.DeleteAsync(id);
        }
    }
}