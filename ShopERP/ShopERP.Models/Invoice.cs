using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopERP.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Column(TypeName ="decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "معلق";

        [MaxLength(500)]
        public string? Notes { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } = null!;

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
