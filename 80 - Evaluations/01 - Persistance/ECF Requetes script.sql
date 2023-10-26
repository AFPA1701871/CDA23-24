DROP DATABASE if exists EvalCDA;
CREATE DATABASE EvalCDA;
USE EvalCDA;
--
-- Table structure for table villes_france
--

CREATE TABLE IF NOT EXISTS villes_france (
  ville_id mediumint(8) unsigned NOT NULL AUTO_INCREMENT,
  ville_departement varchar(3) DEFAULT NULL,
  ville_slug varchar(255) DEFAULT NULL UNIQUE,
  ville_nom varchar(45) DEFAULT NULL,
  ville_nom_simple varchar(45) DEFAULT NULL,
  ville_nom_reel varchar(45) DEFAULT NULL,
  ville_nom_soundex varchar(20) DEFAULT NULL,
  ville_nom_metaphone varchar(22) DEFAULT NULL,
  ville_code_postal varchar(255) DEFAULT NULL,
  ville_commune varchar(3) DEFAULT NULL,
  ville_code_commune varchar(5) NOT NULL UNIQUE,
  ville_arrondissement smallint(3) unsigned DEFAULT NULL,
  ville_canton varchar(4) DEFAULT NULL,
  ville_amdi smallint(5) unsigned DEFAULT NULL,
  ville_population_2010 mediumint(11) unsigned DEFAULT NULL,
  ville_population_1999 mediumint(11) unsigned DEFAULT NULL,
  ville_population_2012 mediumint(10) unsigned DEFAULT NULL COMMENT 'approximatif',
  ville_densite_2010 int(11) DEFAULT NULL,
  ville_surface float DEFAULT NULL,
  ville_longitude_deg float DEFAULT NULL,
  ville_latitude_deg float DEFAULT NULL,
  ville_longitude_grd varchar(9) DEFAULT NULL,
  ville_latitude_grd varchar(8) DEFAULT NULL,
  ville_longitude_dms varchar(9) DEFAULT NULL,
  ville_latitude_dms varchar(8) DEFAULT NULL,
  ville_zmin mediumint(4) DEFAULT NULL,
  ville_zmax mediumint(4) DEFAULT NULL,
  PRIMARY KEY (ville_id)
 
) ENGINE=innoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=36831 ;



--
-- Table structure for table departement
--

