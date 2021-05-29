using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Model
{
    [Table("Categories")]
    class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [NotMapped]
        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return $"Order id : {CategoryId}";
        }
    }
}
