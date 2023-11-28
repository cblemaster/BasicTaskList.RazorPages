using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Data.Context;

public partial class BasicTaskListContext : DbContext
{
    public BasicTaskListContext()
    {
    }

    public BasicTaskListContext(DbContextOptions<BasicTaskListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Folder).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Folders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
