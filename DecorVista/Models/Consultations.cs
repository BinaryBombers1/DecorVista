using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorVista.Models
{
    public class Consultations
    {
        [Key]
        public int consultations_id { get; set; }

        [Required(ErrorMessage = "You must need to logged In")]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users Users { get; set; }

        [Required]
        public int designer_Id { get; set; }
        [ForeignKey("designer_Id")]
        public virtual InteriorDesigner InteriorDesigner { get; set; }

        [Required(ErrorMessage = "Scheduled Date is required.")]
        [Display(Name = "Scheduled Date")]
        [DataType(DataType.Date)]
        public DateTime Scheduled_Date { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public string status { get; set; }

        [Required(ErrorMessage = "Note is required.")]
        [Display(Name = "Note")]
        public string note { get; set;}

        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
