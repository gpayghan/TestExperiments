using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void TestMethod1()
        {
            Type[] ClassTypes = GetClassTypesInNamespace(Assembly.GetExecutingAssembly(), "MyNameSpace");
            
            //Type[] ClassTypes = typelist.Where(x => x.IsClass==true  && x.Name.ToLower().Contains("class")==true).ToArray();
            for (int i = 0; i < ClassTypes.Length; i++)
            {
              
               var constructorType= ClassTypes[i].GetConstructors();
                foreach (ConstructorInfo info in constructorType)
                {
                    var parameters = info.GetParameters();
              
                    if (parameters.Length < 1)
                        continue;
                    else if(parameters.Length==2)
                    {
                        bool desiredConstructorFound = false;
                        desiredConstructorFound = IsDesiredConstructorFound(parameters);
                       //int count1= parameters.Where(x => x.ParameterType == typeof(System.String)).Count();
                       // int count2 = parameters.Where(x => x.ParameterType == typeof(MyNameSpace.MyDevClass)).Count();
                       //if (count1 == 1 && count2 == 1)
                       //    desiredConstructorFound = true;
                        if (desiredConstructorFound)
                        Activator.CreateInstance(ClassTypes[i], new MyNameSpace.MyDevClass(), "One More String");
                    }

                }
                //constructorType.
            }
        }

        private Type[] GetClassTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal) && t.IsClass==true).ToArray();
        }

        private bool IsDesiredConstructorFound(ParameterInfo [] paramInfoArray)
        {
           // int count=0;
            bool found = true;
            int cnt = 0;
            foreach (ParameterInfo  info in paramInfoArray)
            {

                if (cnt == 0 && info.ParameterType != typeof(MyNameSpace.MyDevClass))
                {
                    found = false;
                    break;
                }
                if (cnt==1 && info.ParameterType != typeof(string))
                {
                    found = false;
                    break;
                }
                cnt++;
            }
            return found;


        }
    }
}
