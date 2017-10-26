using System;

namespace FormatFactory.Formats
{
  class TxtFormat : IFormat
  {
    public void Save()
    {
      Console.WriteLine("Save TXT");
    }
  }
}