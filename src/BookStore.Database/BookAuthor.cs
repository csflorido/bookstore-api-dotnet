using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

[Table("BookAuthor")]
[Index("BookId", "AuthorId", Name = "UQ_BookAuthor", IsUnique = true)]
public partial class BookAuthor
{
    [Key]
    public long BookAuthorId { get; set; }

    public long BookId { get; set; }

    public long AuthorId { get; set; }

    public byte? DisplayOrder { get; set; }

    public string? AboutAuthor { get; set; }

    [Column("LanguageISO6392Code")]
    [StringLength(4)]
    [Unicode(false)]
    public string? LanguageIso6392code { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("BookAuthors")]
    public virtual Author Author { get; set; } = null!;

    [ForeignKey("BookId")]
    [InverseProperty("BookAuthors")]
    public virtual Book Book { get; set; } = null!;
}
