﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task = BasicTaskList.RazorPages.Data.Entities.Task;

namespace BasicTaskList.RazorPages.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly BasicTaskList.RazorPages.Data.Context.BasicTaskListContext _context;

        public IndexModel(BasicTaskList.RazorPages.Data.Context.BasicTaskListContext context)
        {
            _context = context;
        }

        public IList<Task> Task { get;set; } = default!;

        public async System.Threading.Tasks.Task OnGetAsync(int? id)
        {
            if (_context.Tasks != null)
            {
                if (id != null)
                {
                    Task = await _context.Tasks.Where(t => t.FolderId == id)
                        .Include(t => t.Folder).ToListAsync();
                }
                else
                {
                    Task = await _context.Tasks
                        .Include(t => t.Folder).ToListAsync();
                }
            }
        }
    }
}
