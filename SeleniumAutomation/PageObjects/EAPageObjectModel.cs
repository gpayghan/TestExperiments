using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace SeleniumAutomation
{
    class ExecuteAutoMationPageObjectModel
    {

        public ExecuteAutoMationPageObjectModel()
        {
            PageFactory.InitElements(TestSetup.driver, this);
        }

        [FindsBy(How=How.Id,Using = "TitleId")]
        public IWebElement ddlTitleId { get; set; }

        [FindsBy(How=How.Id,Using = "Initial")]
        public IWebElement txtIntial { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement btnSave { get; set; }


        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "MiddleName")]
        public IWebElement txtMiddleName { get; set; }

        public void FillUserForm(string Intitial,string FirstName,string MiddleName)
        {
            txtIntial.SendKeys(Intitial);
            txtFirstName.SendKeys(FirstName);
            txtMiddleName.SendKeys(MiddleName);

            btnSave.Submit();
        }

        public void FillUserForm(string Intitial, string FirstName, string MiddleName,string junk="")
        {
            //We are using our custom methods
            RefactoredCommonActions.EnterText(txtIntial,Intitial);
            RefactoredCommonActions.EnterText(txtFirstName,FirstName);
            RefactoredCommonActions.EnterText(txtMiddleName, MiddleName);

            RefactoredCommonActions.Click(btnSave);
        }

    }
}
