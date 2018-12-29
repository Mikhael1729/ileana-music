using IleanaMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IleanaMusic.Data;

namespace IleanaMusic.Helpers
{
    public static class ImportHelper
    {
        public static IEnumerable<Piece> ExtractPieces(this XDocument document)
        {
            var service = AppData.Instance.PieceService;

            return document.Element(service.RootNode)?
                .Elements(service.ChildNode)
                .Select(p => Piece.ConvertFromXElement(p));
        }
    }
}
