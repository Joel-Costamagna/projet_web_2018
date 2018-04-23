using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Playlist.Pages.Account {
    public class LogoutModel : PageModel {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger                     _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger) {
            _signInManager = signInManager;
            _logger        = logger;
        }

        public async Task<IActionResult> OnPost() {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Account/SignedOut");
        }

        public async Task<IActionResult> OnGet() {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Account/SignedOut");
        }
    }
}