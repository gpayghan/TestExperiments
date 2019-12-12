using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
namespace UnitTestProject1.SeleniumTutorial
{
    [TestClass]
    public class SampleSeleniumTest
    {

        IWebDriver chromedriver = new OpenQA.Selenium.Chrome.ChromeDriver(@"C:\Users\Gitesh\source\repos\UnitTestProject1\packages\Selenium.Chrome.WebDriver.2.33\driver");
        //IWebDriver ieDriver = new OpenQA.Selenium.IE.InternetExplorerDriver(@"The full path to the directory containing IEDriverServer.exe");
        //IWebDriver edgeDriver = new OpenQA.Selenium.Edge.EdgeDriver(@"Path to edgedriver.exe");
        IWebDriver firefoxDriver = new OpenQA.Selenium.Firefox.FirefoxDriver(@"Path to gecKodriver.exe");

        [TestMethod]
        public void TestMethod1()
        {
            //IWebDriver driver = new ChromeDriver(@"C:\Users\Gitesh\source\repos\UnitTestProject1\packages\Selenium.Chrome.WebDriver.2.33\driver");

            chromedriver.Navigate().GoToUrl(@"chrome://downloads/");

            IWebElement root1 = chromedriver.FindElement(By.TagName("downloads-manager"));
            chromedriver.Navigate().Back();//Move back to ingle entr in browser history
            chromedriver.Navigate().Forward();//Move forward single "item" in the browser history
            chromedriver.Navigate().Refresh();//Refreshes current page.
            //Get shadow root element
            //IWebElement shadowRoot1 = expandRootElement(root1);


            //IWebElement root2 = shadowRoot1.FindElement(By.CssSelector("downloads-toolbar"));
            //IWebElement shadowRoot2 = expandRootElement(root2);

            //IWebElement root3 = shadowRoot2.FindElement(By.CssSelector("cr-toolbar"));
            //IWebElement shadowRoot3 = expandRootElement(root3);

            By downloads_manager_ShadowDom= By.TagName("downloads-manager");
            By downloadToolBarShadowDom = By.CssSelector("downloads-toolbar");
            By toolBarElement = By.CssSelector("cr-toolbar");

            //IWebElement ToolBarElement = driver.FindElement(downloads_manager_ShadowDom).ExpandRootElement(driver)
            //                  .FindElement(downloadToolBarShadowDom).ExpandRootElement(driver)
            //                  .FindElement(toolBarElement);

            //ToolBarElement.SendKeys("ABC");
            var elem = ExpandShadowDOM(null, downloads_manager_ShadowDom, downloadToolBarShadowDom, toolBarElement);
            elem.SendKeys("Jay Shri Ram");
            //String actualHeading = shadowRoot3.FindElement(By.CssSelector("div[id=leftContent]>h1")).Text;
        }

        [TestMethod]
        public void Difference_Between_Quit_And_Close()
        {
            chromedriver.Close();
            //WebDriver.Close() method is used to close the current open window. It closes current open window on which driver has focus on.
            chromedriver.Quit();
            //Driver.Quit() method is used to destory the instance of webdriver. It closes all browser windows associated with that driver and safey ends the session.
            chromedriver.Dispose();
            //Quit() method calls Dispose() method which actullly does all the trick.
        }

        [TestMethod]
        public void What_Is_Implicit_Wait_And_Explicit_Wait()
        {
            //Implicit wait- Asking the browser to wait for amount of time driver should wait while searching for an element if it is not present immediately
            //If the element is found beofre the time seciified the next step will be executed without waiting for remaining time mentioned in implicit wait.
            chromedriver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            //Explicit Wait- Specific wait 
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(chromedriver,TimeSpan.FromSeconds(10));
            wait.Message = "";//Gets for sets the message to be displayed when time expires
            wait.IgnoreExceptionTypes() ;//Configures this instance to ignore the specific exceptions while waiting on the condition
            wait.PollingInterval = TimeSpan.FromMilliseconds(100); //Gets or sets how often the condition should be evaluated. The deafult timeout is 500milliseond
            wait.Until(x => x.FindElements(By.XPath("")).Count > 1);//Condtion till the wait should be applied. Throws exception when timeout expires.
            //wait.Until(ExpectedConditions.)
            wait.Until(ExpectedConditions.AlertIsPresent());
            //An expectation for checking that an element is present on the DOM of a page
            //This does not necessarily mean that the element is visible.
            //// Returns:
            //     The OpenQA.Selenium.IWebElement once it is located.
            wait.Until(ExpectedConditions.ElementExists(By.Id("elem")));

            // Summary:
            //     An expectation for checking that an element is present on the DOM of a page and
            //     visible. Visibility means that the element is not only displayed but also has
            //     a height and width that is greater than 0.
            // Returns:
            //     The OpenQA.Selenium.IWebElement once it is located and visible.
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("elem")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("elem")));

