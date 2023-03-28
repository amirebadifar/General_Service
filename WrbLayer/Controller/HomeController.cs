using CoreLayer.Services;
using CoreLayer.ViewModel;
using DataLayer.Table;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IAboutService _aboutService;
        private IServiceService _serviceService;
        private IWorkSampleService _workSampleService;
        private IQuestionService _questionService;
        private IProductService _productService;

        public HomeController(IAboutService aboutService, IServiceService serviceService, IWorkSampleService workSampleService, IQuestionService questionService, IProductService productService)
        {
            _aboutService = aboutService;
            _serviceService = serviceService;
            _workSampleService = workSampleService;
            _questionService = questionService;
            _productService = productService;
        }

        [Route("/")]
        public async Task<IActionResult> Index(string Message)
        {
            var modelView = new IndexViewModel()
            {
                About = await _aboutService.GetAboutAsync(),
                Service = await _serviceService.GetAllServiceAsync(),
                WorkSample = await _workSampleService.GetAllWorkSamplesAsync(),
                Questions = await _questionService.GetAllQuestionAsync(),
                GalleryService = await _serviceService.GetGalleryServiceAsync(),
                Product = await _productService.GetNewProductAsync(),
            };
            
            ViewBag.Message = Message;

            return View("IndexView",modelView);
        }

        [Route("/product/{nameProduct?}")]
        public async Task<IActionResult> Product(string? nameProduct)
        {
            return View("ProductView",await _productService.GetAllProductAsync());
        }


        #region Detsils

        [Route("/detail/service/{idService}")]
        public IActionResult DetailService(int idService)
        {
            var service = _serviceService.GetServiceAsync(idService).Result;

            return View("DetailServiceView", service);

        }
        
        [Route("/detail/worksample/{idWorkSample}")]
        public IActionResult DetailWorkSample(int idWorkSample)
        {
            var WorkSample = _workSampleService.GetWorkSamplesAsync(idWorkSample).Result;

            return View("DetailWorkSampleView", WorkSample);

        }
        
        [Route("/detail/product/{idProduct}")]
        public IActionResult DetailProduct(int idProduct)
        {
            var Product = _productService.GetProductAsync(idProduct).Result;

            return View("DetailProductView", Product);

        }

        #endregion

        #region Inserts

        [HttpPost("/insert/service")]
        public async Task<IActionResult> InsertService(InsertServicePartialViewModel model)
        {
            await _serviceService.AddServiceAsync(model);
            
            return RedirectToAction("Index",new
            {
                Message = "OkInsert"
            });
        }
        
        [HttpPost("/insert/product")]
        public async Task<IActionResult> InsertProduct(InsertProductPartialViewmodel model)
        {
            await _productService.AddProductAsync(model);
            
            return RedirectToAction("Index",new
            {
                Message = "OkInsert"
            });
        }
        

        #endregion

    }
}
