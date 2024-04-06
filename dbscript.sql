create database BDD_UFG

use BDD_UFG 

CREATE TABLE Persona(
	Id int primary key identity,
	Nombre varchar(50),
	Correo varchar(50),
	FechaNacimiento datetime
);