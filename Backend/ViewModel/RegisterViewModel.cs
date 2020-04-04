using System.ComponentModel.DataAnnotations;
using Backend.Model;

namespace Backend.ViewModel
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        [RegularExpression((@"^[a-zA-Zа-яА-Я]+$"),ErrorMessage="Имя должно содержать только буквы")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия не может быть пустой")]
        [RegularExpression((@"^[a-zA-Zа-яА-Я]+$"),ErrorMessage="Фамилия должна содержать только буквы")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [MinLength((5),ErrorMessage="Пароль должен содержать минимум 5 символов")]
        [DataType(DataType.Password)]
        [Compare(("Password"),ErrorMessage="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}