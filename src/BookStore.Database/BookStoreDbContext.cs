using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorGuidKey).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTimestamp).HasDefaultValueSql("(getutcdate())");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.BookGuidKey).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTimestamp).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookPublisher");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.HasOne(d => d.Author).WithMany(p => p.BookAuthors).HasConstraintName("FK_BookAuthor_Author");

            entity.HasOne(d => d.Book).WithMany(p => p.BookAuthors).HasConstraintName("FK_BookAuthor_Book");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.CreatedTimestamp).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.PublisherGuidKey).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
