using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        [StringLength(128)]
        public string? FirstName { get; set; }

        [StringLength(128)]
        public string? LastName { get; set; }

        [StringLength(256)]
        public string? DisplayName
        {
            get
            {
                return string.IsNullOrWhiteSpace(_displayName) ? $"{this.FirstName} {this.LastName}".Trim() : _displayName;
            }

            set
            {
                _displayName = value;
            }
        }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        private string? _displayName = null;
    }
}
