using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicTaskList.RazorPages.Data.Context;
using BasicTaskList.RazorPages.Data.Entities;

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

        public async Task OnGetAsync()
        {
            if (_context.Tasks != null)
            {
                Task = await _context.Tasks
                .Include(t => t.Folder).ToListAsync();
            }
        }
    }
}
