using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared.Model;
namespace BlazorApp1.Server.Model
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("st_animals");
                entity.Property(e => e.animalId).HasColumnName("Animalid");
                entity.Property(e => e.name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.breed)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.birthDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.price)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
