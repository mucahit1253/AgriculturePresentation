using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _GalleryViewComponentPartial:ViewComponent
    {
        private readonly IImageService _imageService;

        public _GalleryViewComponentPartial(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IViewComponentResult Invoke()
        {
           var query= _imageService.GetListAll();
            return View(query);
        }
    }
}
