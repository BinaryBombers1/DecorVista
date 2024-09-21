using System.ComponentModel.DataAnnotations;

namespace DecorVista.Img_Models
{
    public class DesinerProfile
    {
        [Key]
        public int designer_Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string contactphone { get; set; }

        [Required(ErrorMessage = "Experience is required.")]
        [Display(Name = "Years Of Experience")]
        public int yearsofexperience { get; set; }

        [Required(ErrorMessage = "Specialization is required.")]
        [Display(Name = "Specialization")]
        public string specialization { get; set; }

        [Required(ErrorMessage = "Portfolio is required.")]
        [Display(Name = "Portfolio")]
        public IFormFile portfolio_Img { get; set; }

        [Required(ErrorMessage = "Profile is required.")]
        [Display(Name = "Profile")]
        public IFormFile Profile_Img { get; set; }

        [Required]
        public string Role { get; set; } = "Interior_Designer";
    }
}
