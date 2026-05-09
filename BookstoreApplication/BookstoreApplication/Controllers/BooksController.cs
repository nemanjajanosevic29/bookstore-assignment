using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;

        public BooksController(BookRepository bookRepository, AuthorRepository authorRepository, PublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null) return BadRequest();

            return Ok(await _bookRepository.AddAsync(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null) return BadRequest();

            return Ok(await _bookRepository.UpdateAsync(book));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}