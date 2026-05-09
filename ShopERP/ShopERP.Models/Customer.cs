using System.ComponentModel.DataAnnotations;

namespace ShopERP.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [EmailAddress]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
