using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Areas.Admin.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail boş geçilemez.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifreyi tekrat giriniz.")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil,kontrol ediniz.")]
        public string PasswordConfirm { get; set; }
    }
}
