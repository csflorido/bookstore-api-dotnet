using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

[Table("Book")]
[Index("BookGuidKey", Name = "UQ_BookGuidKey", IsUnique = true)]
public partial class Book
{
    [Key]
    public long BookId { get; set; }

    public Guid BookGuidKey { get; set; }

    public long PublisherId { get; set; }

    [StringLength(128)]
    public string Title { get; set; } = null!;

    [StringLength(13)]
    [Unicode(false)]
    public string? Isbn10 { get; set; }

    [StringLength(17)]
    [Unicode(false)]
    public string? Isbn13 { get; set; }

    public short? NumberOfPages { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal? WeightInKilos { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedTimestamp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    [ForeignKey("PublisherId")]
    [InverseProperty("Books")]
    public virtual Publisher Publisher { get; set; } = null!;
}
