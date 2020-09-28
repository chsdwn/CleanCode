namespace CodeFirstExistingDb
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class MusicStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CleanCode.db");

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.Artist)
                .IsUnicode(false);

            modelBuilder.Entity<Song>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
    }
}
