-- MySQL dump 10.13  Distrib 5.5.13, for Win32 (x86)
--
-- Host: localhost    Database: tacro
-- ------------------------------------------------------
-- Server version	5.5.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AdminName` varchar(16) DEFAULT NULL,
  `AdminPassword` varchar(16) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `affair`
--

DROP TABLE IF EXISTS `affair`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `affair` (
  `AffairID` int(11) NOT NULL,
  `AffairDescription` varchar(50) DEFAULT NULL,
  `AffairOperatorID` int(11) DEFAULT NULL,
  `AffairTime` time DEFAULT NULL,
  `ProjectNum` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`AffairID`),
  KEY `AffairUser` (`AffairOperatorID`),
  KEY `AffairProject` (`ProjectNum`),
  CONSTRAINT `AffairProject` FOREIGN KEY (`ProjectNum`) REFERENCES `project` (`ProjectNum`),
  CONSTRAINT `AffairUser` FOREIGN KEY (`AffairOperatorID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affair`
--

LOCK TABLES `affair` WRITE;
/*!40000 ALTER TABLE `affair` DISABLE KEYS */;
/*!40000 ALTER TABLE `affair` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `ClientID` int(11) NOT NULL AUTO_INCREMENT,
  `ClientName` varchar(50) DEFAULT NULL,
  `ClientCompany` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ClientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clinicalcontact`
--

DROP TABLE IF EXISTS `clinicalcontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clinicalcontact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClinicalID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ClinicalContactClinical` (`ClinicalID`),
  KEY `ClinicalContactContact` (`ContactID`),
  CONSTRAINT `ClinicalContactClinical` FOREIGN KEY (`ClinicalID`) REFERENCES `clinicalresource` (`ClinicalID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `ClinicalContactContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clinicalcontact`
--

LOCK TABLES `clinicalcontact` WRITE;
/*!40000 ALTER TABLE `clinicalcontact` DISABLE KEYS */;
/*!40000 ALTER TABLE `clinicalcontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clinicalresource`
--

DROP TABLE IF EXISTS `clinicalresource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clinicalresource` (
  `ClinicalID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Hospital` varchar(50) DEFAULT NULL,
  `Department` varchar(50) DEFAULT NULL,
  `DepartIntro` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ClinicalID`),
  KEY `ClinicalResourceUser` (`UserID`),
  CONSTRAINT `ClinicalResourceUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clinicalresource`
--

