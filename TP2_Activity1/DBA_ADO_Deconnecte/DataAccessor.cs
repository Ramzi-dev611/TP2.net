using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_ADO_Deconnecte
{
    class DataAccessor
    {
        private readonly string connectionString;
        private readonly SqlConnection con;
        private readonly SqlDataAdapter dataAdapter;
        private readonly DataTable table;

        public DataAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TP2Activity1"].ConnectionString;

            con = new SqlConnection(connectionString);

            // data adapter configuration
            dataAdapter = new SqlDataAdapter("SELECT * FROM Student;", con);

            // Insert command config
            dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Student VALUES (@name, @lastname, @age, @email);", con);
            dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 30, "Name");
            dataAdapter.InsertCommand.Parameters.Add("@lastname", SqlDbType.NVarChar, 30, "LastName");
            dataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "Email");
            dataAdapter.InsertCommand.Parameters.Add("@age", SqlDbType.Int, 11, "Age");

            // Update command config
            dataAdapter.UpdateCommand = new SqlCommand("UPDATE Student SET Name = @name, LastName = @lastname, Email = @email, Age = @age WHERE ID = @id;", con);
            dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 30, "Name");
            dataAdapter.UpdateCommand.Parameters.Add("@lastname", SqlDbType.NVarChar, 30, "LastName");
            dataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "Email");
            dataAdapter.UpdateCommand.Parameters.Add("@age", SqlDbType.Int, 11, "Age");

            var param = dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int);
            param.SourceColumn = "Id";
            param.SourceVersion = DataRowVersion.Original;

            // Delete command config
            dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Student WHERE ID = @id;", con);
            dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 11, "ID");

            // datatable configuration
            table = new DataTable();
            DataColumn idCol = table.Columns["Id"];
            table.PrimaryKey = new[] { idCol };
            dataAdapter.Fill(table);
        }

        public List<Student> FindAll()
        {
            List<Student> students = new List<Student>();

            //reading all students
            foreach (DataRow row in table.Rows)
            {
                Student student = new Student();
                student.Id = Int32.Parse(row["Id"].ToString());
                student.Name = row["Name"].ToString();
                student.LastName= row["LastName"].ToString();
                student.Email = row["Email"].ToString();
                student.Age = Int32.Parse(row["Age"].ToString());
                students.Add(student);
            }

            return students;
        }

        public Student FindById(int id)
        {
            //finding the row
            DataRow row = table.Select("Id = " + id)[0];

            //configuring Student
            Student student = new Student();
            student.Id = Int32.Parse(row["Id"].ToString());
            student.Name = row["Name"].ToString();
            student.LastName = row["LastName"].ToString();
            student.Email = row["Email"].ToString();
            student.Age = Int32.Parse(row["Age"].ToString());

            return student;
        }

        public void Add(Student student)
        {
            int nomber = table.Rows.Count -1;
            int id = Int32.Parse(table.Rows[nomber]["Id"].ToString()) + 1;

            DataRow row = table.NewRow();
            row["Id"] =  id;
            row["Name"] = student.Name;
            row["LastName"] = student.LastName;
            row["Email"] = student.Email;
            row["Age"] = student.Age; 
            table.Rows.Add(row);
        }

        public void Update(Student student)
        {

            DataRow row = table.Select("ID = " + student.Id)[0];
            row["Name"] = student.Name;
            row["LastName"] = student.LastName;
            row["Email"] = student.Email;
            row["Age"] = student.Age;
        }

        public void Delete(int id)
        {
            DataRow row = table.Select("ID = " + id)[0];
            row.Delete();
        }

        public void CommitChanges()
        {
            dataAdapter.Update(table);
        }
    }
}
