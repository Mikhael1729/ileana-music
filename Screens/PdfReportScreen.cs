    using System;
    using System.IO;
    using IleanaMusic.Data;
    using IleanaMusic.Data.Services;
    using IleanaMusic.Helpers;
    using System.Collections.Generic;
    using IleanaMusic.Models;
    using System.Reflection;
    using System.Linq;
    using static System.Diagnostics.Process;
    using GemBox.Spreadsheet;

    namespace IleanaMusic.Screens
    {
    public class PdfReportScreen
    {
        ConsoleWriter writer = new ConsoleWriter(0);
        PieceService pieceService = AppData.Instance.PieceService;

    public PdfReportScreen()
    {
        writer.WriteLine(
            "Reporte en PDF\n" +
            "--------------\n"
        );

      
        var pieces = pieceService.GetAll();
        var excelPath = Path.Combine(Directory.GetCurrentDirectory(), "Cosas.xlsx");

        ConvertToPdf(excelPath, pieces);
    }

    static void ConvertToPdf(string fileName, List<Piece> pieces)
    {
        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

        string[] headers = { "ID", "Nombre", "Artista", "Genero", "Album", "Duracion", "Calidad", "Formato" };

        var workbook = new ExcelFile();
        var sheet = workbook.Worksheets.Add("Sheet 1");
        sheet.Cells[1, 2].Value = "Hello world!";

        // Adding headers.
        for (int i = 0; i < headers.Length; i++)
        {
            sheet.Cells[0, i].Value = headers[i];
        }

        // Adding pieces
        for (int i = 0; i < pieces.Count; i++)
        {
            var piece = pieces[i];
            sheet.Cells[(i+1), 0].Value = piece.Id.ToString();
            sheet.Cells[(i+1), 1].Value = piece.Name;
            sheet.Cells[(i+1), 2].Value = piece.Artist;
            sheet.Cells[(i+1), 3].Value = ConvertGenderToSpanish(piece.Gender);
            sheet.Cells[(i+1), 4].Value = piece.Album;
            sheet.Cells[(i+1), 5].Value = $"{piece.Duration} minutos";
            sheet.Cells[(i+1), 6].Value = ConvertQualityToSpanish(piece.Quality);
            sheet.Cells[(i+1), 7].Value = ConvertGenderToString(piece);
        }

            workbook.Save(fileName);
    }

    static string ConvertGenderToString(Piece piece)
    {
        return Enum.GetName(piece.Gender.GetType(), piece.Gender);
    }

    static string ConvertQualityToSpanish(Quality quality)
    {
        switch (quality)
        {
        case Quality.High:
            return "Alta";
        case Quality.Low:
            return "Baja";
        case Quality.Medium:
            return "Media";
        default:
            return "";
        }
    }

    static string ConvertGenderToSpanish(Gender gender)
    {
        switch (gender)
        {
        case Gender.Classical:
            return "Clásica";
        case Gender.Raggeton:
            return "Raggeton";
        case Gender.Rock:
            return "Rock";
        default:
            return "";
        }
    }
    }
    }