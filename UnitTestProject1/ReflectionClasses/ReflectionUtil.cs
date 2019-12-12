using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTestProject1.ReflectionClasses
{
   public static class ReflectionUtil
    {
        static int Count;
        public static Object SetPropertyWithCertainTypeOnObject<ObjectType,PropertyType>()
        {
            bool operationSuccesful = true;
            var ObjectInstance = Activator.CreateInstance(typeof(ObjectType));

            try
            {

                foreach (var info in ObjectInstance.GetType().GetProperties())
                {
                    if (info.PropertyType == typeof(PropertyType))
                        info.SetValue(ObjectInstance, Activator.CreateInstance(typeof(PropertyType)));
                }
            }catch(Exception Ex)
            {
                Console.WriteLine($"Something Went Wrong Here are details\n {Ex.StackTrace}\n {Ex.Message}");
                operationSuccesful = false;
            }
            return ObjectInstance;
        }

        public static void PrintEachPublicPropertyAndItsValue(object obj)
        {
            Count++;
            Console.WriteLine($"PrintEachPublicPropertyAndItsValue Method Invoked {Count} Times");
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name+":"+prop.GetValue(obj));
            }
            
        }
    }
}
