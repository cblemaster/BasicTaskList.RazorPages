using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks.Complete
{
    public class EditModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public EditModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Task Task { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tasks == null) { return NotFound(); }

            Task? task = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (task == null) { return NotFound(); }
            Task = task;

            ViewData["FolderNames"] = new SelectList(_context.Folders, "Id", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Task.Folder = (await _context.Folders.FirstOrDefaultAsync(f => f.Id == Task.FolderId))!;

            if (Task.Folder == null) { return Page(); }
            ModelState.Remove("Task.Folder");

            if (!ModelState.IsValid) { return Page(); }

            Task.FolderId = Task.Folder.Id;

            _context.Attach(Task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(Task.Id)) { return NotFound(); }
                else { throw; }
            }

            return RedirectToPage($"../Index", new { folderid = Task.FolderId });

        }

        private bool TaskExists(int id) =>
            (_context.Tasks?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
