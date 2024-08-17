using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Models
{
    public class AuthorUpdateDto
    {
        [StringLength(128)]
        public string? FirstName { get; set; }

        [StringLength(128)]
        public string? LastName { get; set; }

        [StringLength(256)]
        public string? DisplayName { get; set; }
    }
}
