using BookstoreApplication.DTOs;
using BookstoreApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [Authorize(Roles = "Editor")]
        [HttpGet("byVolume/{volumeId}")]
        public async Task<IActionResult> GetIssuesByVolume(int volumeId)
        {
            return Ok(await _issueService.GetIssuesByVolume(volumeId));
        }

        [Authorize(Roles = "Editor")]
        [HttpPost]
        public async Task<IActionResult> SaveIssue(SaveIssueDto dto)
        {
            await _issueService.SaveIssue(dto);
            return NoContent();
        }
    }
}