using BlurHash.Models;
using Microsoft.EntityFrameworkCore;

namespace BlurHash.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<UploadedImage> UploadedImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadedImage>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
