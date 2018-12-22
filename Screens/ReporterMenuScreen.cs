using IleanaMusic.Helpers;
using static IleanaMusic.Helpers.ConsoleReader;

namespace IleanaMusic.Screens 
{
  public class ReporterMenuScreen 
  {
    public ReporterMenuScreen()
    {
      var writer = new ConsoleWriter(0);

      // Title.
      writer.WriteLine(
        "Menú de reportes\n" + 
        "----------------\n"
      );

      // Options.
      writer.WriteLine(
        "1. PDF\n" +
        "2. CSV\n" + 
        "3. Excel\n"
      );

      // Instruction.
      writer.Write(">> Elija el formato para el reporte: ");
      var option = ReadNumber();
    }
  }
}