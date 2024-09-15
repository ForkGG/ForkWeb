## server.jar custom

Fork utilise le  `server.jar` à l'intérieur du dossier de serveur pour commencer ledit serveur. Par défaur, Fork va
trouver cette version et quel type de serveur le server.jar est, mais il est possible de le remplacer par tous types de
fichier `server.jar` que vous préférez.

**ATTENTION: Le type de serveur dans Fork ne changera pas, donc si vous changez le `server.jar` Fork affichera toujours
l'ancien type. Cela veut dire que changer la version, supprimer une dimension, etc. pourrait ne pas marcher comme
souhaité!**

##### Exemple: Remplacer un `server.jar` Vanilla par un Forge pour installer des mods

1. Créez un serveur Vanilla basique dans Fork. votre dossier de Fichiers devrait ressembler à ceci:
   ![](/data/docs/screenshots/customJar1.png)
2. Maintenant vous pouvez utiliser le [Forge Installer](https://files.minecraftforge.net/net/minecraftforge/forge/) ou
   en téléchargeant le `forge.jar` directement via un site internet comme  [ServerJars](https://serverjars.com/#modded)
3. Si vous souhaitez utiliser le Forge installer, veuillez suivre les étapes suivantes:
    1. Exécutez le Forge installer et installez le serveur dans un dossier vierge  
       ![](/data/docs/screenshots/customJar2.png)
    2. Copiez le dossier `libaries` et le fichier `forge-xxx.jar` dans votre localisation de serveur définitive.
       ![](/data/docs/screenshots/customJar3.png)
4. Si vous avez directement téléchargé le  `forge-xxx.jar`, vous n'aurer pas besoin du dossier `libraries`. Mettez juste
   le fichier jar dans le dossier du serveur.
5. Supprimez le vieux `server.jar` et renommez le fichier jar que vous venez de mettre en `server.jar`
   ![](/data/docs/screenshots/customJar4.png)
6. Lancez Fork et démarrez le serveur comme vous le feriez normalement.  
   ![](/data/docs/screenshots/customJar5.png)
7. Pour ajouter des mods, glissez-les uniquement dans le dossier `mods` de votre serveur et redémarrez-le ensuite.

###### Trouver le pack pour serveur

J'ai ici décidé de
télécharger [All the Mods 10 - ATM10]( https://www.curseforge.com/minecraft/modpacks/all-the-mods-10). Il est basé sur
le modloader NeoForge. Vous pouvez évidemment d'autres packs pour serveur sur des sites
comme [Curse Forge](https://www.curseforge.com/minecraft/modpacks/). *Prenez ce que je dis avec la liberté que vous
souhaitez. Mais utilisez-la sagement* 😉.

###### Chemins

Quand vous téléchargez votre pack de serveur, gardez son contenu en dehors de `Fork` pour l'instant, nous le déplacerons
dans `Fork` quand tout sera bien mis en place. *Vous pouvez ici utiliser votre libre-arbitre et choisir d'importer le
pack dans Forge si jamais vous avez lu et compris les autres étapes*

###### Différentes étapes

1. Lancez le `startserver.bat` / `run.bat` / `start.bat`, laissez le serveur se lancer et fonctionner, vérifiez et
   distribuer ses fichiers.
   ![](/data/docs/screenshots/CSP1.png)
2. Ensuite, soyez sûr d'avoir accepté l'`EULA`, trouvé dans EULA.txt *mais ça vous le saviez déjà* 😏
   ![](/data/docs/screenshots/CSP2.png)
3. Après; lancez le serveur une fois de plus, cette fois avec `run.bat`, et vérifiez, plusieurs fois si nécéssaire,
   qu'il se lance bien entièrement. Il est possible de le vérifier avec les lignes suivantes dans vos logs / votre
   console: *(Les ports peuvent varier en fonction des libertés que vous avez prises)*
   ![](/data/docs/screenshots/CSP3.png)
4. Arrêtez le serveur de nouveau et créez un serveur Vanilla dans `Fork`, *J'ai ici ajusté ici
   le `Server Port` & `Player Slots` parce que pourquoi pas.*
   ![](/data/docs/screenshots/CSP4.png)
5. Une fois créé cliquez sûr l'icône engrenage, ensuite `server.properties`, descendez jusqu'en bas jusqu'à
   voir `Custom Startup Parameters`, et en comptant sur votre pack, le `run.bat` devrait contenir une ligne similaire à
   celle-ci:
   ![](/data/docs/screenshots/CSP5.png)
6. `Fork` ne peut pas lire cette ligne comme telle, on doit donc l'ajuster :
   `@user_jvm_args.txt @libraries/net/neoforged/neoforge/21.1.47/win_args.txt --nogui %*`
   *On retire `java` et on ajoure `--nogui`puisque qui l'aime* 👏
7. Après ajustement copiez-collez la ligne dans `Custom Startup Parameters` comme ceci:
   ![](/data/docs/screenshots/CSP6.png)
8. Ouvrez l'explorateur de fichiers, un pour le serveur Vanilla et un pour le NeoForge et remplacez les fichiers
   restants.
   ![](/data/docs/screenshots/CSP7.png)
9. Lancez le serveur dans Fork. **Petit avertissement**: *Vous alez apercevoir des erreurs `colorées` cette fois; Cela
   peut faire peur mais vous êtez grand, je crois en vous* 🫂.

##### Erreurs / Problèmes:

###### `startserver.bat` n'arrête pas de se lancer / de redémarrer

Cela est dû à une `EULA` non acceptée. Si jamais acecptée, cela recommencera encore et encore. `Solution` - *Fermer le
CMD avec CTRL+C & Y est moins inquiétant.*

###### Le serveur ne se lance pas après l'EULA

Si un autre programme utilise les `query.port`, `rcon.port`, `server-port` ou `mod ports`, cela causera l'arrêt du
serveur et ne causera pas de confit. `Solution` - *changez les ports vers un port inutilisé.*

###### `server.properties` est introuvable dans Fork

Cela peut arriver quand des fichiers clés sont supprimés, déplacés ou écrasés. `Solution` – *Finissez ce que vous
faisiez et prenez le prochain`server.properties` dans le dossier du serveur et fermez puis réouvrez `Fork`.*

###### Fichier classe non supporté version majeure

Cela peut arriver quand vous utilisez une version incorrecte / non supportée de Java comparée à celle du
server.jar `Solution` - *Trouvez le [Java](https://www.oracle.com/java/technologies/downloads/) requis pour la version
que vous soihaitez héberger.*

Si vous avez encore des questions à propos de ces étapes, le [discord]( https://discord.fork.gg/) est fait pour ça.


<!--- Translated by CapJumper --->