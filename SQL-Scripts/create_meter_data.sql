CREATE TABLE `meter_data` (
  `DeviceID` varchar(45) NOT NULL,
  `MeterID` int(11) NOT NULL,
  `TimeStamp` int(11) NOT NULL,
  `W` float NOT NULL,
  `F` float NOT NULL,
  `PF1` float NOT NULL,
  `V1` float NOT NULL,
  `A1` float NOT NULL,
  `PF2` float NOT NULL,
  `A2` float NOT NULL,
  `PF3` float NOT NULL,
  `A3` float NOT NULL,
  `FwdHr` float NOT NULL,
  PRIMARY KEY (`TimeStamp`,`MeterID`,`DeviceID`),
  KEY `TDindex` (`TimeStamp`,`DeviceID`),
  KEY `TMDcombo` (`TimeStamp`,`MeterID`,`DeviceID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8