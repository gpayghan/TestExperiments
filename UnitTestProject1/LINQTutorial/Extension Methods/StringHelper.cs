using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.LINQTutorial.Extension_Methods
{

    //The class should be a static class
    public static class StringHelper
    {
        //The type which being extended should be the first argument in the method
        public static string ChangeFirstLetterCase(this string inputStr)
        {
            if(inputStr.Length>0)
            {
                char[] CharArray = inputStr.ToCharArray();
                CharArray[0] = char.IsUpper(CharArray[0]) ?char.ToLower(CharArray[0]) :  char.ToUpper(CharArray[0]);
                return new string(CharArray);
            }
            return inputStr;
        }
    }
}
