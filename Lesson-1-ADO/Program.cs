using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Create an object of  sql connection with the database.
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=studentdb;integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                

                //2. Prepare the sql command
                using(SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from student";
                    command.Connection = connection;
                    // open the sql connection.
                    connection.Open(); // it establishes a connection between this console app and the sql server database (studentdb)

                    //3. Execute the sql command.
                    SqlDataReader reader = command.ExecuteReader(); // Execute the commad.CommandText in the sql server studentdb.

                    //4. Get the result from the database.
                    while (reader.Read()) // Read each row in the student table
                    {
                        Console.WriteLine($"Name - {reader["Name"]},Email - {reader["Email"]}, Mobile -{reader["Mobile"]}");

                    }
                }
                Console.WriteLine("Connection is established!!!");

            }
           
            Console.ReadLine();
        }
    }
}
