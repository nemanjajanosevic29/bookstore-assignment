using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository _publisherRepository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            return Ok(await _publisherRepository.AddAsync(publisher));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest();
            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();
            return Ok(await _publisherRepository.UpdateAsync(publisher));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _publisherRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}