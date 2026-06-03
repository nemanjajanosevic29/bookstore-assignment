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

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(_mapper.Map<BookDto>).ToList();
        }

        public async Task<BookDetailsDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException(id);
            return _mapper.Map<BookDetailsDto>(book);
        }

        public async Task<Book> AddAsync(Book book)
        {
            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
                throw new BadRequestException($"Author with id {book.AuthorId} does not exist.");

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
                throw new BadRequestException($"Publisher with id {book.PublisherId} does not exist.");

            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            if (id != book.Id)
                throw new BadRequestException("Identifier value is invalid.");

            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);

            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
                throw new BadRequestException($"Author with id {book.AuthorId} does not exist.");

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
                throw new BadRequestException($"Publisher with id {book.PublisherId} does not exist.");

            return await _bookRepository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _bookRepository.GetByIdAsync(id);
            if (exists == null)
                throw new NotFoundException(id);
            return await _bookRepository.DeleteAsync(id);
        }
    }
}