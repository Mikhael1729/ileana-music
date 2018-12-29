using IleanaMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using Newtonsoft.Json;

namespace IleanaMusic.Helpers
{
    public static class PieceImporterHelper
    {

        public static IEnumerable<Piece> ExtractPieces(this XDocument document, PieceService service)
        {
            return document.Element(service.RootNode)?
                .Elements(service.ChildNode)
                .Select(p => Piece.ConvertFromXElement(p));
        }

        public static IEnumerable<Piece> ExtractPiecesFromJson(this string json, PieceService service)
        {
            return JsonConvert.DeserializeObject<List<Piece>>(json);
        }

        public static bool ItCanBeAdded(this Piece piece, PieceService service)
        {
            // Pieces with the same name and artist shouldn't added.
            var searched = service.Find((Piece p) =>
                p.Name.ToLower() == piece.Name.ToLower() &&
                p.Artist.ToLower() == piece.Artist.ToLower()
            );

            return searched == null ? true : false;
        }
    }
}
