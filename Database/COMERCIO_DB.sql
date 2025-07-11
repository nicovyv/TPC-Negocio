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
CuilCuit VARCHAR (50) NOT NULL UNIQUE,
Telefono VARCHAR(20) NOT NULL,
Activo BIT NOT NULL DEFAULT 1
);


GO

CREATE TABLE Proveedores (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
Nombre VARCHAR (50) NOT NULL UNIQUE,
Email VARCHAR (50) NOT NULL,
Direccion VARCHAR (50) NOT NULL,
CuilCuit VARCHAR (50) NOT NULL UNIQUE,
Telefono VARCHAR(20) NOT NULL,
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
Nombre VARCHAR (50),
Apellido VARCHAR (50),
Admin BIT NOT NULL,
Activo BIT NOT NULL DEFAULT 1,
UrlImagenPerfil VARCHAR(500)
) 


GO

CREATE TABLE ProductosXProveedor(
IDProducto INT NOT NULL,
IDProveedor INT NOT NULL,
CONSTRAINT PK_PRODXPROV PRIMARY KEY (IDProducto, IDProveedor),
CONSTRAINT FK_PRODXPROV_PROD FOREIGN KEY (IDProducto) REFERENCES Productos (ID),
CONSTRAINT FK_PRODXPROV_PROV FOREIGN KEY (IDProveedor) REFERENCES Proveedores (ID)
);



GO


CREATE OR ALTER PROCEDURE insertarUsuario (@email VARCHAR(100),@pass VARCHAR(20))
AS
BEGIN
INSERT INTO Usuarios (email,pass,admin) OUTPUT inserted.ID VALUES (@email,@pass,0)
END

GO

CREATE TABLE Compras (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),	    
    Fecha DATE NOT NULL,
    IDProveedor INT NOT NULL,    
    Total MONEY NOT NULL CHECK (Total > 0),
    Activo BIT NOT NULL DEFAULT 1
	CONSTRAINT FK_COMPRAS_PROVEEDORES FOREIGN KEY (IDProveedor) REFERENCES Proveedores (ID)
);
GO

CREATE TABLE DetalleCompra (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IDCompra INT NOT NULL FOREIGN KEY REFERENCES Compras(ID),
    IDProducto INT NOT NULL FOREIGN KEY REFERENCES Productos(ID),
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnidad MONEY NOT NULL CHECK (PrecioUnidad > 0),
	CONSTRAINT FK_DetalleCompra_Compra FOREIGN KEY (IDCompra) REFERENCES Compras (ID),
	CONSTRAINT FK_DetalleCompra_Producto FOREIGN KEY (IDProducto) REFERENCES PRODUCTOS (ID),
	Activo BIT NOT NULL DEFAULT 1
);


GO



CREATE TABLE Ventas (
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
IDCliente INT NOT NULL,
Fecha DATETIME NOT NULL,
Total MONEY NOT NULL CHECK (Total >= 0),
Factura INT NOT NULL UNIQUE,
CONSTRAINT FK_VENTAS_CLIENTES FOREIGN KEY (IDCliente) REFERENCES Clientes (ID)
);

GO

CREATE TABLE ItemVenta(
ID INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
IDVenta INT NOT NULL,
IDProducto INT NOT NULL,
Cantidad INT NOT NULL CHECK (Cantidad > 0),
PrecioUnidad MONEY CHECK (PrecioUnidad >= 0),
CONSTRAINT FK_ItemVenta_Venta FOREIGN KEY (IDVenta) REFERENCES Ventas (ID),
CONSTRAINT FK_ItemVenta_Producto FOREIGN KEY (IDProducto) REFERENCES PRODUCTOS (ID)
);

GO

--SP

ALTER PROCEDURE sp_ListarProd AS
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
	ORDER BY P.ID DESC
END

GO

--EXEC sp_ListarProd

--GO

CREATE PROCEDURE SP_GUARDAR_ITEM_VENTA
	@IDVenta INT,
	@IDProducto INT,
	@Cantidad INT,
	@PrecioUnidad MONEY
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO ItemVenta(IDVenta, IDProducto, Cantidad, PrecioUnidad)
			VALUES (@IDVenta, @IDProducto, @Cantidad, @PrecioUnidad)

			UPDATE Productos SET StockActual = StockActual - @Cantidad WHERE ID = @IDProducto


		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
				ROLLBACK TRANSACTION
				RAISERROR ('Ocurrio un error', 16, 1)
	END CATCH
END
go

CREATE PROCEDURE SP_GUARDAR_DETALLE_COMPRA
	@IDCompra INT,
	@IDProducto INT,
	@Cantidad INT,
	@PrecioUnidad MONEY
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			INSERT INTO DetalleCompra(IDCompra, IDProducto, Cantidad, PrecioUnidad)
			VALUES (@IDCompra, @IDProducto, @Cantidad, @PrecioUnidad)

			UPDATE Productos SET StockActual = StockActual + @Cantidad, PrecioCompra = @PrecioUnidad, Precio = @PrecioUnidad * ((100+Ganancia)/100) WHERE ID = @IDProducto


		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
				ROLLBACK TRANSACTION
				RAISERROR ('Ocurrio un error', 16, 1)
	END CATCH
END
