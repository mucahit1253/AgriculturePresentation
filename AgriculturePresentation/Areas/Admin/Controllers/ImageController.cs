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
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly ImageValidator _imageValidator;

        public ImageController(IImageService imageService, ImageValidator imageValidator)
        {
            _imageService = imageService;
            _imageValidator = imageValidator;
        }

        public IActionResult Index()
        {
            var vause = _imageService.GetListAll();
            return View(vause);
        }
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            ValidationResult result = _imageValidator.Validate(image);
            if (result.IsValid)
            {
                _imageService.Insert(image);
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
        public IActionResult DeleteImage(int id)
        {
            var query = _imageService.GetById(id);
            _imageService.Delete(query);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var query = _imageService.GetById(id);
            return View(query);
        }
        [HttpPost]
        public IActionResult UpdateImage(Image image)
        {

            ValidationResult result = _imageValidator.Validate(image);
            if (result.IsValid)
            {
                _imageService.Update(image);
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
