using Microsoft.EntityFrameworkCore;
using RedbullService.Models;
using RedBullService.Models;

namespace RedbullService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product ve Category ilişkisi
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.category_id)
                .OnDelete(DeleteBehavior.Restrict); // Varsayılan olarak Restrict kullanabilirsiniz

            // Comment ve Product ilişkisi
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.product_id)
                .OnDelete(DeleteBehavior.Restrict); // Varsayılan olarak Restrict kullanabilirsiniz

            // Comment ve User ilişkisi
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.user_id)
                .OnDelete(DeleteBehavior.Restrict); // Varsayılan olarak Restrict kullanabilirsiniz
        }
    }
}

