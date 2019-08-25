using System;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class MenuOneScreen
    {
        int option;
        const string menu = @"Menú de canciones
-----------------

1. Agregar una nueva pieza a la lista.
2. Mostrar todas las piezas.
3. Editar pieza.
4. Borrar pieza por ID.
5. Buscar canción.
6. <- Ir atrás.

Escoge una opción: ";

        public MenuOneScreen()
        {
            while (option != 6)
            {
                // Refreshing console if there are some content before menu screen.
                Clear();

                // Menu screen.
                ShowMenuAndRequestAnOption();

                // Go to selected screen.
                switch (option)
                {
                    case 1:
                        var pieceScreen = new AddPieceScreen();
                        break;
                    case 2:
                        new PieceList();
                        break;
                    case 3:
                        new EditPieceScreen();
                        break;
                    case 4:
                        new DeletePieceScreen();
                        break;
                    case 5:
                        new SearchPieceScreen();
                        break;
                }

                if (option != 6) {
                    WriteLine("\nPresiona cualquier tecla para volver atrás");
                    ReadLine();
                }
            }
        }
        void ShowMenuAndRequestAnOption()
        {
            Write(menu);

            while (!Int32.TryParse(ReadLine(), out option))
            {
                // Menu screen.
                Write(menu);
            }

            Clear();
        }
    }

}