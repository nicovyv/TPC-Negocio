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

GO



CREATE TABLE Marcas (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Descripcion VARCHAR (50) NOT NULL UNIQUE,
Activo BIT NOT NULL DEFAULT 1
);

GO

CREATE TABLE Clientes (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Nombre VARCHAR (50) NOT NULL UNIQUE,
Email VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NOT NULL,
CuilCuit VARCHAR (50) NOT NULL,
Telefono INT NOT NULL,
Activo BIT NOT NULL DEFAULT 1
);


GO

CREATE TABLE Proveedores (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Nombre VARCHAR (50) NOT NULL UNIQUE,
Email VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NOT NULL,
CuilCuit VARCHAR (50) NOT NULL,
Telefono INT NOT NULL,
Activo BIT NOT NULL DEFAULT 1
);

GO

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

GO
CREATE TABLE Usuarios(
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Email VARCHAR (100) NOT NULL UNIQUE,
Pass VARCHAR (20) NOT NULL,
Nombre VARCHAR (50) NOT NULL,
Apellido VARCHAR (50) NOT NULL,
Admin BIT NOT NULL,
Activo BIT NOT NULL DEFAULT 1
) 


GO

--INSERTS

INSERT INTO Categorias (Descripcion) 
VALUES ('DESKTOPS'),('NOTEBOOKS'),('CELULARES')

GO

INSERT INTO Usuarios(Email, Pass, Nombre, Apellido, Admin)
VALUES 
('test1@email.com',123456,'Leonel','Messi',1),
('test2@email.com',222222,'Angel','Di Maria',0),
('test3@email.com',111111,'Emiliano','Martinez',0);




--SP

CREATE PROCEDURE sp_ListarProd AS
BEGIN
	SELECT 
	P.ID AS IdProducto, 
	P.CodProd AS Codigo, 
	P.Nombre AS NombreProducto,
	P.Descripcion AS DescripcionProducto,
	C.ID AS IdCategoria,
	C.Descripcion AS DescripcionCategoria, 
	M.ID AS IdMarca,
	M.Descripcion AS DescripcionMarca, 
	P.Precio AS PrecioVenta, 
	P.PrecioCompra, 
	P.StockMinimo, 
	P.StockActual, 
	P.Ganancia, 
	P.Activo
	FROM Productos P
	INNER JOIN Categorias C ON C.ID = P.IDCategoria
	INNER JOIN Marcas M ON M.ID = P.IDMarca
	WHERE P.Activo = 1
END

EXEC sp_ListarProd