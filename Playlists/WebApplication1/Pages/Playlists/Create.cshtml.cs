using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Playlist.Controllers;
using Playlist.Models;

namespace Playlist.Pages.Playlists {
    public class CreateModel : PageModel {
        private readonly PlaylistContext _context;

        public CreateModel(PlaylistContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public PlaylistModel PlaylistModel { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            Console.WriteLine("onPost");
            PlaylistModel.ProprietaireName  = User.Identity.Name;
            PlaylistModel.Musiques = new List<Musique>();
            PlaylistModel.Tags = new List<Tags>();
           
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Playlists.Add(PlaylistModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}