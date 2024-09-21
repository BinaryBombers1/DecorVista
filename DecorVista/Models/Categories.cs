using System.ComponentModel.DataAnnotations;

namespace DecorVista.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set;}

        [Required(ErrorMessage = "Category Name is required.")]
        [Display(Name = "Category Name")]
        public string category_name { get; set;}
    }
}
