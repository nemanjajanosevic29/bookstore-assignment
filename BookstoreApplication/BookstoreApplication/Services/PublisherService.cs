using BookstoreApplication.Exceptions;
using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher == null)
                throw new NotFoundException(id);
            return publisher;
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            return await _publisherRepository.AddAsync(publisher);
        }

        public async Task<Publisher> UpdateAsync(int id, Publisher publisher)
        {
            if (id != publisher.Id)
                throw new BadRequestException("Identifier value is invalid.");
            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            return await _publisherRepository.DeleteAsync(id);
        }
    }
}