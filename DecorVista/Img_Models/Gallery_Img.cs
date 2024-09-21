using System.ComponentModel.DataAnnotations;

namespace DecorVista.Img_Models
{
    public class Gallery_Img
    {
        [Key]
        public int Gallery_id { get; set; }

        [Required(ErrorMessage = "Room Type is required.")]
        [Display(Name = "Room Type")]
        public string Room_Type { get; set; }

        [Required(ErrorMessage = "Style is required.")]
        [Display(Name = "Style")]
        public string Style { get; set; }

        [Required(ErrorMessage = "Color Scheme is required.")]
        [Display(Name = "Color Scheme")]
        public string Color_Scheme { get; set; }

        [Required(ErrorMessage = "Gallery Image is required.")]
        [Display(Name = "Gallery Image")]
        public IFormFile Gallery_Photo { get; set; }
    }
}
