using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using CoreLayer.ViewModel;

namespace WebLayer.Controller
{
    public class AuthorizationController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("/admin/login")]
        public async Task<IActionResult> Login()
        {
            var modelPage = new LoginViewModel()
            {
                BackPage = HttpContext.Request.Query["ReturnUrl"]!
            };

            return View("LoginView");
        }
        
        [HttpPost("/admin/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View("LoginView",model);

            var Principal = new ClaimsPrincipal();
            var Properties = new AuthenticationProperties
            {
                IsPersistent = false
            };

            await HttpContext.SignInAsync(Principal, Properties);

            return Redirect(model.BackPage);
        }

        [Route("/admin/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
