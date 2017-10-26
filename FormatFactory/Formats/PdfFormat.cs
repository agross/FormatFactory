using System;

namespace FormatFactory.Formats
{
  class PdfFormat : IFormat
  {
    public void Save()
    {
      Console.WriteLine("Save PDF");
    }
  }
}