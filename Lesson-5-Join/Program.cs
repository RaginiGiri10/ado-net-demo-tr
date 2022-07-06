using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Join
{

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
           


            List<Standard> standardList = new List<Standard>() 
            {
                 new Standard(){ StandardID = 1, StandardName="Standard 1"},
                 new Standard(){ StandardID = 2, StandardName="Standard 2"},
                 new Standard(){ StandardID = 3, StandardName="Standard 3"}
                 
            };


            List<Student> studentList = new List<Student>() 
            {
             new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
             new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
             new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
             new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
             new Student() { StudentID = 5, StudentName = "Ron" ,StandardID =4 }
            };

            /*
            select stl.StudentName,sl.StandardName  from standardList sl 
            join studentList stl
            on sl.StandardID = stl.StandardID
            */

            //var student = new { FirstName = "James", LastName = "Thomas" };


           

            var studentListWithStandardName = studentList.Join(standardList,
                                                               student => student.StandardID, //outer key selector
                                                               standard => standard.StandardID, //inner key selector
                                                               (student, standard) => new
                                                               {
                                                                   Id = student.StudentID,
                                                                   Name =student.StudentName,
                                                                   Standard = standard.StandardName

                                                               });

            foreach(var data in studentListWithStandardName)
            {
                Console.WriteLine($"Id -{data.Id}, Name ={data.Name},Standard ={data.Standard}");
            }

            Console.ReadLine();
           
        }
    }
}
