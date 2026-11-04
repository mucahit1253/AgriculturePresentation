using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi  giriniz")]
        public string Password { get; set; }
    }
}
