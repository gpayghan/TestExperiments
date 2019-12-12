using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject1.LINQTutorial.Part12_PartitioningOperators
{
    [TestClass]
    public class PartitioningOperators
    {
        [TestMethod]
        public void Linq_Example_Partitioning_Operators()
        {
            string[] Countries = { "India","UK","USA","England","China"};
            //Take method returns specified number of elements from the start of the collection.
            //The number of operators returned is as passed in as an arguement to method

            var FirstThree = Countries.Take(3);

            FirstThree = (from country in Countries
                          select country).Take(3);

            //Skip method skips the specified number of elements in collections and then returns a new collection

            var remaining = Countries.Skip(3);

            //TakeWhile method returns elements from collection as long as given condtion specified by predicate is true

            var result = Countries.TakeWhile(s => s.Length > 2);


                
        }
    }
}
