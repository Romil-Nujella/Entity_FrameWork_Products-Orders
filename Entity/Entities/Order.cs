using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    [Table("Orders")]
    class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }

    }
}
