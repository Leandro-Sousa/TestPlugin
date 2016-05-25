using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace TestPlugin
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(
                    new AssemblyFilter(@"C:\SRC\Tests\TestPlugin\TestPlugin.Concrete\bin\Debug", "TestPlugin.Concrete.dll"))
                    .Pick()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());

            container.Register(Classes.FromThisAssembly()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
        }
    }
}
