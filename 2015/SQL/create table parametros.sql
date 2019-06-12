USE [Condai]

/* Base_Parametro */

	--create table [dbo].[Base_Parametro]
	--(	
	--	parId varchar(3) not null primary key,	
	--	parValor varchar(3) not null,
	--	parDescripcion varchar(3) not null
	--);

/* Parametro Cascada */

	--create table  [dbo].Base_ParametroCascada
	--(	
	--	pacId int not null IDENTITY(1,1) primary key,	
	--	parId1 varchar(3) not null,	
	--	parValor1 varchar(3) not null,
	--	parId2 varchar(3) not null,	
	--	parValor2 varchar(3) not null,
	--	cliId int not null,
	--	empId int null,
	--	pacDescripcion varchar(22) null
	--);

/*	Base_Cliente  cli */

create table Base_Cliente
(	
	cliId int not null IDENTITY(1,1) primary key,	
	
	cliIdentificacion varchar(22) not null,
	cliNombre varchar(150) not null,
	cliDireccion varchar(60) not null,
	cliTelefono varchar(12) not null,
	cliCorreo varchar(255) not null,
	cliActivo bit not null,
	usuIdCreo int not null,
	usuFechaCreo datetime not null,
	usuIdActualizo int not null,
	usuFechaActualizo datetime not null
);

ALTER TABLE Condai.Base_Cliente
add constrain FK_UsuIdCreo foreign key(usuIdCreo)
	references Condai.Seguridad_Usuario (usuId)
	on delete cascade
	on update cascade


ALTER TABLE Condai.Base_Cliente
add constrain FK_usuIdActualizo foreign key(usuIdCreo)
	references Condai.Seguridad_Usuario (usuId)
	on delete cascade
	on update cascade