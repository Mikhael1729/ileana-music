using IleanaMusic.Data;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic.Screens
{
    public class ReporterMenuScreen
    {
        int option = 0;

        public ReporterMenuScreen()
        {
            var thereArePieces = AppData.Instance.PieceService.Count() > 0;

            // Title.
            Title();

            PrintLine("");

            // Options.
            PrintLine(
                "1. PDF\n" +
                "2. Excel\n"+
                "3. CSV\n"+
                "4. <<-- Atrás\n"
            );


            if (!thereArePieces)
            {
                PrintLine(">> No tiene piezas en su lista, por lo que esta función se encuentra deshabilitada <<");
                Pause();
            }
            else
            {
                Print("Elija el formato para el reporte: ");
                option = ReadNumber();

                // Instruction. 
                switch (option)
                {
                    case 1:
                        new PdfReportScreen();
                        break;

                    case 2:
                        new ExcelReportScreen();
                        break;

                    case 3:
                        new CsvReportScreen();
                        break;
                }
            }
        }

        public void Title()
        {
            PrintLine(
                "Menú de reportes\n" +
                "----------------"
            );
        }
  }
}