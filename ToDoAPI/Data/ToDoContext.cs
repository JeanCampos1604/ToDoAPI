using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<Notes> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>(b =>
            {
                b.ToTable("NOTES");
                b.HasKey(n => n.Id);

                b.Property(n => n.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(36);

                b.Property(n => n.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(200)
                    .IsRequired();

                b.Property(n => n.Description)
                    .HasColumnName("DESCRIPTION");

                b.Property(n => n.Priority)
                    .HasColumnName("PRIORITY")
                    .HasMaxLength(50);

                b.Property(n => n.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(100);

                b.Property(n => n.IsCompleted)
                    .HasColumnName("ISCOMPLETED")
                    .HasConversion<int>();

                b.Property(n => n.CreatedAt)
                    .HasColumnName("CREATEDAT");

                b.Property(n => n.UpdatedAt)
                    .HasColumnName("UPDATEDAT");
            });
        }
    }
}