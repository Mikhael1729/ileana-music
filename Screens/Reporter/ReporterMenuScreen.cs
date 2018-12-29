using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic.Screens
{
    public class ReporterMenuScreen
    {
        readonly int option = 0;

        public ReporterMenuScreen()
        {
            Render();
            Clear();

            var thereArePieces = PieceService.Instance.Count() > 0;

            if (!thereArePieces)
            {
                PrintLine(">> No tiene piezas en su lista, por lo que esta función se encuentra deshabilitada <<");
                Pause();
            }
            else
            {
                while(option != 4)
                {
                    option = ReadNumberWithValidation(() =>
                    {
                        Clear();
                        Render();
                    });

                    Clear();
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

                    if(option != 4)
                        Pause();
                }
            }
        }

        public void Render()
        {
            // Title.
            Title();

            PrintLine("");

            // Options.
            PrintLine(
                "1. PDF\n" +
                "2. Excel\n" +
                "3. CSV\n" +
                "4. <<-- Atrás\n"
            );

            Print("Elija el formato para el reporte: ");
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