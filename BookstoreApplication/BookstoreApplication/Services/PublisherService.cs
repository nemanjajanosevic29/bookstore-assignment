using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _publisherRepository;

        public PublisherService(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            return await _publisherRepository.AddAsync(publisher);
        }

        public async Task<Publisher?> UpdateAsync(int id, Publisher publisher)
        {
            var existing = await _publisherRepository.GetByIdAsync(id);
            if (existing == null) return null;
            return await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _publisherRepository.DeleteAsync(id);
        }
    }
}
