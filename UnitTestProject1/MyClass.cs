using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNameSpace
{
   public class Class1
    {
       public Class1()
        {
            Console.WriteLine("Class one Constructor");

        }
        public Class1(string s1)
        {
            Console.WriteLine($"Message Came from: {s1}");

        }

        public Class1(string s1,string s2)
        {
            Console.WriteLine($"Constructor with two parameters");

        }
        public Class1(MyDevClass obj1, string s2)
        {
            Console.WriteLine($"Constructor with object parameters");

        }

        public void Print()
        {
            Console.WriteLine("Print One Method");
        }
    }

    public class Class2
    {
        public Class2()
        {
            Console.WriteLine("Class 2 Constructor");

        }
        public void Print()
        {
            Console.WriteLine("Print 2 Method");
        }
    }

    public class MyDevClass
    {
        public int MyProperty { get; set; }
    }
}
