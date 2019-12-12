using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject1.CSharpInterviewQuestions
{


    [TestClass]
    public class CSharpInterviewQuestions
    {

        //Find the largest palindrome from string.

        public abstract class BaseAbstractClass
        {
            public virtual void AbstractMethod()
            {
                Console.WriteLine("Abstract class Method");
            }

        }
        
        public class SomeClass : BaseAbstractClass
        {
        }

        public class SomeOtherClass : BaseAbstractClass
        {
            public override void AbstractMethod()
            {
                Console.WriteLine("Some Other class implemenataion");
            }
        }

        public class OneMoreclass : BaseAbstractClass
        {
            public  void AbstractMethod()
            {
                Console.WriteLine("OneMOre class implemenataion");
            }
        }

        enum Gender
        {
            Male=5,
            Female,
            Unknown

        }

        [TestMethod]
        public void Enumeration()
        {
            Console.WriteLine(Gender.Male);

          int[] values=( int[] ) Enum.GetValues(typeof(Gender));
            Console.Write("Values from enums");
            foreach (var val in values)
            {
                Console.WriteLine(val);
            }
            Console.Write("Names from enums");
            var names = Enum.GetNames(typeof(Gender));

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        [TestMethod,TestCategory("sdad")]
        
        public void Session_14_Virtual_Method_In_C_Sharp()
        {
            //An abstract class has a default implementation for a method.
            //The methods default implementation is needed  in some class but not in some other class.How can you achieve it?
            SomeClass sc = new SomeClass();
            sc.AbstractMethod();//See that base abstract class method is called
            SomeOtherClass soc = new SomeOtherClass();
            soc.AbstractMethod();//Overridden method is called.

            //In below example method defined in child class will be called since it is present in child class
            OneMoreclass omc = new OneMoreclass();
            omc.AbstractMethod();
        }

        [TestMethod]
        public void Remove_Duplicate_From_String()
        {
            string str = "Gitesh Payghan";

            string outputstring = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (outputstring.Contains(str[i]))
                    continue;
                else
                    outputstring = outputstring + str[i];
            }

            Console.WriteLine(outputstring);

        }

        [TestMethod]
        public void Check_If_Number_Is_Palindrome()
        {
            int num = 121;
            int temporaryPlaceHolder = num;
            int finalNumber = 0;
            int remainder = 0;
            while(num>0)
            {
                remainder = num % 10;

                finalNumber = finalNumber * 10 + remainder;

                num = num /10;
            }

            Console.WriteLine(temporaryPlaceHolder == finalNumber);

        }

        [TestMethod]
        public void Check_If_String_Is_Palindrome_Or_Not_Without_Recursion()
        {
            string palindrome = "abcba";
            string revStr = "";
            //First Reverse the string and compare it with actual string
            for (int i = palindrome.Length-1; i >=0; i--)
            {
                revStr += palindrome[i];//.ToString();
            }
            if (revStr == palindrome)
                Console.WriteLine("String is a Palindrome");

        }
        [TestMethod]
        public void Check_If_String_Is_Palindrome_Or_Not_Without_Recursion1()
        {
            string palindrome = "abcba";
            string revStr = "";

            bool isPlaindrome = false;

            while(palindrome.Length>0)
            {
                if (palindrome.Length == 1)
                {
                    isPlaindrome = true;
                    break;
                }

                if (palindrome[0] == palindrome[palindrome.Length - 1])
                    isPlaindrome = true;
                else
                {
                    isPlaindrome = false;
                    break;
                }
                palindrome = palindrome.Substring(1, palindrome.Length - 2);
            }

            Console.WriteLine("Is Palindrome"+isPlaindrome);
        }

        [TestMethod]
        public void Check_If_String_Is_Palindrome_Or_Not_With_Recursion()
        {
            string palindrome = "abcba";
            Console.WriteLine(IsPalindrome(palindrome));
        }

        public bool IsPalindrome(string str)
        {
            if (str.Length <= 1)
                return true;
           else if (str[0] != str[str.Length - 1])
                return false;
            else
                return IsPalindrome(str.Substring(1, str.Length - 2));

        }

        [TestMethod]
        public void Sum_Of_Digits_In_Integer()
        {
            int abc = 1234556;
            int sum = 0;

            while(abc>0)
            {
                sum += abc % 10;
                abc = abc/10;
            }
            Console.WriteLine(sum);
        }

        [TestMethod]
        public void Pattern_1()
        {
            int k =1 ;

            int z = 6;
            for (int i = 1; i < 6; i++)
            {
                for (int t = z; t>=1; t--)
                {

                    Console.Write(" ");
                    
                }

                for (int j = 1; j <=i; j++)
                {
                    //if (i != j)
                    //    Console.Write(" ");
                    //else
                       Console.Write(k++);
                    //if (j == i)
                    //    break;

                }
                z--;
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void Pattern_2_Star_Pyramid()
        {
            int x = 4; // Total Number of Lines...
            for (int i = 1; i <= x; i++)
            {
                //loop to print spaces
                for (int j = 1; j <= (x - i); j++)
                    Console.Write(" ");

                //loop to print stars
                for (int t = 1; t <= i ; t++)
                    Console.Write("*");
                Console.WriteLine();
            }

        }


        [TestMethod]
        public void Find_The_Element_At_Particular_Index()
        {

            string str = "Gitesh";

            var elementAtIndexOne = str.ToCharArray().ElementAt(1);

            char[] characters = str.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                Console.WriteLine(characters[i]);
            }
        }

        [TestMethod]
        public void Misc_Find_Number_Of_Occurances_Of_Characters_In_Strings()
        {
            string str = "WWW.goggle.com";
            while(str.Length>0)
            {
                int count = 0;

                Console.Write(str[0] +":\t");
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[0] == str[i])
                        count++;
                }
                Console.WriteLine(count);
                str = str.Replace(str[0].ToString(),string.Empty);
            }
            //Yes this is working now.
            Console.WriteLine("\n*****Using LINQ***************\n");

            str = "WWW.goggle.com";

            var response =  str.GroupBy(c => c)
                        
                        .Select(c=>new { character=c.Key, Count=c.Count()}) ;

            foreach (var item in response)
            {
                Console.WriteLine($"{item.character  }:\t {item.Count}");
            }
        }
       [TestMethod]
        public void Session_13_Reverse_Each_Word_In_String()
        {
            //split the input string using single space as seperator. Split() method returns a string array whcihc contains the each word of input string.
            //select method,constructs a new string array, by reversing each character in each word.
            //Join method converts the striung array into a string
            string inputstring = "One Two Three Four";

            var reversedString= string.Join(" ",inputstring.Split(' ').Select(x => new String(x.Reverse().ToArray())));

            Console.WriteLine(reversedString);

            //Without using the Linq or string function
            string temp = "";
            string revStr = "";

            foreach (char  ch in inputstring)
            {
                if (ch != ' ')
                    temp = ch + temp;
                else
                {
                    revStr = revStr + temp + " ";
                    temp = "";
                }
            }
            Console.WriteLine(revStr+temp);

            revStr = "";
            temp = "";

            for (int i = 0; i < inputstring.Length; i++)
            {

                if (inputstring[i] != ' ')
                    temp = inputstring[i] + temp;
                else
                {
                    revStr = revStr + temp + " ";
                    temp = "";
                }

            }

            Console.WriteLine(revStr + temp);
        }


        [TestMethod]
        public void Find_All_The_Factors_For_Given_Number()
        {
            //For this we will find the maximum divisible number first which would be the sqaure root of the given number.
            int num = 25;
            List<int> factors = new List<int>();
            //Since each number is divisible by 1 and itself and half its number
            factors.Add(1);
            factors.Add(num);

            int maxDivisor = num / 2;

            for (int i = 2; i <= maxDivisor; i++) 
            {
                if (num % i == 0)
                    factors.Add(i);
                else
                    Console.WriteLine($"{i} is not a divisor");
            }

            Console.WriteLine("Below are the divisors");

            foreach (int divisor in factors)
            {
                Console.WriteLine(divisor);
            }
        }


        [TestMethod]
        public void Session_10_What_Happens_When_Exception_Occurs_In_Finally_block()
        {
            //The exception propagates up and it should be handled at a higher level.If exception is not handled at higher level the application fails.
            //The finally block execution stops at the point where exception is thrown.
            //If finally block is being executed  after an exception has occurred in the try block , and that exception is not handled  and if finally block throws an exception 
            //Then original exception occurred in try block is lost
            try { Hello(); }catch(Exception ex) { }

        }
        public void Hello()
        {
            try
            {
                //Some exception here and it's not catched and exception occurs in finally will override the excetion from this block

            }

            catch { }
            finally
            {
                Console.WriteLine("Before exception");
                int result = Convert.ToInt32("ABCD");
                Console.WriteLine("After exception");//Will not be executed
            }
        }

        [TestMethod]
        public void Abstract_Class_constructor_And_Calling_Abstarct_method_Thorugh_Constructor()
        {
            //If you want abstract method to be invoked automatically whenever an instance of the class that is derived from abstract class is created,
            //then we call it in an abstract class constructor
            CorporateCustomer cc = new CorporateCustomer();//See that the Print method is called automatically
            SavingsCustomer sc = new SavingsCustomer();
        }

        public abstract class Customer
        {
            protected Customer()
            {
                Print();
            }

            public abstract void Print()
            ;
        }

        public class CorporateCustomer : Customer
        {
            public override void Print() => Console.WriteLine("Corporate Customer ");
        }

        public class SavingsCustomer : Customer
        {
            public override  void Print()
            {
                Console.WriteLine("SavingsCustomer Customer ");
            }
        }

        [TestMethod]
        public void Jay_Question_On_Arrays()
        {
            //Question- Without creating new array give me the even and odd number arrays
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };

            int[] arr2 = { 7, 8, 9, 10 ,12,11};

            //First merge two arrays as follows.

            //First make sure you are increasing the length of array 1

            for (int i = 0; i < arr2.Length; i++)
            {
                arr1[arr1.Length + i + 1] = arr2[i];
            }

            
            for (int i = 0; i < arr1.Length+arr2.Length; i++)
            {
                if (arr1[i] % 2 == 0)
                    continue;
                else
                    arr2[i] = arr1[i];
            }

           


        }


        [TestMethod]
        public void Method_Paramters_In_C_Sharp_Value_Parameters()
        {
            int i = 50;
            PassByValueMethod(i);
            //Note that i value doesnot change.
            //We are passing 50 which is received by a and then a is changed to 10.
            //PassByValue method will make copy of i and then operate on it.
            Console.WriteLine(i);

            
            int k = 90;
            // int k; will result in  error. you need to initilize ref parameter before passing it to method
            PassByReferanceMethod(ref k);
            Console.WriteLine(k);
            //Out Paramter

            int  Total = 0;
            int Product;//Note this doesnot give ANY ERROR
            Calculate(10, 20,out Total,out Product);

            Console.WriteLine("Sum=" + Total + "\n" + "Product=" + Product);


            //Params ParAMETER

            ParamsMethood();//No error even if we dont pass any value.
            //Also you dont need to create an array if you us Params as shown below
            Console.WriteLine("Using Params Sum is "+ParamsMethood(1,2));

            //I cannot do this. It says no overlaod that takes in two arguements.
            //To Call below method I have to use the Interger array
            //MethodWithntegerArrayAsParameter(1, 2);
            int[] numArray = new int[2];
            numArray[0] = 12;
            numArray[1] = 12;
           Console.WriteLine(MethodWithntegerArrayAsParameter(numArray));

        }

        public void PassByValueMethod(int a)
        {
            a = 10;
        }
        
        public void PassByReferanceMethod(ref int a)
        {
            a = 10;
        }

        public int Calculate(int FN,int SN,out int Total,out int Product)
        {
            Total = FN + SN;
            Product = FN * SN;

            return 1;
        }

        public int ParamsMethood(params int[] intarray)
        {
            int sum = 0;
            foreach (var item in intarray)
            {
                sum += item;
            }
            return sum;
        }

        public int MethodWithntegerArrayAsParameter( int[] intarray)
        {
            int sum = 0;
            foreach (var item in intarray)
            {
                sum += item;
            }
            return sum;
        }


        [TestMethod]
        public void Static_Example()
        {
            //Debug this to understand.
            //Order of Execution is
            //static fields==> Static constructor=> instance constructors
            StaticExample ex1 = new StaticExample();
            
        }


        [TestMethod]
        public void OverRideVirutual()
        {
            //You cannot override a method if it is not marked virtual or abstract in base class

        }
    }
    internal  class StaticExample
    {
        static string Name = "Gitesh";
        static int Radius;
       
        static StaticExample()
        {
            Radius = 10;
            Console.WriteLine("Static constuctor called");

        }

        public StaticExample()
        {
            Console.WriteLine("Instance constuctor called");
        }
    }

    class A1
    {
        public virtual void Print()
        {
            Console.WriteLine("M1");
        }
    }

    class A2:A1
    {
        public override void Print()
        {
            Console.WriteLine("M1");
        }
    }

    interface I1
    {

        //You cannot have the acceess modifier 
        void Print();

        //There is only declarationa and no implementation
        int MyProperty { get; set; }
    }




}

