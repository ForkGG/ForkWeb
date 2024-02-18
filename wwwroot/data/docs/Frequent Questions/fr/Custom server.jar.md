## server.jar custom

Fork utilise le  `server.jar` à l'intérieur du dossier de serveur pour commencer ledit serveur. Par défaur, Fork va trouver cette version et quel type de serveur le server.jar est, mais il est possible de le remplacer par tous types de fichier `server.jar` que vous préférez.

**ATTENTION: Le type de serveur dans Fork ne changera pas, donc si vous changez le `server.jar` Fork affichera toujours l'ancien type. Cela veut dire que changer la version, supprimer une dimension, etc. pourrait ne pas marcher comme souhaité!**

##### Exemple: Remplacer un `server.jar` Vanilla par un Forge pour installer des mods
1. Créez un serveur Vanilla basique dans Fork. votre dossier de Fichiers devrait ressembler à ceci:
![](/data/docs/screenshots/customJar1.png)
2. Maintenant vous pouvez utilisert le [Forge Installer](https://files.minecraftforge.net/net/minecraftforge/forge/) ou en téléchargeant le  `forge.jar` directement via un site internet comme  [ServerJars](https://serverjars.com/#modded)
3. Si vous souhaitez utiliser le Forge installer, veuillez suivre les étapes suivantes:
   1. Exécutez le Forge installer et installez le serveur dans un dossier vierge  
      ![](/data/docs/screenshots/customJar2.png)
   2. Copiez le dossier `libaries` et le fichier `forge-xxx.jar` dans votre localisation de serveur définitive.
      ![](/data/docs/screenshots/customJar3.png)
4. Si vous avez directement téléchargé le  `forge-xxx.jar`, vous n'aurer pas besoin du dossier `libraries`. Mettez juste le fichier jar dans le dossier du serveur.
5. Supprimez le vieux `server.jar` et renommez le fichier jar que vous venez de mettre en `server.jar`
   ![](/data/docs/screenshots/customJar4.png)
6. Lancez Fork et démarrez le serveur comme vous le feriez normalement.  
   ![](/data/docs/screenshots/customJar5.png)
7. Pour ajouter des mods, glissez-les uniquement dans le dossier `mods` de votre serveur et redémarrez-le ensuite.

<!--- Translated by CapJumper --->