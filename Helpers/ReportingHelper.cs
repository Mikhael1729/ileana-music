using GemBox.Spreadsheet;
using IleanaMusic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace IleanaMusic.Helpers
{
    public class ReportingHelper
    {
        // Styles
        CellStyle titleStyles;
        CellStyle headerStyle;
        CellStyle normalStyle;
        CellStyle totalStyle;

        string[] headers;

        public ReportingHelper()
        {
            #region Styles initialization
            titleStyles = new CellStyle();
            titleStyles.Font.Weight = ExcelFont.BoldWeight;
            titleStyles.Font.Size = 18 * 20;
            titleStyles.HorizontalAlignment = HorizontalAlignmentStyle.CenterAcross;
            titleStyles.Borders.SetBorders
            (
                MultipleBorders.Top | MultipleBorders.Right | MultipleBorders.Left | MultipleBorders.Bottom | MultipleBorders.Right,
                SpreadsheetColor.FromName(ColorName.Black),
                LineStyle.Thin
            );

            headerStyle = new CellStyle();
            headerStyle.Font.Weight = ExcelFont.BoldWeight; // Weight.
            headerStyle.Font.Size = 12 * 20; // Font size.
            headerStyle.Borders.SetBorders // Border.
            (
                MultipleBorders.Top | MultipleBorders.Right | MultipleBorders.Left | MultipleBorders.Bottom | MultipleBorders.Right,
                SpreadsheetColor.FromName(ColorName.Black),
                LineStyle.Thin
            );

            // Normal cell style.
            normalStyle = new CellStyle();
            normalStyle.Borders.SetBorders // Border.
            (
                MultipleBorders.Top | MultipleBorders.Right | MultipleBorders.Left | MultipleBorders.Bottom | MultipleBorders.Right,
                SpreadsheetColor.FromName(ColorName.Black),
                LineStyle.Thin
            );


            // Total style.
            totalStyle = new CellStyle();
            totalStyle.Font.Weight = ExcelFont.BoldWeight;
            totalStyle.Font.Size = 12 * 20;
            #endregion

            #region Headers
            headers = new string[]{ "ID", "Nombre", "Artista", "Genero", "Album", "Duración", "Calidad", "Formato" };
            #endregion
        }

        public bool ReportPieces(string fileName, List<Piece> pieces, ReportType type, bool portrait=true, string title="Reporte", string sheetName="Piezas")
        {
            var created = false; // Report has been created?
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var report = BaseReport( // Report
                pieces: pieces,
                reportTitle: title,
                sheetName: sheetName,
                format: type,
                portrait: portrait
            );

            try
            {
                switch (type)
                {
                    case ReportType.Pdf:
                        report.Save($"{path}.pdf");
                        break;
                    case ReportType.Excel:
                        report.Save($"{path}.xlsx");
                        break;
                    case ReportType.Csv:
                        report.Save($"{path}.csv");
                        break;
                    default:
                        break;
                }

                created = true;
            } 
            catch(Exception e)
            { }

            return created;
        }

        ExcelFile BaseReport(
            string reportTitle, 
            List<Piece> pieces, 
            ReportType format, 
            string sheetName, 
            bool portrait=false)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var sheet = workbook.Worksheets.Add(sheetName);

            var n = 0;

            var pdf = format == ReportType.Pdf;

            #region Columns                       
            sheet.Columns[0].Width = (portrait && pdf ? 3  : pdf ? 5 : 20) * 256; // Id.
            sheet.Columns[1].Width = (portrait && pdf ? 14 : pdf ? 33 : 40) * 256; // Nombre.
            sheet.Columns[2].Width = (portrait && pdf ? 14 : pdf ? 19 : 40 )* 256; // Artista.
            sheet.Columns[3].Width = (portrait && pdf ? 14 : pdf ? 19 : 20 )* 256; // Género.
            sheet.Columns[4].Width = (portrait && pdf ? 14 : pdf ? 19 : 20 )* 256; // Álbum.
            sheet.Columns[5].Width = (portrait && pdf ? 14 : pdf ? 19 : 20 )* 256; // Duración.
            sheet.Columns[6].Width = (portrait && pdf ? 13 : pdf ? 19 : 20 )& 256; // Calidad.
            sheet.Columns[7].Width = (portrait && pdf ? 13 : pdf ? 19 : 20 )* 256; // Formato.

            var title = sheet.Cells.GetSubrangeAbsolute(0, 0, 0, 7);
            title.Merged = true;
            title.Style = titleStyles;
            title.Value = reportTitle;
            #endregion

            #region Headers
            n += 1;
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = sheet.Cells[n, i];
                cell.Style = headerStyle; // Aplying styles.
                cell.Value = headers[i]; // Value.
            }
            #endregion

            #region Rows
            n += 1;
            for (int i = 0; i < pieces.Count; i++)
            {
                var piece = pieces[i];

                var idCell = sheet.Cells[(i + n), 0];
                idCell.Style = normalStyle;
                idCell.Value = piece.Id.ToString();

                var nameCell = sheet.Cells[(i + n), 1];
                nameCell.Style = normalStyle;
                nameCell.Value = piece.Name;

                var artistCell = sheet.Cells[(i + n), 2];
                artistCell.Style = normalStyle;
                artistCell.Value = piece.Artist;

                var genderCell = sheet.Cells[(i + n), 3];
                genderCell.Style = normalStyle;
                genderCell.Value = ConvertGenderToSpanish(piece.Gender);

                var albumCell = sheet.Cells[(i + n), 4];
                albumCell.Style = normalStyle;
                albumCell.Value = piece.Album;

                var durationCell = sheet.Cells[(i + n), 5];
                durationCell.Style = normalStyle;
                durationCell.Value = $"{piece.Duration}";

                var qualityCell = sheet.Cells[(i + n), 6];
                qualityCell.Style = normalStyle;
                qualityCell.Value = ConvertQualityToSpanish(piece.Quality);

                var formatCell = sheet.Cells[(i + n), 7];
                formatCell.Style = normalStyle;
                formatCell.Value = ConvertFormatToSpanish(piece);
            }
            #endregion

            #region Footer
            n += pieces.Count + 1;

            var totalCell = sheet.Cells.GetSubrangeAbsolute(n, 0, n, 1);
            totalCell.Merged = true;
            totalCell.Style = totalStyle;
            totalCell.Value = $"Total de piezas: {pieces.Count}";
            #endregion

            sheet.PrintOptions.Portrait = portrait;
            return workbook;
        }

        #region Converter Methods
        static string ConvertFormatToSpanish(Piece piece)
        {
            return Enum.GetName(piece.Format.GetType(), piece.Format);
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
        #endregion
    }
}
