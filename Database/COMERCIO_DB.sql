USE MASTER
GO
CREATE DATABASE COMERCIO_DB
ALTER DATABASE COMERCIO_DB COLLATE Latin1_General_CI_AI; 
GO
USE COMERCIO_DB

GO

CREATE TABLE Categorias (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Descripcion VARCHAR (50) NOT NULL UNIQUE,
Activo BIT NOT NULL DEFAULT 1
);

INSERT INTO Categorias (Descripcion) 
VALUES ('DESKTOPS'),('NOTEBOOKS'),('CELULARES')


CREATE TABLE Marcas (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Descripcion VARCHAR (50) NOT NULL UNIQUE,
Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Proveedores (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Nombre VARCHAR (50) NOT NULL UNIQUE,
Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Productos (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
CodProd VARCHAR(50) NOT NULL UNIQUE,
Nombre VARCHAR (100) NOT NULL,
Descripcion VARCHAR (255) NOT NULL,
IDCategoria INT NOT NULL FOREIGN KEY REFERENCES Categorias (ID),
IDMarca INT NOT NULL FOREIGN KEY REFERENCES Marcas (ID),
Precio MONEY NOT NULL CHECK (Precio >= 0),
StockMinimo INT NOT NULL CHECK (StockMinimo >= 0),
StockActual INT NOT NULL CHECK (StockActual >= 0),
Ganancia DECIMAL (5, 2) NOT NULL CHECK (Ganancia >= 0),
PrecioCompra MONEY NOT NULL CHECK (PrecioCompra >= 0),
Activo BIT NOT NULL DEFAULT 1
);
CREATE TABLE Usuarios(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[admin] [bit] NOT NULL
) 
INSERT INTO Usuarios(email,password,nombre,apellido,TipoUsuario)
VALUES 
('test1@email.com',123456,'Leonel','Messi',1),
('test2@email.com',222222,'Angel','Di Maria',2),
('test3@email.com',111111,'Emiliano','Martinez',3);





