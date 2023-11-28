using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly BasicTaskList.RazorPages.Data.Context.BasicTaskListContext _context;

        public CreateModel(BasicTaskList.RazorPages.Data.Context.BasicTaskListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FolderId"] = new SelectList(_context.Folders, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Task Task { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tasks == null || Task == null)
            {
                return Page();
            }

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
