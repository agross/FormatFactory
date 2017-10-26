using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FormatFactory.Installer
{
  public class Formats : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(
                         Classes
                           .FromThisAssembly()
                           .IncludeNonPublicTypes()
                           .InNamespace("FormatFactory.Formats")
                           .Configure(x => x.Named(x.Implementation.Name))
                           .WithServiceFirstInterface()
        );
    }
  }
}
