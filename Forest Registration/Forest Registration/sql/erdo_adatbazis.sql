-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Már 19. 18:39
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `erdo_adatbazis`
--
CREATE DATABASE IF NOT EXISTS `erdo_adatbazis` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `erdo_adatbazis`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `erdogazdalkodok`
--

CREATE TABLE IF NOT EXISTS `erdogazdalkodok` (
  `egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `cim` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`egKod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `erdogazdalkodok`
--

INSERT INTO `erdogazdalkodok` (`egKod`, `nev`, `cim`) VALUES
('DASISTKOD', 'Erdész Péter', 'Szeged Nem utca -2.'),
('Én24141442', 'Ferenczi Tamás', 'Ásotthalom Királyhalmi utca. 56.'),
('FAVAGO134252', 'Favágó János', 'Szeged Favágó utca 50.'),
('Hello There!', 'General Kenobi!', 'Halálcsillag utca 66.');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `erdok`
--

CREATE TABLE IF NOT EXISTS `erdok` (
  `erdeszeti_azonosito` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `helyrajzi_szam` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `kor` int(11) NOT NULL,
  `terulet` int(11) NOT NULL COMMENT 'Négyzetkilóméterben',
  `hasznalatId` int(11) NOT NULL,
  `egKod` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`erdeszeti_azonosito`),
  KEY `egKod` (`egKod`),
  KEY `hasznalatId` (`hasznalatId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `erdok`
--

INSERT INTO `erdok` (`erdeszeti_azonosito`, `helyrajzi_szam`, `kor`, `terulet`, `hasznalatId`, `egKod`) VALUES
('DASISTERDO422', 'LISSZABON3', 40, 5000, 4, 'Én24141442'),
('ERDO555/', 'ÁSOTTALOM22-T', 40, 1000, 1, 'DASISTKOD'),
('ERDO9', 'SZEGED54-K', 10, 870, 2, 'FAVAGO134252'),
('valamiErdo', 'ZALA203', 21, 5000, 3, 'Hello There!');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fafajok`
--

CREATE TABLE IF NOT EXISTS `fafajok` (
  `fafajId` int(11) NOT NULL AUTO_INCREMENT,
  `megnevezes` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`fafajId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `fafajok`
--

INSERT INTO `fafajok` (`fafajId`, `megnevezes`) VALUES
(1, 'Bükk'),
(2, 'Fűz fa'),
(3, 'Galagonya'),
(4, 'Gyertyán'),
(5, 'Hárs'),
(6, 'Jegenye fenyő'),
(7, 'Juhar'),
(8, 'Kecskerágó'),
(9, 'Közönséges boroka'),
(10, 'Éger');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fak`
--

CREATE TABLE IF NOT EXISTS `fak` (
  `fafajId` int(11) NOT NULL,
  `mennyiseg` int(11) NOT NULL,
  `erdeszeti_azonosito` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  KEY `fafajId` (`fafajId`),
  KEY `erdeszeti_azonosito` (`erdeszeti_azonosito`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `fak`
--

INSERT INTO `fak` (`fafajId`, `mennyiseg`, `erdeszeti_azonosito`) VALUES
(3, 400, 'DASISTERDO422'),
(2, 20, 'ERDO555/'),
(4, 200, 'ERDO9'),
(9, 111, 'valamiErdo');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fa_hasznalat_modjai`
--

CREATE TABLE IF NOT EXISTS `fa_hasznalat_modjai` (
  `hasznalatId` int(11) NOT NULL AUTO_INCREMENT,
  `megnevezes` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `rovidites` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`hasznalatId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `fa_hasznalat_modjai`
--

INSERT INTO `fa_hasznalat_modjai` (`hasznalatId`, `megnevezes`, `rovidites`) VALUES
(1, 'Tarvágás', 'TRV'),
(2, 'Tisztítás', 'Ti'),
(3, 'Egészségügyi Termelés', 'EÜ'),
(4, 'Törzskiválaszó gyérítés', 'TKGY');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE IF NOT EXISTS `felhasznalok` (
  `felhasznaloId` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `cim` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`felhasznaloId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`felhasznaloId`, `nev`, `cim`, `email`, `jelszo`) VALUES
(5, 'Ferenczi Tamás', '', 'darius.517.ft@gmail.com', 'Jelszo1'),
(6, 'Favágó Jani', '', 'favagojani@cim.hu', 'Jelszo2'),
(9, 'Bükki Jenő', '', 'bukki.jeno@citromail.hu', 'jelszo3');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlak`
--

CREATE TABLE IF NOT EXISTS `szamlak` (
  `szamlaszam` varchar(17) COLLATE utf8_hungarian_ci NOT NULL,
  `vevoId` int(11) NOT NULL,
  `teljesites_napja` date NOT NULL,
  `szamla_keletkezes` date NOT NULL,
  `kifizetes_napja` date NOT NULL,
  `lerakodasi_hely` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `felrakasi_hely` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `muveleti_lap_sorszam` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  `szallitojegy_sorszam` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`szamlaszam`),
  KEY `vevoId` (`vevoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlak`
--

INSERT INTO `szamlak` (`szamlaszam`, `vevoId`, `teljesites_napja`, `szamla_keletkezes`, `kifizetes_napja`, `lerakodasi_hely`, `felrakasi_hely`, `muveleti_lap_sorszam`, `szallitojegy_sorszam`) VALUES
('02021144-02021313', 1, '2020-03-18', '2020-03-18', '2020-03-20', 'Zala', 'Ásotthalom', 'MUV4255', 'SZAL14414'),
('28271111-11111111', 3, '2020-03-10', '2020-03-10', '2020-03-10', 'Nem Szeged', 'Nem Ásotthalom', 'MUV4255', 'SZALL1T'),
('77777777-77777777', 4, '2020-03-05', '2020-03-06', '2020-03-07', 'LERAKOHELY', 'FELRAKOHELY', 'lap222', 'szam555'),
('99999999-88888888', 2, '2020-03-09', '2020-03-09', '2020-03-09', 'Szeged', 'Tompa', 'MUV42525', 'SZALLITO53');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlatetelek`
--

CREATE TABLE IF NOT EXISTS `szamlatetelek` (
  `fafajId` int(11) NOT NULL,
  `szamlaszam` varchar(17) COLLATE utf8_hungarian_ci NOT NULL,
  `mennyiseg` int(11) NOT NULL,
  `felhasznalas_modja` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `brutto_ar` int(11) NOT NULL,
  `netto_ar` int(11) NOT NULL,
  KEY `fafajId` (`fafajId`),
  KEY `szamlaszam` (`szamlaszam`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlatetelek`
--

INSERT INTO `szamlatetelek` (`fafajId`, `szamlaszam`, `mennyiseg`, `felhasznalas_modja`, `brutto_ar`, `netto_ar`) VALUES
(1, '02021144-02021313', 100, 'Rönk', 2000000, 1000000),
(2, '28271111-11111111', 20, 'Tűzifa', 700000, 650000),
(5, '77777777-77777777', 43, 'Apríték', 400000, 370000),
(7, '99999999-88888888', 50, 'Tüzifa', 3000000, 2800000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vevok`
--

CREATE TABLE IF NOT EXISTS `vevok` (
  `vevoId` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `cim` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `technikai azonosító` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `adoszam` int(11) NOT NULL,
  PRIMARY KEY (`vevoId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `vevok`
--

INSERT INTO `vevok` (`vevoId`, `nev`, `cim`, `technikai azonosító`, `adoszam`) VALUES
(1, 'Nem én', 'Nem az enyém', 'TECH665hwwr', 55444545),
(2, 'Kertész Erik', 'Erik utcája 57', 'ERIK77777', 242442),
(3, 'Erdő Benő', 'Helyi utca 565', 'TECH5555552', 5252526),
(4, 'Valami', 'Valami valami utca 6', '2424242REKT', 25252525);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `erdok`
--
ALTER TABLE `erdok`
  ADD CONSTRAINT `erdok_ibfk_1` FOREIGN KEY (`egKod`) REFERENCES `erdogazdalkodok` (`egKod`),
  ADD CONSTRAINT `erdok_ibfk_2` FOREIGN KEY (`egKod`) REFERENCES `erdogazdalkodok` (`egKod`),
  ADD CONSTRAINT `erdok_ibfk_3` FOREIGN KEY (`hasznalatId`) REFERENCES `fa_hasznalat_modjai` (`hasznalatId`);

--
-- Megkötések a táblához `fak`
--
ALTER TABLE `fak`
  ADD CONSTRAINT `fak_ibfk_1` FOREIGN KEY (`fafajId`) REFERENCES `fafajok` (`fafajId`),
  ADD CONSTRAINT `fak_ibfk_2` FOREIGN KEY (`erdeszeti_azonosito`) REFERENCES `erdok` (`erdeszeti_azonosito`);

--
-- Megkötések a táblához `szamlak`
--
ALTER TABLE `szamlak`
  ADD CONSTRAINT `szamlak_ibfk_1` FOREIGN KEY (`vevoId`) REFERENCES `vevok` (`vevoId`);

--
-- Megkötések a táblához `szamlatetelek`
--
ALTER TABLE `szamlatetelek`
  ADD CONSTRAINT `szamlatetelek_ibfk_1` FOREIGN KEY (`fafajId`) REFERENCES `fafajok` (`fafajId`),
  ADD CONSTRAINT `szamlatetelek_ibfk_2` FOREIGN KEY (`szamlaszam`) REFERENCES `szamlak` (`szamlaszam`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
