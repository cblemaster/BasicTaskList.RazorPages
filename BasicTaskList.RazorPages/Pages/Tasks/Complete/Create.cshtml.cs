using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks.Complete
{
    public class CreateModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public CreateModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Task Task { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["FolderNames"] = new SelectList(_context.Folders, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Task.FolderId != 0)
            {
                Task.Folder = (await _context.Folders.FirstOrDefaultAsync(f => f.Id == Task.FolderId))!;
            }

            if (Task.Folder == null) { return Page(); }
            ModelState.Remove("Task.Folder");

            if (!ModelState.IsValid || _context.Tasks == null || Task == null) { return Page(); }

            Task.FolderId = Task.Folder.Id;

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage($"../Index", new { folderid = Task.FolderId });
        }
    }
}
