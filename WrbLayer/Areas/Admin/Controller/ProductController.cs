using CoreLayer.Services;
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
        public async Task<IActionResult> Product()
        {
            return View("ProductView",await _productService.GetAllProductAsync());
        }

        #region AddProduct

        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        #endregion

        #region EditProduct



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
