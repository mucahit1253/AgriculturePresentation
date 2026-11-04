using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdminEntity= EntityLayer.Concrete.Admin;
namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var query=_adminService.GetListAll();
            return View(query);
        }
        public IActionResult AddAdmin()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(AdminEntity admin)
        {
            _adminService.Insert(admin);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAdmin(int id)
        {
            var query = _adminService.GetById(id);
            _adminService.Delete(query);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var query = _adminService.GetById(id);

            return View(query);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(AdminEntity admin)
        {
            _adminService.Update(admin);

            return RedirectToAction("Index");
        }
    }
}
