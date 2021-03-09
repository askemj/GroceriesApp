-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema opskrifter
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `opskrifter` ;

-- -----------------------------------------------------
-- Schema opskrifter
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `opskrifter` DEFAULT CHARACTER SET utf8 ;
USE `opskrifter` ;

-- -----------------------------------------------------
-- Table `opskrifter`.`Tilberedningstid`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Tilberedningstid` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Tilberedningstid` (
  `tilberedningstid_id` INT NOT NULL AUTO_INCREMENT,
  `tilberedningstid_tid` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tilberedningstid_id`),
  UNIQUE INDEX `Tilberedningstid_UNIQUE` (`tilberedningstid_tid` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Arbejdstid`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Arbejdstid` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Arbejdstid` (
  `arbejdstid_id` INT NOT NULL AUTO_INCREMENT,
  `arbejdstid_tid` INT NOT NULL,
  PRIMARY KEY (`arbejdstid_id`),
  UNIQUE INDEX `Arbejdstid_UNIQUE` (`arbejdstid_tid` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Opskriftstype`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Opskriftstype` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Opskriftstype` (
  `opskriftstype_id` INT NOT NULL AUTO_INCREMENT,
  `opskriftstype_tekst` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`opskriftstype_id`),
  UNIQUE INDEX `opskriftstype_tekst_UNIQUE` (`opskriftstype_tekst` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Ret`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Ret` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Ret` (
  `ret_id` INT NOT NULL AUTO_INCREMENT,
  `ret_navn` VARCHAR(90) NOT NULL,
  `noter` VARCHAR(500) NULL,
  `antal_portioner` INT NULL,
  `Tilberedningstid_tilberedningstid_id` INT NULL,
  `Arbejdstid_arbejdstid_id` INT NULL,
  `Opskriftstype_opskriftstype_id` INT NULL,
  PRIMARY KEY (`ret_id`),
  UNIQUE INDEX `ret_navn_UNIQUE` (`ret_navn` ASC),
  INDEX `fk_Ret_Tilberedningstid1_idx` (`Tilberedningstid_tilberedningstid_id` ASC),
  INDEX `fk_Ret_Arbejdstid1_idx` (`Arbejdstid_arbejdstid_id` ASC),
  INDEX `fk_Ret_OpskriftsType1_idx` (`Opskriftstype_opskriftstype_id` ASC),
  CONSTRAINT `fk_Ret_Tilberedningstid1`
    FOREIGN KEY (`Tilberedningstid_tilberedningstid_id`)
    REFERENCES `opskrifter`.`Tilberedningstid` (`tilberedningstid_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Ret_Arbejdstid1`
    FOREIGN KEY (`Arbejdstid_arbejdstid_id`)
    REFERENCES `opskrifter`.`Arbejdstid` (`arbejdstid_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Ret_OpskriftsType1`
    FOREIGN KEY (`Opskriftstype_opskriftstype_id`)
    REFERENCES `opskrifter`.`Opskriftstype` (`opskriftstype_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Varetype`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Varetype` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Varetype` (
  `varetype_id` INT NOT NULL AUTO_INCREMENT,
  `varetype_tekst` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`varetype_id`),
  UNIQUE INDEX `VareTypeTekst_UNIQUE` (`varetype_tekst` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Vare`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Vare` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Vare` (
  `vare_id` INT NOT NULL AUTO_INCREMENT,
  `vare_navn` VARCHAR(45) NOT NULL,
  `Varetype_varetype_id` INT NULL,
  `basisvare` TINYINT NULL,
  PRIMARY KEY (`vare_id`),
  UNIQUE INDEX `VareNavn_UNIQUE` (`vare_navn` ASC),
  INDEX `fk_Vare_VareType1_idx` (`Varetype_varetype_id` ASC),
  CONSTRAINT `fk_Vare_VareType1`
    FOREIGN KEY (`Varetype_varetype_id`)
    REFERENCES `opskrifter`.`Varetype` (`varetype_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Tag`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Tag` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Tag` (
  `tag_id` INT NOT NULL AUTO_INCREMENT,
  `tag_tekst` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`tag_id`),
  UNIQUE INDEX `TagTekst_UNIQUE` (`tag_tekst` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`RetTag`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`RetTag` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`RetTag` (
  `Ret_ret_id` INT NOT NULL,
  `Tag_tag_id` INT NOT NULL,
  INDEX `fk_Ret_has_Tags_Tags1_idx` (`Tag_tag_id` ASC),
  INDEX `fk_Ret_has_Tags_Ret1_idx` (`Ret_ret_id` ASC),
  PRIMARY KEY (`Ret_ret_id`, `Tag_tag_id`),
  CONSTRAINT `fk_RetTags_Ret1`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetTags_Tags1`
    FOREIGN KEY (`Tag_tag_id`)
    REFERENCES `opskrifter`.`Tag` (`tag_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Enhed`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Enhed` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Enhed` (
  `enhed_id` INT NOT NULL AUTO_INCREMENT,
  `enhed_navn` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`enhed_id`),
  UNIQUE INDEX `Enhed_UNIQUE` (`enhed_navn` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`RetVare`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`RetVare` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`RetVare` (
  `maengde` DECIMAL NULL,
  `Enhed_enhed_id` INT NULL,
  `Ret_ret_id` INT NOT NULL,
  `Vare_vare_id` INT NOT NULL,
  INDEX `fk_Ret_has_Vare_Vare1_idx` (`Vare_vare_id` ASC),
  INDEX `fk_Ret_has_Vare_Ret1_idx` (`Ret_ret_id` ASC),
  PRIMARY KEY (`Ret_ret_id`, `Vare_vare_id`),
  CONSTRAINT `fk_RetVare_Ret1`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetVare_Vare1`
    FOREIGN KEY (`Vare_vare_id`)
    REFERENCES `opskrifter`.`Vare` (`vare_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetVare_Enhed1`
    FOREIGN KEY (`Enhed_enhed_id`)
    REFERENCES `opskrifter`.`Enhed` (`enhed_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Twist`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Twist` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Twist` (
  `maengde` DECIMAL NULL,
  `Enhed_enhed_id` INT NULL,
  `Ret_ret_id` INT NOT NULL,
  `Vare_vare_id` INT NOT NULL,
  INDEX `fk_Ret_has_Vare_Vare1_idx` (`Vare_vare_id` ASC),
  INDEX `fk_Ret_has_Vare_Ret1_idx` (`Ret_ret_id` ASC),
  PRIMARY KEY (`Ret_ret_id`, `Vare_vare_id`),
  CONSTRAINT `fk_RetVare_Ret10`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetVare_Vare10`
    FOREIGN KEY (`Vare_vare_id`)
    REFERENCES `opskrifter`.`Vare` (`vare_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetVare_Enhed10`
    FOREIGN KEY (`Enhed_enhed_id`)
    REFERENCES `opskrifter`.`Enhed` (`enhed_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Saeson`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Saeson` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Saeson` (
  `saeson_id` INT NOT NULL AUTO_INCREMENT,
  `saeson_navn` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`saeson_id`),
  UNIQUE INDEX `saeson_tekst_UNIQUE` (`saeson_navn` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`VareSaeson`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`VareSaeson` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`VareSaeson` (
  `Vare_vare_id` INT NOT NULL,
  `Saeson_saeson_id` INT NOT NULL,
  PRIMARY KEY (`Vare_vare_id`, `Saeson_saeson_id`),
  INDEX `fk_VareSaeson_Vare1_idx` (`Vare_vare_id` ASC),
  CONSTRAINT `fk_VareSaeson_Saeson1`
    FOREIGN KEY (`Saeson_saeson_id`)
    REFERENCES `opskrifter`.`Saeson` (`saeson_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VareSaeson_Vare1`
    FOREIGN KEY (`Vare_vare_id`)
    REFERENCES `opskrifter`.`Vare` (`vare_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Rest`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Rest` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Rest` (
  `rest_id` INT NOT NULL AUTO_INCREMENT,
  `rest_navn` VARCHAR(45) NULL,
  PRIMARY KEY (`rest_id`),
  UNIQUE INDEX `rest_navn_UNIQUE` (`rest_navn` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`RetLaverRest`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`RetLaverRest` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`RetLaverRest` (
  `Rest_rest_id` INT NOT NULL,
  `Ret_ret_id` INT NOT NULL,
  PRIMARY KEY (`Rest_rest_id`, `Ret_ret_id`),
  INDEX `fk_RetRest_Ret1_idx` (`Ret_ret_id` ASC),
  CONSTRAINT `fk_RetRest_Rest1`
    FOREIGN KEY (`Rest_rest_id`)
    REFERENCES `opskrifter`.`Rest` (`rest_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetRest_Ret1`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Log`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Log` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Log` (
  `log_dato` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `log_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`log_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Butik`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Butik` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Butik` (
  `butik_id` INT NOT NULL AUTO_INCREMENT,
  `butik_navn` VARCHAR(45) NULL,
  PRIMARY KEY (`butik_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`VaretypeRaekkefoelge`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`VaretypeRaekkefoelge` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`VaretypeRaekkefoelge` (
  `raekkefoelge_id` INT NOT NULL AUTO_INCREMENT,
  `raekkefoelge_sekvens` INT NOT NULL,
  `Varetype_varetype_id` INT NOT NULL,
  `Butik_butik_id` INT NOT NULL,
  PRIMARY KEY (`raekkefoelge_id`),
  INDEX `fk_VaretypeRaekkefoelge_Varetype1_idx` (`Varetype_varetype_id` ASC),
  INDEX `fk_VaretypeRaekkefoelge_Butik1_idx` (`Butik_butik_id` ASC),
  CONSTRAINT `fk_VaretypeRaekkefoelge_Varetype1`
    FOREIGN KEY (`Varetype_varetype_id`)
    REFERENCES `opskrifter`.`Varetype` (`varetype_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VaretypeRaekkefoelge_Butik1`
    FOREIGN KEY (`Butik_butik_id`)
    REFERENCES `opskrifter`.`Butik` (`butik_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`RetBrugerRest`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`RetBrugerRest` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`RetBrugerRest` (
  `Rest_rest_id` INT NOT NULL,
  `Ret_ret_id` INT NOT NULL,
  PRIMARY KEY (`Rest_rest_id`, `Ret_ret_id`),
  INDEX `fk_RetRest_Ret1_idx` (`Ret_ret_id` ASC),
  CONSTRAINT `fk_RetRest_Rest10`
    FOREIGN KEY (`Rest_rest_id`)
    REFERENCES `opskrifter`.`Rest` (`rest_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RetRest_Ret10`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`Dagligvarer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`Dagligvarer` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`Dagligvarer` (
  `dagligvare_id` INT NOT NULL AUTO_INCREMENT,
  `periode` INT NULL,
  `Vare_vare_id` INT NOT NULL,
  PRIMARY KEY (`dagligvare_id`, `Vare_vare_id`),
  INDEX `fk_Dagligvarer_Vare1_idx` (`Vare_vare_id` ASC),
  CONSTRAINT `fk_Dagligvarer_Vare1`
    FOREIGN KEY (`Vare_vare_id`)
    REFERENCES `opskrifter`.`Vare` (`vare_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `opskrifter`.`LogVare`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `opskrifter`.`LogVare` ;

CREATE TABLE IF NOT EXISTS `opskrifter`.`LogVare` (
  `Log_log_id` INT NOT NULL,
  `Vare_vare_id` INT NOT NULL,
  `Ret_ret_id` INT NOT NULL,
  `maengde` DECIMAL NULL,
  `Enhed_enhed_id` INT NULL,
  PRIMARY KEY (`Log_log_id`, `Vare_vare_id`, `Ret_ret_id`),
  INDEX `fk_Log_has_Vare_Vare1_idx` (`Vare_vare_id` ASC),
  INDEX `fk_Log_has_Vare_Log1_idx` (`Log_log_id` ASC),
  INDEX `fk_Log_has_Vare_Ret1_idx` (`Ret_ret_id` ASC),
  INDEX `fk_LogVare_Enhed1_idx` (`Enhed_enhed_id` ASC),
  CONSTRAINT `fk_Log_has_Vare_Log1`
    FOREIGN KEY (`Log_log_id`)
    REFERENCES `opskrifter`.`Log` (`log_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Log_has_Vare_Vare1`
    FOREIGN KEY (`Vare_vare_id`)
    REFERENCES `opskrifter`.`Vare` (`vare_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Log_has_Vare_Ret1`
    FOREIGN KEY (`Ret_ret_id`)
    REFERENCES `opskrifter`.`Ret` (`ret_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_LogVare_Enhed1`
    FOREIGN KEY (`Enhed_enhed_id`)
    REFERENCES `opskrifter`.`Enhed` (`enhed_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
