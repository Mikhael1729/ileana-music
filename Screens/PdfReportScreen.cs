using IleanaMusic.Helpers;

namespace IleanaMusic.Screens 
{
  public class PdfReportScreen 
  {
    ConsoleWriter writer = new ConsoleWriter(0);

    public PdfReportScreen() 
    {
      writer.WriteLine(
        "Reporte en PDF\n" + 
        "--------------\n"
      );

      
    }
  }
}