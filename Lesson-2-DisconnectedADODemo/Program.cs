using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_DisconnectedADODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable studentDataTable = null; 
            //1. Create an object of  sql connection with the database.
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=studentdb;integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from student";
                    command.Connection = connection;

                    using(SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        studentDataTable = new DataTable();
                        dataAdapter.Fill(studentDataTable);
                    }

                }
            }

            foreach(DataRow row in studentDataTable.Rows)
            {
                Console.WriteLine($"Name - {row["Name"]},Email - {row["Email"]}, Mobile -{row["Mobile"]}");
            }

            Console.ReadLine();
        }
    }
}
