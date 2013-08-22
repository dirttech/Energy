CREATE TABLE `login_info` (
  `UserID` char(38) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `FullName` varchar(50) NOT NULL,
  `apartment` varchar(20) DEFAULT NULL,
  `mobile` varchar(15) DEFAULT NULL,
  `building` varchar(25) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `status` varchar(10) DEFAULT 'pending',
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserID_UNIQUE` (`UserID`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8