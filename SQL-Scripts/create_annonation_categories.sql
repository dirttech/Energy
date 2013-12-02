CREATE TABLE `annonation_categories` (
  `device_name` varchar(45) NOT NULL,
  `created_by` varchar(45) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`device_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8