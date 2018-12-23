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
using OfficeOpenXml;

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

      using (ExcelPackage excel = new ExcelPackage())
      {
        excel.Workbook.Worksheets.Add("Worksheet1");
        excel.Workbook.Worksheets.Add("Worksheet2");
        excel.Workbook.Worksheets.Add("Worksheet3");
        
        var headerRow = new List<string[]>()
        {
          new string[] { "ID", "First Name", "Last Name", "DOB" }
        };
        
        // Determine the header range (e.g. A1:D1)
        string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

        // Target a worksheet
        var worksheet = excel.Workbook.Worksheets["Worksheet1"];
        
        // Popular header row data
        worksheet.Cells[headerRange].LoadFromArrays(headerRow);
        
        FileInfo excelFile = new FileInfo(fileName);
        excel.SaveAs(excelFile);
      }
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