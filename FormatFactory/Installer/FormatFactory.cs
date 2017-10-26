using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FormatFactory.Installer
{
  public class FormatFactory : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      if (!container.Kernel.GetFacilities().Any(x => x is TypedFactoryFacility))
      {
        container.AddFacility<TypedFactoryFacility>();
      }

      container.Register(Component.For<IFormatFactory>()
                                  .AsFactory(config => config.SelectedWith(new FormatterComponentSelector())));
    }
  }

  class FormatterComponentSelector : DefaultTypedFactoryComponentSelector
  {
    public FormatterComponentSelector() : base(false, true)
    {
    }

    protected override string GetComponentName(MethodInfo method, object[] arguments)
    {
      var filename = (string)arguments.First();
      var extension = Path.GetExtension(filename).Substring(1);
      return string.Format("{0}Format", extension);
    }
  }
}
