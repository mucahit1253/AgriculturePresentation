using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _AddressViewComponentPartial:ViewComponent
    {
        private readonly IAddressService _addressService;

        public _AddressViewComponentPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var query = _addressService.GetListAll();

            return View(query);
        }
    }
}
