using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public CreateModel(BasicTaskListContext context) =>
            _context = context;

        public IActionResult OnGet(int? folderid)
        {
            FolderId = folderid;
            ViewData["FolderId"] = new SelectList(_context.Folders, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Task Task { get; set; } = default!;

        public int? FolderId { get; set; }


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
