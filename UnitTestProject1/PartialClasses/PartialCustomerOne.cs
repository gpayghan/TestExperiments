using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PartialClasses
{
   public partial class Customer
    {
        public  string  GetFullName()
        {
            return this.FirstName+","+this.LastName;
        }
    }
}
