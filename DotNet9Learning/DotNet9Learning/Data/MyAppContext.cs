using DotNet9Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet9Learning.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }

        public DbSet<Items> Items { get; set; }

        protected MyAppContext()
        {
        }
    }
}
