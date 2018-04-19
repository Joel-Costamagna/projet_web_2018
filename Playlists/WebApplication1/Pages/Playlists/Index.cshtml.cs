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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.PlaylistContext _context;

        public IndexModel(WebApplication1.Models.PlaylistContext context)
        {
            _context = context;
        }

        public IList<PlaylistModel> PlaylistModel { get;set; }

        public async Task OnGetAsync()
        {
            PlaylistModel = await _context.Playlists.ToListAsync();
        }
    }
}
