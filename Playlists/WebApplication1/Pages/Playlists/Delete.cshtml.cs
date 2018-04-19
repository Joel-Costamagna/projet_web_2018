using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace Playlist.Pages.Playlists
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Models.PlaylistContext _context;

        public DeleteModel(WebApplication1.Models.PlaylistContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlaylistModel PlaylistModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlaylistModel = await _context.Playlists.SingleOrDefaultAsync(m => m.Id == id);

            if (PlaylistModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlaylistModel = await _context.Playlists.FindAsync(id);

            if (PlaylistModel != null)
            {
                _context.Playlists.Remove(PlaylistModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
