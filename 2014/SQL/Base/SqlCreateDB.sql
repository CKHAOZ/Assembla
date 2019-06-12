/*
	SHC - Condai : Script para Creación de Tablas para la Base De Datos SHC, tablas base y Bussiness Inteligence para Cubo.
*/

CREATE TABLE Seguridad_Usuario
(
	usuId int Not Null IDENTITY(1,1) Primary Key,
	usuUsuario varchar(15) not null,
	usuDescripcion varchar(50) not null,
	usuClave varchar(125) not null,
	usuNombre varchar(25) not null,
	usuApellido varchar(25) not null,
	usuCorreo varchar(50) not null,
	usuTelefono int null,
	usuActivo bit not null,
	usuFechaUltimoIngreso datetime not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
);

create TABLE Seguridad_Rol
(
	rouId int Not Null IDENTITY(1,1) Primary Key,
	rouNombre varchar(25) not null,
	rouDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
);

create table Seguridad_RolesPorUsuario
(
	rpuId int Not Null IDENTITY(1,1) Primary Key,
	usuId int not null foreign key references Seguridad_Usuario(usuId),
	rouId int not null foreign key references Seguridad_Rol(rouId),
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

CREATE TABLE Base_Aplicacion
(
	aplId int not null identity(1,1) primary key,
	aplNombre varchar(25) not null,
	aplDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Comentario
(
	bcoId int not null identity(1,1) primary key,	
	aplId int not null foreign key references Base_Aplicacion(aplId),
	rouId int not null foreign key references Seguridad_Rol(rouId),
	usuId int not null foreign key references Seguridad_Usuario(usuId),
	bcoIdCaso int not null,
	bcoComentario varchar(250) not null,	
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_MediosAudiovisuales
(
	mavId int not null identity(1,1) primary key,
	aplId int not null foreign key references Base_Aplicacion(aplId),
	rouId int not null foreign key references Seguridad_Rol(rouId),
	usuId int not null foreign key references Seguridad_Usuario(usuId),
	mavIdCaso int not null,
	mavRuta varchar(125) not null,
	mavDescripcion varchar(50) not null,
	mavActivo bit not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_TipoVoto
(
	tivId int not null identity(1,1) primary key,
	aplId int not null foreign key references Base_Aplicacion(aplId),
	tivNombre varchar(25) not null,
	tivDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Voto
(
	votId int not null identity(1,1) primary key,
	aplId int not null foreign key references Base_Aplicacion(aplId),
	rouId int not null foreign key references Seguridad_Rol(rouId),	
	usuId int not null foreign key references Seguridad_Usuario(usuId),
	tivId int not null foreign key references Base_TipoVoto(tivId),
	votIdCaso int not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_UnidadNegocio
(
	unnId int not null identity(1,1) primary key,
	unnNombre varchar(25) not null,
	unnDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Compania
(
	comId int not null identity(1,1) primary key,
	unnId int not null foreign key references Base_UnidadNegocio(unnId),
	comNombre varchar(25) not null,
	comDescripcion varchar(50) not null,
	comNit varchar(25) not null,
	comTelefono int not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Pais
(
	paiId int not null identity(1,1) primary key,
	paiNombre varchar(25) not null,
	paiDescripcion varchar(50) not null,
	paiCodigoDane varchar(15) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Departamento
(
	depId int not null identity(1,1) primary key,
	paiId int not null foreign key references Base_Pais(paiId),
	depNombre varchar(25) not null,
	depDescripcion varchar(50) not null,
	depCodigoDane varchar(15) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Base_Municipio
(
	munId int not null identity(1,1) primary key,
	depId int not null foreign key references Base_Departamento(depId),
	munNombre varchar(25) not null,
	munDescripcion varchar(50) not null,
	munCodigoDane varchar(15) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_TipoProducto
(
	ctpId int not null identity(1,1) primary key,
	ctpNombre varchar(25) not null,
	ctpDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_Producto
(
	cprId int not null identity(1,1) primary key,
	comId int not null foreign key references Base_Compania(comId),
	ctpId int not null foreign key references Contrato_TipoProducto(ctpId),
	munId int not null foreign key references Base_Municipio(munId),
	usuIdPropietario int not null foreign key references Seguridad_Usuario(usuId),
	cprNombre varchar(25) not null,
	cprDescripcion varchar(50) not null,
	cprDireccion varchar(50) not null,
	cprNumeroHabitaciones int not null,
	cprNumeroGarajes int not null,
	cprNumeroBaños int not null,
	cprValorAdministracion decimal(19,3) not null,
	cprTienePatio bit not null,
	cprMetrosCuadrados decimal(19,3) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_TipoContrato
(
	ctcId int not null identity(1,1) primary key,
	ctcNombre varchar(25) not null,
	ctcDescripcion varchar(50) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_EstadoContrato
(
	cecId int not null identity(1,1) primary key,
	cecNombre varchar(25) not null,
	cecDescripcion varchar(50) not null
)

create table Contrato_Contrato
(
	ccoId int not null identity(1,1) primary key,
	ctcId int not null foreign key references Contrato_TipoContrato(ctcId),
	usuIdCliente int not null foreign key references Seguridad_Usuario(usuId),
	cecId int not null foreign key references Contrato_EstadoContrato(cecId),
	ccoNombre varchar(25) not null,
	ccoDescripcion varchar(50) not null,
	ccoFechaDesde datetime not null,
	ccoFechaHasta datetime null,
	ccoValor decimal(19,3) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_ProductosDeContrato
(
	cpcId int not null identity(1,1) primary key,
	ccoId int not null foreign key references Contrato_Contrato(ccoId),
	cprId int not null foreign key references Contrato_Producto(cprId),
	cpcCantidad int not null,
	cpcValor decimal(19,3) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_Visita
(
	cvcId int not null identity(1,1) primary key,	
	ccoId int not null foreign key references Contrato_Contrato(ccoId),
	usuClienteId int not null foreign key references Seguridad_Usuario(usuId),
	usuAnalistId int not null foreign key references Seguridad_Usuario(usuId),
	usuPropietarioId int not null foreign key references Seguridad_Usuario(usuId),
	cvcDireccion varchar(50) not null,
	cvcFecha datetime not null,
	cvcActiva bit not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_Subasta
(
	csuId int not null identity(1,1) primary key,
	ccoId int not null foreign key references Contrato_Contrato(ccoId),
	csuDescripcion varchar(50) not null,
	csuFechaDesde datetime not null,
	csuFechaHasta datetime not null,
	csuValorInicial decimal(19,3) not null,	
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)

create table Contrato_SubastaOferta
(
	suoId int not null identity(1,1) primary key,
	csuId int not null foreign key references Contrato_Subasta(csuId),
	usuId int not null foreign key references Seguridad_Usuario(usuId),
	csuValor decimal(19,3) not null,
	usuIdCreo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaCreo datetime not null,
	usuIdActualizo int not null foreign key references Seguridad_Usuario(usuId),
	usuFechaActualizo datetime not null
)