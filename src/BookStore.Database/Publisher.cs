using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database;

[Table("Publisher")]
[Index("PublisherGuidKey", Name = "UQ_PublisherGuidKey", IsUnique = true)]
public partial class Publisher
{
    [Key]
    public long PublisherId { get; set; }

    public Guid PublisherGuidKey { get; set; }

    [StringLength(128)]
    public string PublisherName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedTimestamp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [InverseProperty("Publisher")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
