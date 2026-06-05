using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _authorService.GetByIdAsync(id));
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAuthorsPage([FromQuery] int page = 1)
        {
            if (page < 1)
                return BadRequest("Page value is invalid.");
            return Ok(await _authorService.GetAllPaged(page));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            return Ok(await _authorService.AddAsync(author));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            return Ok(await _authorService.UpdateAsync(id, author));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}