using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_ADO_Deconnecte
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessor dataAccessor = new DataAccessor();
            
            Student student = new Student();

            student.Name = "Ramzi";
            student.LastName = "Latrous";
            student.Email = "ramzi.latrous@insat.u-carthage.tn";
            student.Age = 22;

            dataAccessor.Add(student);
            
            List <Student> students = dataAccessor.FindAll();
            foreach (Student looper in students)
            {
                Console.WriteLine(looper);
            }

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            Student student1 = students[0];
            Student student2 = students[1];

            student1.Name = "New Name";

            dataAccessor.Update(student1);

            dataAccessor.Delete(student2.Id);
            

            dataAccessor.CommitChanges();

            students = dataAccessor.FindAll();
            foreach (Student looper in students)
            {
                Console.WriteLine(looper);
            }

            Console.ReadKey();


        }
    }
}
