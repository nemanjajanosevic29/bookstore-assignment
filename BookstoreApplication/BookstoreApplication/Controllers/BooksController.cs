using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult GetAll()
        {
            return Ok(_bookRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            var author = _authorRepository.GetById(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null) return BadRequest();

            return Ok(_bookRepository.Add(book));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var existing = _bookRepository.GetById(id);
            if (existing == null) return NotFound();

            var author = _authorRepository.GetById(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null) return BadRequest();

            return Ok(_bookRepository.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookRepository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
