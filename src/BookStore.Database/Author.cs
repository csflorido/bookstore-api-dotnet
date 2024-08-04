using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

[Table("Author")]
[Index("AuthorGuidKey", Name = "UQ_AuthorGuidKey", IsUnique = true)]
public partial class Author
{
    [Key]
    public long AuthorId { get; set; }

    public Guid AuthorGuidKey { get; set; }

    [StringLength(128)]
    public string? FirstName { get; set; }

    [StringLength(128)]
    public string? LastName { get; set; }

    [StringLength(256)]
    public string? DisplayName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedTimestamp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
