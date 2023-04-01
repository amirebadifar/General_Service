using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("admin")]
    public class ServiceController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("/admin/service")]
        public async Task<IActionResult> Index(bool? message)
        {
            if (message != null)
            {
                ViewBag.Message = message;
            }
            return View("ServiceView", await _serviceService.GetAllServiceAsync());
        }

        #region AddService

        [Route("/admin/addservice")]
        public async Task<IActionResult> AddService()
        {

            return View("AddServiceView");
        }
        [Route("/admin/addservice")]
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceViewModel ServiceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddServiceView", ServiceViewModel);
            }
            var result = await _serviceService.AddService(ServiceViewModel);
            if (result != -1)
            {
                try
                {
                    if (ServiceViewModel.MainImage != null)
                    {
                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", result.ToString());
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", result.ToString(), result + ".png");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await ServiceViewModel.MainImage.CopyToAsync(stream);
                        }
                    }
                    if (ServiceViewModel.Images != null)
                    {

                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", result.ToString(), "Gallery");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }

                        int number = 0;
                        foreach (var image in ServiceViewModel.Images)
                        {
                            number++;
                            var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", result.ToString(), "Gallery", number + ".png");
                            await using (FileStream stream = System.IO.File.Create(physicalPath))
                            {
                                await image.CopyToAsync(stream);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var physicalPath5 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", result.ToString());
                    if (Directory.Exists(physicalPath5))
                    {
                        Directory.Delete(physicalPath5, true);
                    }
                    await _serviceService.DeleteService(result);
                    return RedirectToAction("Index", "Service", new { message = false });
                }

                return RedirectToAction("Index", "Service", new { message = true });
            }


            return RedirectToAction("Index", "Service", new { message = false });
        }

        #endregion

        #region EditService

        [Route("/admin/editservice/{id}")]
        public async Task<IActionResult> EditService(int id)
        {
            var model = await _serviceService.GetServiceByID(id);
            var Images = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString(), "Gallery");
            if (Directory.Exists(Images))
            {
                ViewBag.ExistsGalleryS = true;
            }
            else
            {
                ViewBag.ExistsGalleryS = false;
            }
            var MainImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString(), id + ".png");
            if (System.IO.File.Exists(MainImage))
            {
                ViewBag.ExistsImgeS = true;
            }
            else
            {
                ViewBag.ExistsImgeS = false;
            }
            return View("EditServiceView", model);
        }

        [Route("/admin/editservice/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditService(int id, ServiceViewModel ServiceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditServiceView", ServiceViewModel);
            }
            try
            {
                if (ServiceViewModel.MainImage != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString());
                    var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString(), id + ".png");
                    //if (System.IO.File.Exists(physicalPath))
                    //{
                    //    System.IO.File.Delete(physicalPath);
                    //}
                    if (!Directory.Exists(physicalPath2))
                    {
                        Directory.CreateDirectory(physicalPath2);
                    }
                    await using (FileStream stream = System.IO.File.Create(physicalPath))
                    {
                        await ServiceViewModel.MainImage.CopyToAsync(stream);
                    }
                }
                if (ServiceViewModel.Images != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString(), "Gallery");
                    if (Directory.Exists(physicalPath2))
                    {
                        Directory.Delete(physicalPath2, true);
                    }
                    if (!Directory.Exists(physicalPath2))
                    {
                        Directory.CreateDirectory(physicalPath2);
                    }

                    int number = 0;
                    foreach (var image in ServiceViewModel.Images)
                    {
                        number++;
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString(), "Gallery", number + ".png");
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Service", new { message = false });
            }
            var result = await _serviceService.EditService(ServiceViewModel);
            return RedirectToAction("Index", "Service", new { message = result });
        }

        #endregion

        #region DeleteService

        [HttpPost("admin/deleteservice")]
        public async Task<bool> DeleteService(int id)
        {
            try
            {
                await _serviceService.DeleteService(id);
                var Pathimages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileService", id.ToString());
                if (Directory.Exists(Pathimages))
                {
                    Directory.Delete(Pathimages, true);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}
