## Custom server.jar

Fork usa el `server.jar` que está dentro de la carpeta de tu servidor, para iniciar dicho servidor de Minecraft. Por defecto. Fork manejará la versión y que  tipo de server.jar es, pero puedes reemplazar manualmente el archivo con cualquier `server.jar` que quieras.

**ADVERTENCIA: El tipo de servidor en Fork no cambiará, así que si reemplazas el `server.jar` Fork aún mostrará en pantalla el tipo anterior. Esto significa que, funciones de ese estilo, como cambiar de version, borrar una dimension, etc. Podrían no funcionar correctamente!**

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
 
<!--- Translated by Supraim --->