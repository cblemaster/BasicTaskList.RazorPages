namespace BasicTaskList.RazorPages.Data.Entities;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsComplete { get; set; }

    public bool IsImportant { get; set; }

    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
