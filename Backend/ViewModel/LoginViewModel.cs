using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email не может быть пустым")]
        [EmailAddress(ErrorMessage = "Поле должно содержать Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [MinLength((5),ErrorMessage="Пароль должен содержать минимум 5 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}