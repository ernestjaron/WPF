using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie4;
using GUI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ViewModel vm = new ViewModel();
            Assert.IsTrue(vm.Products.Count > 100);
            Assert.IsNotNull(vm.Read);
            Assert.IsNotNull(vm.Test);
            Assert.IsNotNull(vm.Test);
       

          
        }

        [TestMethod]
        public void TestMethod2()
        {
            ViewModel vm = new ViewModel();
            int first = vm.Products.Count;
            vm.Products.Add(new Product());
            int second = vm.Products.Count;
            Assert.IsFalse(first == second);
            

        }
    }
}
