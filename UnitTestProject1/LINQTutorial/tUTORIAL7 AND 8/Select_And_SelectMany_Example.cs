using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.LINQTutorial.tUTORIAL7_AND_8
{
    [TestClass]
    public class Select_And_SelectMany_Example
    {
        [TestMethod]
        public void Linq_Select_And_SelectMany_Tests()
        {
            //Select only the name propert of Student
           IEnumerable<string> Names= Student.GetAllStudents().Select(stud => stud.Name);
            foreach (var name in Names)
            {
                Console.WriteLine(name);
            }

        
            //Example 2: Project Name and Gender properties of students into an anonymous type.
            var NewStudents= Student.GetAllStudents().Select(stud => new { StudentName = stud.Name, StudentGender = stud.Gender });

            foreach (var stud in NewStudents)
            {
                Console.WriteLine($"{stud.StudentName} is {stud.StudentGender}");
            }

            //***************

            //Print All the subjects
            IEnumerable<string> subjects = Student.GetAllStudents().SelectMany(s => s.Subjects);


            //To select distinct subjects 
            //subjects = Student.GetAllStudents().SelectMany(s => s.Subjects).Distinct();


            foreach (string subject in subjects)
            {
                Console.WriteLine(subject);
            }
            subjects= (from studen in Student.GetAllStudents()
                      from subject in studen.Subjects
                        select subject).Distinct();
            //Select distinct

            subjects = from student in Student.GetAllStudents()
                       from subject in student.Subjects
                       select subject;

            foreach (string subject in subjects)
            {
                Console.WriteLine(subject);
            }

        }

        [TestMethod]
        public void SelectManyExample()
        {
            string[] arrayOfString = new string[]
            {
                "ABCDEFGH",
                "IJKLMOPQRST"
            };

           IEnumerable<char> result= arrayOfString.SelectMany(s => s);

            result = from s in arrayOfString
                     from c in s
                     select c;
            foreach (var charcter in result)
            {
                Console.WriteLine(charcter);
            }

            var newResult = Student.GetAllStudents().SelectMany(s => s.Subjects, (student, subject) =>
                                new {StudentName=student.Name,Subject=subject });

            newResult= from student in Student.GetAllStudents()
            from subject in student.Subjects
            select new { StudentName = student.Name, Subject = subject };



            foreach (var v in newResult)
            {
                Console.WriteLine(v.StudentName+"-"+v.Subject);
            }
        }

        public class Student
        {
            public string Name { get; set; }

            public string Gender { get; set; }

            public List<string> Subjects { get; set; }

            public static List<Student> GetAllStudents()
            {
                return new List<Student>
                {
                    new Student{Name="Ram",Gender="Male",Subjects=new List<string>{ "C#","Java" } },
                    new Student{Name="Sham",Gender="Male",Subjects=new List<string>{ "C#","PHY" } },
                   new Student{Name="Sita",Gender="FeMale",Subjects=new List<string>{ "C#","Fashion" } }
                };
            }
        }
               
    }
}
