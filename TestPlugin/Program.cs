using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Threading;
using TestPlugin.Interfaces;

namespace TestPlugin
{
    class Program
    {

        static void Main(string[] args)
        {
            var myTest = new MyTest();

            myTest.Test.TestMethod();
            myTest.Test2.TestMethod();

            Console.ReadLine();
        }
    }

    public class MyTest
    {
        public MyTest()
        {
            Resolver.Instance.ResolveType(this);
        }

        [Import(typeof(ITest))]
        public ITest Test { get; set; }


        [Import(typeof(ITest2))]
        public ITest2 Test2 { get; set; }
    }

    public class Resolver
    {
        private static readonly Lazy<Resolver> _instance = new Lazy<Resolver>(() => new Resolver(), LazyThreadSafetyMode.ExecutionAndPublication);
        private readonly CompositionContainer container;

        private Resolver()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Resolver).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"C:\SRC\Tests\TestPlugin\TestPlugin.Concrete\bin\Debug")); //Caminho das DLL...

            container = new CompositionContainer(catalog);
        }

        public static Resolver Instance
        {
            get { return _instance.Value; }
        }

        public void ResolveType(object instance)
        {
            container.ComposeParts(instance);
        }
    }
}
