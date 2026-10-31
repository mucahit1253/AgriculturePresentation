using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _ServiceViewComponentPartial:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServiceViewComponentPartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var queriy = _serviceService.GetListAll();
            return View(queriy);
        }
    }
}
