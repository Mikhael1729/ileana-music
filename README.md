# Ilena Music

> Actualmente la última versión del proyecto se encuentra en ```part2-playlists```, por lo que para ejecutar la aplicación en esa branch debes hacer esto desde la consola:
> - ```git pull```
> - ```git checkout part2-playlists```

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
- [ ] Cambiar el menú de la *Parte 1* (```MenuScreen```) por este: 
    - Listar canciones (lleva al menú de la primera tarea (```MenuOneScreen```)).
    - Listas de canciones: (lleva a ```PlaylistsMenuScreen```)
    - Salir. Sale de la aplicación.

**Nuevas entidades**
- [ ] Entidad ```PlayList``` (listas de canciones). Debe tener los siguientes elementos:
    - Propiedades.
        - Id
        - Nombre
        - Logo (un caracter que representa una carátula).
        - Canciones: Lista de canciones.
    - Métodos:
        - Borrar canción.


**Nuevas pantallas**
- [ ] **Canciones** (```MenuOneScreen```) Lleva al menú de la tarea 1, donde la única diferencia será que, la opción de salir, en vez de decir "salir" debe decir "ir atrás".

- [ ] **Listas de canciones** (```PlaylistsMenuScreen```). Muestra las siguientes opciones: 1) Agregar lista de canciones (play list), 2) listar todas las listas de caniones, 3) editar lista, 4) Borrar lista, 5) buscar canción de una lista determinada.

    1. [ ] **Agregar lista de canciones** (```AddPlayListScreen```). Aquí se va a hacer una playlist con los todos los datos de la entidad ```PlayList``` mencionada con anterioridad.

    2. [ ] **Lista de playlists** (```PlayListsScreen```), la cual va a mostrar todas las playlist con la siguiente información:
        - Id
        - Nombre
        - Logo
        - Cantidad de canciones
    3. [ ] **Editar playlist** (```EditPlayListScreen```) (buscar por id), luego, mostrar el siguietne menú
        - Editar Nombre
        - Editar logo, 
        - Agregar canción.
        - Listar canciones.
        - Borrar canción.
        - Volver
    4. [ ] **Borrar playlist** (```DeletePlayListScreen```)
    5. [ ] **Buscar canción de la playlist** (```SearchPieceFromPlayListScreen```).

## Entidades principales

**Canción** (```Piece```)
- ID. (debe ser automático)
- Nombre.
- Artista.
- Álbum.
- Género.
- Duación.
- Calidad.
- Formato.

**Lista de canciones** (```PlayList```). Tiene los siguientes elementos: 

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