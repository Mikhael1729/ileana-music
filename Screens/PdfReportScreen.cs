using System;
using System.IO;
using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using IleanaMusic.Models;
using System.Reflection;
using System.Linq;

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
      var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Cosas.xlsx");

      // Creating excel instance.
      var excel = new Application()
      {
        SheetsInNewWorkbook = 1,
        Visible = true,
      };

      // Creating workbook with a sheet.
      var workbook = (Workbook)(excel.Workbooks.Add(Missing.Value));
      var sheet = (Worksheet)excel.ActiveSheet;

      AddPiecesToSheet(
        workSheet: ref sheet,
        pieces: pieces
      );

      var m = Missing.Value;

      workbook.SaveAs(fileName);
      workbook.Close();

      ReleaseObject(sheet);
      ReleaseObject(workbook);
      ReleaseObject(excel);
    }

    static void ReleaseObject(object obj)
    {
      try
      {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        obj = null;
      }
      catch (Exception ex)
      {
        obj = null;
      }
      finally
      {
        GC.Collect();
      }
    }

    private static AddPiecesToSheet(ref Worksheet workSheet, List<Piece> pieces)
    {
      string[] headers = { "ID", "Nombre", "Artista", "Genero", "Album", "Duracion", "Calidad", "Formato" };

      // Adding headers.
      for (int i = 0; i < headers.Length; i++)
      {
        ((Range)workSheet.Range[1, i+1]).Value= headers[i];
      }

      // Adding pieces
      for (int i = 0; i < pieces.Count; i++)
      { 
        var piece = pieces[i];
        workSheet.Cells[(i + 1), 1] = piece.Id.ToString();
        workSheet.Cells[(i + 1), 2] = piece.Name;
        workSheet.Cells[(i + 1), 3] = piece.Artist;
        workSheet.Cells[(i + 1), 4] = ConvertGenderToSpanish(piece.Gender);
        workSheet.Cells[(i + 1), 5] = piece.Album;
        workSheet.Cells[(i + 1), 6] = $"{piece.Duration} minutos";
        workSheet.Cells[(i + 1), 7] = ConvertQualityToSpanish(piece.Quality);
        workSheet.Cells[(i + 1), 8] = ConvertGenderToString(piece);
      }

      workSheet.Name = "Piezas";
    }

    private string ConvertGenderToString(Piece piece)
    {
      return Enum.GetName(piece.Gender.GetType(), piece.Gender);
    }

    private string ConvertQualityToSpanish(Quality quality)
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

    private string ConvertGenderToSpanish(Gender gender)
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