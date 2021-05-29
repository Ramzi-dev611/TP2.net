using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_EF_CodeFirst
{
    [Table("Students")]
    class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}
