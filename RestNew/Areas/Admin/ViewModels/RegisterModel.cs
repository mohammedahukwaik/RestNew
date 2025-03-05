using System.ComponentModel.DataAnnotations;

namespace RestNew.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }    
    }
}
