using BookstoreApplication.Models;

namespace BookstoreApplication.Interfaces
{
    public interface IIssueRepository
    {
        Task AddAsync(Issue issue);
    }
}