using System.ComponentModel.DataAnnotations;

namespace ShopERP.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;  // هیچوقت پسورد خام ذخیره نکن

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "Operator";    // Admin, Manager, Operator

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
