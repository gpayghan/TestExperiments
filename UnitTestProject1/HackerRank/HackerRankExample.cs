using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.HackerRank
{
    [TestClass]
    public class HackerRankExample
    {
        /// <summary>
        /// Get the consecutive 1"s from the binary number
        /// </summary>
        [TestMethod]
        public void Convert_Integer_To_Binary_Number_And_Returns_Consecutive_1s()
        {
            int n = 439;
            string binaryString = "";
            while (n > 0)
            {
                var remainder  = n % 2;
                binaryString = remainder + binaryString;
                n = n / 2;
            }
            Console.WriteLine(binaryString);
            int placeHolder = 0;
            for (int i = 0; i < binaryString.Length - 1; i++)
            {
                int count = 0;

                if (binaryString[i] == '1' )
                {
                    count++;
                    for (int j = i + 1; j <= binaryString.Length-1; j++)
                    {
                        i = j;
                        if (binaryString[j] == '1')
                            count++;
                        else
                            break;
                    }

                }
               placeHolder= placeHolder > count? placeHolder : count;
            }

            Console.WriteLine(placeHolder);
        }
    }
}
