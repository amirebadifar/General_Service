using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("admin")]
    public class WorkSampleController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IWorkSampleService _workSampleService;
        public WorkSampleController(IWorkSampleService workSampleService)
        {
            _workSampleService = workSampleService;
        }
        
        [Route("/admin/worksample")]
        public async Task<IActionResult> Index(bool? message)
        {
            if (message != null)
            {
                ViewBag.Message = message;
            }
            return View("WorkSampleView",await _workSampleService.GetAllWorkSamplesAsync());
        }

        #region AddWorkSample

        [Route("/admin/addworksample")]
        public async Task<IActionResult> AddWorkSample()
        {

            return View("AddWorkSampleView");
        }
        [Route("/admin/addworksample")]
        [HttpPost]
        public async Task<IActionResult> AddWorkSample(WorkSampleViewModel workSampleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddWorkSampleView", workSampleViewModel);
            }
            var result = await _workSampleService.AddWorkSample(workSampleViewModel);
            if (result != -1)
            {
                try
                {
                    if (workSampleViewModel.MainImage != null)
                    {
                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", result.ToString());
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", result.ToString(), result + ".png");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await workSampleViewModel.MainImage.CopyToAsync(stream);
                        }
                    }
                    if (workSampleViewModel.Images != null)
                    {

                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", result.ToString(), "Gallery");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }

                        int number = 0;
                        foreach (var image in workSampleViewModel.Images)
                        {
                            number++;
                            var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", result.ToString(), "Gallery", number + ".png");
                            await using (FileStream stream = System.IO.File.Create(physicalPath))
                            {
                                await image.CopyToAsync(stream);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var physicalPath5 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", result.ToString());
                    if (Directory.Exists(physicalPath5))
                    {
                        Directory.Delete(physicalPath5, true);
                    }
                    await _workSampleService.DeleteWorkSample(result);
                    return RedirectToAction("Index", "WorkSample", new { message = false });
                }

                return RedirectToAction("Index", "WorkSample", new { message = true });
            }


            return RedirectToAction("Index", "WorkSample", new { message = false });
        }

        #endregion

        #region EditWorkSample

        [Route("/admin/editworksample/{id}")]
        public async Task<IActionResult> EditWorkSample(int id)
        {
            var model = await _workSampleService.GetWorkSamplesByID(id);
            var Images = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString(), "Gallery");
            if (Directory.Exists(Images))
            {
                ViewBag.ExistsGallery = true;
            }
            else
            {
                ViewBag.ExistsGallery = false;
            }
            var MainImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString(), id + ".png");
            if (System.IO.File.Exists(MainImage))
            {
                ViewBag.ExistsImge = true;
            }
            else
            {
                ViewBag.ExistsImge = false;
            }
            return View("EditWorkSampleView", model);
        }

        [Route("/admin/editworksample/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditWorkSample(int id, WorkSampleViewModel workSampleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditWorkSampleView", workSampleViewModel);
            }
            try
            {
                if (workSampleViewModel.MainImage != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString());
                    var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString(), id + ".png");
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
                        await workSampleViewModel.MainImage.CopyToAsync(stream);
                    }
                }
                if (workSampleViewModel.Images != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString(), "Gallery");
                    if (Directory.Exists(physicalPath2))
                    {
                        Directory.Delete(physicalPath2, true);
                    }
                    if (!Directory.Exists(physicalPath2))
                    {
                        Directory.CreateDirectory(physicalPath2);
                    }

                    int number = 0;
                    foreach (var image in workSampleViewModel.Images)
                    {
                        number++;
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString(), "Gallery", number + ".png");
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "WorkSample", new { message = false });
            }
            var result = await _workSampleService.EditWorkSample(workSampleViewModel);
            return RedirectToAction("Index", "WorkSample", new { message = result });
        }

        #endregion

        #region DeleteWorkSample

        [HttpPost("admin/deleteworksample")]
        public async Task<bool> DeleteWorkSample(int id)
        {
            try
            {
                await _workSampleService.DeleteWorkSample(id);
                var Pathimages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileWorkSamples", id.ToString());
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
