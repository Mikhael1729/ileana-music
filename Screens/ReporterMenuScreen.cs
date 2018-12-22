using IleanaMusic.Helpers;
using static IleanaMusic.Helpers.ConsoleReader;

namespace IleanaMusic.Screens
{
  public class ReporterMenuScreen
  {
    ConsoleWriter writer = new ConsoleWriter(0);
    int option = 0;

    public ReporterMenuScreen()
    {
      // Title.
      Title();

      writer.WriteLine("");

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

    public void Title()
    {
      writer.WriteLine(
        "Menú de reportes\n" +
        "----------------"
      );
    }

    public int Data() 
    {
      return option;
    }
  }
}