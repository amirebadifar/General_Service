using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using DataLayer.Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    [Authorize]
    public class InsertProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IProductService _productService;

        public InsertProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("/admin/insert-product")]
        public async Task<IActionResult> ViewInsertProduct(bool? Ok)
        {
            ViewBag.Message = Ok;

            var InsertProducts = await _productService.getAllInsertProductAsync();

            return View("InsertProductView",InsertProducts);
        }

        [HttpPost("/admin/delete/insert-product/{Id}")]
        public bool DeleteInsertProduct(int Id)
        {
            return _productService.DeleteInsertProductAsync(Id).Result;
        }

        [HttpPost("/detail/insert-product/{Id}")]
        public IActionResult DetailInsertProduct(int Id)
        {
            var InsertProduct = _productService.GetInsertProductByIdAsync(Id).Result;
            var Product = _productService.GetProductAsync(InsertProduct.IdProduct).Result;

            var modelPage = new InsertProductViewModel()
            {
                InsertProduct = InsertProduct,
                Product = Product
            };

            return View("DetailInsertProductView",modelPage);
        }

    }
}
