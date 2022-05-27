using System.ComponentModel.DataAnnotations;

namespace ExoApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha Requerida")]
        public string Senha { get; set; }
    }
}
