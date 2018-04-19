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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Models.PlaylistContext _context;

        public DetailsModel(WebApplication1.Models.PlaylistContext context)
        {
            _context = context;
        }

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
    }
}
