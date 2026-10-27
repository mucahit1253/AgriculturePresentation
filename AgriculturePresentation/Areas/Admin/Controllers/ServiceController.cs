using AgriculturePresentation.Areas.Admin.Models;
using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel addViewModel)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = addViewModel.Title,
                    Description = addViewModel.Description,
                    Image = addViewModel.Image

                });
                return RedirectToAction("Index", "Service");
            }
            else
                return View(addViewModel);



        }
        public IActionResult DeleteService(int id)
        {
            var query = _serviceService.GetById(id);
            _serviceService.Delete(query);
            return RedirectToAction("Index", "Service");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var query = _serviceService.GetById(id);

            return View(query);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.Update(service);

            return RedirectToAction("Index", "Service");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }

}
