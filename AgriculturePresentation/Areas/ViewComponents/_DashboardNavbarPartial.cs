using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.ViewComponents
{
    
    public class _DashboardNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
