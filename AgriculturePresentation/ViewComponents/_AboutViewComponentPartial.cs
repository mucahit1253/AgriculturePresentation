using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _AboutViewComponentPartial:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutViewComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var query = _aboutService.GetListAll();
            return View(query);
        }
    }
}
