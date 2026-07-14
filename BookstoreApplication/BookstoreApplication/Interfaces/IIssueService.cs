using BookstoreApplication.DTOs;

namespace BookstoreApplication.Interfaces
{
    public interface IIssueService
    {
        Task<List<IssueDto>> GetIssuesByVolume(int volumeId);
        Task SaveIssue(SaveIssueDto dto);
    }
}