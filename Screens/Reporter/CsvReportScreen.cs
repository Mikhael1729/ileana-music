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
        PieceService pieceService = AppData.Instance.PieceService;
        ReportingHelper reporter = AppData.Instance.ReportingHelper;

        public CsvReportScreen()
        {
            Title();

            var pieces = pieceService.GetAll();

            writer.WriteLine(
                "Generando reporte..."
            );

            var successful = reporter.ReportPieces(
                fileName: "Piezas",
                pieces: pieces,
                title: "Reporte de Piezas",
                type: ReportType.Csv,
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
                "Reporte en CSV\n" +
                "--------------\n"
            );
        }
    }
}