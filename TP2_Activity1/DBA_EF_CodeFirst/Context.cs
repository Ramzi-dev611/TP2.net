using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_EF_CodeFirst
{
    class Context : DbContext
    {
        public Context () : base("name=TP2Activity1CF")
        {
        }
        
        public DbSet<Student> Students { get; set; }
    }
}
