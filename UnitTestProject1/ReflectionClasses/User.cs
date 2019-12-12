using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.ReflectionClasses
{
    public class User
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int AccountNumber { get; set; }

        public PersonalData Data { get; set; }

        //public static SetPropertyDynamically<>()
    }

    public class PersonalData
    {
        public string Name { get; set; }
        public string HouseNumber { get; set; }

    }
}
