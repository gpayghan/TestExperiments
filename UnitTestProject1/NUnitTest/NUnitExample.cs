using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using NUnit.Framework.Interfaces;

namespace UnitTestProject1.NUnitTest
{
    [TestFixture] //TestClass
    public class NUnitExample
    {
        const int constantValue = 3;
        private string CurrentTestFolder = TestContext.CurrentContext.TestDirectory;
        private DirectoryInfo LogsFolder;
        private DirectoryInfo SubTestFolder;

        [OneTimeSetUp]//ClassInitialize
        public void MyClassInitialize()
        {
            LogsFolder = Directory.CreateDirectory(Path.Combine(CurrentTestFolder, "Logs"));
           
        }

        [SetUp]//TestInitialize
        public void MyTestInitialize()
        {
            Console.WriteLine("In SetUp method");
            var currentTestName = TestContext.CurrentContext.Test.Name;
            SubTestFolder = Directory.CreateDirectory(Path.Combine(LogsFolder.FullName, currentTestName));
        }

        [Test]
        public void Print_Occurance_Of_Charcters_in_String()
        {
            string sample = "Foe Doe";
            var x= sample.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });

            List<int> numbers = new List<int>() {1,2,3,4,5,6,7 };
            IEnumerable<int> EvenNumbers = numbers.Where(num => num % 2 == 0);

            foreach (var item in x)
            {
             Console.WriteLine(item.Char + ":" + item.Count);
            }
        }

        [Test]
        public void abc()
        {
            string numnber = "100";
            StringBuilder sb = new StringBuilder();
            sb.Append("8");
            while (sb.Length < (10-numnber.Length))
            {
                sb.Append("0");
            }
            sb.Append(numnber);
            Console.Write(sb.ToString());
        }
        [Test]
        public void OneRandomMethod()
        {
            string s1 = "Gitesh";
            string even = "";

            for (int i = 0; i < s1.Length; i++)
            {
                if (i % 2 == 0)
                    even += s1[i];
            }
            Assert.AreEqual("Gts", even);
        }
        public void abc(int a=0)
        {

        }

        public void abc(int a, int b )
        {

        }

        [Test]
        public void PrintConstatValue()
        {
            Console.WriteLine(NUnitExample.constantValue);
        }
        public delegate void ConsoleDelegate(string message);

        public static void ConsoleMethod(string message)
        {
            Console.WriteLine("Something");
        }
        [TestCase]
        public  void DelegateTest()
        {
            ConsoleDelegate d = ConsoleMethod;

            //ConsoleDelegate t = new ConsoleDelegate("sada");
            d("Something");
            //Assert.AreEqual("", 1);

        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        [Test,Category("SomeCategory")]//TestMethod
        //[ExpectedException(typeof(InsufficientFundsException))]
        public void NUnit_Test1_Example()
        {
            Assert.AreEqual("Gitesh", "Gitesh","Name");
            Assert.IsNotNull(null,"Something is not null?");
        }

        [Ignore("SomeReason")]
        public void SomeTest()
        {

        }
        //Use of Test Context in NUnit
        [Test,Category("SomeCategory")]
        public void RandomGeneratorTest()
        {
            Console.WriteLine(TestContext.CurrentContext.Random.Next());
            Console.WriteLine(TestContext.CurrentContext.Random.NextDecimal());
            Console.WriteLine(TestContext.CurrentContext.Random.NextBool());
        }

        //[Test]
        //[Category("Functional"), Category("Release")]
        //public void CategoriesPropertiesTest(string abc="")
        //{
        //    foreach (var category in TestContext.CurrentContext.Test.Properties["Category"])
        //    {
        //        Console.WriteLine(category);
        //    }
        //}

        [TearDown] //TestCleanUp
        public void MyTestCleanUp()
        {
            Console.WriteLine("My Test CleanUp Code");
            var testResult = TestContext.CurrentContext.Result.Outcome;

            if (Equals(testResult, ResultState.Failure) ||
                Equals(testResult == ResultState.Error))
            {
                // save your logs here
            }
        }
        [OneTimeTearDown]//ClassCleanUp
        public void MyClassCleanUp()
        {

        }


    }
}
