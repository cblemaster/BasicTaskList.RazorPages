using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;

namespace BasicTaskList.RazorPages.Pages.Folders
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
            return Page();
        }

        [BindProperty]
        public Folder Folder { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Folders == null || Folder == null)
            {
                return Page();
            }

            _context.Folders.Add(Folder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
