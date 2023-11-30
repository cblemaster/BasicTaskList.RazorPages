using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public DetailsModel(BasicTaskListContext context) => _context = context;

        public Task Task { get; set; } = default!;

        public int? FolderId { get; set; }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync(int? id, int? folderid)
        {
            FolderId = folderid;

            if (id == null || _context.Tasks == null) { return NotFound(); }

            Task task = (await _context.Tasks.Include(t => t.Folder).FirstOrDefaultAsync(m => m.Id == id))!;
            if (task == null) { return NotFound();}
            else { Task = task; }
            
            return Page();
        }
    }
}
