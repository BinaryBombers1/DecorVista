using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorVista.Models
{
    public class Reviews
    {
        [Key]
        public int Review_Id { get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users Users { get; set; }

        [Required]
        public int designer_Id { get; set; } = 0;
        [ForeignKey("designer_Id")]
        public virtual InteriorDesigner InteriorDesigner { get; set; } 

        [Required(ErrorMessage = "Comments is required.")]
        [Display(Name = "Comments")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Reviews is required.")]
        [Display(Name = "Reviews")]
        public string Review { get; set; }
    }
}
