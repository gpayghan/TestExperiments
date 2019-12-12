using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation
{
    class RefactoredCommonActions
    {
        //Enter Text

        public static void EnterText(IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
        }

        //Click Operation on Button, CheckBox ,Option Button.
        public static void Click(IWebElement webElement)
        {
            webElement.Click();
        }


        //Select a DropDown Contrl

        public static void SelectDropDown(IWebElement   webElement, string value)
        {
            SelectElement select = new SelectElement(webElement);
            select.SelectByText(value);

        }


        //Get the text from the control


        public static string GetText(IWebElement  webElement)
        {
            return webElement.GetAttribute("value");
        }


        public static string GetTextFromDropDown(IWebElement webElement)
        {
            SelectElement select = new SelectElement(webElement);
            return select.AllSelectedOptions.SingleOrDefault().Text;
        }

    }
}
