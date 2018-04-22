using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            PlaylistModel.proprietaire_name = User.Identity.Name;
            if (!ModelState.IsValid) {
                Console.WriteLine("model invalid" + ModelState);
                return Page();
            }

            _context.Playlists.Add(PlaylistModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}