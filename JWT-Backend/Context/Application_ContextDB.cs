using JWT_Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT_Backend.Context
{
    public class Application_ContextDB : DbContext
    {
        public DbSet<Auth> Users { get; set; }

        public Application_ContextDB(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("AuthTable");
                entity.HasKey(u => u.IdAuth);
                entity.Property(u => u.IdAuth).ValueGeneratedOnAdd();
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}