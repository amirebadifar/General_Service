using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using CoreLayer.Services;
using CoreLayer.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebLayer.Controller
{
    public class AuthorizationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IAdminService _adminService;

        public AuthorizationController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("/admin/login")]
        public async Task<IActionResult> Login()
        {
            string backPage = HttpContext.Request.Query["ReturnUrl"]!;

            var modelPage = new LoginViewModel()
            {
                BackPage = (backPage) == null ? "" : backPage
            };

            return View("LoginView");
        }

        [HttpPost("/admin/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View("LoginView", model);

            if (await _adminService.IsLogin(model.NumberPhone, model.Password))
            {

                var Claims = new List<Claim> { };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principal = new ClaimsPrincipal(Identity);
                var Properties = new AuthenticationProperties
                {
                    IsPersistent = model.IsLogin
                };

                await HttpContext.SignInAsync(Principal, Properties);

                return Redirect(model.BackPage ?? "/admin");
            }

            ModelState.AddModelError("NumberPhone", "کاربری با مشخصات وارد شده پیدا نشد");
            return View("LoginView", model);
        }

        [Route("/admin/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
