# Projet DAD Exia CESI
Equipe : Adrien Meltzer - Matthew Allen - Michael Jach

![alt tag](https://github.com/adrienelium/Projet-BI/blob/master/MadeInExiaCesi.jpg)

## Introduction
Le projet Développement Distribuée à pour but de développé un processus de décryptage de fichier avec les technologies WCF (Windows Communication Foundation) et J2EE.

Ci-dessous le découpage fonctionnel du projet.

![alt tag](https://github.com/adrienelium/Projet-DAD-Exia/blob/master/Documents%20annexes/DecoupageFonctionnel.png)

## Modélisation UML commentée de l’application distribuée
UML du server Front WCF.

![alt tag](https://github.com/adrienelium/Projet-DAD-Exia/blob/master/Documents%20annexes/UMLCSharpWCF.png)

On observe sur l'UML que le Front Service possède 2 entrées (EndPoint), l'un accessible depuis le réseau local uniquement et l'autre accessible depuis l'internet par les clients de l'application.

La classe DecryptSystem est le gestionnaire centrale du système, il orchestre les traitements et envois les tâches à effectué au bloc J2EE. La classe ModelUser permet d'interargir directement avec la base de données. 

## Analyse technique
L'enjeux technique majeur réside dans la génération des clés de déchiffrement, les clés sont encodées sur 48bit soit 6 caractères (1 caractère = 8bit).
En terme de complexité algorithmique cela nous donne l'équation ci-dessous :

F x C x A soit Nombre de fichier X Clé alphabétique exposant taille de la clé X Algorithme de chiffrement

L'algorithme de chiffrement symétrique imposé est le XOR.

## Analyse des écarts
Les écarts sont noté entre [].

#### Client .NET
Distribution compilée

Exécution fonctionnelle

Saisie des crédentials

Traitement asynchrone

IHM de qualité

Designs pattern

[NetTCP]

#### Serveur frontal WCF
Serveur fonctionnel

Authentification optimisée

Génération de clef

Déchiffrement

Stockage des credentials et tokens en BDD

Connexion multi-client

Journalisation des logs

Designs pattern

[Communication 128bits]

#### Java EE
Utilisation d’un queue JMS

Middleware fonctionnel

Détermination du taux de confiance

Recherche d’adresse e-mail

Comparaison avec le dictionnaire

Interface Web avec JSF

Administration du dictionnaire via l’interface Web

Stockage en base des informations du fichier 

[Envoi de données au WCF]


## Bilan
Pour conclure sur ce projet nous obersvons des temps de calcul important sur la génération de clé, en effet, pour une clé de 6 caractères, le nombre de combinaisons possible est d'environ 300 millions.

En terme de résultat nouos avons trouvé la première adresse mail, le système est toujorus en cours de génération pour trouver la deuxieme adresse mail dans les fichiers à décryptés.

#### Ressources annexes
Gitignore files : https://github.com/github/gitignore

Basic writing and formatting syntax : https://help.github.com/articles/basic-writing-and-formatting-syntax/
