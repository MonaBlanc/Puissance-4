# Projet Puisssance 4 WPF

## Aperçu
![Preview](https://github.com/MonaBlanc/Puisssance4/blob/master/Puissance4WPF.png?raw=true)

Le puissance 4 est une implémentation simple du jeu en C# utilisant le framework WPF. Ce projet met en œuvre le pattern architectural MVVM (Modèle-Vue-Modèle de vue).

## Fonctionnalités
- Gameplay à deux joueurs
- Plateau de jeu basé sur une grille
- Détection des motifs gagnants
- Interface utilisateur utilisant WPF

## Pour commencer
Pour exécuter le projet Morpion en local, suivez ces étapes :

1. Clonez le dépôt : git clone https://github.com/MonaBlanc/Puissance-4.git

2. Ouvrez le projet dans Visual Studio (ou votre IDE C# préféré).

3. Construisez la solution pour restaurer les dépendances.

4. Exécutez le projet.

## Structure du projet
Le projet Puissance 4 est composé des éléments suivants :

- `MainViewModel` : Cette classe représente le modèle de vue principal du jeu Puissance 4. Elle gère la logique du jeu, les tours des joueurs, la gestion de la grille et la détection des alignements gagnants.

- `CelluleViewModel` : Cette classe représente le modèle de vue pour une cellule individuelle de la grille. Elle gère l'état de la cellule et sa couleur.

- `RelayCommand` : Cette classe est une implémentation personnalisée de `ICommand` utilisée pour gérer les commandes des boutons de l'interface utilisateur.

- `ViewModelBase` : Cette classe de base implémente INotifyPropertyChanged pour faciliter la mise à jour des propriétés du modèle de vue.

- `MainWindow.xaml` : Ce fichier XAML définit la fenêtre principale du jeu, comprenant la grille du plateau de jeu et les éléments de l'interface utilisateur.

## Contribuer
Les contributions au projet sont les bienvenues. Si vous rencontrez des problèmes ou avez des suggestions d'amélioration, n'hésitez pas à ouvrir une issue ou à soumettre une pull request.
