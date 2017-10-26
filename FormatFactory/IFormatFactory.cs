using FormatFactory.Formats;

namespace FormatFactory
{
  public interface IFormatFactory
  {
    IFormat GetFormatterForFilename(string filename);
    void Release(object format);
  }
}