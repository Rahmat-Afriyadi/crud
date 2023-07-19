namespace BookCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> dbContext) : base(dbContext)
    {

    }

    public DbSet<BookCategory> BookCategories { get; set; }

    public DbSet<Book> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    modelBuilder.Entity<Book>()
        .HasOne(b => b.BookCategory)
        .WithMany(a => a.Books)
        .HasForeignKey(b => b.BookCategoryId)
        .OnDelete(DeleteBehavior.Cascade); // Choose the appropriate delete behavior (e.g., Cascade, Restrict, etc.)
    }
}
