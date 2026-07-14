using BookstoreApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Librarian", NormalizedName = "LIBRARIAN" },
                new IdentityRole { Id = "2", Name = "Editor", NormalizedName = "EDITOR" }
            );

            modelBuilder.Entity<AuthorAward>()
                .HasKey(aa => new { aa.AuthorId, aa.AwardId });

            modelBuilder.Entity<AuthorAward>()
                .ToTable("AuthorAwardBridge");

            modelBuilder.Entity<Author>()
                .Property(a => a.DateOfBirth)
                .HasColumnName("Birthday");

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Author)
                .WithMany(aa => aa.AuthorAwards)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Award)
                .WithMany(aa => aa.AuthorAwards)
                .HasForeignKey(aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(aa => aa.Publisher)
                .WithMany(aa => aa.Books)
                .HasForeignKey(aa => aa.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books", Address = "80 Strand, London", Website = "https://www.penguin.co.uk" },
                new Publisher { Id = 2, Name = "HarperCollins", Address = "195 Broadway, New York", Website = "https://www.harpercollins.com" },
                new Publisher { Id = 3, Name = "Simon & Schuster", Address = "1230 Avenue of the Americas, New York", Website = "https://www.simonandschuster.com" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "George Orwell", Biography = "English novelist and essayist.", DateOfBirth = new DateTime(1903, 6, 25, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 2, FullName = "J.K. Rowling", Biography = "British author of Harry Potter.", DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 3, FullName = "Stephen King", Biography = "American author of horror fiction.", DateOfBirth = new DateTime(1947, 9, 21, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 4, FullName = "Agatha Christie", Biography = "Queen of mystery writing.", DateOfBirth = new DateTime(1890, 9, 15, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 5, FullName = "Ernest Hemingway", Biography = "American novelist and Nobel Prize winner.", DateOfBirth = new DateTime(1899, 7, 21, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Booker Prize", Description = "Premier literary award for fiction.", YearEstablished = 1969 },
                new Award { Id = 2, Name = "Nobel Prize in Literature", Description = "Highest literary honor worldwide.", YearEstablished = 1901 },
                new Award { Id = 3, Name = "Hugo Award", Description = "Award for science fiction and fantasy.", YearEstablished = 1953 },
                new Award { Id = 4, Name = "Edgar Award", Description = "Award for mystery writing.", YearEstablished = 1954 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", PageCount = 328, PublishedDate = new DateTime(1949, 6, 8, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0451524935", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Animal Farm", PageCount = 112, PublishedDate = new DateTime(1945, 8, 17, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0451526342", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 3, Title = "Harry Potter and the Philosopher's Stone", PageCount = 223, PublishedDate = new DateTime(1997, 6, 26, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0439708180", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 4, Title = "Harry Potter and the Chamber of Secrets", PageCount = 251, PublishedDate = new DateTime(1998, 7, 2, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0439064873", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 5, Title = "The Shining", PageCount = 447, PublishedDate = new DateTime(1977, 1, 28, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0307743657", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 6, Title = "It", PageCount = 1138, PublishedDate = new DateTime(1986, 9, 15, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-1501156700", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 7, Title = "Carrie", PageCount = 199, PublishedDate = new DateTime(1974, 4, 5, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0307743671", AuthorId = 3, PublisherId = 1 },
                new Book { Id = 8, Title = "Murder on the Orient Express", PageCount = 256, PublishedDate = new DateTime(1934, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0062073501", AuthorId = 4, PublisherId = 2 },
                new Book { Id = 9, Title = "And Then There Were None", PageCount = 272, PublishedDate = new DateTime(1939, 11, 6, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0062073488", AuthorId = 4, PublisherId = 2 },
                new Book { Id = 10, Title = "The ABC Murders", PageCount = 256, PublishedDate = new DateTime(1936, 1, 6, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0062073525", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 11, Title = "The Old Man and the Sea", PageCount = 127, PublishedDate = new DateTime(1952, 9, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0684801223", AuthorId = 5, PublisherId = 3 },
                new Book { Id = 12, Title = "A Farewell to Arms", PageCount = 332, PublishedDate = new DateTime(1929, 9, 27, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-0684801469", AuthorId = 5, PublisherId = 1 }
            );

            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { AuthorId = 1, AwardId = 2, YearAwarded = 1949 },
                new AuthorAward { AuthorId = 2, AwardId = 1, YearAwarded = 2000 },
                new AuthorAward { AuthorId = 2, AwardId = 3, YearAwarded = 2001 },
                new AuthorAward { AuthorId = 3, AwardId = 3, YearAwarded = 1982 },
                new AuthorAward { AuthorId = 3, AwardId = 4, YearAwarded = 1988 },
                new AuthorAward { AuthorId = 4, AwardId = 4, YearAwarded = 1955 },
                new AuthorAward { AuthorId = 4, AwardId = 2, YearAwarded = 1960 },
                new AuthorAward { AuthorId = 5, AwardId = 2, YearAwarded = 1954 },
                new AuthorAward { AuthorId = 5, AwardId = 1, YearAwarded = 1953 },
                new AuthorAward { AuthorId = 1, AwardId = 3, YearAwarded = 1950 },
                new AuthorAward { AuthorId = 1, AwardId = 4, YearAwarded = 1951 },
                new AuthorAward { AuthorId = 2, AwardId = 4, YearAwarded = 2003 },
                new AuthorAward { AuthorId = 3, AwardId = 2, YearAwarded = 1990 },
                new AuthorAward { AuthorId = 4, AwardId = 3, YearAwarded = 1957 },
                new AuthorAward { AuthorId = 5, AwardId = 4, YearAwarded = 1956 }
            );
        }
    }
}