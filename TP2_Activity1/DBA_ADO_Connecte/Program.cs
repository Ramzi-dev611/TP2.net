using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_ADO_Connecte
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessor dataAccessor = new DataAccessor();
            
            Student student = new Student();
            student.Name = "Mehdi";
            student.LastName = "Ben Chikha";
            student.Age = 22;
            student.Email = "mehdi.ben.chikha@insat.u-carthage.tn";

            dataAccessor.Add(student);

            List<Student> students = dataAccessor.FindAll();
            foreach (Student looper in students)
            {
                Console.WriteLine(looper);
            }

            Student s1 = students.FirstOrDefault();
            s1.Age = 23;
            s1.Name = "new Name";

            dataAccessor.Update(s1);

            students = dataAccessor.FindAll();
            foreach (Student looper in students)
            {
                Console.WriteLine(looper);
            }

            dataAccessor.DeleteById(students.FirstOrDefault().Id);

            students = dataAccessor.FindAll();
            foreach (Student looper in students)
            {
                Console.WriteLine(looper);
            }


            Console.ReadKey();

            


        }
    }
}
