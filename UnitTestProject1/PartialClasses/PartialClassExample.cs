using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.PartialClasses;
namespace UnitTestProject1.PartialClasses
{
    [TestClass]
    public class PartialClassExample
    {
        [TestMethod]
        public void Test_Showing_Partial_Classes_Used_As_One_After_Compilation()
        {
            Customer c1 = new Customer() { FirstName = "Gitesh", LastName = "Payghan" };

            Console.WriteLine(c1.GetFullName());
        }

    }
}
