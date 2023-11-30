using System.ComponentModel.DataAnnotations;

namespace BasicTaskList.RazorPages.Data.Entities;

public partial class Task
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Task name is required")]      //TODO: Can data annotations be replaced with fluent api in the db context?
    [MaxLength(255, ErrorMessage = "Max length for task name is 255")]
    public string Name { get; set; } = null!;

    [MaxLength(255, ErrorMessage = "Max length for notes is 255")]
    public string? Notes { get; set; }

    [Display(Name = "Due Date")]
    [DisplayFormat(DataFormatString = "{0:d}")]
    [Required(ErrorMessage = "Due date is required")]
    public DateTime DueDate { get; set; }

    [Display(Name = "Is Complete")]
    public bool IsComplete { get; set; }

    [Display(Name = "Is Important")]
    public bool IsImportant { get; set; }

    [Display(Name = "Folder")]
    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