            wait.Until(ExpectedConditions.TextToBePresentInElement(chromedriver.FindElement(By.Id("elem")),""));
            // An expectation for checking the title of a page.
            wait.Until(ExpectedConditions.TitleIs(""));
            wait.Until(ExpectedConditions.UrlContains(""));


        }

        [TestMethod]
        public void How_To_Handel_Frames_Using_WebDriver()
        {

            //Accept the alert popup generated after certain action on UI.
            chromedriver.SwitchTo().Alert().Accept();
            chromedriver.SwitchTo().Alert().Dismiss();

            ////Switch to Frame. Three ways. Frame Name, Frame Index and IwebElement for particular frame
            chromedriver.SwitchTo().Frame("");

            chromedriver.Navigate().GoToUrl("https://www.youtube.com/watch?v=UFL2AlPBgCw");
            //How to handel the windows
            var windowHandels= chromedriver.WindowHandles;
            string windowName = "";
            Dictionary<int, string> windowpairsbyindex = new Dictionary<int, string>();
            int count = 0;
            using (var iterator = windowHandels.GetEnumerator())
            {
                iterator.MoveNext();
                windowName = iterator.Current;
                windowpairsbyindex.Add(count, windowName);
                count++;
            }
            chromedriver.SwitchTo().Window(windowHandels.LastOrDefault());
            chromedriver.SwitchTo().Window(windowpairsbyindex[0]);
            chromedriver.SwitchTo().DefaultContent();
        }

        [TestMethod] 
        public void How_To_Handle_Https_Certifications()
        {
           
            OpenQA.Selenium.Remote.DesiredCapabilities cap = new OpenQA.Selenium.Remote.DesiredCapabilities();
            cap.SetCapability("Aceept_ssl_certs","true");

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("Aceept_ssl_certs", "true");
            options.AddArgument("start-maximized");//Opens Chrome in maximize mode
            options.AddArgument("incognito ");//Opens Chrome in incognito mode
            options.AddArgument("headless");//Opens Chrome in headless mode
            options.AddAdditionalCapability("download.default_directory","Download Path");//Change the download path
            //TestSetup.driver = new ChromeDriver(@"C:\Users\Gitesh\source\repos\UnitTestProject1\packages\Selenium.Chrome.WebDriver.2.33\driver", options);
        }

        [TestMethod]
        public void How_To_Enter_Text_Caps_Lock()
        {
            
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(chromedriver);
            //action.KeyDown(object, "SHIFT");
            action.KeyDown( Keys.Shift);
            action.SendKeys("ab");
            action.Build().Perform();
            string pageTitle= chromedriver.Title;
            //driver.FindElements(By.XPath("")).Count();
            OpenQA.Selenium.Support.UI.SelectElement selectElement = new OpenQA.Selenium.Support.UI.SelectElement(chromedriver.FindElement(By.XPath("")));
            //selectElement.
        }

        [TestMethod]
        public void How_To_Automate_Slider()
        {
            IWebElement slider = chromedriver.FindElement(By.Id("slider"));
            IWebElement sliderEndPosition = chromedriver.FindElement(By.Id("slider"));

            //Oneway
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(chromedriver);
            action.DragAndDropToOffset(slider,30,30)
                  .Build()
                  .Perform();

            //Another way
            action.DragAndDrop(slider, sliderEndPosition)
                .Build()
                .Perform();
            //Anotherway(loop by how many times you want to shift)
            slider.SendKeys(Keys.Right);

            //One more way
            action.MoveToElement(slider)
                .ClickAndHold()
                .MoveByOffset(0, 250)
                .Release()
                .Perform();
        }

        public IWebElement ExpandShadowDOM(IWebElement webElement=null ,params By[] elements)
        {
            IWebElement iwebElement = webElement;
            By[] remainingElements=null;
            foreach (var elem in elements)
            {
                if (iwebElement == null)
                    return ExpandShadowDOM(chromedriver.FindElement(elem).ExpandRootElement(chromedriver), elements.Skip(1).ToArray());
                else
                {
                    if (elements.Length == 1)
                        return iwebElement.FindElement(elements.FirstOrDefault());
                    else
                       remainingElements= elements.Skip(1).ToArray();

                    return ExpandShadowDOM(iwebElement.FindElement(elem).ExpandRootElement(chromedriver), remainingElements) ;
                }
            }
            return iwebElement;
        }

        //Returns webelement
        public IWebElement expandRootElement(IWebElement element)
        {
            IWebElement ele = (IWebElement)((IJavaScriptExecutor)chromedriver)
    .ExecuteScript("return arguments[0].shadowRoot", element);
            return ele;
        }
    }

    public static class SeleniumExtension
    {
        public static IWebElement ExpandRootElement(this IWebElement element, IWebDriver driver)
        {
            return (IWebElement)((IJavaScriptExecutor)driver)
                    .ExecuteScript("return arguments[0].shadowRoot", element);
        }
    }


    public class GenericExample<T>
    {
        public static bool AreEqual(T a,T b )
        {
            return a.Equals(b);
        }
    }
}
