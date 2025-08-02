-- --------------------------------------------------------
-- Sunucu:                       127.0.0.1
-- Sunucu sürümü:                8.0.42 - MySQL Community Server - GPL
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               12.11.0.7065
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- yektamak_erp için veritabanı yapısı dökülüyor
CREATE DATABASE IF NOT EXISTS `yektamak_erp` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `yektamak_erp`;

-- tablo yapısı dökülüyor yektamak_erp.alan
CREATE TABLE IF NOT EXISTS `alan` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MenuId` int NOT NULL,
  `AlanAd` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_alan_MenuId` (`MenuId`),
  CONSTRAINT `FK_alan_menu_MenuId` FOREIGN KEY (`MenuId`) REFERENCES `menu` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.alan: ~32 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `alan` (`Id`, `MenuId`, `AlanAd`) VALUES
	(1, 1, 'Personel Kod'),
	(2, 1, 'Personel Ad'),
	(3, 1, 'Personel Telefon'),
	(4, 1, 'Personel Mail'),
	(5, 1, 'Pozisyon Adı'),
	(6, 1, 'Firma Adı'),
	(7, 1, 'Personel Resim'),
	(8, 1, 'Ad'),
	(10, 1, 'Personel Yönetici Personeli Adı'),
	(11, 3, 'Firma Kodu'),
	(12, 3, 'Firma Adı'),
	(13, 3, 'Firma Adres'),
	(14, 3, 'Firma Şehir'),
	(15, 3, 'Firma Ülke'),
	(16, 3, 'Firma Vergi Dairesi'),
	(17, 3, 'Firma Vergi No'),
	(18, 3, 'Firma Logo Cari Kodu'),
	(19, 3, 'Firma Telefon'),
	(20, 3, 'Firma Faks'),
	(21, 3, 'Firma Mail'),
	(22, 5, 'Kullanıcı Ad'),
	(23, 5, 'Kullanıcı Şifre Kodu'),
	(24, 5, 'Kullanıcı Salt Kodu'),
	(25, 5, 'Kullanıcı Personel Adı'),
	(26, 5, 'Kullanıcı Rol Adı'),
	(27, 5, 'Kullanıcı Şifre Değiştirdi Mi'),
	(28, 5, 'Kullanıcı Oluşturma Tarihi'),
	(29, 5, 'Kullanıcıyı Oluşturan Kullanıcı Adı '),
	(30, 7, 'Rol Adı'),
	(31, 7, 'Rol Kodu'),
	(32, 7, 'Rol İşlemleri'),
	(33, 8, 'Rol Ekle');

-- tablo yapısı dökülüyor yektamak_erp.alanyetki
CREATE TABLE IF NOT EXISTS `alanyetki` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AlanId` int NOT NULL,
  `KullaniciId` int NOT NULL,
  `Yetki` tinyint(1) NOT NULL,
  `DuzenlemeYetki` tinyint(1) NOT NULL DEFAULT '0',
  `GormeYetki` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_alanyetki_AlanId` (`AlanId`),
  KEY `IX_alanyetki_KullaniciId` (`KullaniciId`),
  CONSTRAINT `FK_alanyetki_alan_AlanId` FOREIGN KEY (`AlanId`) REFERENCES `alan` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_alanyetki_kullanici_KullaniciId` FOREIGN KEY (`KullaniciId`) REFERENCES `kullanici` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.alanyetki: ~4 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `alanyetki` (`Id`, `AlanId`, `KullaniciId`, `Yetki`, `DuzenlemeYetki`, `GormeYetki`) VALUES
	(1, 6, 1, 1, 1, 1),
	(2, 12, 1, 1, 1, 1),
	(3, 13, 1, 1, 1, 1),
	(4, 20, 1, 1, 1, 1);

-- tablo yapısı dökülüyor yektamak_erp.ekran
CREATE TABLE IF NOT EXISTS `ekran` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SiraNo` int DEFAULT NULL,
  `MenuId` int NOT NULL,
  `AltMenuId` int DEFAULT NULL,
  `CreateDate` datetime(6) DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Ad` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.ekran: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `ekran` (`Id`, `SiraNo`, `MenuId`, `AltMenuId`, `CreateDate`, `CreatedBy`, `UpdateDate`, `UpdatedBy`, `Ad`) VALUES
	(1, 1, 1, NULL, '2025-07-03 10:47:57.000000', NULL, NULL, NULL, 'PersonelListele');

-- tablo yapısı dökülüyor yektamak_erp.firma
CREATE TABLE IF NOT EXISTS `firma` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Adres` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `SehirId` int DEFAULT NULL,
  `UlkeId` int DEFAULT NULL,
  `VergiDairesi` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `LogoFirmaId` int DEFAULT NULL,
  `LogoCariKod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `VergiNo` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Telefon` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Faks` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Mail` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PostaKodu` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `SehirId1` int DEFAULT NULL,
  `UlkeId1` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_firma_SehirId` (`SehirId`),
  KEY `IX_firma_SehirId1` (`SehirId1`),
  KEY `IX_firma_UlkeId` (`UlkeId`),
  KEY `IX_firma_UlkeId1` (`UlkeId1`),
  CONSTRAINT `FK_firma_sehir_SehirId` FOREIGN KEY (`SehirId`) REFERENCES `sehir` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_firma_sehir_SehirId1` FOREIGN KEY (`SehirId1`) REFERENCES `sehir` (`Id`),
  CONSTRAINT `FK_firma_ulke_UlkeId` FOREIGN KEY (`UlkeId`) REFERENCES `ulke` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_firma_ulke_UlkeId1` FOREIGN KEY (`UlkeId1`) REFERENCES `ulke` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.firma: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `firma` (`Id`, `Kod`, `Ad`, `Adres`, `SehirId`, `UlkeId`, `VergiDairesi`, `LogoFirmaId`, `LogoCariKod`, `VergiNo`, `Telefon`, `Faks`, `Mail`, `PostaKodu`, `SehirId1`, `UlkeId1`) VALUES
	(1, '54000', 'Yektamak Mühendislik', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '-', NULL, '-', NULL, NULL, NULL),
	(2, 'BKR', 'Baykar Mühendislik', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '06', NULL, 'baykar@baykar.com', NULL, NULL, NULL),
	(3, 'TSŞ', 'TUSAŞ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.hammadde
CREATE TABLE IF NOT EXISTS `hammadde` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.hammadde: ~12 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `hammadde` (`Id`, `Kod`, `Ad`) VALUES
	(4, NULL, 'NPU100 NPU PROFİL ST37'),
	(5, NULL, '50*50*6 KUTU PROFİL ST37'),
	(6, NULL, 'NPU120 NPU PROFİL ST37'),
	(7, NULL, '50*50*4 KUTU PROFİL ST37'),
	(8, NULL, '80*80*5 PROFİL GRUBU ST37'),
	(9, NULL, 'NPI220 NPI PROFİL ST37'),
	(10, NULL, 'NPI140 NPI PROFİL ST37'),
	(11, NULL, 'NPU160 NPU PROFİL ST37'),
	(12, NULL, 'NPI160 NPI PROFİL ST37'),
	(13, NULL, '120*120*5 KUTU PROFİL ST37'),
	(14, NULL, '80*80*5 KUTU PROFİL ST37'),
	(15, NULL, 'NPI120 NPI PROFİL ST37');

-- tablo yapısı dökülüyor yektamak_erp.kullanici
CREATE TABLE IF NOT EXISTS `kullanici` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sifre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Salt` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PersonelId` int DEFAULT NULL,
  `RolId` int DEFAULT NULL,
  `IsSifreDegisti` tinyint(1) DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `RolId1` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_kullanici_PersonelId` (`PersonelId`),
  KEY `IX_kullanici_RolId` (`RolId`),
  KEY `IX_kullanici_RolId1` (`RolId1`),
  CONSTRAINT `FK_kullanici_personel_PersonelId` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_kullanici_rol_RolId` FOREIGN KEY (`RolId`) REFERENCES `rol` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_kullanici_rol_RolId1` FOREIGN KEY (`RolId1`) REFERENCES `rol` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.kullanici: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `kullanici` (`Id`, `Ad`, `Kod`, `Sifre`, `Salt`, `PersonelId`, `RolId`, `IsSifreDegisti`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`, `RolId1`) VALUES
	(1, 'Abdurrahman', 'abd32', 'BAhQjilpbnyDIQWCnDvPk6z6x+5K/NMdH/gXA8K4gno=', 'kzIeSpn9B299+lDe1mAbNA==', 2, 1, 1, '2025-07-02 15:33:28.367957', NULL, NULL, '2025-07-03 13:33:30.096977', NULL, 'ABDURRAHMAN', NULL),
	(4, 'cevdet', 'cevdet', 'dPCIiaXqs96NbUoUOFjDQ8xr50MXTw1p/NiZ7AENvQY=', 'b1OhWaBS7I9nRYeOdHtp2g==', 6, 1, 0, '2025-07-07 16:11:39.672231', NULL, NULL, '2025-07-14 13:28:07.742382', NULL, 'ABDURRAHMAN', NULL),
	(5, 'Bünyamin', 'bboz', 'ovPtD8wo7CXVRQyq3U2UGIlxzMsRc5jFNtGa4Z8Vvko=', 'qK9dRFTPeZAoF5U0kb2Ocg==', 8, 4, 1, '2025-07-09 14:56:59.216578', NULL, NULL, '2025-07-22 16:26:54.201634', NULL, 'ABDURRAHMAN', NULL);

-- tablo yapısı dökülüyor yektamak_erp.malzemealtgrup
CREATE TABLE IF NOT EXISTS `malzemealtgrup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MalzemeGrupId` int DEFAULT NULL,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PdfVar` tinyint(1) NOT NULL,
  `DxfVar` tinyint(1) NOT NULL,
  `StepVar` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_malzemealtgrup_MalzemeGrupId` (`MalzemeGrupId`),
  CONSTRAINT `FK_malzemealtgrup_malzemegrup_MalzemeGrupId` FOREIGN KEY (`MalzemeGrupId`) REFERENCES `malzemegrup` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.malzemealtgrup: ~25 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `malzemealtgrup` (`Id`, `MalzemeGrupId`, `Kod`, `Ad`, `PdfVar`, `DxfVar`, `StepVar`) VALUES
	(1, 2, 'LASR', 'LAZER', 0, 0, 0),
	(2, 2, 'LSBK', 'LAZER BÜKÜM', 0, 0, 0),
	(3, 2, 'LSBT', 'LAZER BÜKÜM TALAŞLI', 0, 0, 0),
	(4, 2, 'LSBK', 'LAZER SİLİNDİR BÜKÜM', 0, 0, 0),
	(5, 2, 'LSBT', 'LAZER SİLİNDİR BÜKÜM TALAŞLI', 0, 0, 0),
	(6, 2, 'LSTL', 'LAZER TALAŞLI', 0, 0, 0),
	(7, 3, 'BORU', 'BORU', 0, 0, 0),
	(8, 3, 'PHEA', 'HEA', 0, 0, 0),
	(9, 3, 'PHEB', 'HEB', 0, 0, 0),
	(10, 3, 'PIBE', 'IPE', 0, 0, 0),
	(11, 3, 'KTPR', 'KUTU PROFİL', 0, 0, 0),
	(12, 3, 'LKOS', 'L KÖŞEBENT', 0, 0, 0),
	(13, 3, 'PNPI', 'NPI', 0, 0, 0),
	(14, 3, 'PNPU', 'PNU', 0, 0, 0),
	(15, 4, 'DBR', 'DİKİŞLİ BORU', 0, 0, 0),
	(16, 4, 'DSB', 'DİKİŞSİZ BORU', 0, 0, 0),
	(17, 4, 'KTK', 'KÜTÜK', 0, 0, 0),
	(18, 4, 'MİL', 'MİL', 0, 0, 0),
	(19, 4, 'LAMA', 'LAMA', 0, 0, 0),
	(20, 20, 'KNTR', 'KONTOLCÜLER(PLC)', 0, 0, 0),
	(21, 20, 'MNML', 'MONTAJ MALZEMELERİ', 0, 0, 0),
	(22, 20, 'MTSR', 'MOTOR SÜRÜCÜLER', 0, 0, 0),
	(23, 20, 'ŞALT', 'ŞALT', 0, 0, 0),
	(24, 21, 'SNLY', 'SENSÖRLER', 0, 0, 0),
	(25, 21, 'YNEK', 'YÖNLENDİRME EKİPMANLARI', 0, 0, 0);

-- tablo yapısı dökülüyor yektamak_erp.malzemealtgrup2
CREATE TABLE IF NOT EXISTS `malzemealtgrup2` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MalzemeAltGrupId` int DEFAULT NULL,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `IsUretim` tinyint(1) NOT NULL,
  `PdfVar` tinyint(1) NOT NULL,
  `DxfVar` tinyint(1) NOT NULL,
  `StepVar` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_malzemealtgrup2_MalzemeAltGrupId` (`MalzemeAltGrupId`),
  CONSTRAINT `FK_malzemealtgrup2_malzemealtgrup_MalzemeAltGrupId` FOREIGN KEY (`MalzemeAltGrupId`) REFERENCES `malzemealtgrup` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.malzemealtgrup2: ~8 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `malzemealtgrup2` (`Id`, `MalzemeAltGrupId`, `Kod`, `Ad`, `IsUretim`, `PdfVar`, `DxfVar`, `StepVar`) VALUES
	(1, 21, '1', 'KLEMENS', 0, 0, 0, 0),
	(2, 21, '2', 'RAY KANAL', 0, 0, 0, 0),
	(3, 22, '1', 'BLDC SÜRÜCÜ', 0, 0, 0, 0),
	(4, 22, '2', 'VFD SERVO SÜRÜCÜ', 0, 0, 0, 0),
	(5, 23, '1', 'KONTAKTÖR', 0, 0, 0, 0),
	(6, 23, '2', 'MKŞ', 0, 0, 0, 0),
	(7, 23, '3', 'RÖLE', 0, 0, 0, 0),
	(8, 23, '4', 'SİGORTA', 0, 0, 0, 0);

