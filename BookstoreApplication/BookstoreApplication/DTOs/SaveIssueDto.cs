namespace BookstoreApplication.DTOs
{
    public class SaveIssueDto
    {
        public string Name { get; set; }
        public string CoverDate { get; set; }
        public string IssueNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ExternalId { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int AvailableCopies { get; set; }
    }
}