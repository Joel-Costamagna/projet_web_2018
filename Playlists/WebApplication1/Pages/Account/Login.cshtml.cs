using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Playlist.Pages.Account {
    public class SigninModel : PageModel {
        private readonly SignInManager<IdentityUser> _signInManager;

        public SigninModel(
            SignInManager<IdentityUser> signInManager
        ) {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel LoginDetails { get; set; } = new LoginViewModel();

        public class LoginViewModel {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }


        public async Task OnGet(string returnUrl = null) {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            if (!String.IsNullOrEmpty(returnUrl) &&
                returnUrl.IndexOf("checkout", StringComparison.OrdinalIgnoreCase) >= 0) {
                ViewData["ReturnUrl"] = "/Basket/Index";
            }
        }

        public async Task<IActionResult> OnPost(string returnUrl = null) {
            if (!ModelState.IsValid) {
                return Page();
            }

            ViewData["ReturnUrl"] = returnUrl;

            var result = await _signInManager.PasswordSignInAsync(
                             LoginDetails.Email,
                             LoginDetails.Password, LoginDetails.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded) {
                return RedirectToPage(returnUrl ?? "/Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}