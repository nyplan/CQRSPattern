using CQRSMediatRAutoMaperTask.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatRAutoMaperTask.DAL
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>()
                .HasMany(a => a.Cars)
                .WithOne(a => a.Brand)
                .HasForeignKey(a => a.BrandId);
            modelBuilder.Entity<Brand>()
                .Property("CreatedDate")
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Car>()
                .Property("CreatedDate")
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Brand>().HasIndex("Name").IsUnique();
            modelBuilder.Entity<Car>().HasIndex("Name").IsUnique();
        }
    }
}
