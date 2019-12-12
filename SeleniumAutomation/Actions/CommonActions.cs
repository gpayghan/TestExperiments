using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
 
namespace SeleniumAutomation
{
   public class CommonActions
    {
        //Enter Text

        public static void EnterText(By webElement,string value)
        {
            try
            {
                TestSetup.driver.FindElement(webElement).SendKeys(value);
            }catch(Exception ex)
            {

            }

        }

        //Click Operation on Button, CheckBox ,Option Button.
        public static  void Click(By control)
        {
            TestSetup.driver.FindElement(control).Click();
        }


        //Select a DropDown Contrl

        public static void SelectDropDown(By control, string value)
        {
            SelectElement select = new SelectElement(TestSetup.driver.FindElement(control));
            select.SelectByText(value);
            
        }


        //Get the text from the control


        public static string GetText(By control)
        {
           return TestSetup.driver.FindElement(control).GetAttribute("value");
        }


        public static string GetTextFromDropDown( By control)
        {
         
            SelectElement select = new SelectElement(TestSetup.driver.FindElement(control));
            
           return select.AllSelectedOptions.SingleOrDefault().Text;
        }


        //Explicit wait untill particular Condition is met
        public static void WaitTillElementToBeVisible(By control)
        {
            WebDriverWait wait = new WebDriverWait(TestSetup.driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(control));
        }

        //Driver will wait for time before continuing any action
        public void SetImplicitTimeForDriver()
        {
            TestSetup.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        //Maximize/Minimize Browser Window
        public void MaxiMizeWindow()
        {
            TestSetup.driver.Manage().Window().Maximize();
        }

        //Takes ScreenShot

        public static void TakeScreenShot()
        {

            //Cast your driver to ITakesInterface and then take the screenshot
            Screenshot ss=((ITakesScreenshot)TestSetup.driver).GetScreenshot();
            ss.SaveAsFile("MyPath", ScreenshotImageFormat.Jpeg);
        }


        //Check if control is displayed or not
        public bool IsElementExist(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;

            }catch(NoSuchElementException ex)
            {
                return false;
            }catch(Exception e)
            {
                return false;
            }
        }

        //Actions class can be used for Drag and Drop /Double Click etc

        public static void DragAndDrop(IWebElement source,IWebElement destination)
        {
            Actions action = new Actions(TestSetup.driver);
            //Double click
            //action.DoubleClick(destination);
            //Drag and Drop
            action.DragAndDrop(source, destination).Perform();
        }
        //How to Hover using selenium
        public static void Hover(IWebElement element)
        {
            Actions action = new Actions(TestSetup.driver);
            action.MoveToElement(element).Perform();
        }
        //Here we are doing two actions one after another
        public static void HoverAndClick(IWebElement elementToHover,IWebElement elementToClick)
        {
            Actions action = new Actions(TestSetup.driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }

        //Handelling a PopUp Window
        public static void SomeMethodToHandelThePopUp()
        {
            //You may need to go back to parent window to perform additional actions;
            // to the new window when some action is done
           TestSetup. driver.SwitchTo().Window(TestSetup.driver.WindowHandles.ToList().Last());

            var x = TestSetup.driver.WindowHandles.ToList();

            //Assuming the above popup is closed then to the new window
            TestSetup.driver.SwitchTo().Window(TestSetup.driver.WindowHandles.ToList().First());
            //or Use below to go back to the default window
            TestSetup.driver.SwitchTo().DefaultContent();

            //Or Get the current handel before doing the action
            var beforePopUp= TestSetup.driver.CurrentWindowHandle;
            //And now do some operation switch to last window and then switch back to above handel as
            TestSetup.driver.SwitchTo().Window(beforePopUp);
        }

        public static void WaitTillPageLoads()
        {
            //Use JavaScript to wait until the page has loaded
            var wait= new WebDriverWait(TestSetup.driver, TimeSpan.FromSeconds(30));
            //wait.Until(driver1 => ((IJavaScriptExecutor)TestSetup.driver)
            //.ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(wd => ((IJavaScriptExecutor)wd).ExecuteScript("return document.readystate").Equals("complete"));

            TestSetup.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

    }
}
