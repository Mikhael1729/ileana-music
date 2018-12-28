﻿using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic.Screens
{
    public class ImportMenuScreen
    {
        public ImportMenuScreen()
        {
            int option = 0;

            while (option != 3)
            {
                option = ReadNumberWithValidation(() =>
                {
                    Clear();

                    PrintLine(
                        "Importar Piezas\n" +
                        "---------------\n"
                    );

                    PrintLine(
                        "1. Importar desde XML\n" +
                        "2. Importar desde JSON\n" +
                        "3. <<-- Ir atrás\n"
                    );

                    Print(
                        "Escoge una opción: "
                    );
                });

                Clear();

                switch (option)
                {
                    case 1:
                        PrintLine("Nothing here");
                        break;
                    case 2:
                        PrintLine("Nothing here 2");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
