USE master
GO 

IF DB_ID('DNDCombatSimulatorDB') IS NOT NULL
BEGIN
	ALTER DATABASE DNDCombatSimulatorDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DNDCombatSimulatorDB;
END

CREATE DATABASE DNDCombatSimulatorDB
GO

USE DNDCombatSimulatorDB;
GO

BEGIN TRANSACTION

CREATE TABLE Races (
	id INT IDENTITY(1,1),
	race NVARCHAR(50) NOT NULL,
	strength_bonus INT NOT NULL,
	dexterity_bonus INT NOT NULL,
	constitution_bonus INT NOT NULL,
	intelligence_bonus INT NOT NULL,
	wisdom_bonus INT NOT NULL,
	charisma_bonus INT NOT NULL,
	size NVARCHAR(50) NOT NULL,
	speed INT NOT NULL,
	traits NVARCHAR(300),

	CONSTRAINT pk_race PRIMARY KEY(id),
	CONSTRAINT str_bonus_positive CHECK (strength_bonus >= 0),
	CONSTRAINT dex_bonus_positive CHECK (dexterity_bonus >= 0),
	CONSTRAINT con_bonus_positive CHECK (constitution_bonus >= 0),
	CONSTRAINT int_bonus_positive CHECK (intelligence_bonus >= 0),
	CONSTRAINT wis_bonus_positive CHECK (wisdom_bonus >= 0),
	CONSTRAINT cha_bonus_positive CHECK (charisma_bonus >= 0),

);
GO

CREATE TABLE Weapons (
	id INT IDENTITY (1,1),
	weapon NVARCHAR(50),
	type_of_dice INT NOT NULL,
	num_of_dice INT NOT NULL,
	damage_type NVARCHAR(50) NOT NULL

	CONSTRAINT pk_weapon PRIMARY KEY(id),
	CONSTRAINT type_of_dice_positive CHECK (type_of_dice >0),
	CONSTRAINT num_of_dice_positive CHECK (num_of_dice >0),
);
GO

CREATE TABLE Characters (
	id INT IDENTITY(1,1),
	name NVARCHAR(50) NOT NULL,
	race INT NOT NULL,
	--hit_points INT NOT NULL,
	--class NVARCHAR(50),
	strength INT NOT NULL,
	dexterity INT NOT NULL,
	constitution INT NOT NULL,
	intelligence INT NOT NULL,
	wisdom INT NOT NULL,
	charisma INT NOT NULL,
	weapon INT,

	CONSTRAINT pk_character PRIMARY KEY(id),
	CONSTRAINT fk_race FOREIGN KEY (race) REFERENCES Races(id),
	CONSTRAINT fk_weapon FOREIGN KEY (weapon) REFERENCES Weapons(id),
	CONSTRAINT str_positive CHECK (strength >= 0),
	CONSTRAINT dex_positive CHECK (dexterity >= 0),
	CONSTRAINT con_positive CHECK (constitution >= 0),
	CONSTRAINT int_positive CHECK (intelligence >= 0),
	CONSTRAINT wis_positive CHECK (wisdom >= 0),
	CONSTRAINT cha_positive CHECK (charisma >= 0),
);
GO

INSERT INTO Races (race, strength_bonus,dexterity_bonus,constitution_bonus,intelligence_bonus,wisdom_bonus,charisma_bonus, size,speed,traits)
VALUES ('Human',1,1,1,1,1,1, 'Medium',30, 'Extra Language'),
		('Elf',0,2,0,0,0,0, 'Medium', 30, 'Darkvision 60ft, Keen Senses, Fey Ancestry, Trance'),
		('Dwarf', 0,0,2,0,0,0,'Medium',25,'Darkvision 60ft, Dwarven Resilience, Dwarven Combat Training, Stonecunning')

INSERT INTO Weapons (weapon,num_of_dice,type_of_dice,damage_type)
VALUES ('Club',1,4,'Bludgeoning'),
		('Hand-Axe',1,6,'Slashing'),
		('Rapier',1,8,'Piercing')

INSERT INTO Characters(name, race, strength,dexterity,constitution,intelligence,wisdom,charisma,weapon)
VALUES ('Joe', 1,10,10,10,10,10,10,1),
		('Sally', 2,10,10,10,10,10,10,2),
		('Becky',3,10,10,10,10,10,10,3)

SELECT * FROM Races
SELECT * FROM Weapons
SELECT * FROM Characters

COMMIT TRANSACTION