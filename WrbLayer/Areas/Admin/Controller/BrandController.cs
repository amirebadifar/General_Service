using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    public class BrandController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IOtherService _otherService;

        public BrandController(IOtherService otherService)
        {
            _otherService = otherService;
        }

        [Route("/admin/brands")]
        public async Task<IActionResult> ViewBrands(bool? Ok)
        {
            ViewBag.Message = Ok;

            return View("BrandsView");
        }

        [HttpGet("/admin/delete/brand/{FileName}")]
        public IActionResult DeleteBrand(string FileName)
        {
            bool OkDelete;
            try
            {
                var imagePath = Path.Combine("wwwroot", "Files", "FileBrands", FileName);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
                else
                    OkDelete = false;

                OkDelete = true;
            }
            catch
            {
                OkDelete = false;
            }

            return RedirectToAction("ViewBrands", "Brand", new
            {
                Ok = OkDelete
            });
        }

        [HttpPost("/admin/add/brand")]
        public async Task<IActionResult> AddBrand(AddBrandViewModel model)
        {
            bool OkAdd;

            try
            {
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileBrands", await _otherService.GetGuid() + ".png");
                var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileBrands");

                if (!Directory.Exists(physicalPath2))
                {
                    Directory.CreateDirectory(physicalPath2);
                }

                await using (FileStream stream = System.IO.File.Create(physicalPath))
                {
                    await model.BrandFile.CopyToAsync(stream);
                }

                OkAdd = true;
            }
            catch
            {
                OkAdd = false;
            }

            return RedirectToAction("ViewBrands", "Brand", new
            {
                Ok = OkAdd
            });
        }

    }
}
