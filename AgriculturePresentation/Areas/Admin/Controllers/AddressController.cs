using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly AddressValidator _validations;
        public AddressController(IAddressService addressService, AddressValidator validations)
        {
            _addressService = addressService;
            _validations = validations;
        }

        public IActionResult Index()
        {
            var vause = _addressService.GetListAll();
            return View(vause);
        }
      
       
        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var query = _addressService.GetById(id);
            return View(query);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {

            ValidationResult result = _validations.Validate(address);
            if (result.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}
