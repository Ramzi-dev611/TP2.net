using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_EF_ModelFirst
{
    class StudentRepository
    {
        private Context context;

        public StudentRepository()
        {
            context = new Context();
        }

        public void Add(Student student)
        {
            context.StudentSet.Add(student);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = context.StudentSet.SingleOrDefault(s => s.Id == id);
            context.StudentSet.Remove(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            Student updated = context.StudentSet.SingleOrDefault(s => s.Id == student.Id);
            updated.Name = student.Name;
            updated.LastName = student.LastName;
            updated.Email = student.Email;
            updated.Age = student.Age;
            context.SaveChanges();
        }

        public Student FindById(int id)
        {
            return context.StudentSet.SingleOrDefault(s => s.Id == id);
        }

        public List<Student> FindAll()
        {
            return context.StudentSet.ToList();
        }
    }
}
