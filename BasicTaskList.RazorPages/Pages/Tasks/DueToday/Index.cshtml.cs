using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks.DueToday
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public IndexModel(BasicTaskListContext context) => _context = context;

        public IList<Task> Task { get; set; } = default!;

        public bool IsShowingCompletedTasks { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(bool? isshowingcompletedtasks)
        {
            if (_context.Tasks != null)
            {
                IQueryable<Task> taskQuery = _context.Tasks.Where(t => t.DueDate.Date == DateTime.Today).
                    Include(t => t.Folder).OrderBy(t => t.DueDate).ThenBy(t => t.Name);

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
