using BasicTaskList.RazorPages.Data.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public IndexModel(BasicTaskListContext context) =>
            _context = context;

        public IList<Task> Task { get; set; } = default!;

        public int? FolderId { get; set; }

        public bool IsShowingAllTasks { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(int? folderid)
        {
            FolderId = folderid;
            
            if (_context.Tasks != null)
            {
                if (folderid != null)
                {
                    Task = await _context.Tasks.Where(t => t.FolderId == folderid)
                        .Include(t => t.Folder).ToListAsync();
                }
                else
                {
                    IsShowingAllTasks = true;
                    Task = await _context.Tasks
                        .Include(t => t.Folder).ToListAsync();
                }
            }
        }
    }
}
