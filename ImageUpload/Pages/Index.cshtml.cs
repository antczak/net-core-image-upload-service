using ImageUpload.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Image> Images { get; set; }

        public async Task OnGetAsync()
        {
            Images = await _context.Images.OrderByDescending(e => e.Date).Take(10).ToListAsync();
        }
    }
}
