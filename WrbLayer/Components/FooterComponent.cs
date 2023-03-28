using CoreLayer.Services;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Components
{
    public class FooterComponent:ViewComponent
    {
        private IContactService _contactService;

        public FooterComponent(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _contactService.GetContactAsync();

            return View("/Views/Shared/PartUserLayout/_FooterPartUserLayout.cshtml",model);
        }
    }
}
