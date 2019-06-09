-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  Dim 09 juin 2019 à 11:16
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
-- Base de données :  `ppe_vallade`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `RenseignerIdSession`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `RenseignerIdSession` (IN `id_participant` INT(11), IN `id_session` INT(11))  NO SQL
BEGIN
UPDATE participant SET participant.idsession = id_session WHERE participant.id = id_participant;
END$$

DELIMITER ;

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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `formation`
--

INSERT INTO `formation` (`Id`, `Niveau`, `Nom`) VALUES
(1, 2, 'Dresser une belle table'),
(2, 3, 'Harmoniser mets et vins'),
(3, 1, '‘Cuisiner les fruits de mer’,'),
(4, 1, '‘Cuisiner les fruits de mer’,'),
(5, 1, 'Dégustation des\r\nvins de Bordeaux');

-- --------------------------------------------------------

--
-- Structure de la table `participant`
--

DROP TABLE IF EXISTS `participant`;
CREATE TABLE IF NOT EXISTS `participant` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(100) NOT NULL,
  `Prenom` varchar(100) NOT NULL,
  `idsession` int(11) DEFAULT NULL,
  `Numero` varchar(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idsession` (`idsession`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `participant`
--

INSERT INTO `participant` (`id`, `Nom`, `Prenom`, `idsession`, `Numero`) VALUES
(1, 'Kristi', 'Maffini', 18, '0615624567'),
(2, 'Vasili', 'Steeden', 13, '7459131042'),
(3, 'Eugine', 'Nutter', 15, '3156864981'),
(4, 'Meade', 'De Laspee', 17, '1207437110'),
(5, 'Elihu', 'Giovannacci', 17, '5455681898'),
(6, 'Antonius', 'Onion', 15, '3457481478'),
(7, 'Kaleb', 'Glaisner', NULL, '3089909505'),
(8, 'Tymon', 'Mort', NULL, '8269373288'),
(9, 'Janeen', 'Folli', 16, '9498690842'),
(10, 'Arron', 'Laydon', 18, '1489323501'),
(16, 'Amarouche', 'Hatim', NULL, '0615624567'),
(18, 'Tekky', 'Rémi', NULL, '0615423256');

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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `session`
--

INSERT INTO `session` (`Id`, `DateDebut`, `DateFin`, `Id_Formation`, `Lieux`) VALUES
(13, '2019-06-10', '2019-06-11', 1, 'Tremblay'),
(14, '2019-06-13', '2019-06-14', 1, 'Paris'),
(15, '2019-06-13', '2019-06-14', 3, 'Marseille'),
(16, '2019-04-09', '2019-04-10', 4, 'Nice'),
(17, '2019-07-10', '2019-07-11', 5, 'Rennes'),
(18, '2019-03-06', '2019-03-07', 2, 'Lille'),
(19, '2019-06-26', '2019-06-27', 2, 'Brest'),
(20, '2019-06-13', '2019-06-20', 4, 'Lyon');

-- --------------------------------------------------------

--
-- Structure de la table `souhait`
--

DROP TABLE IF EXISTS `souhait`;
CREATE TABLE IF NOT EXISTS `souhait` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_participant` int(11) NOT NULL,
  `id_session` int(11) NOT NULL,
  `accepter` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_session` (`id_session`),
  KEY `id_participant` (`id_participant`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `souhait`
--

INSERT INTO `souhait` (`id`, `id_participant`, `id_session`, `accepter`) VALUES
(6, 16, 13, 1),
(10, 2, 13, 1);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ndc` varchar(255) NOT NULL,
  `mdp` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
  `date_co` datetime DEFAULT NULL,
  `nbtentative` int(11) DEFAULT NULL,
  `etat` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`id`, `ndc`, `mdp`, `level`, `date_co`, `nbtentative`, `etat`) VALUES
(1, 'admin', 'admin123', 3, '2019-06-09 12:12:07', 0, NULL),
(2, 'gest', 'gest123', 2, '2019-06-09 12:12:20', 0, NULL),
(3, 'user', 'user123', 1, '2019-06-09 12:13:09', 0, NULL);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `participant`
--
ALTER TABLE `participant`
  ADD CONSTRAINT `participant_ibfk_1` FOREIGN KEY (`idsession`) REFERENCES `session` (`Id`);

--
-- Contraintes pour la table `session`
--
ALTER TABLE `session`
  ADD CONSTRAINT `session_ibfk_1` FOREIGN KEY (`Id_Formation`) REFERENCES `formation` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `souhait`
--
ALTER TABLE `souhait`
  ADD CONSTRAINT `souhait_ibfk_1` FOREIGN KEY (`id_participant`) REFERENCES `participant` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `souhait_ibfk_2` FOREIGN KEY (`id_session`) REFERENCES `session` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
