using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ImageUpload.Data;
using ImageUpload.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageUpload.Pages
{
    [Authorize]
    public class UploadModel : PageModel
    {
        private readonly IUploadManager _uploadManager;
        private readonly UserManager<User> _userManager;

        public UploadModel(IUploadManager uploadManager, UserManager<User> userManager)
        {
            _uploadManager = uploadManager;
            _userManager = userManager;
        }

        [BindProperty]
        [Display(Name = "Image to upload")]
        [Required]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var id = await _uploadManager.UploadFileAsync(Image, user);

            return RedirectToPage("./View/"+id);
        }
    }
}
