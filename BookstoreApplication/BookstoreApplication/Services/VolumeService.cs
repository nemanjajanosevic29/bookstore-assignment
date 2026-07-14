using BookstoreApplication.DTOs;
using BookstoreApplication.Interfaces;
using System.Text.Json;

namespace BookstoreApplication.Services
{
    public class VolumeService : IVolumeService
    {
        private readonly IComicVineConnection _comicVineConnection;
        private readonly IConfiguration _config;

        public VolumeService(IComicVineConnection comicVineConnection, IConfiguration configuration)
        {
            _comicVineConnection = comicVineConnection;
            _config = configuration;
        }

        public async Task<List<VolumeDto>> SearchVolumesByName(string filter)
        {
            var url = $"{_config["ComicVineBaseUrl"]}/volumes" +
                $"?api_key={_config["ComicVineAPIKey"]}" +
                $"&format=json" +
                $"&filter=name:{Uri.EscapeDataString(filter)}";

            var json = await _comicVineConnection.Get(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<VolumeDto>>(json, options);
        }
    }
}