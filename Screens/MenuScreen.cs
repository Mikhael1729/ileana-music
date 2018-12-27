using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic
{
    public class MenuScreen 
    {
        private int option;

        public MenuScreen() 
        {
            option = ReadNumberWithValidation(() => 
            {
                Clear();
                Screen();
            });
        }

        public int Data() 
        {
            return option;
        }

        private void Screen()
        {
            PrintLine(
                 "Ileana Music \n" +
                 "------------\n"
            );

            PrintLine(
                "1. Canciones\n" +
                "2. Playlists\n" +
                "3. Menú de reportes\n" +
                "4. Exportar piezas\n" +
                "5. Importar piezas\n" +
                "6. Salir\n"
            );

            Print("Escoge una opción: ");
        }
    }
}