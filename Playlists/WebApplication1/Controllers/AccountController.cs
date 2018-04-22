using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playlist.Models;

namespace Playlist.Controllers {
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller {
        private ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger) : base() {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser user, string returnUrl = null) {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";
            if (user == null) {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            ApplicationUser lookupUser;
            using (var context = new PlaylistContext()) {
                lookupUser = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            }

            if (lookupUser?.Password != user.Password) {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, lookupUser?.UserName));

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            if (returnUrl == null) returnUrl = TempData["returnUrl"]?.ToString();

            if (returnUrl != null) return Redirect(returnUrl);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Account/SignedOut");
        }
    }
}