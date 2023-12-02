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

        public bool IsShowingTasksInFolder { get; set; }

        public bool IsShowingCompletedTasks { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(int? folderid, bool? isshowingcompletedtasks)
        {
            IsShowingTasksInFolder = false;

            FolderId = folderid;
            if (FolderId.HasValue) { IsShowingTasksInFolder = true; }

            if (IsShowingTasksInFolder && _context.Folders != null)
            {
                Folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == FolderId);
            }

            if (_context.Tasks != null)
            {
                IQueryable<Task> taskQuery = _context.Tasks.Include(t => t.Folder)
                        .OrderBy(t => t.DueDate).ThenBy(t => t.Name);

                if (IsShowingTasksInFolder)
                {
                    taskQuery = taskQuery.Where(t => t.FolderId == FolderId);
                }

                if (isshowingcompletedtasks.HasValue)
                {
                    IsShowingCompletedTasks = isshowingcompletedtasks.Value;
                }

                if (!IsShowingCompletedTasks)
                {
                    taskQuery = taskQuery.Where(t => !t.IsComplete);
                }

                Task = await taskQuery.ToListAsync();
            }
        }
    }
}
