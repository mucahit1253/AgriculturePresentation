using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var vause = _contactService.GetListAll();
            return View(vause);
        }
        public IActionResult DeleteMessage(int id)
        {
            var query = _contactService.GetById(id);
            _contactService.Delete(query);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var query =_contactService.GetById(id);
            return View(query);
        }



    }
}
