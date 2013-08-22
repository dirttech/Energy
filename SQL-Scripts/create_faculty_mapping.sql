CREATE TABLE `faculty_mapping` (
  `DeviceID` varchar(50) NOT NULL,
  `MeterID` int(11) NOT NULL,
  `UserID` char(38) NOT NULL,
  UNIQUE KEY `UserID_UNIQUE` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8