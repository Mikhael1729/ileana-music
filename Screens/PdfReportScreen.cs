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

      ConvertToExcel(excelPath);
    }

    static void ConvertToExcel(string fileName)
    {
      SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
      
      var workbook = new ExcelFile();
      workbook.Worksheets.Add("Sheet 1").Cells["A1"].Value = "Hello world!";

      workbook.Save(fileName);
    }

    string ConvertGenderToString(Piece piece)
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