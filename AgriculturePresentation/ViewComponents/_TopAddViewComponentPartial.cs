using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _TopAddViewComponentPartial:ViewComponent
    {

        private readonly IAddressService _addressService;

        public _TopAddViewComponentPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var query = _addressService.GetById(1);
            return View(query);
        }
    }
}
