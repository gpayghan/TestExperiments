using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPay.Test;

namespace UnitTestProject1.TraitAsEnum
{
    [TestClass]
    public class TraitTest
    {
        [TestMethod, TestTraits(Trait.Customer),TestCategory("123")]
        public void CustomerTest()
        {
        }
    }
}
