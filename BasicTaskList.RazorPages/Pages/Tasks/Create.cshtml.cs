using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public CreateModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Task Task { get; set; } = default!;

        public int? FolderId { get; set; }

        public IActionResult OnGet(int? folderid)
        {
            FolderId = folderid;
            ViewData["FolderNames"] = new SelectList(_context.Folders, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? folderid)
        {
            if (Task.FolderId != 0)
            {
                Task.Folder = (await _context.Folders.FirstOrDefaultAsync(f => f.Id == Task.FolderId))!;
            }
            else if (folderid.HasValue)
            {
                Task.Folder = (await _context.Folders.FirstOrDefaultAsync(f => f.Id == folderid.Value))!;
            }

            if (Task.Folder == null) { return Page(); }
            ModelState.Remove("Task.Folder");

            if (!ModelState.IsValid || _context.Tasks == null || Task == null) { return Page(); }

            Task.FolderId = Task.Folder.Id;

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return folderid.HasValue ? RedirectToPage($"./Index", new { folderid = folderid }) : RedirectToPage("./Index");
        }
    }
}
