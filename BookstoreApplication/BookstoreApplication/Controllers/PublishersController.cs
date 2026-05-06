using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult GetAll()
        {
            return Ok(_publisherRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var publisher = _publisherRepository.GetById(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            return Ok(_publisherRepository.Add(publisher));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest();
            var existing = _publisherRepository.GetById(id);
            if (existing == null) return NotFound();
            return Ok(_publisherRepository.Update(publisher));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _publisherRepository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
