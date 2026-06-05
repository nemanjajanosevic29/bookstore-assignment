using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _publisherService.GetByIdAsync(id));
        }

        [HttpGet("sortTypes")]
        public async Task<IActionResult> GetSortTypes()
        {
            return Ok(await _publisherService.GetSortTypes());
        }

        [HttpGet("sort")]
        public async Task<IActionResult> GetSortedPublishers([FromQuery] int sortType = (int)PublisherSortType.NAME_ASCENDING)
        {
            return Ok(await _publisherService.GetAllSorted(sortType));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            return Ok(await _publisherService.AddAsync(publisher));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            return Ok(await _publisherService.UpdateAsync(id, publisher));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _publisherService.DeleteAsync(id);
            return NoContent();
        }
    }
}