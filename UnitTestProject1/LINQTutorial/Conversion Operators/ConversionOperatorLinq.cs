using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace UnitTestProject1.LINQTutorial.Conversion_Operators
{
    [TestClass]
    public class ConversionOperatorLinq
    {
        [TestMethod]
        public void LINQ_Conversion_Operators_ToList_Example()
        {
            int[] numbers = { 1,2,3,4,5};

            List<int> result = numbers.ToList();

            foreach (int num in result)
            {
                Console.WriteLine(num);
            }
        }


        [TestMethod]
        public void LINQ_Conversion_Operators_ToArray_Example()
        {
            // Convert List<string > to string array. The items in the array should be sorted in ascending order.
            List<string> countries = new List<string> { "US", "India", "Germany", "China", "Bhutan", "Nepal" };

            var result = (from country in countries
                          orderby country ascending
                          select country).ToArray();
            //result = countries.OrderBy(x=>x).ToArray();
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }


            int square;
            Calcu(1, out square);

        }


        public static void Calcu(int n, out int product)
        {
            product = n * n; 
        }

        [TestMethod]
        public void LINQ_Conversion_Operators_ToDictionary_Example()
        {
            List<Student> listStudents = new List<Student>
            {
                new Student { ID= 101, Name = "Tom", TotalMarks = 800 },
                new Student { ID= 102, Name = "Mary", TotalMarks = 900 },
                new Student { ID= 103, Name = "Pam", TotalMarks = 800 }
            };

            Dictionary<int, string> result = listStudents.ToDictionary(x => x.ID, x => x.Name);

            foreach (KeyValuePair<int, string> kvp in result)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
        }
    }

}
