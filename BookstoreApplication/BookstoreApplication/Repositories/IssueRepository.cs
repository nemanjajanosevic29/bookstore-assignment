using BookstoreApplication.Interfaces;
using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
        }
    }
}