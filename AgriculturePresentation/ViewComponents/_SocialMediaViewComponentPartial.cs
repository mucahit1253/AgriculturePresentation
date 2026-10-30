using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _SocialMediaViewComponentPartial:ViewComponent
    {
        private readonly ISocialMediaService _socialMedia;

        public _SocialMediaViewComponentPartial(ISocialMediaService socialMedia)
        {
            _socialMedia = socialMedia;
        }

        public IViewComponentResult Invoke()
        {
            var query = _socialMedia.GetListAll();
            return View(query);
        }
    }
}
