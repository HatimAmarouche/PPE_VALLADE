-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  ven. 08 fév. 2019 à 10:47
-- Version du serveur :  5.7.19
-- Version de PHP :  5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `ppe_valad`
--

-- --------------------------------------------------------

--
-- Structure de la table `candidater`
--

DROP TABLE IF EXISTS `candidater`;
CREATE TABLE IF NOT EXISTS `candidater` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `accepter` int(1) NOT NULL,
  `Id_Participant` int(11) NOT NULL,
  `Id_Session` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Session` (`Id_Session`),
  KEY `Id_Participant` (`Id_Participant`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `candidater`
--

INSERT INTO `candidater` (`Id`, `accepter`, `Id_Participant`, `Id_Session`) VALUES
(1, 1, 4, 5),
(2, 1, 3, 1),
(3, 0, 8, 2),
(4, 0, 1, 3),
(5, 1, 5, 2),
(6, 1, 2, 4),
(7, 1, 5, 6);

-- --------------------------------------------------------

--
-- Structure de la table `formation`
--

DROP TABLE IF EXISTS `formation`;
CREATE TABLE IF NOT EXISTS `formation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Niveau` int(11) NOT NULL,
  `Nom` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `formation`
--

INSERT INTO `formation` (`Id`, `Niveau`, `Nom`) VALUES
(1, 1, 'thé box'),
(2, 2, 'sio slam'),
(3, 2, 'sio sisr'),
(4, 3, 'licence pro'),
(5, 5, 'master');

-- --------------------------------------------------------

--
-- Structure de la table `participant`
--

DROP TABLE IF EXISTS `participant`;
CREATE TABLE IF NOT EXISTS `participant` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(100) NOT NULL,
  `Prenom` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `participant`
--

INSERT INTO `participant` (`Id`, `Nom`, `Prenom`) VALUES
(1, 'waeckel', 'theo'),
(2, 'waeckel', 'lucas'),
(3, 'waeckel', 'brandon'),
(4, 'dupont', 'yvent'),
(5, 'jean', 'kevin'),
(6, 'collin', 'delphine'),
(7, 'egot', 'guylaine'),
(8, 'guiraud', 'lucie');

-- --------------------------------------------------------

--
-- Structure de la table `session`
--

DROP TABLE IF EXISTS `session`;
CREATE TABLE IF NOT EXISTS `session` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DateDebut` date NOT NULL,
  `DateFin` date NOT NULL,
  `Id_Formation` int(11) NOT NULL,
  `Lieux` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Formation` (`Id_Formation`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `session`
--

INSERT INTO `session` (`Id`, `DateDebut`, `DateFin`, `Id_Formation`, `Lieux`) VALUES
(1, '2019-02-03', '2019-02-12', 4, 'chambly'),
(2, '2019-02-15', '2019-02-27', 5, 'chambly'),
(3, '2019-03-03', '2019-03-27', 5, 'beauvais'),
(4, '2019-03-03', '2019-03-30', 2, 'beauvais'),
(5, '2019-04-03', '2019-04-26', 3, 'beauvais'),
(6, '2019-08-10', '2019-08-30', 2, 'beauvais');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `candidater`
--
ALTER TABLE `candidater`
  ADD CONSTRAINT `candidater_ibfk_1` FOREIGN KEY (`Id_Session`) REFERENCES `session` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `candidater_ibfk_2` FOREIGN KEY (`Id_Participant`) REFERENCES `participant` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `session`
--
ALTER TABLE `session`
  ADD CONSTRAINT `session_ibfk_1` FOREIGN KEY (`Id_Formation`) REFERENCES `formation` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
