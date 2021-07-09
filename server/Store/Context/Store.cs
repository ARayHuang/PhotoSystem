using Microsoft.EntityFrameworkCore;
using Store.Model;

namespace Store.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<User> tblUsers { get; set; }
        public DbSet<Project> tblProjects { get; set; }
        public DbSet<Photo> tblPhotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=photo;user=root;password=Password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();

                entity.HasMany(p => p.Projects)
                    .WithOne(p => p.Owner)
                    .HasForeignKey(p => p.Owner_id);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.status).IsRequired();
                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Projects);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Photos);
            });
        }
    }
}
