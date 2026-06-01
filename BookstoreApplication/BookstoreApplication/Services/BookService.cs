using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book?> AddAsync(Book book)
        {
            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null) return null;

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null) return null;

            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null) return null;

            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null) return null;

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null) return null;

            return await _bookRepository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
    }
}