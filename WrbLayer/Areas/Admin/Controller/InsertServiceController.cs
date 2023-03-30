using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Areas.Admin.Controller
{
    public class InsertServiceController : Microsoft.AspNetCore.Mvc.Controller
    {
        

        public async Task<IActionResult> ViewInsertService()
        {
            return View();
        }
    }
}
