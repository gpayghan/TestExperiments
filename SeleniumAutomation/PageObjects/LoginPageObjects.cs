    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace SeleniumAutomation
{
    class LoginPageObjects
    {

        public LoginPageObjects()
        {
            PageFactory.InitElements(TestSetup.driver, this);
        }
        [FindsBy(How=How.Name,Using ="UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassWord{ get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement btnLogin { get; set; }


        public ExecuteAutoMationPageObjectModel Login(string UserName,string Password)
        {
            //Login

            txtUserName.SendKeys(UserName);
            txtPassWord.SendKeys(Password);
            btnLogin.Submit();

            //Return the Page Object
            return new ExecuteAutoMationPageObjectModel();



        }
    }
}
