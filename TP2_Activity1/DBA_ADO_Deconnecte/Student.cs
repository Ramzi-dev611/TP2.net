using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_ADO_Deconnecte
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id : {Id} , Full name : {Name + ' ' + LastName}, age: {Age}, email: {Email} ";
        }
    }
}
