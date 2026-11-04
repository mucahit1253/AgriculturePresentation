using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _annoumcementservice;

        public AnnouncementController(IAnnouncementService annoumcementservice)
        {
            _annoumcementservice = annoumcementservice;
        }

        public IActionResult Index()
        {
            var values = _annoumcementservice.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            _annoumcementservice.Insert(announcement);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var query = _annoumcementservice.GetById(id);
            _annoumcementservice.Delete(query);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var query = _annoumcementservice.GetById(id);

            return View(query);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            _annoumcementservice.Update(announcement);

            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _annoumcementservice.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _annoumcementservice.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }

    }
}
