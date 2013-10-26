CREATE TABLE `bill_settings` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `fixed_charge` double NOT NULL,
  `adj_charge` double NOT NULL,
  `def_charge` double NOT NULL,
  `electicity_tax` double NOT NULL,
  `slab_size` varchar(100) NOT NULL,
  `slab_price` varchar(100) NOT NULL,
  `applicable_date` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8