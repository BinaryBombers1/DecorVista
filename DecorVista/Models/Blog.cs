using System.ComponentModel.DataAnnotations;

namespace DecorVista.Models
{
    public class Blog
    {
        [Key]
        public int Blog_Id { get; set; }

        [Required] 
        public string Heading { get; set; }

        [Required]
        public string Paragraph { get; set; }

        [Required]
        public string Img { get; set; }
    }
}
