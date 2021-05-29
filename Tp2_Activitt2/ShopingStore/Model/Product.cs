using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Model
{
    [Table("Products")]
    class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public Category ProductCategory { get; set; }

        [Required]
        public Order ProductOrder { get; set; }

        public override string ToString()
        {
            return $"Product id : {ProductId} \n" 
                + $"Category : {ProductCategory.CategoryId} \n"
                + $"Order : {ProductOrder.OrderId}"
                ;
        }

    }
}
