using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.ViewComponents
{
    public class _DashboardTablePartial:ViewComponent
    {
        private readonly IContactService _contactService;

        public _DashboardTablePartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var query = _contactService.GetListAll();

            return View(query);
        }
    }
}
