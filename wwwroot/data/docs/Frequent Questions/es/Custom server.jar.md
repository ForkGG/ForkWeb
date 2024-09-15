## Custom server.jar

`Fork` puede ser utilizado para ejecutar varios tipos de servidores. `Fork` hace esto al observar el `server.jar` dentro de la carpeta de tu servidor, para poder iniciarlo. Por defecto, `Fork` manejará la versión y que  tipo de `server.jar` es, pero puedes reemplazar manualmente el archivo con cualquier `server.jar` que quieras.

**ADVERTENCIA: El tipo de servidor en `Fork` no cambiará, así que si reemplazas el `server.jar` Fork aún mostrará en pantalla el tipo anterior. Estos métodos no están soportados oficialmente, y no serán actualizados vía `Fork` cuando haya una actualización disponible para tu server pack, necesitarás manejar manualmente la versión / archivos del mundo**

##### Ejemplo: Reemplazar un `server.jar` Vanilla con Forge para instalar mods.
1. Crear un servidor Vanilla básico en Fork. Tu servidor debería verse así ahora:
![](/data/docs/screenshots/customJar1.png)
2. Ahora puedes continuar usando el [Forge Installer](https://files.minecraftforge.net/net/minecraftforge/forge/) o descargando el `forge.jar` directamente desde un sitio web como [ServerJars](https://serverjars.com/#modded)
3. Si decides utilizar el Forge Installer necesitas seguir los siguientes pasos:
   1. Ejecutar el Forge Installer e instalar un servidor en un directorio vacío.  
      ![](/data/docs/screenshots/customJar2.png)
   2. Copiar la carpeta `libaries` y el `forge-xxx.jar` dentro de la carpeta de tu servidor.
      ![](/data/docs/screenshots/customJar3.png)
4. Si has descargado directamente el `forge-xxx.jar`, no necesitas la carpeta `libraries`. Solo pon el archivo jar en la carpeta de tu servidor.
5. Eliminar el antiguo `server.jar` y renombrar el nuevo archivo jar como: `server.jar`.
   ![](/data/docs/screenshots/customJar4.png)
6. Ejecutar Fork e iniciar el servidor como lo harías normalmente.
   ![](/data/docs/screenshots/customJar5.png)
7. Para agregar mods, arrástralos manualmente dentro de la carpeta `mods` de tu servidor, y luego reiniciarlo.
 
##### Ejemplo: Configurando `Custom Startup Paremeters` en Vanilla para lanzar Forge en instalaciones con mods.

Esta guía mostrará cómo configurar un servidor Forge que no utiliza el sencillo o nuevo `forge-xxxxx-shim.jar`.

###### Eligiendo el server pack
He elegido descargar [All the Mods 10 - ATM10]( https://www.curseforge.com/minecraft/modpacks/all-the-mods-10) esto es basado en el NeoForge mod loader, por supuesto que puedes elegir otro server pack en lugares como [Curse Forge](https://www.curseforge.com/minecraft/modpacks/). *Toma todo lo que dije sobre escoger el server pack de ejemplo, puedes usar el que desees* 😉.
###### Ubicaciones
Cuando descargues el server pack, guarda los contenidos fuera de `Fork` de momento, los moveremos a `Fork` cuando esté todo listo. *Puedes usar tu libre elección y elegir importar el server pack en Forge si lees y entiendes los otros pasos.*
###### Pasos
1. Ejecuta el `startserver.bat` / `run.bat` / `start.bat`, deja que el servidor inicie, corrobore, cree y distribuya sus archivos.
   ![](/data/docs/screenshots/CSP1.png)
2. Hecho esto, asegúrate de aceptar el `EULA` , esto lo encuentras en el EULTA.txt *Aunque eso ya lo sabías* 😏
   ![](/data/docs/screenshots/CSP2.png)
3. Ahora, ejecuta el servidor nuevamente, esta vez utilizando el `run.bat`, asegúrate de que comience y se ejecute exitosamente.  Puedes confirmar que está funcionando con las líneas a continuación en tus registros / consola: *(El puerto puede variar según tu elección)*
   ![](/data/docs/screenshots/CSP3.png)
4. Detén el servidor y crea un servidor Vanilla en `Fork`, *Ajusté el `Server Port` & `Player Slots` aunque esta es una elección libre.*
   ![](/data/docs/screenshots/CSP4.png)
5. Una vez creado, haz click en el engranaje, luego en `server.properties`, haz scroll hasta abajo, hasta que veas los `Custom Startup Parameters`, dependiendo de tu server pack, el `run.bat` debería contener una línea similar a esta:
   ![](/data/docs/screenshots/CSP5.png)
6. `Fork` no puede leer esta línea tal cual, así que debemos ajustarla a: 
`@user_jvm_args.txt @libraries/net/neoforged/neoforge/21.1.47/win_args.txt --nogui %*`
*Removiendo `java` & agregando `--nogui` porque a nadie le gusta tampoco* 👏
7. Hecho esto, pega la nueva línea en `Custom Startup Parameters` así:
   ![](/data/docs/screenshots/CSP6.png)
8. Abre el explorador de archivos, uno para el servidor Vanilla y otro para los archivos del servidor Neoforge,  sugiero que elimines todo en la ruta del servidor Vanilla, aparte de `server.properties`, transfieras los archivos de Neoforge y reemplaces los archivos restantes.
   ![](/data/docs/screenshots/CSP7.png)
9. Inicia el servidor en Fork. **Pequeña advertencia**: *Verás errores con `colour` esta vez, puede ser tenebroso pero eres una gran persona, confío en ti* 🫂.

##### Errores / Problemas:
###### `startserver.bat` se mantiene en bucle o reiniciando
Esto es debido a que el `EULA` no ha sido aceptado y seguirá ocurriendo hasta que lo esté. `Solution` - *Cierra el CMD con CTL+C & no se preocupe.*
###### El servidor falla al comienzo después del EULA
Si estás ejecutando algo en `query.port`, `rcon.port`, `server-port` o `mod ports` hará que el servidor se detenga para no causar conflictos. `Solution` - *Cambia los puertos y pon unos que no estén en uso.*
###### `server.properties` no se encuentra en Fork
Puede ocurrir cuando archivos clave son borrados / movidos o sobreescritos. `Solution` - *Detén el servidor y consigue el archivo de `server.properties` en la ubicación del servidor, después cierra y vuelve a abrir `Fork`.*
###### Clase no soportada en la versión mayor
Esto puede suceder cuando estás utilizando una versión incorrecta o incompatible de Java en comparación con la versión de server.jar. `Solution` - *Encuentra la versión de [Java](https://www.oracle.com/java/technologies/downloads/) para la versión de minecraft que deseas hostear.*


Si tienes mas preguntas acerca de este proceso, siéntete libre de preguntar en [discord]( https://discord.fork.gg/)
<!--- Translated by Supraim --->