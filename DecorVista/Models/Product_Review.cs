using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DecorVista.Models
{
    public class Product_Review
    {
        [Key]
        public int Review_Id { get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users Users { get; set; }

        [Required]
        public int product_id { get; set; } = 0;
        [ForeignKey("product_id")]
        public virtual Products Products { get; set; }

        [Required(ErrorMessage = "Comments is required.")]
        [Display(Name = "Comments")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Reviews is required.")]
        [Display(Name = "Reviews")]
        public string Review { get; set; }
    }
}
