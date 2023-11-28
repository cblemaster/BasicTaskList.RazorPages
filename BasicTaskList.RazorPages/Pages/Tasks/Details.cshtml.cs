using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly BasicTaskList.RazorPages.Data.Context.BasicTaskListContext _context;

        public DetailsModel(BasicTaskList.RazorPages.Data.Context.BasicTaskListContext context)
        {
            _context = context;
        }

      public Task Task { get; set; } = default!; 

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            Task task = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            else 
            {
                Task = task;
            }
            return Page();
        }
    }
}
