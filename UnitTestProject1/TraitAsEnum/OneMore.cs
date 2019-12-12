//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

////namespace EPay.Test
////{
//    public enum Category : int
//    {
//        UnitTest = 0,
//        IntegrationTest = 1
//    }


//    public class TestCategoryAttribute : TestCategoryBaseAttribute
//    {
//        private Category _category;

//        public TestCategoryAttribute(Category category)
//        {
//            _category = category;
//        }

//        public override IList<string> TestCategories
//        {
//            get
//            {
//                var value = Enum.GetName(typeof(Category), _category);
//                return new List<string> { value };
//            }
//        }
//    }

//}
