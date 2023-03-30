using System.Text;
using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        IAboutService _aboutService;

        public HomeController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("admin/")]
        public async Task<IActionResult> Index()
        {
            return View("IndexView");
        }

        #region SiteSetings

        #region About

        [Route("admin/about")]
        public async Task<IActionResult> About(bool? message)
        {
            var About = await _aboutService.GetAboutAsync();
            string AboutImagedirectoryPath = System.IO.Path.Combine("wwwroot", "Files", "AboutImage.png");
            if (!System.IO.File.Exists(AboutImagedirectoryPath))
            {
                ViewBag.existsimg = false;
            }
            else
            {
                ViewBag.existsimg = true;
            }

            if (!message == null)
            {
                ViewBag.message = message;
            }
            return View("AboutView", new AboutViewModel()
            {
                Title = About.Title,
                Description = About.Description,
            });
        }
        [HttpPost]
        [Route("admin/about")]
        public async Task<IActionResult> About(AboutViewModel about)
        {
            if (!ModelState.IsValid)
            {
                return View("AboutView", about);
            }

            try
            {
                if (about.Imege != null)
                {
                    var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "AboutImage.png");
                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");

                    if (!Directory.Exists(physicalPath2))
                    {
                        Directory.CreateDirectory(physicalPath2);
                    }
                    await using (FileStream stream = System.IO.File.Create(physicalPath))
                    {
                        await about.Imege.CopyToAsync(stream);
                    }
                }

                if (!await _aboutService.UpdateAbout(about))
                {
                    return RedirectToAction("About", "Home", new { message = false });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("About", "Home", new { message = false });
            }
            return RedirectToAction("About","Home",new { message= true});
        }

        #endregion

        #region Contact



        #endregion

        #endregion

        #region Product

        #region AddProduct

        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        #endregion

        #endregion
    }
}
