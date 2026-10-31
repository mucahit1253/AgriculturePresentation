using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _AnnouncementViewComponentPartial : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _AnnouncementViewComponentPartial(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var query = _announcementService.GetDefaults(a=>a.Status==true);
            return View(query);
        }
    }
}
