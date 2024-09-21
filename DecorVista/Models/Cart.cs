using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecorVista.Models
{
    public class Cart
    {
        [Key]
        public int Cartid { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Users Users { get; set; }

               public int Product_id { get; set; }
        [ForeignKey("Product_id")]
        public virtual Products Products { get; set; }
    }
}
