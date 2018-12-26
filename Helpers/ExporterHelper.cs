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

            var basePath = Path.Combine(Directory.GetCurrentDirectory());
            var toCopy = Path.Combine(Directory.GetCurrentDirectory(), "MyXmlFile.xml");
            var toPaste = Path.Combine(Directory.GetCurrentDirectory(), "Exports", "MyXmlFileExported.xml");

            try
            {
                if(File.Exists(basePath))
                {

                }
                File.Copy(toCopy, toPaste);
            }
            catch (Exception e)
            { }

            return completeExport;
        }
    }
}
