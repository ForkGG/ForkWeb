## Custom server.jar

`Fork` can be used to launch all sorts of servers; `Fork` does this by looking for `server.jar` inside your server folder to start the given Minecraft server. By default `Fork` will manage what version and what server type the `server.jar` is, but you can manually replace the file with any `server.jar` file you like.

**WARNING: The type of the server in `Fork` will not change, so if you replace the `server.jar` Fork will still display the old type. These methods are not officially supported and will not be updated via `Fork` when an update is available for your server pack, you will need to manually manage the version / world files.**

##### Example: Replacing a Vanilla `server.jar` with Forge to install mods
1. Create a basic Vanilla server in `Fork`. Your server folder should look like this now:
![](/data/docs/screenshots/customJar1.png)
2. Now you can either continue by using the [Forge Installer](https://files.minecraftforge.net/net/minecraftforge/forge/) or by downloading the `forge.jar` directly from a website like [ServerJars](https://serverjars.com/#modded)
3. If you choose to use the Forge Installer you need to follow the following steps:
   i. Execute the Forge Installer and install a server in an empty directory  
      ![](/data/docs/screenshots/customJar2.png)
   ii. Copy the created `libaries` folder and the `forge-xxx.jar` into your server folder
      ![](/data/docs/screenshots/customJar3.png)
4. If you have downloaded the `forge-xxx.jar` directly, you do not need the `libraries` folder. Just put the jar file in your server folder
5. Delete the old `server.jar` and rename the new jar file to `server.jar`
   ![](/data/docs/screenshots/customJar4.png)
6. Launch Fork and start the server as you would otherwise  
   ![](/data/docs/screenshots/customJar5.png)
7. To add mods, manually drag them into the `mods` folder of your server and restart it afterwards
 
##### Example: Configuring a Vanilla `Custom Startup Paremeters` to launch Forge for modded installs

This guide will showcase how to setup a Forge server that does not use the simple / newer `forge-xxxxx-shim.jar`.

###### Finding the server pack
I have chosen to download [All the Mods 10 - ATM10]( https://www.curseforge.com/minecraft/modpacks/all-the-mods-10) this is based on the NeoForge mod loader, you can of course find other server packs in places like [Curse Forge](https://www.curseforge.com/minecraft/modpacks/). *Take anything I say with a wide berth on your choice of server pack, use that free will wisely* 😉.
###### Locations
When you download your server pack keep the contents outside of `Fork` for the time being, we will be moving them into `Fork` once fully setup. *You can use free will and choose to import the server pack into Forge if you read and understood the other steps.*
###### Steps
1. Run the `startserver.bat` / `run.bat` / `start.bat`, let the server run, check, create and distribute its files.
   ![](/data/docs/screenshots/CSP1.png)
2. Once complete, make sure you accept the `EULA`, this can be found in EULA.txt *but you already knew that* 😏
   ![](/data/docs/screenshots/CSP2.png)
3. Next, run the server once more, this time using `run.bat`, make sure it starts up and you can see it has started fully. You can confirm its working with the below lines in your logs / console: *(Port may vary based on free will)*
   ![](/data/docs/screenshots/CSP3.png)
4. Stop the server and make a Vanilla server in `Fork`, *I adjusted the `Server Port` & `Player Slots` cause free will and what not.*
   ![](/data/docs/screenshots/CSP4.png)
5. Once created click the cog wheel icon, then `server.properties`, scroll to the bottom until you see `Custom Startup Parameters`, counting on your server pack, the `run.bat` should contain a similar line to this:
   ![](/data/docs/screenshots/CSP5.png)
6. `Fork` cannot read this line as is, so we will need to adjust it: 
`@user_jvm_args.txt @libraries/net/neoforged/neoforge/21.1.47/win_args.txt --nogui %*`
*Removing `java` & adding `--nogui` because nobody likes either* 👏
7. Once adjusted paste the line into `Custom Startup Parameters` like so:
   ![](/data/docs/screenshots/CSP6.png)
8. Open file explorer, one for the Vanilla server and one for the Neoforge server files, I suggest deleting everything in the Vanilla server path, apart from `server.properties`, transfer in the Neoforge files and replace remaining files.
   ![](/data/docs/screenshots/CSP7.png)
9. Start the server in Fork. **Little warning**: *You will see errors with `colour` this time, it can be scary but you`re a big person, I believe in you* 🫂.

##### Errors / Issues:
###### `startserver.bat` keeps looping / restarting
Found that is due to the `EULA` not being accepted and will keep happening until done. `Solution` - *I find closing the CMD with CTRL+C & Y less worrying.* 
###### Server failed to boot after EULA
Found that if you are running something on the `query.port`, `rcon.port`, `server-port` or `mod ports` it will cause the server to stop as to not cause a conflict. `Solution` - *change the ports to something unused / not bound.*
###### `server.properties` is missing in Fork
Can occur when key files are deleted / moved or overwritten. `Solution` – *Finish what you started and get the next `server.properties` in the server location, then close and reopen `Fork`.*
###### Unsupported class file major version
This can happen when you are using an incorrect / incompatible version of Java compared to the server.jar version. `Solution` - *Find the relevant [Java](https://www.oracle.com/java/technologies/downloads/) for the version you wish to host.*


If you do have more questions about this process, feel free to hop in the [discord]( https://discord.fork.gg/) with your *free will* and ask about.