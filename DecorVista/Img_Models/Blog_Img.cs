using System.ComponentModel.DataAnnotations;

namespace DecorVista.Img_Models
{
    public class Blog_Img
    {
        [Key]
        public int Blog_Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Paragraph { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
