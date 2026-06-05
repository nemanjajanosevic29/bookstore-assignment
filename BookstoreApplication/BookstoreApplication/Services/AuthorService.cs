using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private const int PageSize = 4;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
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

        public async Task<PaginatedList<AuthorDTO>> GetAllPaged(int page)
        {
            var authors = await _authorRepository.GetAllPaged(page);
            var dtos = authors.Items.Select(_mapper.Map<AuthorDTO>).ToList();
            return new PaginatedList<AuthorDTO>(dtos, authors.Count, authors.PageIndex, PageSize);
        }
    }
}