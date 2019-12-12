using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.LINQTutorial.tUTORIAL7_AND_8;
using System.Linq;
using System.Collections.Generic;
namespace UnitTestProject1.LINQTutorial.Ordering_Operators
{
    [TestClass]
    public class OrderingOperators
    {
        [TestMethod]
        public void Linq_Ordering_Operators_Example1()
        {
            Console.WriteLine("Students names before sorting");

            List <Student> students= Student.GetAllStudents();
            PrintStudentName(students);
            Console.WriteLine("Students names after sorting");
            IEnumerable<Student> studs=  Student.GetAllStudents().OrderBy(s => s.Name);

            PrintStudentName(studs);

            //Rewrite using SQL like Syntax
            Console.WriteLine("Students names after sorting with SQL Like query");

            var result=  from student in Student.GetAllStudents()
            orderby student.Name ascending
            select student;

            PrintStudentName(result);


            //
        }


        [TestMethod]
        public void Linq_Ordering_Operators_Example2()
        {
           IEnumerable<Student> result= Student.GetAllStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name);

            foreach (Student s in result)
            {
                Console.WriteLine(s.TotalMarks + "\t" + s.Name + "\t" + s.ID);

            }

            //
        }

        public void PrintStudentName(IEnumerable<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.Name);
            }
        }
    }

  
}
