using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            return Ok(await _authorRepository.AddAsync(author));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            if (id != author.Id) return BadRequest();
            var existing = await _authorRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();
            return Ok(await _authorRepository.UpdateAsync(author));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _authorRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}