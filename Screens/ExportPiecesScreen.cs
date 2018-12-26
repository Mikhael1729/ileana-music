using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{

    public class ExportPiecesScreen
    {
        ConsoleWriter writer = new ConsoleWriter(0);
        
        public ExportPiecesScreen()
        {
            writer.WriteLine(
                "Exportar Piezas\n" + 
                "---------------\n"
            );

            writer.WriteLine(
                "1. Exportar a formato XML" + 
                "2. Exportar a formato JSON"
            );
        }
    }
}
