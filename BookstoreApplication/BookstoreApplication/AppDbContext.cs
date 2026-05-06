using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasForeignKey (aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(aa => aa.Publisher)
                .WithMany(aa => aa.Books)
                .HasForeignKey(aa => aa.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
