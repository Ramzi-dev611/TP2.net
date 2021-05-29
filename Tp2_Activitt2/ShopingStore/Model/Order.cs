using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Model
{
    [Table("Orders")]
    class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId {get; set;}

        [NotMapped]
        public ICollection<Product> OrderedProducts { get; set; }

        public override string ToString()
        {
            return $"Order id : {OrderId}";
        }

    }
}
