CREATE DATABASE VegetablesAndFruits;

USE VegetablesAndFruits;

CREATE TABLE MainTable(
	id INT PRIMARY Key Identity(1, 1),
	Name VARCHAR (Max) NOT NULL,
	Type VARCHAR (1) NOT NULL,
	Color NVARCHAR(Max) NOT NULL,
	Calories NVARCHAR(Max) NOT NULL
);