CREATE TABLE IF NOT EXISTS departements (
  departement_id int(11) NOT NULL AUTO_INCREMENT,
  departement_code varchar(3) CHARACTER SET utf8 DEFAULT NULL,
  departement_nom varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  departement_nom_uppercase varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  departement_slug varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  departement_nom_soundex varchar(20) DEFAULT NULL,
  departement_regionId INT NULL,
  PRIMARY KEY (departement_id)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=102 ;

CREATE TABLE IF NOT EXISTS regions (
  region_id int(11) NOT NULL AUTO_INCREMENT,
  region_nom varchar(50) NOT NULL,
  PRIMARY KEY (region_id)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;


--
-- Dumping data for table regions
--
INSERT INTO regions (region_id, region_nom) VALUES
(1, 'Auvergne-Rhône-Alpes'),
(2, 'Bourgogne-Franche-Comté'),
(3, 'Bretagne'),
(4, 'Centre-Val de Loire'),
(5, 'Corse'),
(6, 'Grand-Est'),
(7, 'Hauts-de-France'),
(8, 'Ile-de-France'),
(9, 'Normandie'),
(10, 'Nouvelle-Aquitaine'),
(11, 'Occitanie'),
(12, 'Pays de la Loire'),
(13, 'Provence-Alpes-Côte d''Azur'),
(14, 'DOM-TOM');


--
-- Dumping data for table departement
--


INSERT INTO `departements` (`departement_id`, `departement_code`, `departement_nom`, `departement_nom_uppercase`, `departement_slug`, `departement_nom_soundex`, `departement_regionId`) VALUES
(1, '01', 'Ain', 'AIN', 'ain', 'A500', 1),
(2, '02', 'Aisne', 'AISNE', 'aisne', 'A250', 7),
(3, '03', 'Allier', 'ALLIER', 'allier', 'A460', 1),
(4, '04', 'Alpes-de-Haute-Provence', 'ALPES-DE-HAUTE-PROVENCE', 'alpes-de-haute-provence', 'A412316152', 13),
(5, '05', 'Hautes-Alpes', 'HAUTES-ALPES', 'hautes-alpes', 'H32412', 13),
(6, '06', 'Alpes-Maritimes', 'ALPES-MARITIMES', 'alpes-maritimes', 'A41256352', 13),
(7, '07', 'Ardèche', 'ARDÈCHE', 'ardeche', 'A632', 1),
(8, '08', 'Ardennes', 'ARDENNES', 'ardennes', 'A6352', 6),
(9, '09', 'Ariège', 'ARIÈGE', 'ariege', 'A620', 11),
(10, '10', 'Aube', 'AUBE', 'aube', 'A100', 6),
(11, '11', 'Aude', 'AUDE', 'aude', 'A300', 11),
(12, '12', 'Aveyron', 'AVEYRON', 'aveyron', 'A165', 11),
(13, '13', 'Bouches-du-Rhône', 'BOUCHES-DU-RHÔNE', 'bouches-du-rhone', 'B2365', 13),
(14, '14', 'Calvados', 'CALVADOS', 'calvados', 'C4132', 9),
(15, '15', 'Cantal', 'CANTAL', 'cantal', 'C534', 1),
(16, '16', 'Charente', 'CHARENTE', 'charente', 'C653', 10),
(17, '17', 'Charente-Maritime', 'CHARENTE-MARITIME', 'charente-maritime', 'C6535635', 10),
(18, '18', 'Cher', 'CHER', 'cher', 'C600', 4),
(19, '19', 'Corrèze', 'CORRÈZE', 'correze', 'C620', 10),
(20, '2a', 'Corse-du-sud', 'CORSE-DU-SUD', 'corse-du-sud', 'C62323', 5),
(21, '2b', 'Haute-corse', 'HAUTE-CORSE', 'haute-corse', 'H3262', 5),
(22, '21', 'Côte-d\'or', 'CÔTE-D\'OR', 'cote-dor', 'C360', 2),
(23, '22', 'Côtes-d\'armor', 'CÔTES-D\'ARMOR', 'cotes-darmor', 'C323656', 3),
(24, '23', 'Creuse', 'CREUSE', 'creuse', 'C620', 10),
(25, '24', 'Dordogne', 'DORDOGNE', 'dordogne', 'D6325', 10),
(26, '25', 'Doubs', 'DOUBS', 'doubs', 'D120', 2),
(27, '26', 'Drôme', 'DRÔME', 'drome', 'D650', 1),
(28, '27', 'Eure', 'EURE', 'eure', 'E600', 9),
(29, '28', 'Eure-et-Loir', 'EURE-ET-LOIR', 'eure-et-loir', 'E6346', 4),
(30, '29', 'Finistère', 'FINISTÈRE', 'finistere', 'F5236', 3),
(31, '30', 'Gard', 'GARD', 'gard', 'G630', 11),
(32, '31', 'Haute-Garonne', 'HAUTE-GARONNE', 'haute-garonne', 'H3265', 11),
(33, '32', 'Gers', 'GERS', 'gers', 'G620', 11),
(34, '33', 'Gironde', 'GIRONDE', 'gironde', 'G653', 10),
(35, '34', 'Hérault', 'HÉRAULT', 'herault', 'H643', 11),
(36, '35', 'Ile-et-Vilaine', 'ILE-ET-VILAINE', 'ile-et-vilaine', 'I43145', 3),
(37, '36', 'Indre', 'INDRE', 'indre', 'I536', 4),
(38, '37', 'Indre-et-Loire', 'INDRE-ET-LOIRE', 'indre-et-loire', 'I536346', 4),
(39, '38', 'Isère', 'ISÈRE', 'isere', 'I260', 1),
(40, '39', 'Jura', 'JURA', 'jura', 'J600', 2),
(41, '40', 'Landes', 'LANDES', 'landes', 'L532', 10),
(42, '41', 'Loir-et-Cher', 'LOIR-ET-CHER', 'loir-et-cher', 'L6326', 4),
(43, '42', 'Loire', 'LOIRE', 'loire', 'L600', 1),
(44, '43', 'Haute-Loire', 'HAUTE-LOIRE', 'haute-loire', 'H346', 1),
(45, '44', 'Loire-Atlantique', 'LOIRE-ATLANTIQUE', 'loire-atlantique', 'L634532', 12),
(46, '45', 'Loiret', 'LOIRET', 'loiret', 'L630', 4),
(47, '46', 'Lot', 'LOT', 'lot', 'L300', 11),
(48, '47', 'Lot-et-Garonne', 'LOT-ET-GARONNE', 'lot-et-garonne', 'L3265', 10),
(49, '48', 'Lozère', 'LOZÈRE', 'lozere', 'L260', 11),
(50, '49', 'Maine-et-Loire', 'MAINE-ET-LOIRE', 'maine-et-loire', 'M346', 12),
(51, '50', 'Manche', 'MANCHE', 'manche', 'M200', 9),
(52, '51', 'Marne', 'MARNE', 'marne', 'M650', 6),
(53, '52', 'Haute-Marne', 'HAUTE-MARNE', 'haute-marne', 'H3565', 6),
(54, '53', 'Mayenne', 'MAYENNE', 'mayenne', 'M000', 12),
(55, '54', 'Meurthe-et-Moselle', 'MEURTHE-ET-MOSELLE', 'meurthe-et-moselle', 'M63524', 6),
(56, '55', 'Meuse', 'MEUSE', 'meuse', 'M200', 6),
(57, '56', 'Morbihan', 'MORBIHAN', 'morbihan', 'M615', 3),
(58, '57', 'Moselle', 'MOSELLE', 'moselle', 'M240', 6),
(59, '58', 'Nièvre', 'NIÈVRE', 'nievre', 'N160', 2),
(60, '59', 'Nord', 'NORD', 'nord', 'N630', 7),
(61, '60', 'Oise', 'OISE', 'oise', 'O200', 7),
(62, '61', 'Orne', 'ORNE', 'orne', 'O650', 9),
(63, '62', 'Pas-de-Calais', 'PAS-DE-CALAIS', 'pas-de-calais', 'P23242', 7),
(64, '63', 'Puy-de-Dôme', 'PUY-DE-DÔME', 'puy-de-dome', 'P350', 1),
(65, '64', 'Pyrénées-Atlantiques', 'PYRÉNÉES-ATLANTIQUES', 'pyrenees-atlantiques', 'P65234532', 10),
(66, '65', 'Hautes-Pyrénées', 'HAUTES-PYRÉNÉES', 'hautes-pyrenees', 'H321652', 11),
(67, '66', 'Pyrénées-Orientales', 'PYRÉNÉES-ORIENTALES', 'pyrenees-orientales', 'P65265342', 11),
(68, '67', 'Bas-Rhin', 'BAS-RHIN', 'bas-rhin', 'B265', 6),
(69, '68', 'Haut-Rhin', 'HAUT-RHIN', 'haut-rhin', 'H365', 6),
(70, '69', 'Rhône', 'RHÔNE', 'rhone', 'R500', 1),
(71, '70', 'Haute-Saône', 'HAUTE-SAÔNE', 'haute-saone', 'H325', 2),
(72, '71', 'Saône-et-Loire', 'SAÔNE-ET-LOIRE', 'saone-et-loire', 'S5346', 2),
(73, '72', 'Sarthe', 'SARTHE', 'sarthe', 'S630', 12),
(74, '73', 'Savoie', 'SAVOIE', 'savoie', 'S100', 1),
(75, '74', 'Haute-Savoie', 'HAUTE-SAVOIE', 'haute-savoie', 'H321', 1),
(76, '75', 'Paris', 'PARIS', 'paris', 'P620', 8),
(77, '76', 'Seine-Maritime', 'SEINE-MARITIME', 'seine-maritime', 'S5635', 9),
(78, '77', 'Seine-et-Marne', 'SEINE-ET-MARNE', 'seine-et-marne', 'S53565', 8),
(79, '78', 'Yvelines', 'YVELINES', 'yvelines', 'Y1452', 8),
(80, '79', 'Deux-Sèvres', 'DEUX-SÈVRES', 'deux-sevres', 'D2162', 10),
(81, '80', 'Somme', 'SOMME', 'somme', 'S500', 7),
(82, '81', 'Tarn', 'TARN', 'tarn', 'T650', 11),
(83, '82', 'Tarn-et-Garonne', 'TARN-ET-GARONNE', 'tarn-et-garonne', 'T653265', 11),
(84, '83', 'Var', 'VAR', 'var', 'V600', 13),
(85, '84', 'Vaucluse', 'VAUCLUSE', 'vaucluse', 'V242', 13),
(86, '85', 'Vendée', 'VENDÉE', 'vendee', 'V530', 12),
(87, '86', 'Vienne', 'VIENNE', 'vienne', 'V500', 10),
(88, '87', 'Haute-Vienne', 'HAUTE-VIENNE', 'haute-vienne', 'H315', 10),
(89, '88', 'Vosges', 'VOSGES', 'vosges', 'V200', 6),
(90, '89', 'Yonne', 'YONNE', 'yonne', 'Y500', 2),
(91, '90', 'Territoire de Belfort', 'TERRITOIRE DE BELFORT', 'territoire-de-belfort', 'T636314163', 2),
(92, '91', 'Essonne', 'ESSONNE', 'essonne', 'E250', 8),
(93, '92', 'Hauts-de-Seine', 'HAUTS-DE-SEINE', 'hauts-de-seine', 'H32325', 8),
(94, '93', 'Seine-Saint-Denis', 'SEINE-SAINT-DENIS', 'seine-saint-denis', 'S525352', 8),
(95, '94', 'Val-de-Marne', 'VAL-DE-MARNE', 'val-de-marne', 'V43565', 8),
(96, '95', 'Val-d\'oise', 'VAL-D\'OISE', 'val-doise', 'V432', 8),
(97, '976', 'Mayotte', 'MAYOTTE', 'mayotte', 'M300', 23),
(98, '971', 'Guadeloupe', 'GUADELOUPE', 'guadeloupe', 'G341', 14),
(99, '973', 'Guyane', 'GUYANE', 'guyane', 'G500', 14),
(100, '972', 'Martinique', 'MARTINIQUE', 'martinique', 'M6352', 14),
(101, '974', 'Réunion', 'RÉUNION', 'reunion', 'R500', 14);


