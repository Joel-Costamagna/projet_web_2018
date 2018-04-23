using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Playlist.Models;

namespace Playlist.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<IdentityUser>   _userManager;
        private readonly RoleManager<IdentityRole>   _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger                     _logger;
        private readonly PlaylistContext             _context;
        private readonly IConfiguration              _configuration;

        public AccountController(
            UserManager<IdentityUser>   userManager,
            RoleManager<IdentityRole>   roleManager,
            SignInManager<IdentityUser> signInManager,
            ILoggerFactory              loggerFactory,
            PlaylistContext             context,
            IConfiguration              configuration
        ) {
            _userManager   = userManager;
            _roleManager   = roleManager;
            _signInManager = signInManager;
            _logger        = loggerFactory.CreateLogger<AccountController>();
            _context       = context;
            _configuration = configuration;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }
    }
}