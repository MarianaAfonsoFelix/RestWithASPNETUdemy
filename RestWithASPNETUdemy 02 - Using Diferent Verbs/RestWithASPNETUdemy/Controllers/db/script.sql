CREATE TABLE `person` (
`Id` int(10) auto_increment primary key,
`FirstName` VARCHAR(50) NULL DEFAULT NULL,
`LastName` VARCHAR(50) NULL DEFAULT NULL,
`Address` VARCHAR(50) NULL DEFAULT NULL,
`Gender` VARCHAR(50) NULL DEFAULT NULL
)
ENGINE=InnoDB
;