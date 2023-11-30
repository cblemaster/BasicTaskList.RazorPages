using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BasicTaskList.RazorPages.Pages.Folders
{
    public class EditModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public EditModel(BasicTaskListContext context) => _context = context;

        [BindProperty]
        public Folder Folder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? folderid)
        {
            if (folderid == null || _context.Folders == null) { return NotFound(); }

            Folder? folder = await _context.Folders.FirstOrDefaultAsync(m => m.Id == folderid);
            if (folder == null) { return NotFound(); }
            Folder = folder;
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            _context.Attach(Folder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderExists(Folder.Id)) { return NotFound(); }
                else { throw; }
            }

            return RedirectToPage("./Index");
        }

        private bool FolderExists(int id) => (_context.Folders?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
