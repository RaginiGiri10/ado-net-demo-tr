using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_Student_Procedure_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Inserting Record to database
                AddStudent();


                //Reading data from database
                PrintAllStudentDetails();

                
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static void PrintAllStudentDetails()
        {
            //Reading Student Records
            StudentRepository studentRepository = new StudentRepository();           
            List<Student> students = studentRepository.GetAllStudentDetails();
            foreach (Student student in students)
            {
                Console.WriteLine($"Id -{student.ID},Name -{student.Name},Email -{student.Email}, Mobile- {student.Mobile}");
            }
        }

        private static void AddStudent()
        {
            Student student = new Student { Name = "Veena", Email = "Veena@test.com", Mobile = "8795000000" };
            StudentRepository studentRepository = new StudentRepository();
            studentRepository.AddStudent(student);
        }
    }
}
