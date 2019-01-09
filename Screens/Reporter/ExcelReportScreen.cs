using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class ExcelReportScreen
    {
        ConsoleWriter writer = new ConsoleWriter(0);
        PlaylistService playlistSevice = AppData.Instance.PlaylistService;
        ReportingHelper reporter = AppData.Instance.ReportingHelper;

        public ExcelReportScreen()
        {
            Title();

            var playlists = playlistSevice.GetAll();

            writer.WriteLine(
                "Generando reporte..."
            );

            var successful = reporter.ReportPieces(
                fileName: "Piezas",
                playlists: playlists,
                title: "Reporte de Piezas",
                type: ReportType.Excel,
                portrait: false,
                sheetName: "Piezas"
            );

            Clear();

            Title();
            if (successful)
                writer.WriteLine("¡Reporte generado exitósamente! : )");
            else
                writer.WriteLine("Lo sentimos, el reporte no ha podido ser generado. : (");
        }

        public void Title()
        {
            writer.WriteLine(
                "Reporte en Excel\n" +
                "----------------\n"
            );
        }
    }
}
