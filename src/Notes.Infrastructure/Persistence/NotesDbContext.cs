using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;

namespace Notes.Infrastructure.Persistence
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        public DbSet<Note> Notes => Set<Note>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>(b =>
            {
                b.HasKey(n => n.Id);
                b.Property(n => n.Title).IsRequired().HasMaxLength(150);
                b.Property(n => n.Content).HasColumnType("nvarchar(max)");
                b.Property(n => n.Priority).HasConversion<int>().IsRequired().HasDefaultValue(Priority.Medium);
            });
        }
    }
}
