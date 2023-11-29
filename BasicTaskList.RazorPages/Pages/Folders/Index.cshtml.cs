using BasicTaskList.RazorPages.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BasicTaskList.RazorPages.Pages.Folders
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskList.RazorPages.Data.Context.BasicTaskListContext _context;

        public IndexModel(BasicTaskList.RazorPages.Data.Context.BasicTaskListContext context)
        {
            _context = context;
        }

        public IList<Folder> Folder { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (_context.Folders != null)
            {
                Folder = await _context.Folders.Include(f => f.Tasks).ToListAsync();  //TODO: The only reason I'm getting Tasks here is so I can count 'em; use an unmapped property on the entity class instead
            }
        }
    }
}
