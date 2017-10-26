using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

using FormatFactory.Formats;

namespace FormatFactory
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var container = new WindsorContainer())
      {
        container.Install(FromAssembly.InDirectory(new AssemblyFilter(".", "*.exe")));

        var factory = container.Resolve<IFormatFactory>();

        var txtFormat = factory.GetFormatterForFilename("C:\\text.txt");
        txtFormat.Save();
        factory.Release(txtFormat);

        var pdfFormat = factory.GetFormatterForFilename("C:\\text.pdf");
        pdfFormat.Save();
        factory.Release(pdfFormat);

        //txtFormat.Save(...);
      }

      Console.ReadKey();
    }
  }

  class Document
  {
    readonly IFormatFactory _formatFactory;

    public Document(IFormatFactory formatFactory)
    {
      _formatFactory = formatFactory;
    }

    public void Save()
    {
      // OpenFileDialog
      string filename = "Foobar.txt";

      IFormat format = _formatFactory.GetFormatterForFilename(filename);

      //format.Save(this);

    }
  }
}
