using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _TeamViewComponentPartial:ViewComponent
    {
        private readonly ITeamService _team;

        public _TeamViewComponentPartial(ITeamService team)
        {
            _team = team;
        }

        public IViewComponentResult Invoke()
        {
            
            var query = _team.GetListAll();
            return View(query);
        }
    }
}
