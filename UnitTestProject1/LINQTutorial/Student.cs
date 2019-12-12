using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.LINQTutorial
{
   public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int TotalMarks { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> MyStudentList = new List<Student>();
            Student s1 = new Student { ID = 1, Name = "Gitesh", Gender = "Male",TotalMarks=800 };
            Student s2 = new Student { ID = 2, Name = "Ram", Gender = "Male",TotalMarks=650 };
            Student s3 = new Student { ID = 3, Name = "Mary", Gender = "Female",TotalMarks=700 };
            Student s4 = new Student { ID = 4, Name = "Gitesh", Gender = "Male", TotalMarks = 750 };

            MyStudentList.Add(s1);
            MyStudentList.Add(s2);
            MyStudentList.Add(s3);
            MyStudentList.Add(s4);
            return MyStudentList;

            TRFWRF rs = new TRFWRF();
            
         }
    }

    public class TRFWRF {  internal int a; }


}



