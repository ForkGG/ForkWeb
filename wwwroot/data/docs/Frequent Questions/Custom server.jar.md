## Custom server.jar

Fork is using the `server.jar` inside your server folder to start the given Minecraft server. By default Fork will manage what version and what server type the server.jar is, but you can manually replace the file with any `server.jar` file you like.

**WARNING: The type of the server in Fork will not change, so if you replace the `server.jar` Fork will still display the old type. This means, that features, like changing the version, deleting a dimension etc. might not work as expected!**

##### Example: Replacing a Vanilla `server.jar` with Forge to install mods
1. Create a basic Vanilla server in Fork. Your server folder should look like this now:
![](/data/docs/screenshots/customJar1.png)
2. Now you can either continue by using the [Forge Installer](https://files.minecraftforge.net/net/minecraftforge/forge/) or by downloading the `forge.jar` directly from a website like [ServerJars](https://serverjars.com/#modded)
3. If you choose to use the Forge Installer you need to follow the following steps:
   1. Execute the Forge Installer and install a server in an empty directory  
      ![](/data/docs/screenshots/customJar2.png)
   2. Copy the created `libaries` folder and the `forge-xxx.jar` into your server folder
      ![](/data/docs/screenshots/customJar3.png)
4. If you have downloaded the `forge-xxx.jar` directly, you do not need the `libraries` folder. Just put the jar file in your server folder
5. Delete the old `server.jar` and rename the new jar file to `server.jar`
   ![](/data/docs/screenshots/customJar4.png)
6. Launch Fork and start the server as you would otherwise  
   ![](/data/docs/screenshots/customJar5.png)
7. To add mods, manually drag them into the `mods` folder of your server and restart it afterwards
 