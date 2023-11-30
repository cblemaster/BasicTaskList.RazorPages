﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicTaskList.RazorPages.Data.Entities;

public partial class Folder
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Folder name is required")]
    [MaxLength(255, ErrorMessage = "Max length for folder name is 255")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    //[NotMapped]
    //public bool HasTasks => Tasks.Any();

    //[NotMapped]
    //public int TasksCount => HasTasks ? Tasks.Count : 0;
}
