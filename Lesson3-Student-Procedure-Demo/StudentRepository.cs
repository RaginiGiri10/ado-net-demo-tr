using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_Student_Procedure_Demo
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }
    class StudentRepository
    {
        string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=studentdb;integrated security=SSPI";

        public List<Student> GetAllStudentDetails()
        {
            List<Student> studentList = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //2. Prepare the sql command
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "spGetAllStudents";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    // open the sql connection.
                    connection.Open(); // it establishes a connection between this console app and the sql server database (studentdb)

                    //3. Execute the sql command.
                    SqlDataReader reader = command.ExecuteReader(); // Execute the commad.CommandText in the sql server studentdb.

                    //4. Get the result from the database.
                    while (reader.Read()) // Read each row in the student table
                    {
                        Student student = new Student();
                        student.ID = Convert.ToInt32(reader["Id"]);
                        student.Name = Convert.ToString(reader["Name"]);
                        student.Email = Convert.ToString(reader["Email"]);
                        student.Mobile = Convert.ToString(reader["Mobile"]);
                        studentList.Add(student);

                    }

                    
                }
                

            }

            return studentList;
        }

        public void AddStudent(Student student)
        {
            if (!CheckStudentWithNameExists(student.Name))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "spInsertStudentRecord";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        // open the sql connection.
                        connection.Open();

                        SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = student.Name };
                        SqlParameter paramEmail = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = student.Email };
                        SqlParameter paramMobile = new SqlParameter { ParameterName = "@mobile", SqlDbType = SqlDbType.VarChar, Value = student.Mobile };

                        //Adding parameter instance to sql command.
                        command.Parameters.Add(paramName);
                        command.Parameters.Add(paramEmail);
                        command.Parameters.Add(paramMobile);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Student record added successfully!!!");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Student with name {student.Name} already exists!!!");
            }

           
        }


        public bool CheckStudentWithNameExists(string name)
        {
            int countOfExistsingStudents = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "spGetStudentByName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    // open the sql connection.
                    connection.Open();

                    SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = name };
                   

                    //Adding parameter instance to sql command.
                    command.Parameters.Add(paramName);


                     countOfExistsingStudents=Convert.ToInt32(command.ExecuteScalar());
                    
                }


            }

            return countOfExistsingStudents > 0;
        }

    }
}
