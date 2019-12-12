using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RA;
using System.Collections.Generic;
namespace UnitTestProject1.REST_Assured
{
    [TestClass]
    public class REST_API_Automation
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Response retreived

//            {
//                "ip":"2605:6000:f705:ab00:78e3:1959:78d4:bd76",
//                "about":"/about",
//                "Pro!":"http://getjsonip.com"
//}


            new RestAssured()
             .Given()
                //Optional, set the name of this suite
                .Name("JsonIP Test Suite")
                //Optional, set the header parameters.  
                //Defaults will be set to application/json if none is given
                .Header("Content-Type", "application/json")
                .Header("Accept-Encoding", "gzip,deflate")
             .When()
                //url
                .Get("http://jsonip.com")
             .Then()
                //Give the name of the test and a lambda expression to test with
                //The lambda expression keys off of 'x' which represents the json blob as a dynamic.
                .TestBody("test a", x => x.about != null)
                //Throw an AssertException if the test case is false.
                .Assert("test a")
                ;

            var response = new RestAssured()
             .Given()
                //Optional, set the name of this suite
                .Name("JsonIP Test Suite")
                //Optional, set the header parameters.  
                //Defaults will be set to application/json if none is given
                .Header("Content-Type", "application/json")
                .Header("Accept-Encoding", "gzip,deflate")
             .When()
                //url
                .Get("http://jsonip.com");
            //.Then()
            //    .Retrieve(x=>x.about);


            response.Then().TestBody("", x => x.about);

        }
    }


    public class calculator
    {
        public static void AreEqual<T> (T firstValue,T secondValue)
        {

        }

        public static void AreEqual(dynamic firstValue, dynamic secondValue)
        {
         //   if(typeof(firs))
        }

    }
}

