using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_EF_DataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repository = new StudentRepository();

            Student student = new Student();
            student.Name = "Ramzi";
            student.LastName = "Latrous";
            student.email = "ramzi.latrous@insat.u-carthage.tn";
            student.Age = 22;

            repository.Add(student);

            List<Student> students = repository.FindAll();

            foreach(Student looper in students)
            {
                Console.WriteLine(looper.Name);
            }

            Student s1 = students.FirstOrDefault();
            Student s2 = students[1];
            
            s1.Age = 50;
            repository.Update(s1);


            repository.Delete(s2.Id);

            Console.WriteLine(repository.FindById(s1.Id).Age);

            Console.ReadKey();



        }
    }
}
