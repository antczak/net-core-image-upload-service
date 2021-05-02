using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ImageUpload.Data;

namespace ImageUpload.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Image Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Image = await _context.Images.Include(e => e.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Image == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
