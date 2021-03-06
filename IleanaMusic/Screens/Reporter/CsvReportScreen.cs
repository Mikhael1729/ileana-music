﻿using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class CsvReportScreen
    {
        ConsoleWriter writer = new ConsoleWriter(0);
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        ReportingHelper reporter = AppData.Instance.ReportingHelper;

        public CsvReportScreen()
        {
            Title();

            var playlists = playlistService.GetAll();

            writer.WriteLine(
                "Generando reporte..."
            );

            var successful = reporter.ReportPieces(
                fileName: "Playlists",
                playlists: playlists,
                title: "Reporte de Piezas",
                type: ReportType.Csv,
                portrait: false,
                sheetName: "Playlists"
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
                "Reporte en CSV\n" +
                "--------------\n"
            );
        }
    }
}
