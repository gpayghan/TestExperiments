using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1.LINQTutorial.Tutorisl_6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example_showing_Restriction_Operator()
        {
            //WHERE standard query operator belong to Restriction Operators category.

            int[] numbers = { 1,2,3,4,5,6,7,8,9,10};
            var evenNumbers = numbers.Where(x => x % 2 == 0);
            evenNumbers = from number in numbers
                          where number % 2 == 0
                          select number;


            //Lets take a look at another overloaded version of WHERE clause. 
            //First version take Func<int,bool> . Here int specifies each number in the integer and output will be boolean.
            //Second version take Func<int,int,bool>
            //In this case first int refers the element in the array and second int specifies the index of element and it would return in the bool.
            //Func<Tin in,T out > is actually a delegate so you can either pass lambda expression or the function to WHERE clause.

            //Now lets use second overloaded version to print the even numbers and their index using Lambda expression
            
            var allNumbersWithIndex= numbers.Select((num, index) => new { Number = num, Index = index });

            //Here we are taking the number and its index to translate it into an anonymious type with two proprties

            var evenNumbersWithIndex = allNumbersWithIndex.Where(x => x.Number % 2 == 0);




        }
    }
}
