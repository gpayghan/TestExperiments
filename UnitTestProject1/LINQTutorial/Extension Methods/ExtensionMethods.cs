using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
namespace UnitTestProject1.LINQTutorial.Extension_Methods
{
    [TestClass]
    public class ExtensionMethods
    { 

        //According to MSDN Extension methods enable you to add methods to existing types without creating a new derived type
        //recompiling or otherwise modifying the original types.

        //Extension methods are some kind of static methods but they were called as if they were instance methods on
        //extended types.

        //In things example we will write the extension methods on string to change first letter to case
        [TestMethod]
        public void Extension_Methods_Example()
        {
            string str = "gITESH";
            Console.WriteLine(str.ChangeFirstLetterCase());
            Console.WriteLine(StringHelper.ChangeFirstLetterCase(str));
            //So we can use wrapper class syntx(Used in above line) on other methods as well
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> EvenNumbers = numbers.Where(x => x % 2 == 0);
            foreach (var number in EvenNumbers)
            {
                Console.WriteLine(number);
            }
            //Using Wrapper class style. Note that the first arguement is soruce on which we wish to do operation

            EvenNumbers = Enumerable.Where(numbers,x=>x%2==0);

            foreach (var number in EvenNumbers)
            {
                Console.WriteLine(number);
            }





        }

    }
}
