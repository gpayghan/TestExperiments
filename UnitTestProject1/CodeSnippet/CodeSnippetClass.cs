using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.CodeSnippet
{

    public class abc
    {
        private static abc myObj = new abc();
        public int Id
        {
            get; set;
        }
        [StringLength(20)]
        public string Name
        {
            get; set;
        }
        [EmailAddress]
        public string Email
        {
            get; set;
        }
    }

}
