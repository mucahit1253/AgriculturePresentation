using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IServiceService _serviceService;
        private readonly IContactService _contactService;
        private readonly IAnnouncementService _announcementService;

        public _DashboardOverviewPartial(ITeamService teamService, IServiceService serviceService, IContactService contactService, IAnnouncementService announcementService)
        {
            _teamService = teamService;
            _serviceService = serviceService;
            _contactService = contactService;
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = _teamService.GetListAll().Count();
            ViewBag.serviceCount = _serviceService.GetListAll().Count();
            ViewBag.messageCount = _contactService.GetListAll().Count();
            ViewBag.currentMountMessage = _contactService.GetThisMonthMessageCount();

            ViewBag.announcementTrue = _announcementService.GetListAll().Where(p => p.Status == true).Count();
            ViewBag.announcementFalse = _announcementService.GetListAll().Where(p => p.Status == false).Count();

            ViewBag.kargoIslemleri = _teamService.GetListAll().Where(p => p.Title == "Kargolama İşlemleri").Select(p => p.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetim = _teamService.GetListAll().Where(p => p.Title == "Bakliyat Yönetim").Select(p => p.PersonName).FirstOrDefault();
            ViewBag.sutUrtici = _teamService.GetListAll().Where(p => p.Title == "Süt Üretici").Select(p => p.PersonName).FirstOrDefault();
            ViewBag.gubreYonetici = _teamService.GetListAll().Where(p => p.Title == "Gübre Yönetici").Select(p => p.PersonName).FirstOrDefault();
            return View();
        }
    }
}
