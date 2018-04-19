using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace Playlist.Pages.Playlists
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Models.PlaylistContext _context;

        public CreateModel(WebApplication1.Models.PlaylistContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlaylistModel PlaylistModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Playlists.Add(PlaylistModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}