using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageUpload.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Pages
{
    public class ImageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ImageModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Image image = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            if (image == null)
            {
                return NotFound();
            }
            return new FileContentResult(image.Data, image.MimeType);
        }
    }
}
