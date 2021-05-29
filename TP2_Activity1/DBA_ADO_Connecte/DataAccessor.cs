using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_ADO_Connecte
{
    class DataAccessor
    {
        private string connectionString;
        private SqlConnection con;
        public DataAccessor()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TP2Activity1"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public List<Student> FindAll()
        {
            List<Student> Students = new List<Student>();
            try
            {
                // Open Connection to DB
                con.Open();

                // Command Confing
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Student;";

                // Reading data
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Int32.Parse(reader["ID"].ToString());
                    student.Name = reader["Name"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Age = Int32.Parse(reader["Age"].ToString());
                    Students.Add(student);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Students;
        }

        public Student FindById(int id)
        {
            Student student = new Student();
            try
            {
                // Connection to DB
                con.Open();

                // Command Config
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Student WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                // Reading data into student
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader != null) 
                { 
                    student.Id = Int32.Parse(reader["Id"].ToString());
                    student.Age = Int32.Parse(reader["Age"].ToString());
                    student.Name = reader["Name"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return student;
        }

        public void Add(Student student)
        {
            try
            {
                // Open Connection to DB
                con.Open();

                // Command Config
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Student " +
                                        "VALUES ( @name , @lastname , @age , @email );";

                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@lastname", student.LastName);
                cmd.Parameters.AddWithValue("@age", student.Age);
                cmd.Parameters.AddWithValue("@email", student.Email);

                // Adding student to DB
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                // Open Connection to DB
                con.Open();

                // Command Config
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Student WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                // Deleting student from DB
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Update(Student student)
        {
            try
            {
                // Open Connection to DB
                con.Open();

                // Command Config
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Student SET NAME = @name, LastName = @lastname , Email = @email , Age = @age " +
                                    "WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@lastname", student.LastName);
                cmd.Parameters.AddWithValue("@age", student.Age);
                cmd.Parameters.AddWithValue("@email", student.Email);

                // Updating Student 
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
