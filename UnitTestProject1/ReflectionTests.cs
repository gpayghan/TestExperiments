using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.ReflectionClasses;

namespace UnitTestProject1
{
    [TestClass]
    public class ReflectionTests
    {
        [TestMethod]
        public void Set_Certain_Property_Value_Using_Reflection()
        {
            User user = new User();

            //This Method is going initialize the User Object with Default constructor and 
            //Set propoert with Type Personal Data
            ReflectionUtil.SetPropertyWithCertainTypeOnObject<User, PersonalData>();
        }
    }
}
