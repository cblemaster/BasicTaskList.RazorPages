using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public DeleteModel(BasicTaskListContext context) =>
            _context = context;

        [BindProperty]
        public Task Task { get; set; } = default!;

        public int? FolderId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? folderid)
        {
            FolderId = folderid;
            
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            Task? task = await _context.Tasks.Include(t => t.Folder).FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }
            Task? task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                Task = task;
                _context.Tasks.Remove(Task);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
