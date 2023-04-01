using CoreLayer.Services;
using CoreLayer.ViewModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    [Area("Admin")]
    [Authorize]
    public class InsertServiceController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IServiceService _serviceService;

        public InsertServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("/admin/insert-service")]
        public async Task<IActionResult> ViewInsertService(bool? Ok)
        {
            ViewBag.Message = Ok;

            var InsertServices = await _serviceService.getAllInsertServiceAsync();

            return View("InsertServiceView", InsertServices);
        }

        [HttpPost("/admin/delete/insert-service/{Id}")]
        public bool DeleteInsertService(int Id)
        {
            return _serviceService.DeleteInsertServiceAsync(Id).Result;
        }

        [HttpPost("/detail/insert-service/{Id}")]
        public IActionResult DetailInsertService(int Id)
        {
            var InsertService = _serviceService.GetInsertServiceByIdAsync(Id).Result;
            var Service = _serviceService.GetServiceAsync(InsertService.ServiceId).Result;

            var modelPage = new InsertServiceViewModel()
            {
                InsertService = InsertService,
                Service = Service
            };

            return View("DetailInsertServiceView", modelPage);
        }
    }
}
