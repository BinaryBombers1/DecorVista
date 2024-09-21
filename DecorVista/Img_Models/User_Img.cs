using System.ComponentModel.DataAnnotations;

namespace DecorVista.Img_Models
{
    public class User_Img
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "Home_Owner";

        [Required(ErrorMessage = "Contact number is required.")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Profile is required.")]
        [Display(Name = "Profile")]
        public IFormFile Profile_Img { get; set; }
    }
}
