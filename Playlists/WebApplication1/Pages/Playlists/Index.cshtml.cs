using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Pages.Playlists {
    public class IndexModel : PageModel {
        private readonly PlaylistContext _context;

        public IndexModel(PlaylistContext context) {
            _context = context;
        }

        public IList<PlaylistModel> PlaylistModel { get; set; }

        public async Task OnGetAsync() {
            PlaylistModel = await _context.Playlists.ToListAsync();
        }
    }
}