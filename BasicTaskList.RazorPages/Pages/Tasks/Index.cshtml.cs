using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public IndexModel(BasicTaskListContext context) => _context = context;

        public IList<Task> Task { get; set; } = default!;

        public int? FolderId { get; set; }

        public Folder? Folder { get; set; }

        public bool IsShowingAllTasks { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(int? folderid, bool? isshowingalltasks)
        {
            FolderId = folderid;
            if (FolderId.HasValue && _context.Folders != null)
            {
                Folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == FolderId);
            }

            if (_context.Tasks != null)
            {
                IQueryable<Task> taskQuery = default!;

                if (FolderId.HasValue)
                {
                    taskQuery = _context.Tasks.Where(t => t.FolderId == FolderId)
                        .Include(t => t.Folder).OrderBy(t => t.DueDate).ThenBy(t => t.Name);
                }
                else
                {
                    taskQuery = _context.Tasks.Include(t => t.Folder)
                        .OrderBy(t => t.DueDate).ThenBy(t => t.Name);
                }

                if (isshowingalltasks.HasValue)
                {
                    IsShowingAllTasks = isshowingalltasks.Value;
                }

                if (!IsShowingAllTasks)
                {
                    taskQuery = taskQuery.Where(t => !t.IsComplete);
                }

                Task = taskQuery.ToList();
            }
        }
    }
}
