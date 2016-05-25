using System;
using System.ComponentModel.Composition;
using TestPlugin.Interfaces;

namespace TestPlugin.Concrete
{
    [Export(typeof(ITest))]
    public class TestConcrete : ITest
    {
        public void TestMethod()
        {
            Console.WriteLine("Test....");
        }
    }
}
