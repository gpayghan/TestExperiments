using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.CSharpTutorial.ToString_Example
{
    [TestClass]
    public class ToStringExample
    {
        [TestMethod]
        public void Print_Default_Implementation_Of_To_String()
        {
            Console.WriteLine("Let's see what default implementaion of ToString prints\n It prints the Fully Qualified Name");
            C1 cust1 = new C1() { FirstName = "Ram" };

            Console.WriteLine(cust1.ToString());

            Console.WriteLine("If we override ToString then it's going to befave as per our implementation\n Here First Name will be printed");
            C2 cust2 = new C2 { FirstName = "Ram" };
            Console.WriteLine(cust2.ToString());

            Console.WriteLine("Lets find out the difference between Convert.ToString() and ToString");

            C1 cust3 = new C1();
            Console.WriteLine(cust3.ToString());
            Console.WriteLine(Convert.ToString(cust3));

            Console.WriteLine("One Major Difference would be if we use Convert.ToString() then we will not get the null exception" +
                "So even if the object passed is null ,it will be converted to empty string");
            cust3 = null;

            Console.WriteLine("We get empty string and no exception"+Convert.ToString(cust3));

            Console.WriteLine("If you are going to use ToString then you have to make sure that your ToString Method is overrridden to handel nulls" +
                "Else We are going to get the null exception.\n GTo see that in action uncomment below line of code");
            //cust2 = null;
            //Console.WriteLine(cust3.ToString());

        }

      
    }

   public  class C1
    {
        public string FirstName { get; set; }
    }

    public class C2
    {
        public string FirstName { get; set; }

        public override string ToString()
        {
            return this.FirstName.ToString();
        }
    }
}
