using DecorVista.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorVista.Img_Models
{
    public class Product_Img
    {
        [Key]
        public int product_id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Required]
        public int category_id { get; set; }
        [ForeignKey("category_id")]
        public virtual Categories Categories { get; set; }

        [Required(ErrorMessage = "Brand Name is required.")]
        [Display(Name = "Brand Name")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Product Image is required.")]
        [Display(Name = "Product Image")]
        public IFormFile ProductPhoto { get; set; }
    }
}
