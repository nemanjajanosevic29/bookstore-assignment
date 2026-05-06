using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(Author author)
        {
            return Ok(_authorRepository.Add(author));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Author author)
        {
            if (id != author.Id) return BadRequest();
            var existing = _authorRepository.GetById(id);
            if (existing == null) return NotFound();
            return Ok(_authorRepository.Update(author));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _authorRepository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
