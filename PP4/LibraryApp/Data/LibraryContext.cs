using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class LibraryContext : DbContext

    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TitleTag> TitlesTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ruta completa del archivo de base de datos SQLite
            var dbFolder = Path.Combine(Directory.GetCurrentDirectory(), "data");
            var dbFile = Path.Combine(dbFolder, "library.db");


            // Crear carpeta si no existe
            Directory.CreateDirectory(dbFolder);

            // Conexión usando SQLite
            optionsBuilder.UseSqlite($"Data Source={dbFile}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Asegurar que la tabla intermedia tenga un nombre plural
            modelBuilder.Entity<TitleTag>().ToTable("TitlesTags");

            // Definir el orden de las columnas en la tabla Title
            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(t => t.TitleId).HasColumnOrder(1);
                entity.Property(t => t.AuthorId).HasColumnOrder(2);
                entity.Property(t => t.TitleName).HasColumnOrder(3);
            });

            // Clave compuesta (si aplica en tu modelo)
            modelBuilder.Entity<TitleTag>()
                .HasKey(tt => new { tt.TitleId, tt.TagId });
        }
    }
}

