using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomation
{
    //http://executeautomation.com/demosite/Login.html
    [TestClass]
    public class SeleniumTests
    {

    //   static IWebDriver driver;
        [ClassInitialize]
        public static void  MyClassInitialize(TestContext tc)
        {
            TestSetup.driver = new ChromeDriver(@"C:\Users\Gitesh\source\repos\UnitTestProject1\packages\Selenium.Chrome.WebDriver.2.33\driver");
            
            //Implicit Wait


            //TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
        }

        [TestMethod]
        public void My_First_Test_Method()
        {
            

            CommonActions.SelectDropDown( By.Id("TitleId"), "Mr.");
            CommonActions.EnterText( By.Id("Initial"), "Popat");

            CommonActions.Click( By.Name("Save"));

           var text= CommonActions.GetTextFromDropDown( By.Id("TitleId"));

            Console.WriteLine($"Value from Title Id is '{text}'");
        }

        [TestMethod]
        public void Another_Test_Using_Page_Object_Model()
        {

            //Initialize the page by calling it's referance.

            ExecuteAutoMationPageObjectModel page = new ExecuteAutoMationPageObjectModel();

            page.txtIntial.SendKeys("ExecuteAutomation");
            page.btnSave.Click();
        }

        [TestMethod]
        public void Using_Only_PageObject_Model()
        {

            //Initialize the page by calling it's referance.
            TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            LoginPageObjects loginPage = new LoginPageObjects();
            ExecuteAutoMationPageObjectModel EA= loginPage.Login("User1", "test1234");

            EA.FillUserForm("sdasfas","asfasf","dgdsg");

        }


        [TestMethod]
        public void Drag_And_Drop_Test()
        {
            TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Dragging.html");
            CommonActions.DragAndDrop(TestSetup.driver.FindElement(By.Id("item2")),
                TestSetup.driver.FindElement(By.Id("item4")));
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        public void Hover_Test()
        {
            TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            CommonActions.Hover(TestSetup.driver.FindElement(By.Id("Automation Tools")));
            System.Threading.Thread.Sleep(3000);
            //Automation Tools
           
        }

        [TestMethod]
        public void Hover_And_Click_Test()
        {
            TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            CommonActions.HoverAndClick(TestSetup.driver.FindElement(By.Id("Automation Tools")), TestSetup.driver.FindElement(By.Id("Selenium WebDriver")));
            System.Threading.Thread.Sleep(3000);
        }


        [TestMethod]
        public void Time_Out_On_Page_Load()
        {

            //Setting up negative timeout results in indefinite timeout. As shown below it will wait for page to load for indefinite time
            TestSetup.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(-1);
            TestSetup.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }

        [ClassCleanup]
        public static void MyTestCleanUp()
        {
            TestSetup.driver.Close();
        }
    }

    public class XXT
    {
        protected int a;
    }

    public class XXu:XXT
    {
        public XXu():base()
        {
            a = 1;
            base.a=0;
        }
    }

    public class sdgds
    {
        public void asfsdaf()

        {
            XXu xu = new XXu();
        }
    }

}
