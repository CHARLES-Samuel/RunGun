# 🎮 RunGun

Bienvenue sur le dépôt de **RunGun** ! C'est ici que je pose les bases de mon **tout premier vrai projet Unity**. 

## 🎯 À propos du projet
L'objectif de ce projet est de me lancer pour de bon dans la création de jeux vidéo. Actuellement en plein développement, je construis les fondations brique par brique, en commençant par expérimenter et prototyper la mécanique principale du jeu. 

Étant donné que c'est une grande première pour moi, ce dépôt va évoluer au fil de mes apprentissages, de mes tests et de mes réussites (et de quelques bugs, sûrement !).

## 🛠️ Ce qu'on y trouve pour l'instant
### v0.1 - Prototype de test de la mécanique principale (Fini)
*(Pour plus d'infos, je vous renvoie vers la release : [v0.1](https://github.com/CHARLES-Samuel/RunGun/releases#release-v0.1) )*
* Déplacement du joueur automatique (auto-runner)
* Système de saut fluide (j'essaie d'améliorer au plus le game feel)
* Système de vie
* Arme basique tirant des balles
* Ennemi simple qui nous tire dessus
* Piège infligeant des dégâts
* Punition du joueur s'il reste bloqué

### v0.2 - Construction d'une base solide pour le futur (En cours)
* Intégration des différents types d'armes (SMG, Assault Rifle, Shotgun, Sniper).
* Ajout d'un système de points de vie pour les ennemis.
* Implémentation du système de pièces (ramassage en jeu).
* Création d'une interface de boutique dans le menu principal.
* Déblocage et achat des armes via l'argent récolté en jeu.
* Système de sélection et d'équipement de l'arme directement depuis le menu.
* L'inventaire, les pièces en banque et l'arme équipée sont désormais sauvegardés de manière permanente.
* Refonte des interfaces (Boutique, Compteurs de pièces) avec un système d'Événements (`Action`)
* Le menu lit dynamiquement les prix et les informations depuis un catalogue de `ScriptableObjects`, facilitant l'ajout futur de nouveau contenu.

## 🎮 Comment jouer (Tester le prototype)
1. Accédez aux téléchargements : [Télécharger la dernière Release](https://github.com/CHARLES-Samuel/RunGun/releases#release-v0.1)
2. Téléchargez le fichier `.zip` correspondant à votre système (Windows ou Linux) dans la section **Assets**.
3. **Faites un clic-droit sur le fichier et choisissez "Extraire tout"** pour décompresser le dossier complet.

**🪟 Pour les joueurs Windows :**
* Ouvrez le dossier extrait et double-cliquez sur l'exécutable (`RunnerMobile.exe`).
* *Note : Si Windows Defender affiche un écran bleu de protection, cliquez sur "Informations complémentaires" puis sur "Exécuter quand même".*

**🐧 Pour les joueurs Linux :**
* Ouvrez le dossier extrait et double-cliquez sur le fichier (`v0.1.x86_64`). Si le jeu ne veut pas se lancer directement, il faut lui donner les droits d'exécution.
* Faites un *Clic-droit > Propriétés > Autoriser l'exécution comme un programme*.
* *(Alternative terminal : ouvrez un terminal dans le dossier et tapez `chmod +x v0.1.x86_64`)*.
* Lancez ensuite le fichier exécutable !

## 🚀 Prochaines étapes
* Affiner la mécanique principale et le game feel.
* Mise en place d'une structuration solide des armes, des pièges et des ennemis pour le futur.
* Ajouter une vraie navigation de jeu entre les menus.

## 🔮 Ma vision pour le futur du jeu
Ce prototype n'est que le début. Voici la direction que j'aimerais prendre pour transformer cette mécanique de base en un jeu complet :

* **Progression et Améliorations :** Les ennemis auront des barres de vie et deviendront de plus en plus forts au fil des niveaux. Pour y faire face, il faudra récolter des pièces permettant d'améliorer ses armes (dégâts, capacité du chargeur, portée, ou même le type de munitions).
* **Mode Infini :** En plus des niveaux classiques, j'aimerais créer un mode "Endless" où le but sera de survivre et d'aller le plus loin possible.
* **Objets Bonus (Power-ups) :** L'ajout de bonus temporaires à ramasser en cours de partie pour se sortir des situations difficiles et booster ses statistiques.
* **Le mot de la fin :** J'ai encore des dizaines d'autres idées en tête ! Je n'ai peut-être pas encore toutes les compétences techniques pour les réaliser aujourd'hui, mais c'est **exactement** le but de ce projet : apprendre en pratiquant et repousser mes limites.
---
*Dans le but de devenir meilleur*
