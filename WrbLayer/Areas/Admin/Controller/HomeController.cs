using System.Text;
using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        IAboutService _aboutService;
        IContactService _contactService;
        private IServiceService _serviceService;
        private IProductService _productService;
        private IWorkSampleService _workSampleService;

        public HomeController(IAboutService aboutService, IContactService contactService, IServiceService serviceService, IProductService productService, IWorkSampleService workSampleService)
        {
            _aboutService = aboutService;
            _contactService = contactService;
            _serviceService = serviceService;
            _productService = productService;
            _workSampleService = workSampleService;
        }

        [Route("/admin/")]
        public async Task<IActionResult> Index()
        {
            var pageModel = new IndexViewModel()
            {
                CountInsertProduct = await _productService.CountInsertProductAsync(),
                CountInsertService = await _serviceService.CountInsertServiceAsync(),
                CountProduct = await _productService.CountProductAsync(),
                CountService = await _serviceService.CountServiceAsync(),
                CountWorkSample = await _workSampleService.CountWorkSampleAsync()
            };

            return View("IndexView",pageModel);
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

        [Route("/admin/contact")]
        public async Task<IActionResult> Contact(bool? message)
        {
            ViewBag.message = message;
            
            var q = await _contactService.GetContactAsync();
            return View("ContactView", new ContactViewModel()
            {
                Addres = q.Addres,
                Addres_X = q.Addres_X,
                Addres_Y = q.Addres_Y,
                Numberphone = q.Numberphone,
                ResponseTime = q.ResponseTime,
            });
        }
        [HttpPost("/admin/contact")]
        public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactView",contactViewModel);
            }

            if (!await _contactService.UpdateContact(contactViewModel))
            {
                    return RedirectToAction("About", "Home", new { message = false });
            }
            return RedirectToAction("About", "Home", new { message = true });
        }

        #endregion

        #endregion
        
    }
}
