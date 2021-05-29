using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_EF_DataBaseFirst
{
    class StudentRepository
    {
        private Context context;

        public StudentRepository()
        {
            context = new Context();
        }

        public void Add (Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Delete (int id)
        {
            Student student = context.Students.SingleOrDefault(s => s.Id == id);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            Student updated = context.Students.SingleOrDefault(s => s.Id == student.Id);
            updated.Name = student.Name;
            updated.LastName = student.LastName;
            updated.email = student.email;
            updated.Age = student.Age;
            context.SaveChanges();
        }

        public Student FindById(int id)
        {
            return context.Students.SingleOrDefault(s => s.Id == id);
        }

        public List<Student> FindAll()
        {
            return context.Students.ToList();
        }
    }
}