LOCK TABLES `clinicalresource` WRITE;
/*!40000 ALTER TABLE `clinicalresource` DISABLE KEYS */;
/*!40000 ALTER TABLE `clinicalresource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contact` (
  `ContactID` int(11) NOT NULL AUTO_INCREMENT,
  `ContactName` varchar(50) DEFAULT NULL,
  `Position` varchar(50) DEFAULT NULL,
  `Mobilephone` varchar(50) DEFAULT NULL,
  `Telephone` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `PostCode` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ContactID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactrecord`
--

DROP TABLE IF EXISTS `contactrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactrecord` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ContactID` int(11) DEFAULT NULL,
  `RecordDetail` varchar(50) DEFAULT NULL,
  `RecordTime` time DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactrecord`
--

LOCK TABLES `contactrecord` WRITE;
/*!40000 ALTER TABLE `contactrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `CustomerCity` varchar(50) DEFAULT NULL,
  `CustomerType` varchar(50) DEFAULT NULL,
  `CustomerRank` varchar(50) DEFAULT NULL,
  `CutomerName` varchar(50) DEFAULT NULL,
  `ProductRange` varchar(50) DEFAULT NULL,
  `TaxID` varchar(50) DEFAULT NULL,
  `OrganCode` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CustomerID`),
  KEY `CustomerUser` (`UserID`),
  CONSTRAINT `CustomerUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customercontact`
--

DROP TABLE IF EXISTS `customercontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customercontact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `CustomerContactCustomer` (`CustomerID`),
  KEY `CustomerContactContact` (`ContactID`),
  CONSTRAINT `CustomerContactContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `CustomerContactCustomer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customercontact`
--

LOCK TABLES `customercontact` WRITE;
/*!40000 ALTER TABLE `customercontact` DISABLE KEYS */;
/*!40000 ALTER TABLE `customercontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerprojcontact`
--

DROP TABLE IF EXISTS `customerprojcontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customerprojcontact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerProjID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `CustomerProjContactContact` (`ContactID`),
  KEY `CustomerProjContactCustomerProject` (`CustomerProjID`),
  CONSTRAINT `CustomerProjContactContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `CustomerProjContactCustomerProject` FOREIGN KEY (`CustomerProjID`) REFERENCES `customerproject` (`ProjID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerprojcontact`
--

LOCK TABLES `customerprojcontact` WRITE;
/*!40000 ALTER TABLE `customerprojcontact` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerprojcontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerproject`
--

DROP TABLE IF EXISTS `customerproject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customerproject` (
  `ProjID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `CustomerCity` varchar(50) DEFAULT NULL,
  `CustomerType` varchar(50) DEFAULT NULL,
  `CustomerName` varchar(50) DEFAULT NULL,
  `ProductName` varchar(50) DEFAULT NULL,
  `Service` varchar(50) DEFAULT NULL,
  `Progress` varchar(50) DEFAULT NULL,
  `ProductCategory` varchar(50) DEFAULT NULL,
  `ContractAmount` float(50,0) DEFAULT NULL,
  `Payment` varchar(50) DEFAULT NULL,
  `PayState` varchar(50) DEFAULT NULL,
  `TaxID` varchar(50) DEFAULT NULL,
  `OrganCode` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ProjID`),
  KEY `CustomerProjectUser` (`UserID`),
  CONSTRAINT `CustomerProjectUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerproject`
--

LOCK TABLES `customerproject` WRITE;
/*!40000 ALTER TABLE `customerproject` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerproject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departdoccate`
--

DROP TABLE IF EXISTS `departdoccate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departdoccate` (
  `ID` int(11) NOT NULL,
  `DepartID` int(11) DEFAULT NULL,
  `Visibility` int(11) DEFAULT NULL,
  `CategoryName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DepartDocCatDepartment` (`DepartID`),
  CONSTRAINT `DepartDocCatDepartment` FOREIGN KEY (`DepartID`) REFERENCES `department` (`DepartID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departdoccate`
--

LOCK TABLES `departdoccate` WRITE;
/*!40000 ALTER TABLE `departdoccate` DISABLE KEYS */;
/*!40000 ALTER TABLE `departdoccate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department` (
  `DepartID` int(11) NOT NULL AUTO_INCREMENT,
  `DepartName` varchar(50) DEFAULT NULL,
  `DepartAdminID` int(11) DEFAULT NULL,
  PRIMARY KEY (`DepartID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (2,'销售部',12);
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document`
--

DROP TABLE IF EXISTS `document`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `document` (
  `DocID` int(11) NOT NULL AUTO_INCREMENT,
  `DocName` varchar(50) DEFAULT NULL,
  `DocVersion` varchar(50) DEFAULT NULL,
  `DocDescription` varchar(1000) DEFAULT NULL,
  `DocKey` varchar(50) DEFAULT NULL,
  `DepartID` int(11) DEFAULT NULL,
  `DocCategoryID` int(11) DEFAULT NULL,
  `DocState` varchar(50) DEFAULT NULL,
  `DocUrl` varchar(50) DEFAULT NULL,
  `DocPermission` int(11) DEFAULT NULL,
  `UploadUserID` int(11) DEFAULT NULL,
  `UploadTime` time DEFAULT NULL,
  PRIMARY KEY (`DocID`),
  KEY `DocumentUser` (`UploadUserID`),
  KEY `DocumentDartDocCat` (`DocCategoryID`),
  KEY `DocumentDepartment` (`DepartID`),
  CONSTRAINT `DocumentDartDocCat` FOREIGN KEY (`DocCategoryID`) REFERENCES `departdoccate` (`ID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `DocumentDepartment` FOREIGN KEY (`DepartID`) REFERENCES `department` (`DepartID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `DocumentUser` FOREIGN KEY (`UploadUserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document`
--

LOCK TABLES `document` WRITE;
/*!40000 ALTER TABLE `document` DISABLE KEYS */;
/*!40000 ALTER TABLE `document` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docuser`
--

DROP TABLE IF EXISTS `docuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docuser` (
  `ID` int(11) NOT NULL,
  `DocID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `DocUserUser` (`UserID`),
  KEY `DocUserDocment` (`DocID`),
  CONSTRAINT `DocUserDocment` FOREIGN KEY (`DocID`) REFERENCES `document` (`DocID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `DocUserUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docuser`
--

LOCK TABLES `docuser` WRITE;
/*!40000 ALTER TABLE `docuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `docuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `govercontact`
--

DROP TABLE IF EXISTS `govercontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `govercontact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `GoverID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `GoverContactContact` (`ContactID`),
  KEY `GoverContactGover` (`GoverID`),
  CONSTRAINT `GoverContactContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `GoverContactGover` FOREIGN KEY (`GoverID`) REFERENCES `goverresource` (`GoverID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `govercontact`
--

LOCK TABLES `govercontact` WRITE;
/*!40000 ALTER TABLE `govercontact` DISABLE KEYS */;
/*!40000 ALTER TABLE `govercontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `goverresource`
--

DROP TABLE IF EXISTS `goverresource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `goverresource` (
  `GoverID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `GoverCity` varchar(50) DEFAULT NULL,
  `OrganName` varchar(50) DEFAULT NULL,
  `OrganIntro` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`GoverID`),
  KEY `GoverResource` (`UserID`),
  CONSTRAINT `GoverResource` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goverresource`
--

LOCK TABLES `goverresource` WRITE;
/*!40000 ALTER TABLE `goverresource` DISABLE KEYS */;
/*!40000 ALTER TABLE `goverresource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partnercontact`
--

DROP TABLE IF EXISTS `partnercontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partnercontact` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PartnerID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PartnerContactContact` (`ContactID`),
  KEY `PartnerContactPartner` (`PartnerID`),
  CONSTRAINT `PartnerContactContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `PartnerContactPartner` FOREIGN KEY (`PartnerID`) REFERENCES `partnerresource` (`PartnerID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partnercontact`
--

LOCK TABLES `partnercontact` WRITE;
/*!40000 ALTER TABLE `partnercontact` DISABLE KEYS */;
/*!40000 ALTER TABLE `partnercontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partnerresource`
--

DROP TABLE IF EXISTS `partnerresource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `partnerresource` (
  `PartnerID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `PartnerCity` varchar(50) DEFAULT NULL,
  `OrganName` varchar(50) DEFAULT NULL,
  `OrganIntro` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PartnerID`),
  KEY `PartnerResourceUser` (`UserID`),
  CONSTRAINT `PartnerResourceUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partnerresource`
--

LOCK TABLES `partnerresource` WRITE;
/*!40000 ALTER TABLE `partnerresource` DISABLE KEYS */;
/*!40000 ALTER TABLE `partnerresource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project` (
  `ProjectNum` varchar(50) NOT NULL,
  `ProjectName` varchar(50) DEFAULT NULL,
  `ProjectAdminID` int(11) DEFAULT NULL,
  `ProjectDescription` varchar(200) DEFAULT NULL,
  `ProjectType` varchar(50) DEFAULT NULL,
  `BeginTime` time DEFAULT NULL,
  `EndTime` time DEFAULT NULL,
  PRIMARY KEY (`ProjectNum`),
  KEY `ProjectUser` (`ProjectAdminID`),
  CONSTRAINT `ProjectUser` FOREIGN KEY (`ProjectAdminID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectclient`
--

DROP TABLE IF EXISTS `projectclient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projectclient` (
  `ID` int(11) NOT NULL,
  `ProjectNum` varchar(50) DEFAULT NULL,
  `ClientID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ProcjectClientProjet` (`ProjectNum`),
  KEY `ProjectClientClient` (`ClientID`),
  CONSTRAINT `ProcjectClientProjet` FOREIGN KEY (`ProjectNum`) REFERENCES `project` (`ProjectNum`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `ProjectClientClient` FOREIGN KEY (`ClientID`) REFERENCES `client` (`ClientID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectclient`
--

LOCK TABLES `projectclient` WRITE;
/*!40000 ALTER TABLE `projectclient` DISABLE KEYS */;
/*!40000 ALTER TABLE `projectclient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectdoc`
--

DROP TABLE IF EXISTS `projectdoc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projectdoc` (
  `ProjDocID` int(11) NOT NULL,
  `TaskID` int(11) DEFAULT NULL,
  `ProjDocCate` int(11) DEFAULT NULL,
  `DocName` varchar(50) DEFAULT NULL,
  `DocKey` varchar(50) DEFAULT NULL,
  `DocDescription` varchar(200) DEFAULT NULL,
  `DocUrl` varchar(50) DEFAULT NULL,
  `DocPermission` int(11) DEFAULT NULL,
  `UploadTime` time DEFAULT NULL,
  `UploadUserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ProjDocID`),
  KEY `ProjectDocUser` (`UploadUserID`),
  KEY `ProjectDocSubtask` (`TaskID`),
  CONSTRAINT `ProjectDocSubtask` FOREIGN KEY (`TaskID`) REFERENCES `subtask` (`TaskID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `ProjectDocUser` FOREIGN KEY (`UploadUserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectdoc`
--

LOCK TABLES `projectdoc` WRITE;
/*!40000 ALTER TABLE `projectdoc` DISABLE KEYS */;
/*!40000 ALTER TABLE `projectdoc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectdocuser`
--

DROP TABLE IF EXISTS `projectdocuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projectdocuser` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProjDocID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PDUPDI` (`ProjDocID`),
  KEY `PDUUI` (`UserID`),
  CONSTRAINT `PDUPDI` FOREIGN KEY (`ProjDocID`) REFERENCES `projectdoc` (`ProjDocID`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `PDUUI` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectdocuser`
--

LOCK TABLES `projectdocuser` WRITE;
/*!40000 ALTER TABLE `projectdocuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `projectdocuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projectuser`
--

DROP TABLE IF EXISTS `projectuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projectuser` (
  `ID` int(11) NOT NULL,
  `ProjectNum` varchar(50) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ProjectUserProject` (`ProjectNum`),
  KEY `projectUserUser_ibfk_1` (`UserID`),
  CONSTRAINT `ProjectUserProject` FOREIGN KEY (`ProjectNum`) REFERENCES `project` (`ProjectNum`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `projectUserUser_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projectuser`
--

LOCK TABLES `projectuser` WRITE;
/*!40000 ALTER TABLE `projectuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `projectuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schedule` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `ScheduleContent` varchar(50) DEFAULT NULL,
  `ScheduleTime` time DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ScheduleUser` (`UserID`),
  CONSTRAINT `ScheduleUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtask`
--

DROP TABLE IF EXISTS `subtask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subtask` (
  `TaskID` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectNum` varchar(50) DEFAULT NULL,
  `TaskName` varchar(50) DEFAULT NULL,
  `Period` int(11) DEFAULT NULL,
  `StartTime` time DEFAULT NULL,
  `EndTime` time DEFAULT NULL,
  `Product` varchar(50) DEFAULT NULL,
  `ForeTask` varchar(50) DEFAULT NULL,
  `Resource` varchar(50) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `TaskState` varchar(50) DEFAULT NULL,
  `IsRemind` int(11) DEFAULT NULL,
  `RemindTime` time DEFAULT NULL,
  PRIMARY KEY (`TaskID`),
  KEY `SubtaskUser` (`UserID`),
  KEY `SUbtaskProject` (`ProjectNum`),
  CONSTRAINT `SUbtaskProject` FOREIGN KEY (`ProjectNum`) REFERENCES `project` (`ProjectNum`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `SubtaskUser` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtask`
--

LOCK TABLES `subtask` WRITE;
/*!40000 ALTER TABLE `subtask` DISABLE KEYS */;
/*!40000 ALTER TABLE `subtask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `Password` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `UserType` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `UserEmail` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `UserPhone` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `DepartID` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `DepartID` (`DepartID`),
  CONSTRAINT `user_ibfk_2` FOREIGN KEY (`DepartID`) REFERENCES `department` (`DepartID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'user1','pass','一般用户','myemail@email.com','123456789123',NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visitrecord`
--

DROP TABLE IF EXISTS `visitrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `visitrecord` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ContactID` int(11) DEFAULT NULL,
  `VisitDetail` varchar(50) DEFAULT NULL,
  `RecordTime` time DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `VistRecordContact` (`ContactID`),
  CONSTRAINT `VistRecordContact` FOREIGN KEY (`ContactID`) REFERENCES `contact` (`ContactID`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visitrecord`
--

LOCK TABLES `visitrecord` WRITE;
/*!40000 ALTER TABLE `visitrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `visitrecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-26 10:55:02
