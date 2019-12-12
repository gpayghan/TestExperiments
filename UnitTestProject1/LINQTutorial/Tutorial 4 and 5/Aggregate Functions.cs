using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1.LINQTutorial.Tutorial_4
{
    [TestClass]
    public class AggreagteFunctions
    {
        [TestMethod]
        public void Linq_Aggregate_Functions_Examples()
        {
            int[] Numbers = { 1,2,3,4,5,6,7,89,10};

            int minNumber = Numbers.Min();

            //Get Minimum Even number using Aggreagte Linq 
            int minmumEvenNumber = Numbers.Where(x => x % 2 == 0).Min();

            //Find out Largest Number
            int MaxNum = Numbers.Max();

            //Sum of all elements

            int sum = Numbers.Sum();

            //Find sum of even numbers

            int sumOfEvenNumbers = Numbers.Where(x => x % 2 == 0).Sum();

            //Find the Count of number of elemnt

            int totalElements = Numbers.Count();

            //Get the Average

            double avergae = Numbers.Average();


            //Print the coutry with minimum charcters

            string[] Countries = { "India","UK","USA"};
            int ? result = null;
            foreach (string country in Countries)
            {
                if (!result.HasValue||country.Length < result)
                    result = country.Length;
                    
            }
            Console.WriteLine($"Country with shortest name has {result} characters in it");

            //Using Aggregate Functions

            int MiniMumCount = Countries.Min(x => x.Length);
        }

        [TestMethod]
        public void Linq_Aggregate_Function_Tutorial5()
        {
            string[] Countries = { "India", "UK", "USA" ,"England","Australia"};

            string AllCountriesCommaSeperated = string.Empty;

            foreach (string country in Countries)
            {
                AllCountriesCommaSeperated = AllCountriesCommaSeperated + country + ",";
            }

            Console.WriteLine(AllCountriesCommaSeperated);

            //There is extra comma in above result so lets just remove it.

            Console.WriteLine(AllCountriesCommaSeperated.Remove(AllCountriesCommaSeperated.LastIndexOf(',')));

            //NOw let's see how we can acheive the same results with Linq Aggregate function

            string result = Countries.Aggregate((a,b)=>a+","+b);

            Console.WriteLine(result);

            int[] numbers = { 2,3,4,5};

            int RunningMultiplication = numbers.Aggregate((a,b)=>a*b);

            Console.WriteLine(RunningMultiplication);
        }
    }
}
