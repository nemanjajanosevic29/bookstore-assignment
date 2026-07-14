using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;
using System.Text.Json;

namespace BookstoreApplication.Services
{
    public class IssueService : IIssueService
    {
        private readonly IComicVineConnection _comicVineConnection;
        private readonly IConfiguration _config;
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public IssueService(IComicVineConnection comicVineConnection, IConfiguration configuration, IIssueRepository issueRepository, IMapper mapper)
        {
            _comicVineConnection = comicVineConnection;
            _config = configuration;
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<List<IssueDto>> GetIssuesByVolume(int volumeId)
        {
            var url = $"{_config["ComicVineBaseUrl"]}/issues" +
                $"?api_key={_config["ComicVineAPIKey"]}" +
                $"&format=json" +
                $"&filter=volume:{volumeId}";

            var json = await _comicVineConnection.Get(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<IssueDto>>(json, options);
        }

        public async Task SaveIssue(SaveIssueDto dto)
        {
            var issue = _mapper.Map<Issue>(dto);
            await _issueRepository.AddAsync(issue);
        }
    }
}