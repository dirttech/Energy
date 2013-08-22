CREATE TABLE `register_requests` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Apartment` varchar(40) NOT NULL,
  `EMail` varchar(50) NOT NULL,
  `ContactNo` varchar(20) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Building` varchar(40) DEFAULT NULL,
  `status` varchar(15) DEFAULT 'pending',
  PRIMARY KEY (`Apartment`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8