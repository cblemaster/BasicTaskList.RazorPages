using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Folders
{
    public class DeleteModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public DeleteModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Folder Folder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? folderid)
        {
            if (folderid == null || _context.Folders == null) { return NotFound(); }

            Folder? folder = await _context.Folders.FirstOrDefaultAsync(m => m.Id == folderid);

            if (folder == null) { return NotFound(); }
            else { Folder = folder; }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? folderid)
        {
            if (folderid == null || _context.Folders == null) { return NotFound(); }
            Folder? folder = await _context.Folders.Include(f => f.Tasks).FirstOrDefaultAsync(f => f.Id == folderid);

            if (folder != null)
            {
                Folder = folder;
                foreach (Task task in Folder.Tasks)
                {
                    _context.Tasks.Remove(task);
                }
                _context.Folders.Remove(Folder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
