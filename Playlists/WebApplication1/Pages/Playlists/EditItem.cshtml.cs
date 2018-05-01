using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Pages.Playlists
{
    public class EditItemModel : PageModel
    {
        private readonly PlaylistContext _context;

        public EditItemModel(PlaylistContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlaylistModel PlaylistModel { get; set; }
        [BindProperty]
        public Musique Musique  { get; set; }
        

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