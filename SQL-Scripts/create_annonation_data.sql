CREATE TABLE `annonation_data` (
  `meter_id` int(11) NOT NULL,
  `fromtime` int(11) NOT NULL,
  `totime` int(11) NOT NULL,
  `device` varchar(45) NOT NULL,
  `building` varchar(45) NOT NULL,
  `annonation_datacol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`meter_id`,`fromtime`,`totime`,`device`,`building`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8