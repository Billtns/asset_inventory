using Microsoft.EntityFrameworkCore;
using AssetInventory.Api.Models;

namespace AssetInventory.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetsModel>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<AssetsModel>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Assets)
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StatusModel>().HasData(
                    new StatusModel { StatusId = 1, StatusName = "Available", CreatedAt = DateTime.Now },
                    new StatusModel { StatusId = 2, StatusName = "In Use", CreatedAt = DateTime.Now },
                    new StatusModel { StatusId = 3, StatusName = "Repair", CreatedAt = DateTime.Now },
                    new StatusModel { StatusId = 4, StatusName = "Disposed", CreatedAt = DateTime.Now }
            );
        }

        public DbSet<CategoriesModel> Categories => Set<CategoriesModel>();
        public DbSet<AssetsModel> Assets => Set<AssetsModel>();
        public DbSet<StatusModel> Status => Set<StatusModel>();
    }
}
