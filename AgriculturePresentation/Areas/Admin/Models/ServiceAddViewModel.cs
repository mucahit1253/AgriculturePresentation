using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Areas.Admin.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş geçilmez")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama boş geçilmez")]
        public string Description { get; set; }
        [Display(Name = "Görsel")]
        [Required(ErrorMessage = "Görsel boş geçilmez")]
        public string Image { get; set; }
    }
}
