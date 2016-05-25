using System;
using System.ComponentModel.Composition;
using TestPlugin.Interfaces;

namespace TestPlugin.Concrete
{
    [Export(typeof(ITest2))]
    public class TestConcrete2 : ITest2
    {
        public void TestMethod()
        {
            Console.WriteLine("Test 2 called...");
        }
    }
}
