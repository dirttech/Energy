CREATE TABLE `meter_map` (
  `UserID` char(38) DEFAULT NULL,
  `Apartment` varchar(50) DEFAULT NULL,
  `MeterNo` int(11) NOT NULL,
  `FloorNo` int(11) DEFAULT NULL,
  `Building` varchar(50) NOT NULL,
  `MeterType` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8