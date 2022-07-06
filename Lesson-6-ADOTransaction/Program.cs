using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6_ADOTransaction
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=studentdb;integrated security=SSPI";

            Student student = new Student { Name = "Gerik", Email = "Gerik@test.com", Mobile = "890123456" };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlTransaction transaction = connection.BeginTransaction())
                {
                    using(SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "spInsertStudentRecord";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        command.Transaction = transaction;

                        SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = student.Name };
                        SqlParameter paramEmail = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Value = student.Email };
                        SqlParameter paramMobile = new SqlParameter { ParameterName = "@mobile", SqlDbType = SqlDbType.VarChar, Value = student.Mobile };

                        //Adding parameter instance to sql command.
                        command.Parameters.Add(paramName);
                        command.Parameters.Add(paramEmail);
                        command.Parameters.Add(paramMobile);

                        try
                        {
                            command.ExecuteNonQuery();                          
                            transaction.Commit();
                            //SOme logic here

                          
                            //
                            Console.WriteLine("Student record added successfully!!!");
                        }
                        catch(Exception ex)
                        {
                            transaction.Rollback();
                        }
                       
                    }

                }


            }

            Console.ReadLine();
        }
    }
}
