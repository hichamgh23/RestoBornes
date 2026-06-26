using Microsoft.EntityFrameworkCore;
using RestoBorne.Domain.Entities;

namespace RestoBorne.Infrastructure.Persistence
{
    public class RestoBorneDbContext : DbContext
    {
        public RestoBorneDbContext(DbContextOptions<RestoBorneDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(o => o.Id);

                builder.HasMany(o => o.Items)
                       .WithOne(i => i.Order)
                       .HasForeignKey(i => i.OrderId);

                builder.Navigation(o => o.Items)
                       .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.HasKey(i => i.Id);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.HasKey(c => c.Id);

                builder.HasMany(c => c.Products)
                       .WithOne(p => p.Category)
                       .HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(p => p.Id);
            });

            var categoryId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryId,
                    Name = "Plats",
                    Description = "Plats principaux"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Burger Classic",
                    Description = "Le classique",
                    Price = 10.5m,
                    IsAvailable = true,
                    CategoryId = categoryId
                },
                new Product
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Frites",
                    Description = "Frites croustillantes",
                    Price = 3.5m,
                    IsAvailable = true,
                    CategoryId = categoryId
                }
            );
        }
    }
}