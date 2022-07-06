using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_LINQ
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public int Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ - Language Integrated Query

            string[] names = { "Indranil", "Harshit", "Amruta", "Asutosh" };


            //select * from tablename
            var query = from name in names
                        where name.ToUpper().StartsWith("a")
                        select name;

            //Lamda expression

            var nameQuery = names.Where(name => name.ToLower().StartsWith("a"));

            foreach(string name in nameQuery)
            {
                Console.WriteLine(name);
            }

            //List of persons

            List<Person> personList = new List<Person>
            {
                new Person{ Id=1,FirstName="Thomas",Age=18,Salary=9500},
                new Person{ Id=2,FirstName="Thomas",Age=18,  Salary=4500},
                new Person{ Id=3,FirstName="Jerry",Age=32, Salary=23000},
                new Person{ Id=4,FirstName="Vicky",Age=32, Salary=45000}

            };

            var personsWithAgeGreaterThan18 = personList.Where(p => p.Age > 18);

            var personNameEndingWithY = personList.Where(p => p.FirstName.ToLower().EndsWith("y"));

            int maxAge = personList.Max(p => p.Age);

            //People with max age
            var seniorPersons = personList.FindAll(p => p.Age == maxAge);

            int minAge = personList.Min(p => p.Age);

            //Peeople with minimum age
            var teenagers = personList.FindAll(p => p.Age == minAge);

            int personWithSalaryGreaterThanTenThousandCount = personList.FindAll(p => p.Salary > 10000).Count;

            int personSumSalary = personList.Sum(p => p.Salary);

            double averagarSalary = personList.Average(p => p.Salary);

            //First Example

        

            Person thomasByFirstOrDefault = personList.FirstOrDefault(x => x.FirstName == "Thomas123");

            Person thomas = personList.First(x => x.FirstName == "Thomas123");

            Console.ReadLine();

        }
    }
}
