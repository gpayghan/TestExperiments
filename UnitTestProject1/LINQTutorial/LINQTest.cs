using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
namespace UnitTestProject1.LINQTutorial
{
    [TestClass]
    public class LINQTest
    {
        [TestMethod]
        public void Get_Male_Students_With_Lamda_Expression_And_General_SQL_Like_Syntax()
        {
          var MaleStudents=  Student.GetAllStudents().Where(x => x.Gender == "Male");
            MaleStudents = from student in Student.GetAllStudents()
                           where student.Gender=="Male"
                           select student;

            var t = from x in Student.GetAllStudents()
                    where x.ID == 1
                    select x;


            PrintStudents(MaleStudents);
        }

        public  void PrintStudents(IEnumerable<Student> studentList)
        {
            foreach (Student stud in studentList)
            {
                ReflectionClasses.ReflectionUtil.PrintEachPublicPropertyAndItsValue(stud);
            }
        }
    }
}
