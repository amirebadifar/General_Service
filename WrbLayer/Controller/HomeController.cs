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
        public async Task<IActionResult> Index()
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

            return View("IndexView",modelView);
        }

        [Route("/product/{nameProduct?}")]
        public async Task<IActionResult> Product(string? nameProduct)
        {
            return View("ProductView",await _productService.GetAllProductAsync());
        }


        [Route("/detail/service/{idService}")]
        public IActionResult DetailService(int idService)
        {
            var service = _serviceService.GetServiceAsync(idService).Result;

            return View("DetailServiceView", service);

        }

    }
}
