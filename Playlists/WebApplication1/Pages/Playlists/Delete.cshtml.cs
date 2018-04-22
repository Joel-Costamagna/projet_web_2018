using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Pages.Playlists
{
    public class DeleteModel : PageModel
    {
        private readonly PlaylistContext _context;

        public DeleteModel(PlaylistContext context)
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
