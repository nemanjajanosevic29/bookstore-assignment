using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            return Ok(await _bookService.AddAsync(book));
        }

        [Authorize(Roles = "Editor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            return Ok(await _bookService.UpdateAsync(id, book));
        }

        [Authorize(Roles = "Editor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}