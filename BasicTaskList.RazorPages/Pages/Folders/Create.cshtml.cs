using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicTaskList.RazorPages.Pages.Folders
{
    public class CreateModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public CreateModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Folder Folder { get; set; } = default!;

        public IActionResult OnGet() => Page();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Folders == null || Folder == null) { return Page(); }

            _context.Folders.Add(Folder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
