# Ilena Music

> Actualmente la última versión del proyecto se encuentra en ```part2-playlists```, por lo que para ejecutar la aplicación en esa branch debes hacer esto desde la consola:
> - ```git pull``` // Traes todas las ramas remotas.
> - ```git checkout part2-playlists``` // Te posicionas en la rama para esta parte del trabajo.
>
> Luego de haber hecho tus cambios, los debes subir al repositorio remoto a la rama en la que actualmente todos debemos estar trabajando: 
>
> - ```git push -u origin part2-playlists```

## Instrucciones para ejecutar la aplicación

1. Instalar [Visual Studio Code (VSCode)](https://code.visualstudio.com/download)
2. Instalar [.NET Core 2.1 (el SDK de Microsoft)](https://www.microsoft.com/net/download)
3. Agrega dotnet a las variables de entorno.
4. Clonar el repositorio
5. Abrir el proyecto con VSCode
6. Ejecútalo con la consola: ```dotnet run``` 
¡Listo, a programar!

## Progreso 

> - Con *[x]* se marca cuando una tarea está completa.
> - Con *[ ]* se marca cuando aún no se ha realizado.

### Parte 1 (completada)
- [x] Lógica de la aplicación.
- [x] Menú.
- [x] Pantalla para agregar una pieza musical a la lista.
- [x] Pantalla para listar las canciones.
- [x] Pantalla para editar una canción.
- [x] Pantalla para borrar canciones por ID.
- [x] Pantalla para buscar una canción.

### Parte 2 (en progreso)

**Modificaciones de la parte 1**
- [x] Cambiar el menú de la *Parte 1* (```MenuScreen```) por este: 
    - Listar canciones (lleva al menú de la primera tarea (```MenuOneScreen```)).
    - Listas de canciones: (lleva a ```PlaylistsMenuScreen```)
    - Salir. Sale de la aplicación.

**Nuevas entidades**
- [x] Entidad ```Playlist``` (listas de canciones). Debe tener los siguientes elementos:
    - Propiedades.
        - Id
        - Nombre
        - Logo (un caracter que representa una carátula).
        - Canciones: Lista de canciones.
    - Métodos:
        - Borrar canción.


**Nuevas pantallas**
- [x] **Canciones** (```MenuOneScreen```) Lleva al menú de la tarea 1, donde la única diferencia será que, la opción de salir, en vez de decir "salir" debe decir "ir atrás".

- [x] **Listas de canciones** (```PlaylistsMenuScreen```). Muestra las siguientes opciones: 1) Agregar lista de canciones (play list), 2) listar todas las listas de caniones, 3) editar lista, 4) Borrar lista, 5) buscar canción de una lista determinada.

    1. [x] **Agregar lista de canciones** (```AddPlayListScreen```). Aquí se va a hacer una playlist con los todos los datos de la entidad ```Playlist``` mencionada con anterioridad.

    2. [x] **Lista de playlists** (```PlayListsScreen```), la cual va a mostrar todas las playlist con la siguiente información:
        - Id
        - Nombre
        - Logo
        - Cantidad de canciones
    3. [x] **Editar playlist** (```EditPlayListScreen```) (buscar por id), luego, mostrar el siguietne menú
        - Editar Nombre
        - Editar logo, 
        - Agregar canción.
        - Listar canciones.
        - Borrar canción.
        - Volver
    4. [x] **Borrar playlist** (```DeletePlayListScreen```)
    5. [x] **Buscar canción de la playlist** (```SearchPieceFromPlayListScreen```).

### Parte 3 (final)

Esta tercera parte está orientada a la reportería de las piezas. Básicamente consiste en dar la habilidad a nuestra aplicación de exportar e importar piezas. 

Solamente hay tres nuevas pantallas. A continuación, las enumero:

**Pantallas**

- **Menú de reportes** (5 puntos):
  - Pantalla:

    Elige el formato:

    1. PDF.
    2. CSV.
    3. Excel

  - Formato del reporte:
    ```
    NOMBRE DE LA LISTA

    | ID | Nombre | Artista | Genero | Album | Duracion | Calidad | Formato
    .
    .
    .


    Total de canciones: N, donde N es el número de canciones en la lista.
    ```

- **Exportar canciones** (2.5)
  1. XML.
  2. JSON

- **Importar canciones** 


**Reglas de negocio**

Se debe informar al usuario cuando se vaya a infringir alguna de estas reglas. Estas reglas no se tienen que aplicar en la importacion, de data.

1. El nombre de una playlist debe ser único. M
2. No se puede agregar dos veces la misma cancion a la misma lista.
3. Una cancion no puede pertenecer a mas de tres listas.
4. Una lista no puede tener mas de 10 canciones.
5. No pueden existir dos canciones con el mismo Nombre y Artista

- Si es muy complicado al usuario se pierden putnos. Se pierden puntos si explota el programa.

- Se va a entregar miércoles de la décima semana.

## Entidades

**Canción** (```Piece```)
- ID. (debe ser automático)
- Nombre.
- Artista.
- Álbum.
- Género.
- Duación.
- Calidad.
- Formato.

**Lista de canciones** (```Playlist```). Tiene los siguientes elementos: 

- Propiedades.
    - Id
    - Nombre
    - Logo (un caracter que representa una carátula).
    - Canciones: Lista de canciones.
- Métodos:
    - Borrar canción.

## Pantallas:

> Resumen de las pantallas de la aplicación. Éstas se encunetran anidadas para entender cómo se llega a un sitio determinado.

- **Menú** (pantalla inicial de la aplicación). Tiene estas tres opciones: Canciones, Listas de canciones, Salir:

    - **Canciones** (menú de la tarea 1). Tiene las opciones: Agregar canción, Listar todas las canciones, Editar canción, Borrar canción por ID, Buscar canción, Ir atrás
        - Agregar canción.
        - Listar todas las canciones.
        - Editar canción. 
        - Borrar canciones por ID.
        - Buscar:
            - Por artista.
            - Por género
            - Por nombre.

    - **Listas de canciones**
        - Agregar lista de canciones
        - Lista de playlists
        - Editar playlist
        - Borrar playlist
        - Buscar canción de la playlist

    - **Salir**