-- tablo yapısı dökülüyor yektamak_erp.malzemegrup
CREATE TABLE IF NOT EXISTS `malzemegrup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StokGrupId` int DEFAULT NULL,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PdfVar` tinyint(1) NOT NULL,
  `DxfVar` tinyint(1) NOT NULL,
  `StepVar` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_malzemegrup_StokGrupId` (`StokGrupId`),
  CONSTRAINT `FK_malzemegrup_stokgrup_StokGrupId` FOREIGN KEY (`StokGrupId`) REFERENCES `stokgrup` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.malzemegrup: ~22 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `malzemegrup` (`Id`, `StokGrupId`, `Kod`, `Ad`, `PdfVar`, `DxfVar`, `StepVar`) VALUES
	(2, 3, 'LSR', 'LAZER', 0, 0, 0),
	(3, 3, 'PRF', 'PROFİL', 0, 0, 0),
	(4, 3, 'THM', 'TALAŞLI HAMMADDE', 0, 0, 0),
	(5, 4, 'FRN', 'FREN', 0, 0, 0),
	(6, 4, 'HPN', 'HİDROLİK PNÖMATİK', 0, 0, 0),
	(7, 4, 'KTM', 'KABLO TAMBURU', 0, 0, 0),
	(8, 4, 'LNA', 'LİNEER AKTÜATÖR', 0, 0, 0),
	(9, 4, 'MTR', 'MOTOR', 0, 0, 0),
	(11, 4, 'M&R', 'MOTOR + REDÜKTÖR', 0, 0, 0),
	(12, 4, 'RDK', 'REDÜKTÖR', 0, 0, 0),
	(13, 4, 'V&C', 'VINC-CARASKAL', 0, 0, 0),
	(14, 5, 'AKE', 'AKTARMA ELEMANLARI', 0, 0, 0),
	(15, 5, 'MEK', 'MEKANİK EKİPMAN', 0, 0, 0),
	(16, 5, 'SPS', 'SÜSPANSİYON', 0, 0, 0),
	(17, 5, 'YAY', 'YAY', 0, 0, 0),
	(18, 6, 'KMM', 'KABLO MONTAJ MALZEMELERİ', 0, 0, 0),
	(19, 6, 'KBL', 'KABLOLAR', 0, 0, 0),
	(20, 6, 'PIM', 'PANO İÇİ MALZEMELER', 0, 0, 0),
	(21, 6, 'SMM', 'SAHA MONTAJ MALZEMELERİ', 0, 0, 0),
	(22, 7, 'BOY', 'BOYA', 0, 0, 0),
	(23, 8, 'ETK', 'ETİKET', 0, 0, 0),
	(24, 5, 'SNM', 'SÖNÜMLEYİCİLER', 0, 0, 0);

-- tablo yapısı dökülüyor yektamak_erp.malzemestandart
CREATE TABLE IF NOT EXISTS `malzemestandart` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `StandartAdi` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.malzemestandart: ~5 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `malzemestandart` (`Id`, `Kod`, `Ad`, `StandartAdi`) VALUES
	(2, 'ST37', 'ST37', NULL),
	(3, 'Ç1040', 'Ç1040', NULL),
	(4, 'ST52', 'ST52', NULL),
	(5, 'AISI 304', 'AISI 304', NULL),
	(6, 'AISI 316', 'AISI 316', NULL);

-- tablo yapısı dökülüyor yektamak_erp.marka
CREATE TABLE IF NOT EXISTS `marka` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.marka: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `marka` (`Id`, `Ad`, `Kod`) VALUES
	(3, 'YEKTAMAK', 'YKTMK');

-- tablo yapısı dökülüyor yektamak_erp.markaaltgrup
CREATE TABLE IF NOT EXISTS `markaaltgrup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MarkaId` int DEFAULT NULL,
  `Ad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_markaaltgrup_MarkaId` (`MarkaId`),
  CONSTRAINT `FK_markaaltgrup_marka_MarkaId` FOREIGN KEY (`MarkaId`) REFERENCES `marka` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.markaaltgrup: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `markaaltgrup` (`Id`, `MarkaId`, `Ad`, `Kod`) VALUES
	(3, 3, 'SEYİTON', 'SYT'),
	(4, 3, 'TURNART', 'TURN'),
	(5, 3, 'WALLKER', 'WLK');

-- tablo yapısı dökülüyor yektamak_erp.markaaltgrupkategori
CREATE TABLE IF NOT EXISTS `markaaltgrupkategori` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MarkaAltGrupId` int DEFAULT NULL,
  `Ad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_markaaltgrupkategori_MarkaAltGrupId` (`MarkaAltGrupId`),
  CONSTRAINT `FK_markaaltgrupkategori_markaaltgrup_MarkaAltGrupId` FOREIGN KEY (`MarkaAltGrupId`) REFERENCES `markaaltgrup` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.markaaltgrupkategori: ~14 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `markaaltgrupkategori` (`Id`, `MarkaAltGrupId`, `Ad`, `Kod`) VALUES
	(2, 4, 'TURN 4.11', NULL),
	(3, 3, 'SYT 1.1', NULL),
	(4, 3, 'SYT 1.2', NULL),
	(5, 3, 'SYT 1.6', NULL),
	(6, 3, 'SYT 1.3', NULL),
	(7, 3, 'SYT 1.4', NULL),
	(8, 5, 'WLK 1.1', NULL),
	(9, 5, 'WLK 1.2', NULL),
	(10, 5, 'WLK 1.3', NULL),
	(11, 5, 'WLK 1.4', NULL),
	(12, 5, 'WLK 1.5', NULL),
	(13, 5, 'WLK 1.6', NULL),
	(14, 5, 'WLK 1.7', NULL),
	(15, 4, 'TRN 1.4', NULL);

-- tablo yapısı dökülüyor yektamak_erp.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SiraNo` int DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FormAd` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Model` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MenuGroupId` int DEFAULT NULL,
  `MenuGroupId1` int DEFAULT NULL,
  `CreateDate` datetime(6) DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_menu_MenuGroupId` (`MenuGroupId`),
  KEY `IX_menu_MenuGroupId1` (`MenuGroupId1`),
  CONSTRAINT `FK_menu_menugroup_MenuGroupId` FOREIGN KEY (`MenuGroupId`) REFERENCES `menugroup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_menu_menugroup_MenuGroupId1` FOREIGN KEY (`MenuGroupId1`) REFERENCES `menugroup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.menu: ~56 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `menu` (`Id`, `SiraNo`, `Ad`, `FormAd`, `Model`, `Icon`, `MenuGroupId`, `MenuGroupId1`, `CreateDate`, `CreatedBy`, `UpdateDate`, `UpdatedBy`) VALUES
	(1, 1, 'Personel Listesi', '/personeller', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(2, 2, 'Personel Ekle', '/personel-ekle', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(3, 3, 'Firma Listesi', '/firmalar', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(4, 4, 'Firma Ekle', '/firma-ekle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(5, 5, 'Kullanıcı Listesi', '/kullanicilar', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(6, 6, 'Kullanıcı Ekle', '/kullanici-ekle', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(7, 7, 'Rol Listesi', '/roller', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(8, 8, 'Rol Ekle', '/rol-ekle', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(9, 9, 'Rol Güncelle', '/rol-guncelle', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(10, 10, 'Firma Güncelle', '/firma-guncelle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(11, 11, 'Yetki Yönetimi', '/yetki-yonetimi', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(13, 13, 'Personel Güncelle', '/personel-guncelle', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(14, 14, 'Pozisyon Listele', '/pozisyonlar', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(15, 15, 'Pozisyon Ekle', '/pozisyon-ekle', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(16, 16, 'Pozisyon Güncelle', '/pozisyon-guncelle', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(17, 17, 'Şehir Listesi', '/sehirler', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(18, 18, 'Şehir Ekle', '/sehir-ekle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(19, 19, 'Şehir Güncelle', '/sehir-guncelle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(20, 20, 'Ülke Listele', '/ulkeler', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(21, 21, 'Ülke Ekle', '/ulke-ekle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(22, 22, 'Ülke Güncelle', '/ulke-guncelle', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL),
	(23, 10, 'Personel Resim Detay', '/personel-resim-detay', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL),
	(24, 24, 'Kullanıcı Güncelle', '/kullanici-guncelle', NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL),
	(25, 25, 'Stok Kartları Listesi', '/stok-kartlari', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(26, 26, 'Stok Kart Detay', '/stok-kart-detay', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(27, 27, 'Stok Kart Guncelle', '/stok-kart-guncelle', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(28, 28, 'Stok Kart Ekle', '/stok-kart-ekle', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(29, 29, 'Stok Kart Araçları', '/stok-kart-araclari', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(30, 30, 'Stok Tip Yönetimi', '/stok-tipler', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(31, 31, 'Hammadde Yönetimi', '/hammaddeler', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(32, 32, 'Malzeme Alt Grup2 Yönetimi', '/malzeme-alt-grup2ler', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(33, 33, 'Malzeme Alt Grup Yönetimi', '/malzeme-alt-gruplar', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(34, 34, 'Malzeme Grup Yönetimi', '/malzeme-gruplar', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(35, 35, 'Malzeme Standart Yönetimi', '/malzeme-standartlar', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(36, 36, 'Ölçü Birim Yönetimi', '/olcu-birimler', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(37, 37, 'Stok Grup Yönetimi', '/stok-gruplar', NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL),
	(38, 38, 'Proje Listesi', '/projeler', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(39, 39, 'Proje Ekle', '/proje-ekle', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(40, 40, 'Proje Güncelle', '/proje-guncelle', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(41, 41, 'Proje Takvim Listele', '/proje-takvim', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(42, 42, 'Proje Takvim Ekle', '/proje-takvim-ekle', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(43, 43, 'Proje Takvim Güncelle', '/proje-takvim-guncelle', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(44, 44, 'Proje Süreç Tanımlar', '/proje-surec-tanimlar', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(47, 45, 'Markalar', '/markalar', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(48, 46, 'Marka Alt Gruplar', '/marka-alt-gruplar', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(49, 47, 'Marka Alt Grup Kategoriler', '/marka-altgrup-kategoriler', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(50, 48, 'Proje Tipleri', '/proje-tipler', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(51, 49, 'Satış Siparişler', '/satis-siparisler', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(52, 50, 'Proje Stok Kartları', '/proje-stok-kartlar', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(53, 51, 'Proje Sorumlular', '/proje-sorumlular', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(54, 52, 'Proje Yönetim Araçları', '/proje-yonetim-araclari', NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL),
	(55, 53, 'Satın Alma Talepleri', '/satinalma-talepler', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(56, 54, 'Satın Alma Talep Ekle', '/satinalma-talep-ekle', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(57, 55, 'Satın Alma Talep Guncelle', '/satinalma-talep-guncelle', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(58, 56, 'Satın Alma Talep Detay Görüntüle', '/satinalma-talep-detay-goruntule', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(59, 57, 'Satın Alma Talep Onay', '/satinalma-talep-onay', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(60, 58, 'Dashboard', '/dashboard', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(61, 59, 'Satın Alma Sipariş Ekle', '/satinalma-siparis-ekle', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(62, 60, 'Satın Alma Sipariş Listesi', '/satinalma-siparisler', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(63, 61, 'Satın Alma Sipariş Guncelle', '/satinalma-siparis-guncelle', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL),
	(64, 62, 'Satın Alma Sipariş Detay Görüntüle', '/satinalma-siparis-detay-goruntule', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.menugroup
CREATE TABLE IF NOT EXISTS `menugroup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Aciklama` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `SiraNo` int DEFAULT NULL,
  `CreateDate` datetime(6) DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.menugroup: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `menugroup` (`Id`, `Ad`, `Aciklama`, `SiraNo`, `CreateDate`, `CreatedBy`, `UpdateDate`, `UpdatedBy`) VALUES
	(1, 'Personeller', 'Personel', NULL, NULL, NULL, NULL, NULL),
	(2, 'Kullanıcılar', 'Kullanıcı', NULL, NULL, NULL, NULL, NULL),
	(3, 'Firmalar', 'Firma', NULL, NULL, NULL, NULL, NULL),
	(4, 'Stoklar', 'Stok', NULL, NULL, NULL, NULL, NULL),
	(5, 'Projeler', 'Proje', NULL, NULL, NULL, NULL, NULL),
	(6, 'Satın Almalar', 'Satın Alma', NULL, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.olcubirim
CREATE TABLE IF NOT EXISTS `olcubirim` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tanim` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.olcubirim: ~10 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `olcubirim` (`Id`, `Kod`, `Ad`, `Tanim`) VALUES
	(1, '01', 'UZUNLUK BİRİM SETİ', NULL),
	(2, '02', 'ALAN BİRİM SETİ', NULL),
	(3, '03', 'HACİM BİRİM SETİ', NULL),
	(4, '04', 'AĞIRLIK BİRİM SETİ', NULL),
	(5, '05', 'ÖNDEĞER BİRİM SETİ', NULL),
	(6, 'ADET', 'ADET', NULL),
	(7, 'MT', 'METRE', NULL),
	(8, 'GR', 'GRAM', NULL),
	(9, 'SET', 'SET', NULL),
	(10, 'KG', 'KİLOGRAM', NULL);

