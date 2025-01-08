using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SimpleQuotes.Data.Entities;

namespace SimpleQuotes.Data.Context;

public class SimpleQuoteContext: DbContext
{
    public DbSet<Quote> Quotes { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Text).HasMaxLength(500);
            
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(e => e.Author)
                .WithMany(e => e.Quotes)
                .HasForeignKey(e => e.AuthorId);
            
            entity.HasOne(e => e.CreatedBy)
                .WithMany(e => e.QuotesModified)
                .HasForeignKey(e => e.CreatedById);
            
            entity.HasOne(e => e.UpdatedBy)
                .WithMany(e => e.QuotesModified)
                .HasForeignKey(e => e.UpdatedById);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasMany(e => e.Quotes)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId);
            
            entity.HasOne(e => e.CreatedBy)
                .WithMany(e => e.AuthorsModified)
                .HasForeignKey(e => e.CreatedById);
        });
    }
}