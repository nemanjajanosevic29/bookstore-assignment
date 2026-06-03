using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IMapper mapper, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            _logger.LogInformation("Getting all books.");
            var books = await _bookRepository.GetAllAsync();
            _logger.LogInformation($"Returning {books.Count} books.");
            return books.Select(_mapper.Map<BookDto>).ToList();
        }

        public async Task<BookDetailsDto> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Get book with id {id}.");
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Book with id {id} does not exist.");
                throw new NotFoundException(id);
            }
            _logger.LogInformation($"Book with id {id} exists.");
            return _mapper.Map<BookDetailsDto>(book);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _logger.LogInformation($"Adding new book: {book.Title}.");
            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                _logger.LogError($"Author with id {book.AuthorId} does not exist.");
                throw new BadRequestException($"Author with id {book.AuthorId} does not exist.");
            }

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                _logger.LogError($"Publisher with id {book.PublisherId} does not exist.");
                throw new BadRequestException($"Publisher with id {book.PublisherId} does not exist.");
            }

            var result = await _bookRepository.AddAsync(book);
            _logger.LogInformation($"Book {book.Title} added successfully.");
            return result;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            _logger.LogInformation($"Updating book with id {id}.");
            if (id != book.Id)
            {
                _logger.LogError("Identifier value is invalid.");
                throw new BadRequestException("Identifier value is invalid.");
            }

            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null)
            {
                _logger.LogError($"Book with id {id} does not exist.");
                throw new NotFoundException(id);
            }

            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                _logger.LogError($"Author with id {book.AuthorId} does not exist.");
                throw new BadRequestException($"Author with id {book.AuthorId} does not exist.");
            }

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
            {
                _logger.LogError($"Publisher with id {book.PublisherId} does not exist.");
                throw new BadRequestException($"Publisher with id {book.PublisherId} does not exist.");
            }

            var result = await _bookRepository.UpdateAsync(book);
            _logger.LogInformation($"Book with id {id} updated successfully.");
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation($"Deleting book with id {id}.");
            var exists = await _bookRepository.GetByIdAsync(id);
            if (exists == null)
            {
                _logger.LogError($"Book with id {id} does not exist.");
                throw new NotFoundException(id);
            }
            var result = await _bookRepository.DeleteAsync(id);
            _logger.LogInformation($"Book with id {id} deleted successfully.");
            return result;
        }
    }
}