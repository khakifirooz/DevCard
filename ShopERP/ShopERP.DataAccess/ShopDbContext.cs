using Microsoft.EntityFrameworkCore;
using ShopERP.Models;

namespace ShopERP.DataAccess
{
    public class ShopDbContext : DbContext
    {
        // DbSet ها (جداول دیتابیس)
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// تنظیمات اتصال به دیتابیس
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection String
            // توجه: نام سرور را بر اساس سیستم خودت تغییر بده
            // . = localhost
            // .\SQLEXPRESS = SQL Server Express
            optionsBuilder.UseSqlServer(
                @"Server = .; Database = ShopERP; Integrated Security = True; encrypt = True; TrustServerCertificate = True;"
            );
        }

        /// <summary>
        /// تنظیمات مدل‌ها و روابط
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
       .HasIndex(p => p.Code)
       .IsUnique();

            // نام کاربری باید یونیک باشه
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // رابطه Invoice → Customer
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);  // مشتری با فاکتور حذف نشه

            // رابطه InvoiceItem → Invoice
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Invoice)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);   // آیتم‌ها با فاکتور حذف بشن

            // رابطه InvoiceItem → Product
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Product)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(ii => ii.ProductId)
                .OnDelete(DeleteBehavior.Restrict);  // محصول با آیتم حذف نشه
        }
    }
}
