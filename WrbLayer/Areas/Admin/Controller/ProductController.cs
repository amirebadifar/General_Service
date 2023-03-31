using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("/admin/product")]
        public async Task<IActionResult> Product(bool? message)
        {
            if (message != null)
            {
                ViewBag.Message = message;
            }
            return View("ProductView", await _productService.GetAllProductAsync());
        }

        #region AddProduct

        [Route("/admin/addproduct")]
        public async Task<IActionResult> AddProduct()
        {

            return View("AddProductView");
        }
        [Route("/admin/addproduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProductView", productViewModel);
            }
            var result = await _productService.AddProduct(productViewModel);
            if (result != -1)
            {
                try
                {
                    if (productViewModel.MainImage != null)
                    {
                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", result.ToString());
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", result.ToString(), result + ".png");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await productViewModel.MainImage.CopyToAsync(stream);
                        }
                    }
                    if (productViewModel.Images != null)
                    {

                        var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", result.ToString(), "Gallery");

                        if (!Directory.Exists(physicalPath2))
                        {
                            Directory.CreateDirectory(physicalPath2);
                        }

                        int number = 0;
                        foreach (var image in productViewModel.Images)
                        {
                            number++;
                            var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", result.ToString(), "Gallery", number + ".png");
                            await using (FileStream stream = System.IO.File.Create(physicalPath))
                            {
                                await image.CopyToAsync(stream);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    var physicalPath5 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", result.ToString());
                    if (Directory.Exists(physicalPath5))
                    {
                        Directory.Delete(physicalPath5, true);
                    }
                    await _productService.DeleteProduct(result);
                    return RedirectToAction("Product", "Product", new { message = false });
                }

                return RedirectToAction("Product", "Product", new { message = true });
            }


            return RedirectToAction("Product", "Product", new { message = false });
        }

        #endregion

        #region EditProduct

        [Route("/admin/editproduct/{id}")]
        public async Task<IActionResult> EditProduct(int id)
        {
            var model = await _productService.GetProductByID(id);
            model.IsNew = !model.IsNew;
            var Images = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString(), "Gallery");
            if (Directory.Exists(Images))
            {
                ViewBag.ExistsGallery = true;
            }
            else
            {
                ViewBag.ExistsGallery = false;
            }
            var MainImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString(), id + ".png");
            if (System.IO.File.Exists(MainImage))
            {
                ViewBag.ExistsImge = true;
            }
            else
            {
                ViewBag.ExistsImge = false;
            }
            return View("EditProductView", model);
        }

        [Route("/admin/editproduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProductView", productViewModel);
            }
            try
            {
                if (productViewModel.MainImage != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString());
                    var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString(), id + ".png");
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
                        await productViewModel.MainImage.CopyToAsync(stream);
                    }
                }
                if (productViewModel.Images != null)
                {

                    var physicalPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString(), "Gallery");
                    if (Directory.Exists(physicalPath2))
                    {
                        Directory.Delete(physicalPath2,true);
                    }
                    if (!Directory.Exists(physicalPath2))
                    {
                        Directory.CreateDirectory(physicalPath2);
                    }

                    int number = 0;
                    foreach (var image in productViewModel.Images)
                    {
                        number++;
                        var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString(), "Gallery", number + ".png");
                        await using (FileStream stream = System.IO.File.Create(physicalPath))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Product", "Product", new { message = false });
            }
            var result = await _productService.EditProduct(productViewModel);
            return RedirectToAction("Product", "Product", new { message = result });
        }

        #endregion

        #region DeleteProduct

        [HttpPost("admin/deleteproduct")]
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                var Pathimages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "FileProducts", id.ToString());
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
