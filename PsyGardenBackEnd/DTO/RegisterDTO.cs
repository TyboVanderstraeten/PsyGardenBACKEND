using System.ComponentModel.DataAnnotations;

namespace PsyGardenBackEnd.DTO
{
    public class RegisterDTO : LoginDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name contains 50 chars. max")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name contains 50 chars. max")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Compare("Email", ErrorMessage = "Email and email-confirmation do not match")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirmation { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = ("Password and password-confirmation do not match"))]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string PasswordConfirmation { get; set; }
    }
}
