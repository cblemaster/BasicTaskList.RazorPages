using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BasicTaskList.RazorPages.Pages.Folders
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskListContext _context;

        public IndexModel(BasicTaskListContext context) => _context = context;

        public IList<Folder> Folder { get; set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Folders != null)
            {
                Folder = await _context.Folders.Include(f => f.Tasks).OrderBy(f => f.Name).ToListAsync();
            }
        }
    }
}
