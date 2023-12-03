using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks.Complete
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public IndexModel(BasicTaskListContext context) => _context = context;

        public IList<Task> Task { get; set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Tasks != null)
            {
                Task = await _context.Tasks.Where(t => t.IsComplete)
                    .Include(t => t.Folder).OrderBy(t => t.DueDate)
                    .ThenBy(t => t.Name).ToListAsync();
            }
        }
    }
}
