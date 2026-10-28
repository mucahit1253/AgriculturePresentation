using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly TeamValidator _validations;
        public TeamController(ITeamService teamService, TeamValidator validations)
        {
            _teamService = teamService;
            _validations = validations;
        }

        public IActionResult Index()
        {
            var vause= _teamService.GetListAll();
            return View(vause);
        }
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            ValidationResult result = _validations.Validate(team);
            if (result.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index", "Team");
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
        public IActionResult DeleteTeam (int id)
        {
            var query = _teamService.GetById(id);
            _teamService.Delete(query);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var query = _teamService.GetById(id);
            return View(query);
        }
        [HttpPost]
       public IActionResult UpdateTeam(Team team)
        {

            ValidationResult result = _validations.Validate(team);
            if (result.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index", "Team");
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
