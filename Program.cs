using System;
using static System.Console;
using IleanaMusic.Models;
using IleanaMusic.Screens;
using IleanaMusic.Data;

namespace IleanaMusic
{
  class Program
  {
    static void Main(string[] args)
    {
      int option = 0;
      int playlistsOption = 0;

      /* Options (of MenuScreen)
       *  1. Canciones
       *  2. Playlists
       *  3. Menú de reportes
       *  4. Exportar piezas
       *  5. Importar piezas
       *  6. Salir 
       */
      while (option != 6)
      {
        // Refreshing console if there are some content before menu screen.
        Clear();

        // Menu screen.
        var menuScreen = new MenuScreen();
        option = menuScreen.Data();

        switch (option)
        {
          case 1:
            new MenuOneScreen();
            break;
          case 2:
            /*
                1. Agregar playlist
                2. Listar playlists
                3. Editar playlist
                4. Borrar playlist
                5. Buscar canción en playlist
                6. Buscar pieza en playlist
                7. <<-- Ir atrás
             */
            if (AppData.Instance.PieceService.GetAll().Count > 0)
            {
              while (playlistsOption != 7)
              {
                Clear();
                // Showing the menu and getting selected option.
                playlistsOption = (new PlayListsMenuScreen()).Data();
                Clear();
                switch (playlistsOption)
                {
                  case 1:
                    new AddPlayListScreen();
                    break;
                  case 2:
                    new PlaylistsScreen();
                    break;
                  case 3:
                    new EditPlayListScreen();
                    break;
                  case 4:
                    new DeletePlaylitScreen();
                    break;
                  case 5:
                    new SearchPlaylistScreen();
                    break;
                  case 6:
                    new SearchPieceInPlaylistScreen();
                    break;
                }
                if (playlistsOption != 7)
                  Pause();
              }
            }
            else
            {
              WriteLine("Playlists\n"
                      + "---------\n");
              WriteLine(">> No tienes canciones, por lo que esta función está deshabilitada.");
              WriteLine("\nEscribe cualquier tecla para continuar");
              ReadLine();
            }

            playlistsOption = 0;
            break;
          case 3:
            /*
                1. PDF
                2. Excel 
                3. CSV
            */
            var reporterMenuScreen = new ReporterMenuScreen();
            Clear();
            switch (reporterMenuScreen.Data())
            {
                case 1:
                  new PdfReportScreen();
                break;

                case 2:
                  new ExcelReportScreen();
                break;

                case 3:
                  
                break;
            }
            break;

            case 4: 
                WriteLine("Nothing here 4");
                break;

            case 5: 
                WriteLine("Nothing here 5");
                break;
        }

        // If option is "1" you don't want to show the follow message.
        if (option != 1 && playlistsOption == 0)
        {
          Pause();
        }
      }
    }

    static void Pause()
    {
      WriteLine("\nPresiona cualquier tecla para volver atrás");
      ReadLine();
    }
  }
}
