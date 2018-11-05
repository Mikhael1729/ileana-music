using System;
using static System.Console;

namespace IleanaMusic 
{
    public class MenuScreen 
    {
        private int option;
        private const string menu = @"Ileana Music
------------
1. Agregar una nueva pieza a la lista.
2. Mostrar todas las piezas.
3. Editar pieza.
4. Borrar pieza por ID.
5. Buscar canción.
6. Salir.

Escoge una opción: ";


        public MenuScreen() 
        {
            option = 0; 

            Write(menu);

            while(!Int32.TryParse(ReadLine(), out option))
            {
                Clear();

                // Menu screen.
                Write(menu);
            }

            Clear();
        }

        public int Data() 
        {
            return option;
        }
    }
}