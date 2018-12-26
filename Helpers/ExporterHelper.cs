using System;
using System.IO; 

namespace IleanaMusic.Helpers
{
    public class ExporterHelper
    {
        public ExporterHelper()
        {

        }

        public static bool ExportPiecesToXml()
        {
            var completeExport = false;

            var toCopy = Path.Combine(Directory.GetCurrentDirectory(), "Testing", "MyXmlFile.xml");
            var toPaste = Path.Combine(Directory.GetCurrentDirectory(), "Exports", "MyXmlFileExported.xml");

            try
            {
                File.Copy(toCopy, toPaste);
            }
            catch (Exception e)
            { }

            return completeExport;
        }
    }
}
