using System.ComponentModel.DataAnnotations;

namespace SV.Models.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