-- tablo yapısı dökülüyor yektamak_erp.personel
CREATE TABLE IF NOT EXISTS `personel` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PersonelAd` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PersonelSoyad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Telefon` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Mail` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PozisyonId` int DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  `PersonelResimId` int DEFAULT NULL,
  `Ad` varchar(91) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `YoneticiPersonelId` int DEFAULT NULL,
  `FirmaId1` int DEFAULT NULL,
  `PozisyonId1` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_personel_FirmaId` (`FirmaId`),
  KEY `IX_personel_FirmaId1` (`FirmaId1`),
  KEY `IX_personel_PersonelResimId` (`PersonelResimId`),
  KEY `IX_personel_PozisyonId` (`PozisyonId`),
  KEY `IX_personel_PozisyonId1` (`PozisyonId1`),
  KEY `IX_personel_YoneticiPersonelId` (`YoneticiPersonelId`),
  CONSTRAINT `FK_personel_firma_FirmaId` FOREIGN KEY (`FirmaId`) REFERENCES `firma` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_personel_firma_FirmaId1` FOREIGN KEY (`FirmaId1`) REFERENCES `firma` (`Id`),
  CONSTRAINT `FK_personel_personel_YoneticiPersonelId` FOREIGN KEY (`YoneticiPersonelId`) REFERENCES `personel` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_personel_personelresim_PersonelResimId` FOREIGN KEY (`PersonelResimId`) REFERENCES `personelresim` (`PersonelResimId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_personel_pozisyon_PozisyonId` FOREIGN KEY (`PozisyonId`) REFERENCES `pozisyon` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_personel_pozisyon_PozisyonId1` FOREIGN KEY (`PozisyonId1`) REFERENCES `pozisyon` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.personel: ~4 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `personel` (`Id`, `Kod`, `PersonelAd`, `PersonelSoyad`, `Telefon`, `Mail`, `PozisyonId`, `FirmaId`, `PersonelResimId`, `Ad`, `YoneticiPersonelId`, `FirmaId1`, `PozisyonId1`) VALUES
	(2, NULL, 'Abdurrahman', 'Öz', '05058395456', 'oz@oz.com', 21, 1, NULL, NULL, 8, NULL, NULL),
	(6, NULL, 'Cevdet', 'Oğuz', '05061257717', 'cevdet.oguz@yektamak.com.tr', 22, 1, NULL, NULL, 8, NULL, NULL),
	(7, NULL, 'Emre', 'Küçük', NULL, 'emre.kucuk@yektamak.com.tr', 6, 3, NULL, NULL, 8, NULL, NULL),
	(8, NULL, 'Bünyamin', 'Boz', '05497621120', 'bunyamin.boz@yektamak.com.tr', 20, 1, NULL, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.personelresim
CREATE TABLE IF NOT EXISTS `personelresim` (
  `PersonelResimId` int NOT NULL AUTO_INCREMENT,
  `PersonelId` int NOT NULL,
  `ResimData` longblob,
  `ImageFormat` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`PersonelResimId`),
  KEY `IX_personelresim_PersonelId` (`PersonelId`),
  CONSTRAINT `FK_personelresim_personel_PersonelId` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.personelresim: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `personelresim` (`PersonelResimId`, `PersonelId`, `ResimData`, `ImageFormat`) VALUES
	(10, 2, _binary 0xffd8ffe000104a46494600010100000100010000ffdb00840009060713121215131312151615171515181718171815151817171516171617161715181d2820181a251d151521312125292b2e2e2e171f3338332d37282d2e2b010a0a0a0e0d0e1a10101a2b1d1f1f2d2d2d2d2b2d2d2b2d2d2d2d2d2d2d2d2d2d2d2d2d2d2b2d2d2d2d2b2d2d2d372d2d2d2d2d2d2d372d2d2d372d2b2d2d2d2dffc0001108010a00bd03012200021101031101ffc4001c0000010501010100000000000000000000050203040607010008ffc4004110000103020403050409020601050100000100020304110512213106415113226171810791a1b1143242526272c1d1f023e133738292b2f11624435363a215ffc4001a010002030101000000000000000000000000020103040506ffc40026110002020202020201050100000000000000010211032112310441132251324261627133ffda000c03010002110311003f00bf71e610c963cc742d06de3aacfb3b2068b68d3a79231c57c646573218ed637ccee5cac02e8c3192c433fd6d0b7a03d55527f63388a36b650d7b7416d0f3f153a098807bc4816b6b743d948d8db94696dedf3560e11c30ced7bde7bb9acd02da91ba7e57a00af0d34b8f7872d1778e30d6be99fa0d354428f0b7c6f05ae059e3bf9281c7150e6d3bdb6d0b4eaa26bead16416d1878560e151afaa03b0b9db9a1159c42e00b22d06c4f3bf5f05cd841ca5a3d0f919631c5c6f66bb88710d342d21f330380faa082ebf4b2cb78a388e2a877701b037d74baaa4d99c6e6e49deea4b28ddd2d6b7f3f9d16be297672a377687db89b9bb0f0b2e0c55f7d815d8f0f79d6db6c7e03de9c761eeca34dadefd41f925e302ee791fb1231cb1d5be5bf8294cc56371d4db51bff00650a6c28eb7dc03f0e7ee43aa285cc36f3feca563815655292fb1b2f0ee3b9631d9c809b0d2f72072b8dd3545c4d54e9ce77ff004fa058ec124b13b33496907704f2fd37562c271c7bcf78f7f63d0ff74f916b461789a3e92e1bad63a3b837ea8c8a86ed985fcc2f9be978b6565c662cf243ebb8c6527491d6f126ea639740a4d1f52172870e291b896876a0db5d17ccff00f9b56b9b93e993e53a58380d3ced7f8a86dab2f759ef964b8b6574cfb1e99b5dbe6a5e5432959f48e3fc654746d2659e3cc368dae697b8f40dbac5389f8d6bf1673a2a764821b91d940d7bdc7fcd7b46be5b79a9dc15c094125a5aca81fe4b1a6167fa9f725c3c885abb6b69a9e211d3b236c4d1f66cc6340e7e3e69fbf6437664dc19ecd6ab376953421e342d6cf30899e6e8e30e738f81b22fc49ed2a5a29053c2694860b39b0c6ec8c70fb01c4d8dbc000a2f1bfb4996addf42c3c3c871c8e7b6f9e5e45b18fb2dfc5a7a045b85fd8d45d966ae739d2bac7246e21b1f519bed1ea76d143fea42bf466b3e241fb696d958786f17924391e410d1a1e6aa32d116bedb8b9f9a21493ba2ef37a6ab3393bb0ad1a7065d9bf3b2e6078ac945216919e37f7add1dcca09c2826a87b731eef82d1c70cb5d6bad3056acadf61cc2f101334386974c713c4d7534b9b6c87e4a4e1b46226068e4a91ed731d3142d818757f79fcbb83600f52534b4b66885b31dc42ab30ca00cbaeb7e9a5ca1cda41268dbeff00ce49d998e3a374bdfa9b7eead7c2f825c073815924d4568df18bc8f642c1f864100bbfeac8a4d81358dcc05cef657065286b6d64ccf07c07effbaa39bb35ac6922815672002dad87a1e5b741f12a135c002e3b5ade400bdfc91cc7a9dbaf2f502d6e8a9d30d0b75b58f3babe3b289b6896ead6137d4102d736d86bea1409a60e71b9df9f5b1bdd21ed2e713c88d3d761f2518466f63d7d3cd3a454db27d1c41f66b86b6209f7a66bf0a319bb6f6e6a661b11cd7b6a8f983336c79a494e87f87922b52461f112082f68b91d4055e73ae55aea691d03ae363aff00655dc4a97248e16d0f79be4ed7fb2b31d1873e3e2c6e3254b89ca1466c89d0c39ae6f60373d3f727928999683585d43f29b9b346e49360971d754d7b994301eeb9dcf407f13cfdc1d140a785d52f11b4e489a45c9d7d7f138f20afdc3d863232c6c2dd2fde71face3d49f551088add1a3f00f01c186c771692770efca46bf9583ec33c39f356e43e818eecc02e37b28155874f98964e403c9689c94116c676b48c478728c54cb675801bad419c1d1187468dba2c6787b13741287723badab0de296ba117dadbf554a9478eca77653f08ac34554e88b0e5fac0efbee169b458db5d6b822ea9f854b15454926d63d7cd6831534600b342784a968229b643c6b12ece27b86e0121629c45883ea642f7837cadb026c05bf5e4b69c6e833c66dd0faac65d15de74dc923a787aa4c927ecdbe32b96c83866145c466bee7fe95f28181ad0020f48c00df9a9a25b2c7395b3b18a0920cb64052253a150639d29d509116501718a36b88beeaad5386b6fb6a4eb6e8aed56d077439d0379056c645728595a6611607a6bc943761763a8570ecc00a24b00dd3f223e3409868c0528bac9e2d512a5d62aa7b1d1ea9607b729d3a6bcd56f12a3ced06dab0d88fc276dfc7e68c4b5164d4b280f0770e16215906d18fc982922b468ada91b27a2bb806ea183e27aab01c273d9d26fc9a3eab478f5726994b95daa673a397c5558cc3196801ba7968b44e0beeb066def7551a38039de4ac94b883621aa8c72a654e3ecd4287196ec7de935dc4f046402e59ed3f10b4dc0d502c5eb44afd2fa279e4b44db5d14d138ed34175a7708506788660468b2ec25c03bbd6dd6b781e2acecdb908d869e4ad84148af249a2162f843d8fed207e5239723d558704c72a1c0076c2de68554c9239ce23507925e0504e2405cccacf9f8a4e0d4888b5e8d09f59682479ddb1b8fb8158ec2db0d56b78a8028e723ff00864ff8958cba4b1e80dcef7e964d9fa474bc3eac28c913ef92e2e86e7d3c79a914afea745cf7d9d88744c86a129d3266f6df64b6b9845892a5318f3a4d2f701467c8d07523d14810b46cdbf89d6cb8fb8be507d07ee991244fa436ff00585bd146a8a8613a124787f652cc8f1af6573e4c2a2cf2c8795bd45fdca45643a8aa68d90ca896e5179e12771cb9d90b9e302e744c8564091faa6deed47985d94a8ce7ea3cd323366fd2c2d157f24b7befa84044a41f546f0d99a5baeeab69b6719bd9269ab1ac16e6b9511492ea341c94ea5c259259d753658db19cbd02b163d5b124fd1cc1684363d4ebcd4f6c310e881546296161a2133571bfd628e74a88e20182173de1a06a4dbe2b71e10e056451873af723e2a99c1f8137b56bddd79adda900ca0782dd8f1f156cabfe92e365769705b3ec469c8a3c28db940b6ca5640944ab0ba1838f657f13706c7344e7b5a1f1bc36fcae0807c962950e71201ebbdb9f4d39ab471e6332371191ac376358c6b9a76b817b8f472afc403a4711b1d6dcf5dc7bd61cb93949afc1d8c5e3fc704ff248847c54a8e1b689a0404dbebc460972c3b6cdaa920d31a00dd25c41d04c07b951714c6e49490d06de1a7bd04a892702e2e3d4abe38afb2b965ae8d36cf06e246bbaa4c9536dff009aacbe931a9e23f58fbf74422e217bbeb171f3fecacf868239ecb84b55a5eea2c3540f9a0b86d5b9c1c5c39a62bea80b81a7428e03b9d07e7949bdba218ea73b921562a31894681c9a656caefbc6ff00cd93fc5a334fc8565967d3c9426440bc0d8733d07328636a1cde47d510c3e4cc478821471a2b964e5a1f9695a1fdd7666ee0dad71e23aa9063005c271f405ad66f7cad3ef17fd526a21eeeb70551cd1cdc8d26c770bc60b0e5dc228f12cc76dfe4ab343180ed7aab56198dc519373aabb1a727d943e895ff00843deccce710ab55d80bd8eb6eb44671631cdb0d4f82015f5399d73a5d5d978410b8f932cb0521635a729d75e8acfc318abdcd2d783a1dfc12689b9da05ae02334d4ed68b0002d507a326d3b4118a6ba4d41e8abcdc48b26cbb826cac1b84cabb352c929478becc8f8fa80c75524c3ff0071b7f5160e1f01ef554c12a1ce7bc91b0e9e3b2d6f8ff0ecd4dda002f1bc1f47774fe8b3aa7a41135e46cfb39a7c3a7cfdeb9d9e1c66ff0093d078791e4c0b97a3c3542f1aa7246e89531d6e76534d235fe2b22d334be8cfea1eff00a913741bb8f3f243eba8660f198b9c343717dacb40aec38d88b5bc501928641a5b4f72d78f2233cf13900a7c2408d8ed4b88ef0b5cdf958f248650b858f5e5b1f723268dc4ee6fe1fcdd4fa5c37994d29a0863ae8e60d405ccd508e21a321c183457ec269accb2adf11443b40ab84b65d385a29830cbe6bdee36bf3fd9269f0f25da82cd4dcdcedc86bbab04d4637b9f34c9a536d082b47c863962d81e3ce1d94f7878a254edcb64ec54b74e3c6a02ae52b071a41c662cd7dc5802bb50c2e1a6a8750d0dc78f556ae1da1b0d75e46eb135723973d946aaa4736e75099c330b74b26b7b02b45c730f6bae2da7241a9699b01bab9371163b5b0bd3618c8997b2a6e3789912581dae8f631c44d0cb5f92cceb6bcbde4f8ab230790b1a7d44fadf0aa76b1ba24e2874d154b0cc69eed335d47c531c7c7a3869d7aa78793171a32ca03c5f6977d559f0fc75999ac3b959dd36225eecdb24e275640b877786a0a959aba659c3499aee254e2685ecd3bcd23d791f7ac8f19a77b1807d8d875beba7bae88605c71231b95fadb9a138b62465cc41eedef6e849d7e6a8c9954dd9d2f0f325f57ec1824b052e8aa08424bf552049655347553541b7d6df7175026a473ce9a79aec33a7c558d94a2461944d60bf3eabb11693ba818b6256161ba25815231b18ce4673a9bf8f252c12a0d5230363553e22a6b9cde2ac0eac16cb71a2058e5402dd3c53c5112a0253c80e89469802997b431c083b8d7cd4c32689c4ab23cef0d1642deebb801b9d94aa976eb98043da54c4dfc57ff682efd143d2b33e67483dc2b4eeed031e342aff005146c6466da7ee84d151b4106c73782938b563836ce690163f93d9cb710507e637e4157b1dbea1a8dbe4b0b3772a0c30b8b5ce3a9ba2392c94acce310792e20dd30cc3cbb5b2b062f4a0ca2fbf34961cba05bd64a8aa11aa66bdc191b4cb677346f8f70c67621ed162de8a8f418a76328b3ac7aa3d8bf12b65680e779ac5c125609ae9956a42e03550abaa8b8d9109eac38903d52198597ea979de912f6a816c93d174cd6d3aa2f261ac68b9dd3381e13f49aa8a217b1777adc9a3571f7298f7410fac902f35f45d64bc9375b198a59233bb1ee6df6faa6df1dd3523b985a389d88c898d9ba14e3a6d10f64be2942a45c03b734712e52d1328e80bdd9dde88563b4b335f7123b2f2b5b4f346d98a35a37b68a2d44d9ec5c090478268a698929df457e1c5246e8e24f8f3299aaa9964d069e68ad4d1dcf75a571d4ae02ee6dbe2ae4915394a86b0da43909792e3f24e3de46890f94b5b6d94535374ae3b1a391747679159bd91d009b10b91711c523bd4d983fe47dcaa33bd6b9ec1b0cb47515246af73631e4cbb8fc5ff00049923716babd19f348b64f873629012d397a8e564231c6b1c0f32797457e9a2045b92ae62781b00ccdd2cb93384f14ea5d19da4d148930cb11e0147af84363b5adaee89544f67803d50fc7de3b322eae834e5a2b5a33ec4c6696ccdec115a1c2406f7b72a0d001da127aa2b5b8986d80e8b63ea915dd8f5551873b335346127ba54da5aa0dbe9751a5ab697dd6752bd0b48416967a29787e3194d920d7c6feee97436ae2b1bb7d10b1f1768948b0d45731c3bc42b27b2484486a2a6d668708a3f1160f7bbde40f458f6215ceb16df53d3905a17b0ae2300cd46f362f2258fc486e591a3d035def5d0c38bf7490f1ec83ed4284c55af70da40241e6459df1685548aa3f6f25b3fb49c07e954f9983fab15dc3c5bbb87c8fa2c2de482a650d9ba13d0523b15cac67774dd40ed74ba4c6f24ea52516f3b38da59b716b0ea97da556d98347503e08d534d716516b8bc6ad1e8853dd1646291062abaa8f4bb4dfaeaa2d43a6be62fef1e42ff00a25bb10945c18eff00a2543248752db2b740dc5e90c39f311de2df8dd76161e6a73ae05ca8134a953b6679248e39a49006a49b01e27657fc0715a8c39ad6c7b1fac08b824ea4ff003a2aef0bd01665aa91bdcb90ce62fcc9e87a2be5218a76e523bdc8ac9e44d5f1665c92727a2cd83f1df6997b48f283b904903d110c7b1b8cc6046e04bbe01575b83451c200ef388f774541acad7c323985c4d8dbf9ef5cfb73955e8572715b2cf15635af374338a6b9a18483c90d8ea0bb555fe23af36ca792df8e117d080aa5aa73e5b6c2e8ed5d1136d95630ccc5d987244ea71292fae8b54a1f6a42d1666bfba4136285b1c4bade28b62f236ca16153b5a6eed9628abd09ec90ca51bd946c5e51134006e48f727f11c63368c018debccaab56ce5c4dc92b6e3f1f76cb52234cebdcae5056c904ac962765918e0e69e841d2e398ebd6ebc4a65c16c03e98e14e268f10a66cccd1df5646f363c0d5bebb8f0b2a17b40e11ca5d510b7ba757b5bf64fde03eef82a0f04f143f0fa80fb9313acd95bd5b7d1c3f105f40d3d4326635ec21cc736ed3bdc1ff00b4ae365b199f3bc808364812eab4ce31e08cd7929c6bb98f913d5be3e0b32aa8cb1c43c1041d74d47985571a345df415a1a91cf923d056306e01f054a8a5b6c6e9dfa59ea91e31a1968b5cf5119fb214492a5a0681578d61ea9b7d678953c46f95136bea6e3d50f8985de491ab94da33a5ac994514b6e4cb470be2a2c629007308cae6f51b023a108a4e5d46e677f3466fd9bce971be527ef054e84169046e3f96578c3248eaa1304c2f1bc7ab4f22d3c9c0ea1264c11c9a65738fb44dc33127c99bbd66f86bbf8a930e1b0f66e79b39ce3a936597e28daac32731f68729d58eddaf6723fa11c94ca0e2dcce1db0d011b69f05832f813ee2cabfd2c7161af7c8f2c6da3be8501e2ac1f283d55b69f8b206c64b353c9bcfdc815455fd209279a31296396c95149156e1a837bf553abe21991c870a0c65c20758c2e71f05a7e4dd90d521c747be77e63f876f52a34b37209a9e6239a8e5fe2b5c71c622a5476ae521a7aa1c4fc93d5925d303f4569274243976ebae082061eb45f647c59d9c9f4299dfd379fe893f65fcd97e87978ace5eb8d241041b1041046e083a14127d52f8ee151f8d38584c0b9a009391eb6e4517f679c422ba95ae71feab3b920fc43677911aab25453870d90d58e9d1f33d45096bcb5c0b5cd3623620fede2901a7a95adf1af07f6c3b48fbb201a7e21f74feeb3374041208b106c41dc10a89268d10929220188f82eb29faa98d6782ef6774b63f1180d526923bfa6fe479a4166aa5501b48dbeceee9f22a53d8ae24b1168112c29f91de07f974e7ff00cf22e1488690d95ca254d87711c3a3aea730cba11ac6fe6c76c1c3c0f30b18c570f929a57432b72bd86c7a11c9c0f30770b64c35e47811b207c6ed82b581a1a44b1dc324d00ff2ddccb74f44f454ccd21aa239a3b83e3395c1af3dd3a03d0f8aab6a0d8ee37ba75afe5c95738292a62db35496a2d1dbc10a658ea86613891920b1faccee9f1e854880e9bae64a2e32a19b023df7d520b924bb448739756851b91c90c2bae4c48d276362a481f684a2141ed9e129b537d2ca40ebceabcd5c76eb975005abd9cf117d0ab1a5c7fa52da393c2ff55de87e057d1f1588046a08f82f91c85bff00b1fe25fa4d2f62f75e582cd3d5ccd98ef85bd14928b955c1759f71af09f680cd137fa807787de03f55a7491dd57f88712645dc6d9d21d86f6079badf250e29a2c8ba7a30d235b1d08defb83d085c2d56be2ac0c861a9fb408127a9b077f3aaab34dd66941c59ae12e4ac8e5baa79ecee9ebb8f31a84b6c7aa71c8435175c3dc25863900facd04f9db5f8dd3ae8adb285c1d2e6a7cbf75ee1f1bfea8d8a7bb6eb6c69a30cb4c1f0121d7f242f15688e473b66805daf43afe88cf6762a8ded231701dd830ea40ce7a0e4df551221943a89733dcefbce27de495c69484a68ba52027804f9643f74b4dfc2db7edeaa798e49c92deeb4682e6d740c39adb5892799e56e9647e865eeacd9beaee84910b326c948ccbc0dd68245592084b0924a00439a084db1a05ca71e5324dd48092bc4a538249401e08ff047101a1ac8e7bf72f9641d6376feed1de8abe0a5200fa9f14c780686c2439ce00e61a8008b83e26c8251d0dc979fac77773f7aa97b2cc4db341d938f7e2ee9ea5bbb1df31e8b478a1b27f43595ee2b0d8e8a6b9fb3617eae200f8959536c15f3da5c553246d1146e740c39a42dd4e6d81cbcda35f559d0946c4acf9b6cd382a891982497dfc93123fa2f0935d74d36549a2cb4f00cf77cd1fe577cda7e4aeb16a1667c255392b58393dae6fadb30f92d243ace5af13d18b2afb0dcb01bdc2cc3da170e3e271aa04b9af700ebfd975b4f4d16c0d8efb2a37b61a82da58a3fbd29bffa5b71f34ef656642bcbcbc5201e08c53cc40f720e8cc00e506dc82ab2f424c8774a0f4d0294ad24703d773260b975ae400a9baf248b2749ba65c2c7c3e4803af4da5b8a41401e09613774a0800f705e2e696ad8e27b8fb31fd2c4e87d0d8f95d7d0b875635cdb3b90f5057cba56e1ecff0015fa452b1f7efb3fa6ff00368dfd4594a2517581f71ef555e28e078aa6ef8ad14bd40ee38fe36fea2c7cd581d505a2e1b7ea2f63e62eb83186ece8e41fed3f228693193a30ac570e969a531cac2d3cb9823ab5dcc28ece456d78d414d54c31cd71d09696969ead2b25c77047d2bb2b88730df23dba870f1e8ef0544f1b46884d322d238f6d0b9a2e7b565875bb80b7c56b988332b8059161329654404ec268fcaf982da7158beab93e21331ec3e6b8f159afb67aecd343083f5585e7cde6c3e015fa0bb5faec7f758a71b573a6ae99ee16efe568e8d6e82de1a5fd55ade8a406570ae95e4a0715c30f0c3133f2854e567c33fc26f92cde57e9424fa01dd749495ebad24892579a5252820071a579cb8128a00688b69ee49714e39325007425048096803aad7ece71d75354e4bf725b348fc43ea9f75c7b95502eb1e5a439a6ce69041f106e3e4803e8fa3c418f171eefd17a716d46df240f0395b510473b3edb4123a3868e1e8eba2d0484775c14a189950d6bda1d6432b70864d1ba370eeb87bba11e2a747a5c72dc25c4537ad82ecc465a67473063beb325634fe60f0b7aa8a7cd18f2592f1f50f655ec70d04ce89ffeacc1aefd16cec6f7479055c15365b3768adc8cd0f82c4f8de10250e1b9b83e9b2dcf168f2079fc04aca31ac23b76b8fda1721332a280bcba06b65c2948388e61135d96e9faa06a4d2cf96fe89724792a21ab38bc57ae924a701296136961003817525aba8010f4dbd3af4d9401c0949012c94033a0ae95c0bc1043349f6458a7f8b4ce3ffdacdfa80f03ff00c9f7ad2648d7cf981e2469aa22987d87027f2ea1c3fda4afa0619c38020dc10083d41b107dc54a1d0963eda14fc6131237a2453cd63aa74004f68587768da5900d63a9881fcb2380f9d968c1ba203590b6466570b82e61f56b8381f785606ede9f0515b24aff0015bc3613d5ddd1faff003c550e923ef10ad3c67539a5118d98dd7f33b5f7dacabcc1de052cbb20cb78ae87b1a991a362730f276bf3ba1055f3da5d17f8728e5769f5d415430a0838bcbc5710492170af2e291448296d484a672f35002da57525a9610071c9a29d7269c803d95712da9326e803a02e82ba1250078ad93d9be27db51b5a4f7a12633e5bb3e1f258e395ff00d919fea547e58ffe4e5289469a0a4ba35d09d6a9198f53c6e706db70f683e448563a89044c73dc7bad17f772fd107c379fe61f35238bcffe9cfe767cd49067f57397b9cf3bb8971f54860d17a4dfd575891810788e9bb6a77339e536f31a85908dd6d736def58d577f8aff00ceef99400d392425b92142211fffd9, 'jpg'),
	(11, 7, _binary 0xffd8ffe000104a46494600010100000100010000ffdb00840009060713121215131312151615171515181718171815151817171516171617161715181d2820181a251d151521312125292b2e2e2e171f3338332d37282d2e2b010a0a0a0e0d0e1a10101a2b1d1f1f2d2d2d2d2b2d2d2b2d2d2d2d2d2d2d2d2d2d2d2d2d2d2b2d2d2d2d2b2d2d2d372d2d2d2d2d2d2d372d2d2d372d2b2d2d2d2dffc0001108010a00bd03012200021101031101ffc4001c0000010501010100000000000000000000050203040607010008ffc4004110000103020403050409020601050100000100020304110512213106415113226171810791a1b1143242526272c1d1f023e133738292b2f11624435363a215ffc4001a010002030101000000000000000000000000020103040506ffc40026110002020202020201050100000000000000010211032112310441132251324261627133ffda000c03010002110311003f00bf71e610c963cc742d06de3aacfb3b2068b68d3a79231c57c646573218ed637ccee5cac02e8c3192c433fd6d0b7a03d55527f63388a36b650d7b7416d0f3f153a098807bc4816b6b743d948d8db94696dedf3560e11c30ced7bde7bb9acd02da91ba7e57a00af0d34b8f7872d1778e30d6be99fa0d354428f0b7c6f05ae059e3bf9281c7150e6d3bdb6d0b4eaa26bead16416d1878560e151afaa03b0b9db9a1159c42e00b22d06c4f3bf5f05cd841ca5a3d0f919631c5c6f66bb88710d342d21f330380faa082ebf4b2cb78a388e2a877701b037d74baaa4d99c6e6e49deea4b28ddd2d6b7f3f9d16be297672a377687db89b9bb0f0b2e0c55f7d815d8f0f79d6db6c7e03de9c761eeca34dadefd41f925e302ee791fb1231cb1d5be5bf8294cc56371d4db51bff00650a6c28eb7dc03f0e7ee43aa285cc36f3feca563815655292fb1b2f0ee3b9631d9c809b0d2f72072b8dd3545c4d54e9ce77ff004fa058ec124b13b33496907704f2fd37562c271c7bcf78f7f63d0ff74f916b461789a3e92e1bad63a3b837ea8c8a86ed985fcc2f9be978b6565c662cf243ebb8c6527491d6f126ea639740a4d1f52172870e291b896876a0db5d17ccff00f9b56b9b93e993e53a58380d3ced7f8a86dab2f759ef964b8b6574cfb1e99b5dbe6a5e5432959f48e3fc654746d2659e3cc368dae697b8f40dbac5389f8d6bf1673a2a764821b91d940d7bdc7fcd7b46be5b79a9dc15c094125a5aca81fe4b1a6167fa9f725c3c885abb6b69a9e211d3b236c4d1f66cc6340e7e3e69fbf6437664dc19ecd6ab376953421e342d6cf30899e6e8e30e738f81b22fc49ed2a5a29053c2694860b39b0c6ec8c70fb01c4d8dbc000a2f1bfb4996addf42c3c3c871c8e7b6f9e5e45b18fb2dfc5a7a045b85fd8d45d966ae739d2bac7246e21b1f519bed1ea76d143fea42bf466b3e241fb696d958786f17924391e410d1a1e6aa32d116bedb8b9f9a21493ba2ef37a6ab3393bb0ad1a7065d9bf3b2e6078ac945216919e37f7add1dcca09c2826a87b731eef82d1c70cb5d6bad3056acadf61cc2f101334386974c713c4d7534b9b6c87e4a4e1b46226068e4a91ed731d3142d818757f79fcbb83600f52534b4b66885b31dc42ab30ca00cbaeb7e9a5ca1cda41268dbeff00ce49d998e3a374bdfa9b7eead7c2f825c073815924d4568df18bc8f642c1f864100bbfeac8a4d81358dcc05cef657065286b6d64ccf07c07effbaa39bb35ac6922815672002dad87a1e5b741f12a135c002e3b5ade400bdfc91cc7a9dbaf2f502d6e8a9d30d0b75b58f3babe3b289b6896ead6137d4102d736d86bea1409a60e71b9df9f5b1bdd21ed2e713c88d3d761f2518466f63d7d3cd3a454db27d1c41f66b86b6209f7a66bf0a319bb6f6e6a661b11cd7b6a8f983336c79a494e87f87922b52461f112082f68b91d4055e73ae55aea691d03ae363aff00655dc4a97248e16d0f79be4ed7fb2b31d1873e3e2c6e3254b89ca1466c89d0c39ae6f60373d3f727928999683585d43f29b9b346e49360971d754d7b994301eeb9dcf407f13cfdc1d140a785d52f11b4e489a45c9d7d7f138f20afdc3d863232c6c2dd2fde71face3d49f551088add1a3f00f01c186c771692770efca46bf9583ec33c39f356e43e818eecc02e37b28155874f98964e403c9689c94116c676b48c478728c54cb675801bad419c1d1187468dba2c6787b13741287723badab0de296ba117dadbf554a9478eca77653f08ac34554e88b0e5fac0efbee169b458db5d6b822ea9f854b15454926d63d7cd6831534600b342784a968229b643c6b12ece27b86e0121629c45883ea642f7837cadb026c05bf5e4b69c6e833c66dd0faac65d15de74dc923a787aa4c927ecdbe32b96c83866145c466bee7fe95f28181ad0020f48c00df9a9a25b2c7395b3b18a0920cb64052253a150639d29d509116501718a36b88beeaad5386b6fb6a4eb6e8aed56d077439d0379056c645728595a6611607a6bc943761763a8570ecc00a24b00dd3f223e3409868c0528bac9e2d512a5d62aa7b1d1ea9607b729d3a6bcd56f12a3ced06dab0d88fc276dfc7e68c4b5164d4b280f0770e16215906d18fc982922b468ada91b27a2bb806ea183e27aab01c273d9d26fc9a3eab478f5726994b95daa673a397c5558cc3196801ba7968b44e0beeb066def7551a38039de4ac94b883621aa8c72a654e3ecd4287196ec7de935dc4f046402e59ed3f10b4dc0d502c5eb44afd2fa279e4b44db5d14d138ed34175a7708506788660468b2ec25c03bbd6dd6b781e2acecdb908d869e4ad84148af249a2162f843d8fed207e5239723d558704c72a1c0076c2de68554c9239ce23507925e0504e2405cccacf9f8a4e0d4888b5e8d09f59682479ddb1b8fb8158ec2db0d56b78a8028e723ff00864ff8958cba4b1e80dcef7e964d9fa474bc3eac28c913ef92e2e86e7d3c79a914afea745cf7d9d88744c86a129d3266f6df64b6b9845892a5318f3a4d2f701467c8d07523d14810b46cdbf89d6cb8fb8be507d07ee991244fa436ff00585bd146a8a8613a124787f652cc8f1af6573e4c2a2cf2c8795bd45fdca45643a8aa68d90ca896e5179e12771cb9d90b9e302e744c8564091faa6deed47985d94a8ce7ea3cd323366fd2c2d157f24b7befa84044a41f546f0d99a5baeeab69b6719bd9269ab1ac16e6b9511492ea341c94ea5c259259d753658db19cbd02b163d5b124fd1cc1684363d4ebcd4f6c310e881546296161a2133571bfd628e74a88e20182173de1a06a4dbe2b71e10e056451873af723e2a99c1f8137b56bddd79adda900ca0782dd8f1f156cabfe92e365769705b3ec469c8a3c28db940b6ca5640944ab0ba1838f657f13706c7344e7b5a1f1bc36fcae0807c962950e71201ebbdb9f4d39ab471e6332371191ac376358c6b9a76b817b8f472afc403a4711b1d6dcf5dc7bd61cb93949afc1d8c5e3fc704ff248847c54a8e1b689a0404dbebc460972c3b6cdaa920d31a00dd25c41d04c07b951714c6e49490d06de1a7bd04a892702e2e3d4abe38afb2b965ae8d36cf06e246bbaa4c9536dff009aacbe931a9e23f58fbf74422e217bbeb171f3fecacf868239ecb84b55a5eea2c3540f9a0b86d5b9c1c5c39a62bea80b81a7428e03b9d07e7949bdba218ea73b921562a31894681c9a656caefbc6ff00cd93fc5a334fc8565967d3c9426440bc0d8733d07328636a1cde47d510c3e4cc478821471a2b964e5a1f9695a1fdd7666ee0dad71e23aa9063005c271f405ad66f7cad3ef17fd526a21eeeb70551cd1cdc8d26c770bc60b0e5dc228f12cc76dfe4ab343180ed7aab56198dc519373aabb1a727d943e895ff00843deccce710ab55d80bd8eb6eb44671631cdb0d4f82015f5399d73a5d5d978410b8f932cb0521635a729d75e8acfc318abdcd2d783a1dfc12689b9da05ae02334d4ed68b0002d507a326d3b4118a6ba4d41e8abcdc48b26cbb826cac1b84cabb352c929478becc8f8fa80c75524c3ff0071b7f5160e1f01ef554c12a1ce7bc91b0e9e3b2d6f8ff0ecd4dda002f1bc1f47774fe8b3aa7a41135e46cfb39a7c3a7cfdeb9d9e1c66ff0093d078791e4c0b97a3c3542f1aa7246e89531d6e76534d235fe2b22d334be8cfea1eff00a913741bb8f3f243eba8660f198b9c343717dacb40aec38d88b5bc501928641a5b4f72d78f2233cf13900a7c2408d8ed4b88ef0b5cdf958f248650b858f5e5b1f723268dc4ee6fe1fcdd4fa5c37994d29a0863ae8e60d405ccd508e21a321c183457ec269accb2adf11443b40ab84b65d385a29830cbe6bdee36bf3fd9269f0f25da82cd4dcdcedc86bbab04d4637b9f34c9a536d082b47c863962d81e3ce1d94f7878a254edcb64ec54b74e3c6a02ae52b071a41c662cd7dc5802bb50c2e1a6a8750d0dc78f556ae1da1b0d75e46eb135723973d946aaa4736e75099c330b74b26b7b02b45c730f6bae2da7241a9699b01bab9371163b5b0bd3618c8997b2a6e3789912581dae8f631c44d0cb5f92cceb6bcbde4f8ab230790b1a7d44fadf0aa76b1ba24e2874d154b0cc69eed335d47c531c7c7a3869d7aa78793171a32ca03c5f6977d559f0fc75999ac3b959dd36225eecdb24e275640b877786a0a959aba659c3499aee254e2685ecd3bcd23d791f7ac8f19a77b1807d8d875beba7bae88605c71231b95fadb9a138b62465cc41eedef6e849d7e6a8c9954dd9d2f0f325f57ec1824b052e8aa08424bf552049655347553541b7d6df7175026a473ce9a79aec33a7c558d94a2461944d60bf3eabb11693ba818b6256161ba25815231b18ce4673a9bf8f252c12a0d5230363553e22a6b9cde2ac0eac16cb71a2058e5402dd3c53c5112a0253c80e89469802997b431c083b8d7cd4c32689c4ab23cef0d1642deebb801b9d94aa976eb98043da54c4dfc57ff682efd143d2b33e67483dc2b4eeed031e342aff005146c6466da7ee84d151b4106c73782938b563836ce690163f93d9cb710507e637e4157b1dbea1a8dbe4b0b3772a0c30b8b5ce3a9ba2392c94acce310792e20dd30cc3cbb5b2b062f4a0ca2fbf34961cba05bd64a8aa11aa66bdc191b4cb677346f8f70c67621ed162de8a8f418a76328b3ac7aa3d8bf12b65680e779ac5c125609ae9956a42e03550abaa8b8d9109eac38903d52198597ea979de912f6a816c93d174cd6d3aa2f261ac68b9dd3381e13f49aa8a217b1777adc9a3571f7298f7410fac902f35f45d64bc9375b198a59233bb1ee6df6faa6df1dd3523b985a389d88c898d9ba14e3a6d10f64be2942a45c03b734712e52d1328e80bdd9dde88563b4b335f7123b2f2b5b4f346d98a35a37b68a2d44d9ec5c090478268a698929df457e1c5246e8e24f8f3299aaa9964d069e68ad4d1dcf75a571d4ae02ee6dbe2ae4915394a86b0da43909792e3f24e3de46890f94b5b6d94535374ae3b1a391747679159bd91d009b10b91711c523bd4d983fe47dcaa33bd6b9ec1b0cb47515246af73631e4cbb8fc5ff00049923716babd19f348b64f873629012d397a8e564231c6b1c0f32797457e9a2045b92ae62781b00ccdd2cb93384f14ea5d19da4d148930cb11e0147af84363b5adaee89544f67803d50fc7de3b322eae834e5a2b5a33ec4c6696ccdec115a1c2406f7b72a0d001da127aa2b5b8986d80e8b63ea915dd8f5551873b335346127ba54da5aa0dbe9751a5ab697dd6752bd0b48416967a29787e3194d920d7c6feee97436ae2b1bb7d10b1f1768948b0d45731c3bc42b27b2484486a2a6d668708a3f1160f7bbde40f458f6215ceb16df53d3905a17b0ae2300cd46f362f2258fc486e591a3d035def5d0c38bf7490f1ec83ed4284c55af70da40241e6459df1685548aa3f6f25b3fb49c07e954f9983fab15dc3c5bbb87c8fa2c2de482a650d9ba13d0523b15cac67774dd40ed74ba4c6f24ea52516f3b38da59b716b0ea97da556d98347503e08d534d716516b8bc6ad1e8853dd1646291062abaa8f4bb4dfaeaa2d43a6be62fef1e42ff00a25bb10945c18eff00a2543248752db2b740dc5e90c39f311de2df8dd76161e6a73ae05ca8134a953b6679248e39a49006a49b01e27657fc0715a8c39ad6c7b1fac08b824ea4ff003a2aef0bd01665aa91bdcb90ce62fcc9e87a2be5218a76e523bdc8ac9e44d5f1665c92727a2cd83f1df6997b48f283b904903d110c7b1b8cc6046e04bbe01575b83451c200ef388f774541acad7c323985c4d8dbf9ef5cfb73955e8572715b2cf15635af374338a6b9a18483c90d8ea0bb555fe23af36ca792df8e117d080aa5aa73e5b6c2e8ed5d1136d95630ccc5d987244ea71292fae8b54a1f6a42d1666bfba4136285b1c4bade28b62f236ca16153b5a6eed9628abd09ec90ca51bd946c5e51134006e48f727f11c63368c018debccaab56ce5c4dc92b6e3f1f76cb52234cebdcae5056c904ac962765918e0e69e841d2e398ebd6ebc4a65c16c03e98e14e268f10a66cccd1df5646f363c0d5bebb8f0b2a17b40e11ca5d510b7ba757b5bf64fde03eef82a0f04f143f0fa80fb9313acd95bd5b7d1c3f105f40d3d4326635ec21cc736ed3bdc1ff00b4ae365b199f3bc808364812eab4ce31e08cd7929c6bb98f913d5be3e0b32aa8cb1c43c1041d74d47985571a345df415a1a91cf923d056306e01f054a8a5b6c6e9dfa59ea91e31a1968b5cf5119fb214492a5a0681578d61ea9b7d678953c46f95136bea6e3d50f8985de491ab94da33a5ac994514b6e4cb470be2a2c629007308cae6f51b023a108a4e5d46e677f3466fd9bce971be527ef054e84169046e3f96578c3248eaa1304c2f1bc7ab4f22d3c9c0ea1264c11c9a65738fb44dc33127c99bbd66f86bbf8a930e1b0f66e79b39ce3a936597e28daac32731f68729d58eddaf6723fa11c94ca0e2dcce1db0d011b69f05832f813ee2cabfd2c7161af7c8f2c6da3be8501e2ac1f283d55b69f8b206c64b353c9bcfdc815455fd209279a31296396c95149156e1a837bf553abe21991c870a0c65c20758c2e71f05a7e4dd90d521c747be77e63f876f52a34b37209a9e6239a8e5fe2b5c71c622a5476ae521a7aa1c4fc93d5925d303f4569274243976ebae082061eb45f647c59d9c9f4299dfd379fe893f65fcd97e87978ace5eb8d241041b1041046e083a14127d52f8ee151f8d38584c0b9a009391eb6e4517f679c422ba95ae71feab3b920fc43677911aab25453870d90d58e9d1f33d45096bcb5c0b5cd3623620fede2901a7a95adf1af07f6c3b48fbb201a7e21f74feeb3374041208b106c41dc10a89268d10929220188f82eb29faa98d6782ef6774b63f1180d526923bfa6fe479a4166aa5501b48dbeceee9f22a53d8ae24b1168112c29f91de07f974e7ff00cf22e1488690d95ca254d87711c3a3aea730cba11ac6fe6c76c1c3c0f30b18c570f929a57432b72bd86c7a11c9c0f30770b64c35e47811b207c6ed82b581a1a44b1dc324d00ff2ddccb74f44f454ccd21aa239a3b83e3395c1af3dd3a03d0f8aab6a0d8ee37ba75afe5c95738292a62db35496a2d1dbc10a658ea86613891920b1faccee9f1e854880e9bae64a2e32a19b023df7d520b924bb448739756851b91c90c2bae4c48d276362a481f684a2141ed9e129b537d2ca40ebceabcd5c76eb975005abd9cf117d0ab1a5c7fa52da393c2ff55de87e057d1f1588046a08f82f91c85bff00b1fe25fa4d2f62f75e582cd3d5ccd98ef85bd14928b955c1759f71af09f680cd137fa807787de03f55a7491dd57f88712645dc6d9d21d86f6079badf250e29a2c8ba7a30d235b1d08defb83d085c2d56be2ac0c861a9fb408127a9b077f3aaab34dd66941c59ae12e4ac8e5baa79ecee9ebb8f31a84b6c7aa71c8435175c3dc25863900facd04f9db5f8dd3ae8adb285c1d2e6a7cbf75ee1f1bfea8d8a7bb6eb6c69a30cb4c1f0121d7f242f15688e473b66805daf43afe88cf6762a8ded231701dd830ea40ce7a0e4df551221943a89733dcefbce27de495c69484a68ba52027804f9643f74b4dfc2db7edeaa798e49c92deeb4682e6d740c39adb5892799e56e9647e865eeacd9beaee84910b326c948ccbc0dd68245592084b0924a00439a084db1a05ca71e5324dd48092bc4a538249401e08ff047101a1ac8e7bf72f9641d6376feed1de8abe0a5200fa9f14c780686c2439ce00e61a8008b83e26c8251d0dc979fac77773f7aa97b2cc4db341d938f7e2ee9ea5bbb1df31e8b478a1b27f43595ee2b0d8e8a6b9fb3617eae200f8959536c15f3da5c553246d1146e740c39a42dd4e6d81cbcda35f559d0946c4acf9b6cd382a891982497dfc93123fa2f0935d74d36549a2cb4f00cf77cd1fe577cda7e4aeb16a1667c255392b58393dae6fadb30f92d243ace5af13d18b2afb0dcb01bdc2cc3da170e3e271aa04b9af700ebfd975b4f4d16c0d8efb2a37b61a82da58a3fbd29bffa5b71f34ef656642bcbcbc5201e08c53cc40f720e8cc00e506dc82ab2f424c8774a0f4d0294ad24703d773260b975ae400a9baf248b2749ba65c2c7c3e4803af4da5b8a41401e09613774a0800f705e2e696ad8e27b8fb31fd2c4e87d0d8f95d7d0b875635cdb3b90f5057cba56e1ecff0015fa452b1f7efb3fa6ff00368dfd4594a2517581f71ef555e28e078aa6ef8ad14bd40ee38fe36fea2c7cd581d505a2e1b7ea2f63e62eb83186ece8e41fed3f228693193a30ac570e969a531cac2d3cb9823ab5dcc28ece456d78d414d54c31cd71d09696969ead2b25c77047d2bb2b88730df23dba870f1e8ef0544f1b46884d322d238f6d0b9a2e7b565875bb80b7c56b988332b8059161329654404ec268fcaf982da7158beab93e21331ec3e6b8f159afb67aecd343083f5585e7cde6c3e015fa0bb5faec7f758a71b573a6ae99ee16efe568e8d6e82de1a5fd55ade8a406570ae95e4a0715c30f0c3133f2854e567c33fc26f92cde57e9424fa01dd749495ebad24892579a5252820071a579cb8128a00688b69ee49714e39325007425048096803aad7ece71d75354e4bf725b348fc43ea9f75c7b95502eb1e5a439a6ce69041f106e3e4803e8fa3c418f171eefd17a716d46df240f0395b510473b3edb4123a3868e1e8eba2d0484775c14a189950d6bda1d6432b70864d1ba370eeb87bba11e2a747a5c72dc25c4537ad82ecc465a67473063beb325634fe60f0b7aa8a7cd18f2592f1f50f655ec70d04ce89ffeacc1aefd16cec6f7479055c15365b3768adc8cd0f82c4f8de10250e1b9b83e9b2dcf168f2079fc04aca31ac23b76b8fda1721332a280bcba06b65c2948388e61135d96e9faa06a4d2cf96fe89724792a21ab38bc57ae924a701296136961003817525aba8010f4dbd3af4d9401c0949012c94033a0ae95c0bc1043349f6458a7f8b4ce3ffdacdfa80f03ff00c9f7ad2648d7cf981e2469aa22987d87027f2ea1c3fda4afa0619c38020dc10083d41b107dc54a1d0963eda14fc6131237a2453cd63aa74004f68587768da5900d63a9881fcb2380f9d968c1ba203590b6466570b82e61f56b8381f785606ede9f0515b24aff0015bc3613d5ddd1faff003c550e923ef10ad3c67539a5118d98dd7f33b5f7dacabcc1de052cbb20cb78ae87b1a991a362730f276bf3ba1055f3da5d17f8728e5769f5d415430a0838bcbc5710492170af2e291448296d484a672f35002da57525a9610071c9a29d7269c803d95712da9326e803a02e82ba1250078ad93d9be27db51b5a4f7a12633e5bb3e1f258e395ff00d919fea547e58ffe4e5289469a0a4ba35d09d6a9198f53c6e706db70f683e448563a89044c73dc7bad17f772fd107c379fe61f35238bcffe9cfe767cd49067f57397b9cf3bb8971f54860d17a4dfd575891810788e9bb6a77339e536f31a85908dd6d736def58d577f8aff00ceef99400d392425b92142211fffd9, 'jpg');

-- tablo yapısı dökülüyor yektamak_erp.pozisyon
CREATE TABLE IF NOT EXISTS `pozisyon` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.pozisyon: ~22 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `pozisyon` (`Id`, `Ad`, `Kod`) VALUES
	(1, 'Genel Müdür', 'GM'),
	(2, 'Proje Müdürü', 'PM'),
	(3, 'Satış Müdürü', 'SM'),
	(4, 'İmalat Müdürü', 'IM'),
	(5, 'Satış Sorumlsu', 'SS'),
	(6, 'Proje Sorumlusu', 'PS'),
	(7, 'Satın Alma Sorumlusu', 'SAS'),
	(8, 'Depo Sorumlusu', 'DS'),
	(9, 'Giriş Kalite Sorumlusu', 'GKS'),
	(10, 'Otomasyon Takım Lideri', 'OTL'),
	(11, 'Talaşlı İmalat Sorumlusu', 'TIS'),
	(12, 'İmalat Sorumlusu', 'IS'),
	(13, 'Kalite Yönetim Sistemi Risk Temsilcisi', 'KYSRT'),
	(14, 'Teknik Kalite Sorumlusu', 'TKS'),
	(15, 'Kaynaklı İmalat Personeli', 'KIP'),
	(16, 'Malzeme Planlama Sorumlusu', 'MPS'),
	(17, 'Muhasebe Müdürü', 'MM'),
	(18, 'Dijital Pazarlama Birimi', 'DPB'),
	(19, 'Muhasebe Sorumlusu', 'MS'),
	(20, 'Genel Müdür Yardımcısı', 'GMY'),
	(21, 'Stajyer Öğrenci', 'SO'),
	(22, 'ERP Sorumlusu', 'ERPS');

-- tablo yapısı dökülüyor yektamak_erp.proje
CREATE TABLE IF NOT EXISTS `proje` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ProjeTipId` int DEFAULT NULL,
  `MarkaId` int DEFAULT NULL,
  `ProjeNo` int DEFAULT NULL,
  `AltGrupId` int DEFAULT NULL,
  `KategoriId` int DEFAULT NULL,
  `Aciklama` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FilePaths` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SatisSiparisId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_proje_AltGrupId` (`AltGrupId`),
  KEY `IX_proje_KategoriId` (`KategoriId`),
  KEY `IX_proje_MarkaId` (`MarkaId`),
  KEY `IX_proje_ProjeTipId` (`ProjeTipId`),
  KEY `IX_proje_SatisSiparisId` (`SatisSiparisId`),
  CONSTRAINT `FK_proje_marka_MarkaId` FOREIGN KEY (`MarkaId`) REFERENCES `marka` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_proje_markaaltgrup_AltGrupId` FOREIGN KEY (`AltGrupId`) REFERENCES `markaaltgrup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_proje_markaaltgrupkategori_KategoriId` FOREIGN KEY (`KategoriId`) REFERENCES `markaaltgrupkategori` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_proje_projetip_ProjeTipId` FOREIGN KEY (`ProjeTipId`) REFERENCES `projetip` (`ProjeTipId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_proje_satissiparis_SatisSiparisId` FOREIGN KEY (`SatisSiparisId`) REFERENCES `satissiparis` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.proje: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `proje` (`Id`, `Kod`, `Ad`, `ProjeTipId`, `MarkaId`, `ProjeNo`, `AltGrupId`, `KategoriId`, `Aciklama`, `FilePaths`, `SatisSiparisId`) VALUES
	(1, '21', 'seyiton makine', 2, 3, NULL, 3, 5, NULL, NULL, 1),
	(10, '15', '15', 3, 3, NULL, 3, 11, NULL, NULL, 1);

-- tablo yapısı dökülüyor yektamak_erp.projesorumlu
CREATE TABLE IF NOT EXISTS `projesorumlu` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProjeId` int DEFAULT NULL,
  `PersonelId` int DEFAULT NULL,
  `Gorev` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_projesorumlu_PersonelId` (`PersonelId`),
  KEY `IX_projesorumlu_ProjeId` (`ProjeId`),
  CONSTRAINT `FK_projesorumlu_personel_PersonelId` FOREIGN KEY (`PersonelId`) REFERENCES `personel` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_projesorumlu_proje_ProjeId` FOREIGN KEY (`ProjeId`) REFERENCES `proje` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.projesorumlu: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `projesorumlu` (`Id`, `ProjeId`, `PersonelId`, `Gorev`) VALUES
	(3, 1, 2, NULL),
	(4, 1, 7, NULL),
	(5, 10, 2, NULL);

-- tablo yapısı dökülüyor yektamak_erp.projestokkart
CREATE TABLE IF NOT EXISTS `projestokkart` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProjeId` int DEFAULT NULL,
  `StokKartId` int DEFAULT NULL,
  `Miktar` decimal(65,30) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_projestokkart_ProjeId` (`ProjeId`),
  KEY `IX_projestokkart_StokKartId` (`StokKartId`),
  CONSTRAINT `FK_projestokkart_proje_ProjeId` FOREIGN KEY (`ProjeId`) REFERENCES `proje` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_projestokkart_stokkart_StokKartId` FOREIGN KEY (`StokKartId`) REFERENCES `stokkart` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.projestokkart: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `projestokkart` (`Id`, `ProjeId`, `StokKartId`, `Miktar`) VALUES
	(2, 1, 6, NULL);

-- tablo yapısı dökülüyor yektamak_erp.projesurectanim
CREATE TABLE IF NOT EXISTS `projesurectanim` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Aciklama` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.projesurectanim: ~7 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `projesurectanim` (`Id`, `Ad`, `Aciklama`) VALUES
	(4, 'TASARIM', NULL),
	(5, 'SATIN ALMA', NULL),
	(6, 'KAYNAKLI İMALAT', NULL),
	(7, 'İMALAT', NULL),
	(8, 'MONTAJ - DENEME', NULL),
	(9, 'OTOMASYON - PANO', NULL),
	(10, 'NAKLİYE - KURULUM', NULL);

-- tablo yapısı dökülüyor yektamak_erp.projetakvim
CREATE TABLE IF NOT EXISTS `projetakvim` (
  `ProjeTakvimId` int NOT NULL AUTO_INCREMENT,
  `ProjeId` int DEFAULT NULL,
  `ProjeSurecId` int DEFAULT NULL,
  `PlanlananBaslangicTarihi` datetime(6) DEFAULT NULL,
  `PlanlananBitisTarihi` datetime(6) DEFAULT NULL,
  `GerceklesenBaslangicTarihi` datetime(6) DEFAULT NULL,
  `GerceklesenBitisTarihi` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`ProjeTakvimId`),
  KEY `IX_projetakvim_ProjeId` (`ProjeId`),
  KEY `IX_projetakvim_ProjeSurecId` (`ProjeSurecId`),
  CONSTRAINT `FK_projetakvim_proje_ProjeId` FOREIGN KEY (`ProjeId`) REFERENCES `proje` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_projetakvim_projesurectanim_ProjeSurecId` FOREIGN KEY (`ProjeSurecId`) REFERENCES `projesurectanim` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.projetakvim: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `projetakvim` (`ProjeTakvimId`, `ProjeId`, `ProjeSurecId`, `PlanlananBaslangicTarihi`, `PlanlananBitisTarihi`, `GerceklesenBaslangicTarihi`, `GerceklesenBitisTarihi`) VALUES
	(9, 1, 4, '2025-07-18 00:00:00.000000', '2025-07-31 00:00:00.000000', NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.projetip
CREATE TABLE IF NOT EXISTS `projetip` (
  `ProjeTipId` int NOT NULL AUTO_INCREMENT,
  `ProjeTipAd` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ProjeTipId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.projetip: ~4 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `projetip` (`ProjeTipId`, `ProjeTipAd`) VALUES
	(2, 'NORMAL'),
	(3, 'AS 9100'),
	(4, 'AR-GE'),
	(5, 'SSH');

-- tablo yapısı dökülüyor yektamak_erp.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Ad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kod` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.rol: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `rol` (`Id`, `Ad`, `Kod`) VALUES
	(1, 'Admin', '1'),
	(2, 'Stajyer', '2'),
	(4, 'Yonetici', '3');

-- tablo yapısı dökülüyor yektamak_erp.satinalmasiparisbaslik
CREATE TABLE IF NOT EXISTS `satinalmasiparisbaslik` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `SiparisNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ProjeId` int DEFAULT NULL,
  `ParcaGrupId` int DEFAULT NULL,
  `SiparisTarihi` datetime(6) DEFAULT NULL,
  `TeslimTarihi` datetime(6) DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  `OdemeVadeId` int DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tutar` double DEFAULT NULL,
  `DovizCinsiId` int DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmasiparisbaslik: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `satinalmasiparisbaslik` (`Id`, `SiparisNo`, `ProjeId`, `ParcaGrupId`, `SiparisTarihi`, `TeslimTarihi`, `FirmaId`, `OdemeVadeId`, `Aciklama`, `Tutar`, `DovizCinsiId`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`) VALUES
	(2, 'YKMSIP-2025-000001', NULL, NULL, '2025-07-25 14:51:56.071675', NULL, 2, NULL, NULL, NULL, NULL, '2025-07-25 14:52:05.519550', NULL, 'ABDURRAHMAN', '2025-07-25 14:56:38.692323', NULL, NULL),
	(3, 'YKMSIP-2025-000002', NULL, NULL, '2025-07-25 16:06:33.007854', NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-25 16:06:41.441364', NULL, 'ABDURRAHMAN', NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.satinalmasiparisdetay
CREATE TABLE IF NOT EXISTS `satinalmasiparisdetay` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `SatinalmaSiparisBaslikId` bigint NOT NULL,
  `StokKartId` bigint DEFAULT NULL,
  `Miktar` int DEFAULT NULL,
  `BirimFiyat` double DEFAULT NULL,
  `DovizCinsiId` int DEFAULT NULL,
  `Kdv` double DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `OlcuBirimi` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_satinalmasiparisdetay_SatinalmaSiparisBaslikId` (`SatinalmaSiparisBaslikId`),
  CONSTRAINT `FK_satinalmasiparisdetay_satinalmasiparisbaslik_SatinalmaSipari~` FOREIGN KEY (`SatinalmaSiparisBaslikId`) REFERENCES `satinalmasiparisbaslik` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmasiparisdetay: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `satinalmasiparisdetay` (`Id`, `SatinalmaSiparisBaslikId`, `StokKartId`, `Miktar`, `BirimFiyat`, `DovizCinsiId`, `Kdv`, `Aciklama`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`, `OlcuBirimi`) VALUES
	(3, 2, 10, 10, 20, NULL, NULL, NULL, '2025-07-25 14:56:38.719644', NULL, NULL, NULL, NULL, NULL, NULL),
	(4, 2, 11, 20, 40, NULL, NULL, NULL, '2025-07-25 14:56:38.727625', NULL, NULL, NULL, NULL, NULL, NULL),
	(5, 3, 11, 5, NULL, NULL, NULL, NULL, '2025-07-25 16:06:41.601296', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.satinalmatalepbaslik
CREATE TABLE IF NOT EXISTS `satinalmatalepbaslik` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `SatinalmaTalepNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ProjeId` int DEFAULT NULL,
  `MalzemeGrupId` int DEFAULT NULL,
  `TalepTarihi` datetime(6) DEFAULT NULL,
  `TeslimTarihi` datetime(6) DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TalepEdenKullaniciId` int DEFAULT NULL,
  `OnayKullaniciId` int DEFAULT NULL,
  `OnayDurum` tinyint(1) DEFAULT NULL,
  `OnayTarihi` datetime(6) DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_satinalmatalepbaslik_FirmaId` (`FirmaId`),
  KEY `IX_satinalmatalepbaslik_OnayKullaniciId` (`OnayKullaniciId`),
  KEY `IX_satinalmatalepbaslik_TalepEdenKullaniciId` (`TalepEdenKullaniciId`),
  CONSTRAINT `FK_satinalmatalepbaslik_firma_FirmaId` FOREIGN KEY (`FirmaId`) REFERENCES `firma` (`Id`),
  CONSTRAINT `FK_satinalmatalepbaslik_kullanici_OnayKullaniciId` FOREIGN KEY (`OnayKullaniciId`) REFERENCES `kullanici` (`Id`),
  CONSTRAINT `FK_satinalmatalepbaslik_kullanici_TalepEdenKullaniciId` FOREIGN KEY (`TalepEdenKullaniciId`) REFERENCES `kullanici` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmatalepbaslik: ~9 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `satinalmatalepbaslik` (`Id`, `SatinalmaTalepNo`, `ProjeId`, `MalzemeGrupId`, `TalepTarihi`, `TeslimTarihi`, `Aciklama`, `TalepEdenKullaniciId`, `OnayKullaniciId`, `OnayDurum`, `OnayTarihi`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`, `FirmaId`) VALUES
	(26, 'YKMTLP541', NULL, NULL, '2025-07-17 14:20:50.352962', NULL, NULL, 1, 1, 1, '2025-07-17 14:22:07.019796', '2025-07-17 14:20:50.353150', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 1),
	(31, 'YKMTLP542', NULL, NULL, '2025-07-18 14:44:15.803741', '2025-07-26 00:00:00.000000', NULL, 1, 1, NULL, NULL, '2025-07-18 14:44:15.803816', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(33, 'YKMTLP543', NULL, NULL, '2025-07-18 14:49:23.493969', NULL, '44', 1, 1, 0, '2025-07-18 14:49:46.509347', '2025-07-18 14:49:23.494057', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 1),
	(34, 'YKMTLP544', NULL, NULL, '2025-07-18 16:43:31.326668', '2025-07-20 00:00:00.000000', NULL, 1, 1, 1, '2025-07-21 12:23:23.608884', '2025-07-18 16:43:31.326730', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(36, 'YKMTLP545', NULL, NULL, '2025-07-18 16:48:35.728342', '2025-07-23 00:00:00.000000', NULL, 1, 5, 0, '2025-07-25 09:52:40.779617', '2025-07-18 16:48:35.728443', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(37, 'YKMTLP546', NULL, NULL, '2025-07-18 17:38:37.551100', NULL, NULL, 1, 1, 1, '2025-07-21 12:20:56.609143', '2025-07-18 17:38:37.551206', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(38, 'YKMTLP547', NULL, NULL, '2025-07-21 12:13:36.339858', '2025-07-26 00:00:00.000000', NULL, 1, 5, 0, '2025-07-25 09:52:53.971897', '2025-07-21 12:13:36.340005', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(41, 'YKMTLP548', NULL, NULL, '2025-07-25 09:50:07.967587', '2025-07-30 00:00:00.000000', 'Profil ihtiyacı acil.', 1, 5, 1, '2025-07-25 09:51:44.266280', '2025-07-25 09:50:07.967649', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 1),
	(43, 'YKMTLP549', NULL, NULL, '2025-07-25 10:04:36.296007', '2025-07-26 00:00:00.000000', NULL, 1, 5, NULL, NULL, '2025-07-25 10:04:36.296127', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2),
	(44, 'YKMTLP5410', NULL, NULL, '2025-07-28 17:40:31.621524', '2025-07-30 00:00:00.000000', NULL, 1, 5, NULL, NULL, '2025-07-28 17:40:31.621715', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.satinalmatalepdetay
CREATE TABLE IF NOT EXISTS `satinalmatalepdetay` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `SatinalmaTalepBaslikId` bigint NOT NULL,
  `StokKartId` int DEFAULT NULL,
  `Miktar` int DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `OnayKullaniciId` int DEFAULT NULL,
  `OnayDurum` tinyint(1) DEFAULT NULL,
  `OnayTarihi` datetime(6) DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `OlcuBirimi` int DEFAULT NULL,
  `StokKartId1` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_satinalmatalepdetay_OlcuBirimi` (`OlcuBirimi`),
  KEY `IX_satinalmatalepdetay_SatinalmaTalepBaslikId` (`SatinalmaTalepBaslikId`),
  KEY `IX_satinalmatalepdetay_StokKartId` (`StokKartId`),
  KEY `IX_satinalmatalepdetay_StokKartId1` (`StokKartId1`),
  CONSTRAINT `FK_satinalmatalepdetay_olcubirim_OlcuBirimi` FOREIGN KEY (`OlcuBirimi`) REFERENCES `olcubirim` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_satinalmatalepdetay_satinalmatalepbaslik_SatinalmaTalepBasli~` FOREIGN KEY (`SatinalmaTalepBaslikId`) REFERENCES `satinalmatalepbaslik` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_satinalmatalepdetay_stokkart_StokKartId` FOREIGN KEY (`StokKartId`) REFERENCES `stokkart` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_satinalmatalepdetay_stokkart_StokKartId1` FOREIGN KEY (`StokKartId1`) REFERENCES `stokkart` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmatalepdetay: ~13 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `satinalmatalepdetay` (`Id`, `SatinalmaTalepBaslikId`, `StokKartId`, `Miktar`, `Aciklama`, `OnayKullaniciId`, `OnayDurum`, `OnayTarihi`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`, `OlcuBirimi`, `StokKartId1`) VALUES
	(54, 26, 6, 5, '5p', NULL, 1, '2025-07-17 14:22:05.113210', '2025-07-21 09:40:18.873185', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 6, NULL),
	(55, 26, 8, 10, '10', NULL, 1, '2025-07-17 14:22:06.967247', '2025-07-21 09:40:18.948383', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 10, NULL),
	(59, 33, 6, 12, '4', NULL, 0, '2025-07-18 14:49:45.848818', '2025-07-21 09:40:32.700681', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 2, NULL),
	(60, 33, 8, 5, '6', NULL, 0, '2025-07-18 14:49:46.464969', '2025-07-21 09:40:32.732205', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 7, NULL),
	(66, 36, 8, 4, NULL, NULL, 0, '2025-07-25 09:52:40.762087', '2025-07-21 09:40:58.017356', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, NULL, NULL),
	(68, 38, 8, 5, NULL, NULL, 0, '2025-07-25 09:52:53.958498', '2025-07-21 12:14:40.703166', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 4, NULL),
	(69, 31, 6, 54, '5', NULL, 0, '2025-07-18 14:45:25.177898', '2025-07-21 12:17:53.446465', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 3, NULL),
	(70, 31, 8, 5, '65', NULL, 0, '2025-07-18 14:45:26.035516', '2025-07-21 12:17:53.520225', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 7, NULL),
	(71, 37, 6, 4, '4', NULL, 1, '2025-07-21 12:20:56.548306', '2025-07-21 12:18:32.399762', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 3, NULL),
	(72, 34, 6, 4, NULL, NULL, 1, '2025-07-21 12:23:23.554218', '2025-07-21 12:23:14.745273', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, NULL, NULL),
	(85, 41, 8, 10, NULL, NULL, 1, '2025-07-25 09:51:38.589982', '2025-07-25 09:50:43.338936', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 4, NULL),
	(86, 41, 6, 50, NULL, NULL, 1, '2025-07-25 09:51:44.244900', '2025-07-25 09:50:43.366351', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 3, NULL),
	(88, 43, 6, 5, NULL, NULL, NULL, NULL, '2025-07-25 10:04:48.952315', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 3, NULL),
	(89, 44, 10, 2, NULL, NULL, NULL, NULL, '2025-07-28 17:41:01.184030', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 5, NULL),
	(90, 44, 19, 2, NULL, NULL, NULL, NULL, '2025-07-28 17:41:01.266839', NULL, 'ABDURRAHMAN', NULL, NULL, NULL, 6, NULL);

-- tablo yapısı dökülüyor yektamak_erp.satinalmateklifbaslik
CREATE TABLE IF NOT EXISTS `satinalmateklifbaslik` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `TeklifNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ProjeId` int DEFAULT NULL,
  `ParcaGrupId` int DEFAULT NULL,
  `TeklifTalepTarihi` datetime(6) DEFAULT NULL,
  `TerminSuresi` int DEFAULT NULL,
  `TeklifTarihi` datetime(6) DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  `OdemeVadeId` int DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tutar` double DEFAULT NULL,
  `DovizCinsiId` int DEFAULT NULL,
  `TeklifGecerlilikSuresi` int DEFAULT NULL,
  `TeklifTalepSurecId` int DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmateklifbaslik: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.satinalmateklifdetay
CREATE TABLE IF NOT EXISTS `satinalmateklifdetay` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `SatinalmaTeklifBaslikId` bigint NOT NULL,
  `SatinalmaTalepDetayId` bigint DEFAULT NULL,
  `StokKartId` int DEFAULT NULL,
  `Miktar` int DEFAULT NULL,
  `BirimFiyat` double DEFAULT NULL,
  `DovizCinsiId` int DEFAULT NULL,
  `Aciklama` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kdv` double DEFAULT NULL,
  `CreationTime` datetime(6) DEFAULT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `OlcuBirimi` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_satinalmateklifdetay_SatinalmaTalepDetayId` (`SatinalmaTalepDetayId`),
  KEY `IX_satinalmateklifdetay_SatinalmaTeklifBaslikId` (`SatinalmaTeklifBaslikId`),
  CONSTRAINT `FK_satinalmateklifdetay_satinalmatalepdetay_SatinalmaTalepDetay~` FOREIGN KEY (`SatinalmaTalepDetayId`) REFERENCES `satinalmatalepdetay` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_satinalmateklifdetay_satinalmateklifbaslik_SatinalmaTeklifBa~` FOREIGN KEY (`SatinalmaTeklifBaslikId`) REFERENCES `satinalmateklifbaslik` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satinalmateklifdetay: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.satissiparis
CREATE TABLE IF NOT EXISTS `satissiparis` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SiparisNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SiparisTarihi` datetime(6) DEFAULT NULL,
  `TeslimTarihi` datetime(6) DEFAULT NULL,
  `SiparisTutari` double DEFAULT NULL,
  `OngoruMaliyeti` double DEFAULT NULL,
  `Kdv` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.satissiparis: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `satissiparis` (`Id`, `SiparisNo`, `SiparisTarihi`, `TeslimTarihi`, `SiparisTutari`, `OngoruMaliyeti`, `Kdv`) VALUES
	(1, '1', '2025-07-09 00:00:00.000000', '2025-07-20 00:00:00.000000', 150000, 100000, 20);

-- tablo yapısı dökülüyor yektamak_erp.sehir
CREATE TABLE IF NOT EXISTS `sehir` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` int DEFAULT NULL,
  `Ad` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UlkeId` int DEFAULT NULL,
  `UlkeId1` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_sehir_UlkeId` (`UlkeId`),
  KEY `IX_sehir_UlkeId1` (`UlkeId1`),
  CONSTRAINT `FK_sehir_ulke_UlkeId` FOREIGN KEY (`UlkeId`) REFERENCES `ulke` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_sehir_ulke_UlkeId1` FOREIGN KEY (`UlkeId1`) REFERENCES `ulke` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.sehir: ~13 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `sehir` (`Id`, `Kod`, `Ad`, `UlkeId`, `UlkeId1`) VALUES
	(1, 54, 'Sakarya', 1, NULL),
	(2, 34, 'İstanbul', 1, NULL),
	(3, 6, 'Ankara', 1, NULL),
	(4, 42, 'Konya', 1, NULL),
	(5, 16, 'Bursa', 1, NULL),
	(6, 35, 'İzmir', 1, NULL),
	(7, 7, 'Antalya', 1, NULL),
	(8, 14, 'Bolu', 1, NULL),
	(9, 48, 'Muğla', 1, NULL),
	(10, 0, 'Bakü', 2, NULL),
	(11, 43, 'Kütahya', 1, NULL),
	(12, 32, 'Isparta', 1, NULL),
	(13, 3, 'Afyonkarahisar', 1, NULL);

-- tablo yapısı dökülüyor yektamak_erp.stokgrup
CREATE TABLE IF NOT EXISTS `stokgrup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.stokgrup: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `stokgrup` (`Id`, `Kod`, `Ad`) VALUES
	(3, 'MT', 'METAL'),
	(4, 'MA', 'MEKANİK ALT SİSTEM'),
	(5, 'HR', 'HIRDAVAT'),
	(6, 'EL', 'ELEKTRİK ELEKTRONİK'),
	(7, 'İS', 'İŞLETME SARF MALZEMESİ'),
	(8, 'MB', 'MATBAA');

-- tablo yapısı dökülüyor yektamak_erp.stokkart
CREATE TABLE IF NOT EXISTS `stokkart` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ParcaKod` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ParcaAdi` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Boyut` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Malzeme` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Aciklama` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Agirlik` double DEFAULT NULL,
  `Boy` double DEFAULT NULL,
  `En` double DEFAULT NULL,
  `Yukseklik` double DEFAULT NULL,
  `Uzunluk` double DEFAULT NULL,
  `Cap` double DEFAULT NULL,
  `EtKalınligi` double DEFAULT NULL,
  `StokGrupId` int DEFAULT NULL,
  `StokTipId` int DEFAULT NULL,
  `MalzemeGrupId` int DEFAULT NULL,
  `MalzemeAltGrupId` int DEFAULT NULL,
  `MalzemeAltGrup2Id` int DEFAULT NULL,
  `OlcuBirimId` int DEFAULT NULL,
  `MalzemeStandartId` int DEFAULT NULL,
  `HammaddeId` int DEFAULT NULL,
  `IsFromExcel` tinyint(1) NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatedByUser` int DEFAULT NULL,
  `CreatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdatedTime` datetime(6) DEFAULT NULL,
  `UpdatedByUser` int DEFAULT NULL,
  `UpdatedByComputer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_stokkart_HammaddeId` (`HammaddeId`),
  KEY `IX_stokkart_MalzemeAltGrup2Id` (`MalzemeAltGrup2Id`),
  KEY `IX_stokkart_MalzemeAltGrupId` (`MalzemeAltGrupId`),
  KEY `IX_stokkart_MalzemeGrupId` (`MalzemeGrupId`),
  KEY `IX_stokkart_MalzemeStandartId` (`MalzemeStandartId`),
  KEY `IX_stokkart_OlcuBirimId` (`OlcuBirimId`),
  KEY `IX_stokkart_StokGrupId` (`StokGrupId`),
  KEY `IX_stokkart_StokTipId` (`StokTipId`),
  CONSTRAINT `FK_stokkart_hammadde_HammaddeId` FOREIGN KEY (`HammaddeId`) REFERENCES `hammadde` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_malzemealtgrup2_MalzemeAltGrup2Id` FOREIGN KEY (`MalzemeAltGrup2Id`) REFERENCES `malzemealtgrup2` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_malzemealtgrup_MalzemeAltGrupId` FOREIGN KEY (`MalzemeAltGrupId`) REFERENCES `malzemealtgrup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_malzemegrup_MalzemeGrupId` FOREIGN KEY (`MalzemeGrupId`) REFERENCES `malzemegrup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_malzemestandart_MalzemeStandartId` FOREIGN KEY (`MalzemeStandartId`) REFERENCES `malzemestandart` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_olcubirim_OlcuBirimId` FOREIGN KEY (`OlcuBirimId`) REFERENCES `olcubirim` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_stokgrup_StokGrupId` FOREIGN KEY (`StokGrupId`) REFERENCES `stokgrup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_stokkart_stoktip_StokTipId` FOREIGN KEY (`StokTipId`) REFERENCES `stoktip` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.stokkart: ~13 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `stokkart` (`Id`, `Kod`, `ParcaKod`, `Ad`, `ParcaAdi`, `Boyut`, `Malzeme`, `Aciklama`, `Agirlik`, `Boy`, `En`, `Yukseklik`, `Uzunluk`, `Cap`, `EtKalınligi`, `StokGrupId`, `StokTipId`, `MalzemeGrupId`, `MalzemeAltGrupId`, `MalzemeAltGrup2Id`, `OlcuBirimId`, `MalzemeStandartId`, `HammaddeId`, `IsFromExcel`, `CreationTime`, `CreatedByUser`, `CreatedByComputer`, `UpdatedTime`, `UpdatedByUser`, `UpdatedByComputer`) VALUES
	(6, '4', '1', 'aaa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, 3, 3, 9, NULL, 3, 4, 9, 0, '2025-07-10 13:34:20.348767', NULL, NULL, NULL, NULL, NULL),
	(8, NULL, NULL, 'profil', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, 2, 3, 7, NULL, 4, 4, 8, 0, '2025-07-17 10:28:49.276935', NULL, NULL, NULL, NULL, NULL),
	(10, NULL, NULL, 'd1', NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, 15, NULL, NULL, 5, NULL, NULL, 0, '2025-07-18 08:18:44.342900', NULL, NULL, NULL, NULL, NULL),
	(11, '', '1', 'd2', '1', NULL, '1', NULL, 1, 1, 1, 1, 1, 1, 1, 3, NULL, 4, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:20.509268', NULL, NULL, NULL, NULL, NULL),
	(12, NULL, NULL, 'd3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:26.207399', NULL, NULL, NULL, NULL, NULL),
	(13, NULL, NULL, 'd4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:31.110279', NULL, NULL, NULL, NULL, NULL),
	(14, NULL, NULL, 'd5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:35.498768', NULL, NULL, NULL, NULL, NULL),
	(15, NULL, NULL, 'd6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:41.166962', NULL, NULL, NULL, NULL, NULL),
	(16, NULL, NULL, 'd7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:47.325608', NULL, NULL, NULL, NULL, NULL),
	(17, NULL, NULL, 'd8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:17:56.116851', NULL, NULL, NULL, NULL, NULL),
	(18, NULL, NULL, 'd9', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 09:18:02.930568', NULL, NULL, NULL, NULL, NULL),
	(19, NULL, NULL, 'd10', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, 2, 2, 2, NULL, 6, 3, 5, 0, '2025-07-21 09:18:09.213869', NULL, NULL, NULL, NULL, NULL),
	(20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, 2, 4, NULL, NULL, NULL, NULL, NULL, 0, '2025-07-21 12:28:10.978475', NULL, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.stoktip
CREATE TABLE IF NOT EXISTS `stoktip` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.stoktip: ~7 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `stoktip` (`Id`, `Kod`, `Ad`) VALUES
	(2, 'HAMMADDE', 'HAMMADDE'),
	(3, 'YARI MAMÜL', 'YARI MAMÜL'),
	(4, 'MAMÜL', 'MAMÜL'),
	(5, 'SARF MALZEME', 'SARF MALZEME'),
	(6, 'İŞLETME MALZEMESİ', 'İŞLETME MALZEMESİ'),
	(7, 'HİZMET', 'HİZMET'),
	(8, 'SABİT KIYMET', 'SABİT KIYMET');

-- tablo yapısı dökülüyor yektamak_erp.teklif
CREATE TABLE IF NOT EXISTS `teklif` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `No` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Tarih` datetime(6) DEFAULT NULL,
  `SatisSorumluId` int DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  `Konusu` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MarkaId` int DEFAULT NULL,
  `AltGrupId` int DEFAULT NULL,
  `OngoruMaliyeti` int DEFAULT NULL,
  `OngoruMaliyetDovizCinsi` int DEFAULT NULL,
  `TeklifTutari` double DEFAULT NULL,
  `TeklifTutariDovizCinsi` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_teklif_FirmaId` (`FirmaId`),
  KEY `IX_teklif_SatisSorumluId` (`SatisSorumluId`),
  CONSTRAINT `FK_teklif_firma_FirmaId` FOREIGN KEY (`FirmaId`) REFERENCES `firma` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_teklif_personel_SatisSorumluId` FOREIGN KEY (`SatisSorumluId`) REFERENCES `personel` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.teklif: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.teklifmaliyetdetay
CREATE TABLE IF NOT EXISTS `teklifmaliyetdetay` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TeklifId` int NOT NULL,
  `MaliyetUnsuru` int DEFAULT NULL,
  `MaliyetTespitKanali` int DEFAULT NULL,
  `OngorulenMaliyet` int DEFAULT NULL,
  `DovizCinsiId` int DEFAULT NULL,
  `Belge` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_teklifmaliyetdetay_TeklifId` (`TeklifId`),
  CONSTRAINT `FK_teklifmaliyetdetay_teklif_TeklifId` FOREIGN KEY (`TeklifId`) REFERENCES `teklif` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.teklifmaliyetdetay: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.teklifsurec
CREATE TABLE IF NOT EXISTS `teklifsurec` (
  `TeklifSurecId` int NOT NULL AUTO_INCREMENT,
  `TeklifSurecTanimId` int NOT NULL,
  `TeklifId` int NOT NULL,
  `BaslamaZamani` datetime(6) DEFAULT NULL,
  `Sure` int DEFAULT NULL,
  `BitisZamani` datetime(6) DEFAULT NULL,
  `SorumluKullaniciId` int DEFAULT NULL,
  PRIMARY KEY (`TeklifSurecId`),
  KEY `IX_teklifsurec_TeklifId` (`TeklifId`),
  KEY `IX_teklifsurec_TeklifSurecTanimId` (`TeklifSurecTanimId`),
  CONSTRAINT `FK_teklifsurec_teklif_TeklifId` FOREIGN KEY (`TeklifId`) REFERENCES `teklif` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_teklifsurec_teklifsurectanim_TeklifSurecTanimId` FOREIGN KEY (`TeklifSurecTanimId`) REFERENCES `teklifsurectanim` (`TeklifSurecTanimId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.teklifsurec: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.teklifsurectanim
CREATE TABLE IF NOT EXISTS `teklifsurectanim` (
  `TeklifSurecTanimId` int NOT NULL AUTO_INCREMENT,
  `TeklifSurecTanimAdi` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `VarsayilanSorumluPozisyon` int DEFAULT NULL,
  `Sure` int DEFAULT NULL,
  PRIMARY KEY (`TeklifSurecTanimId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.teklifsurectanim: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.tekliftalep
CREATE TABLE IF NOT EXISTS `tekliftalep` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TeklifTalepTarihi` datetime(6) DEFAULT NULL,
  `SatisSorumlusuId` int DEFAULT NULL,
  `FirmaId` int DEFAULT NULL,
  `TeklifKonusu` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MarkaId` int DEFAULT NULL,
  `AltGrupId` int DEFAULT NULL,
  `KategoriId` int DEFAULT NULL,
  `ReferansKaynakId` int DEFAULT NULL,
  `IsTeklifSave` tinyint(1) DEFAULT NULL,
  `MaliyetSorumluId` int DEFAULT NULL,
  `MaliyetSorumluAtamaTarihi` datetime(6) DEFAULT NULL,
  `IsMaliyetTamamlandi` tinyint(1) DEFAULT NULL,
  `IsMaliyetOnaylandi` tinyint(1) DEFAULT NULL,
  `TeklifFiyati` double DEFAULT NULL,
  `TeklifFiyatDovizId` int DEFAULT NULL,
  `FinansalTakvimId` int DEFAULT NULL,
  `TeklifTarihi` datetime(6) DEFAULT NULL,
  `TeklifNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TeslimBilgileri` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TeklifSuresi` int DEFAULT NULL,
  `TeslimSuresi` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `IsMaliyetTalep` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_tekliftalep_AltGrupId` (`AltGrupId`),
  KEY `IX_tekliftalep_FinansalTakvimId` (`FinansalTakvimId`),
  KEY `IX_tekliftalep_FirmaId` (`FirmaId`),
  KEY `IX_tekliftalep_KategoriId` (`KategoriId`),
  KEY `IX_tekliftalep_MarkaId` (`MarkaId`),
  KEY `IX_tekliftalep_SatisSorumlusuId` (`SatisSorumlusuId`),
  CONSTRAINT `FK_tekliftalep_firma_FirmaId` FOREIGN KEY (`FirmaId`) REFERENCES `firma` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tekliftalep_marka_MarkaId` FOREIGN KEY (`MarkaId`) REFERENCES `marka` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tekliftalep_markaaltgrup_AltGrupId` FOREIGN KEY (`AltGrupId`) REFERENCES `markaaltgrup` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tekliftalep_markaaltgrupkategori_KategoriId` FOREIGN KEY (`KategoriId`) REFERENCES `markaaltgrupkategori` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tekliftalep_personel_SatisSorumlusuId` FOREIGN KEY (`SatisSorumlusuId`) REFERENCES `personel` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tekliftalep_projetakvim_FinansalTakvimId` FOREIGN KEY (`FinansalTakvimId`) REFERENCES `projetakvim` (`ProjeTakvimId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.tekliftalep: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.tekliftalepbelge
CREATE TABLE IF NOT EXISTS `tekliftalepbelge` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TeklifTalepId` int NOT NULL,
  `BelgeAd` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DosyaAd` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DosyaUzanti` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DosyaVeri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DosyaBoyut` double DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_tekliftalepbelge_TeklifTalepId` (`TeklifTalepId`),
  CONSTRAINT `FK_tekliftalepbelge_tekliftalep_TeklifTalepId` FOREIGN KEY (`TeklifTalepId`) REFERENCES `tekliftalep` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.tekliftalepbelge: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.tekliftalepsurec
CREATE TABLE IF NOT EXISTS `tekliftalepsurec` (
  `TeklifTalepSurecId` int NOT NULL AUTO_INCREMENT,
  `TeklifTalepSurecTanimId` int NOT NULL,
  `TeklifTalepId` int NOT NULL,
  `BaslamaZamani` datetime(6) DEFAULT NULL,
  `Sure` int DEFAULT NULL,
  `BitisZamani` datetime(6) DEFAULT NULL,
  `SorumluKullaniciId` int DEFAULT NULL,
  PRIMARY KEY (`TeklifTalepSurecId`),
  KEY `IX_tekliftalepsurec_TeklifTalepId` (`TeklifTalepId`),
  KEY `IX_tekliftalepsurec_TeklifTalepSurecTanimId` (`TeklifTalepSurecTanimId`),
  CONSTRAINT `FK_tekliftalepsurec_tekliftalep_TeklifTalepId` FOREIGN KEY (`TeklifTalepId`) REFERENCES `tekliftalep` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_tekliftalepsurec_tekliftalepsurectanim_TeklifTalepSurecTanim~` FOREIGN KEY (`TeklifTalepSurecTanimId`) REFERENCES `tekliftalepsurectanim` (`TeklifTalepSurecTanimId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.tekliftalepsurec: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.tekliftalepsurectanim
CREATE TABLE IF NOT EXISTS `tekliftalepsurectanim` (
  `TeklifTalepSurecTanimId` int NOT NULL AUTO_INCREMENT,
  `Aciklama` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `VarsayilanSorumluPozisyon` int DEFAULT NULL,
  `Sure` int DEFAULT NULL,
  `Ekran` int DEFAULT NULL,
  PRIMARY KEY (`TeklifTalepSurecTanimId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.tekliftalepsurectanim: ~0 rows (yaklaşık) tablosu için veriler indiriliyor

-- tablo yapısı dökülüyor yektamak_erp.ulke
CREATE TABLE IF NOT EXISTS `ulke` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Kod` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Ad` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.ulke: ~12 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `ulke` (`Id`, `Kod`, `Ad`) VALUES
	(1, 'TR', 'Türkiye'),
	(2, 'AZ', 'Azerbaycan'),
	(3, 'US', 'Amerika Birleşik Devletleri'),
	(4, 'BE', 'Belçika'),
	(5, 'DE', 'Almanya'),
	(6, 'NL', 'Hollanda'),
	(7, 'CH', 'İsviçre'),
	(8, 'FR', 'Fransa'),
	(9, 'RU', 'Rusya'),
	(10, 'UK', 'İngiltere'),
	(11, 'ES', 'İspanya'),
	(12, 'PL', 'Polonya');

-- tablo yapısı dökülüyor yektamak_erp.yetki
CREATE TABLE IF NOT EXISTS `yetki` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RolId` int NOT NULL,
  `MenuId` int NOT NULL,
  `EkranId` int DEFAULT NULL,
  `AlanId` int DEFAULT NULL,
  `DuzenlemeYetki` tinyint(1) NOT NULL,
  `GormeYetki` tinyint(1) NOT NULL,
  `CreateDate` datetime(6) DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `UpdatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_yetki_AlanId` (`AlanId`),
  KEY `IX_yetki_EkranId` (`EkranId`),
  KEY `IX_yetki_MenuId` (`MenuId`),
  KEY `IX_yetki_RolId` (`RolId`),
  CONSTRAINT `FK_yetki_alan_AlanId` FOREIGN KEY (`AlanId`) REFERENCES `alan` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_yetki_ekran_EkranId` FOREIGN KEY (`EkranId`) REFERENCES `ekran` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_yetki_menu_MenuId` FOREIGN KEY (`MenuId`) REFERENCES `menu` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_yetki_rol_RolId` FOREIGN KEY (`RolId`) REFERENCES `rol` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=1962 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.yetki: ~174 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `yetki` (`Id`, `RolId`, `MenuId`, `EkranId`, `AlanId`, `DuzenlemeYetki`, `GormeYetki`, `CreateDate`, `CreatedBy`, `UpdateDate`, `UpdatedBy`) VALUES
	(1731, 2, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1732, 2, 2, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1733, 2, 3, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1734, 2, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1735, 2, 5, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1736, 2, 6, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1737, 2, 7, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1738, 2, 8, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1739, 2, 9, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1740, 2, 10, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1741, 2, 23, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1742, 2, 11, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1743, 2, 13, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1744, 2, 14, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1745, 2, 15, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1746, 2, 16, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1747, 2, 17, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1748, 2, 18, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1749, 2, 19, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1750, 2, 20, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1751, 2, 21, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1752, 2, 22, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1753, 2, 24, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1754, 2, 25, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1755, 2, 26, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1756, 2, 27, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1757, 2, 28, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1758, 2, 29, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1759, 2, 30, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1760, 2, 31, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1761, 2, 32, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1762, 2, 33, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1763, 2, 34, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1764, 2, 35, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1765, 2, 36, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1766, 2, 37, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1767, 2, 38, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1768, 2, 39, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1769, 2, 40, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1770, 2, 41, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1771, 2, 42, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1772, 2, 43, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1773, 2, 44, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1774, 2, 47, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1775, 2, 48, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1776, 2, 49, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1777, 2, 50, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1778, 2, 51, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1779, 2, 52, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1780, 2, 53, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1781, 2, 54, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1782, 2, 55, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1783, 2, 56, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1784, 2, 57, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1785, 2, 58, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1786, 2, 59, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1844, 4, 1, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1845, 4, 2, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1846, 4, 3, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1847, 4, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1848, 4, 5, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1849, 4, 6, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1850, 4, 7, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1851, 4, 8, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1852, 4, 9, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1853, 4, 10, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1854, 4, 23, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1855, 4, 11, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1856, 4, 13, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1857, 4, 14, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1858, 4, 15, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1859, 4, 16, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1860, 4, 17, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1861, 4, 18, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1862, 4, 19, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1863, 4, 20, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1864, 4, 21, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1865, 4, 22, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1866, 4, 24, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1867, 4, 25, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1868, 4, 26, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1869, 4, 27, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1870, 4, 28, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1871, 4, 29, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1872, 4, 30, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1873, 4, 31, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1874, 4, 32, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1875, 4, 33, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1876, 4, 34, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1877, 4, 35, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1878, 4, 36, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1879, 4, 37, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1880, 4, 38, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1881, 4, 39, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL),
	(1882, 4, 40, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1883, 4, 41, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1884, 4, 42, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1885, 4, 43, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1886, 4, 44, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1887, 4, 47, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1888, 4, 48, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1889, 4, 49, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1890, 4, 50, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1891, 4, 51, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1892, 4, 52, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1893, 4, 53, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1894, 4, 54, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1895, 4, 55, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1896, 4, 56, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1897, 4, 57, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1898, 4, 58, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1899, 4, 59, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1900, 4, 60, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1901, 1, 1, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1902, 1, 2, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1903, 1, 3, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1904, 1, 4, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1905, 1, 5, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1906, 1, 6, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1907, 1, 7, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1908, 1, 8, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1909, 1, 9, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1910, 1, 10, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1911, 1, 23, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1912, 1, 11, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1913, 1, 13, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1914, 1, 14, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1915, 1, 15, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1916, 1, 16, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1917, 1, 17, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1918, 1, 18, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1919, 1, 19, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1920, 1, 20, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1921, 1, 21, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1922, 1, 22, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1923, 1, 24, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1924, 1, 25, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1925, 1, 26, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1926, 1, 27, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1927, 1, 28, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1928, 1, 29, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1929, 1, 30, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1930, 1, 31, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1931, 1, 32, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1932, 1, 33, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1933, 1, 34, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1934, 1, 35, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1935, 1, 36, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1936, 1, 37, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1937, 1, 38, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1938, 1, 39, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1939, 1, 40, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1940, 1, 41, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1941, 1, 42, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1942, 1, 43, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1943, 1, 44, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1944, 1, 47, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1945, 1, 48, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1946, 1, 49, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1947, 1, 50, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1948, 1, 51, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1949, 1, 52, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1950, 1, 53, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1951, 1, 54, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1952, 1, 55, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1953, 1, 56, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1954, 1, 57, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1955, 1, 58, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1956, 1, 59, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1957, 1, 60, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1958, 1, 61, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1959, 1, 62, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1960, 1, 63, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL),
	(1961, 1, 64, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL);

-- tablo yapısı dökülüyor yektamak_erp.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- yektamak_erp.__efmigrationshistory: ~13 rows (yaklaşık) tablosu için veriler indiriliyor
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250702072703_InitialCreate', '7.0.19'),
	('20250703062330_MenuYetkilendirmeInit', '7.0.19'),
	('20250703080038_AlanYetkiGuncellemesi', '7.0.19'),
	('20250704083158_EkranAdiGuncellemesi', '7.0.19'),
	('20250704085209_YetkiGuncelleme1', '7.0.19'),
	('20250707101346_YetkiGuncelleme2', '7.0.19'),
	('20250708063800_StokKartTablolar', '7.0.19'),
	('20250710140119_ProjeTablolar', '7.0.19'),
	('20250711075222_ProjeTablolar_projev2', '7.0.19'),
	('20250716055948_SatinAlmaTalepveTeklif', '7.0.19'),
	('20250716083029_SatinAlmaTalepveTeklif', '7.0.19'),
	('20250716085738_SatinAlmaTalepveTeklif_v2', '7.0.19'),
	('20250718081518_SatinAlmaTalepveTeklif_v2_talepdetay', '7.0.19');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
