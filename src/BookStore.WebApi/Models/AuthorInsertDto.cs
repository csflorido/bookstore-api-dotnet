using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Models
{
    public class AuthorInsertDto
    {
        [Required]
        [StringLength(128)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string? DisplayName { get; set; }
    }
}
