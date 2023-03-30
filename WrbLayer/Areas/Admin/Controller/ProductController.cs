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
        public async Task<IActionResult> Product(bool? Ok)
        {
            ViewBag.Message = Ok;
            return View("ProductView",await _productService.GetAllProductAsync());
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
            return RedirectToAction("Product", "Product", new
            {
                Ok = _productService.AddProduct(productViewModel)
            });
        }

        #endregion

        #region EditProduct

        [Route("/admin/editproduct")]
        public async Task<IActionResult> EditProduct()
        {
            return View("EditProductView");
        }

        #endregion

        #region DeleteProduct

        [HttpPost("admin/deleteproduct")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }

        #endregion
    }
}
