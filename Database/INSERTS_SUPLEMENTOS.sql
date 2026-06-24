USE COMERCIO_DB
GO

-- Datos base para emprendimiento de suplementos deportivos.
-- Los productos se crean sin stock: el stock debe ingresar mediante compras.

-- Categorias
INSERT INTO Categorias (Descripcion)
VALUES
('Creatinas'),
('Proteinas');
GO

-- Marcas
INSERT INTO Marcas (Descripcion)
VALUES
('Star Nutrition'),
('One Fit');
GO

-- Proveedores
-- Requiere que Email, Direccion, CuilCuit y Telefono permitan NULL en la tabla Proveedores.
INSERT INTO Proveedores (Nombre, Email, Direccion, CuilCuit, Telefono)
VALUES
('AFit Suplementos', NULL, 'Marconi y Smith Quilmes', NULL, NULL);
GO

-- Productos
-- Precio, StockActual y PrecioCompra inician en 0.
-- La compra al proveedor actualiza PrecioCompra, Precio y StockActual.
INSERT INTO Productos (
    CodProd,
    Nombre,
    Descripcion,
    IDCategoria,
    IDMarca,
    Precio,
    StockMinimo,
    StockActual,
    Ganancia,
    PrecioCompra
)
VALUES
(
    'ST1',
    'Creatina Star Nutrition 300g',
    'Creatina en polvo 300g',
    (SELECT ID FROM Categorias WHERE Descripcion = 'Creatinas'),
    (SELECT ID FROM Marcas WHERE Descripcion = 'Star Nutrition'),
    0,
    4,
    0,
    31.75,
    0
),
(
    'OF1',
    'Creatina One Fit 200g',
    'Creatina en polvo 200g',
    (SELECT ID FROM Categorias WHERE Descripcion = 'Creatinas'),
    (SELECT ID FROM Marcas WHERE Descripcion = 'One Fit'),
    0,
    2,
    0,
    31.75,
    0
);
GO

-- Relacion productos-proveedor
INSERT INTO ProductosXProveedor (IDProducto, IDProveedor)
VALUES
(
    (SELECT ID FROM Productos WHERE CodProd = 'ST1'),
    (SELECT ID FROM Proveedores WHERE Nombre = 'AFit Suplementos')
),
(
    (SELECT ID FROM Productos WHERE CodProd = 'OF1'),
    (SELECT ID FROM Proveedores WHERE Nombre = 'AFit Suplementos')
);
GO

-- Ejemplo opcional para cargar stock inicial como compra real:
--
-- INSERT INTO Compras (Fecha, IDProveedor, Total)
-- VALUES (
--     GETDATE(),
--     (SELECT ID FROM Proveedores WHERE Nombre = 'AFit Suplementos'),
--     438000
-- );
--
-- DECLARE @IDCompra INT = SCOPE_IDENTITY();
--
-- EXEC SP_GUARDAR_DETALLE_COMPRA
--     @IDCompra = @IDCompra,
--     @IDProducto = (SELECT ID FROM Productos WHERE CodProd = 'ST1'),
--     @Cantidad = 14,
--     @PrecioUnidad = 18900;
--
-- EXEC SP_GUARDAR_DETALLE_COMPRA
--     @IDCompra = @IDCompra,
--     @IDProducto = (SELECT ID FROM Productos WHERE CodProd = 'OF1'),
--     @Cantidad = 2,
--     @PrecioUnidad = 8700;
-- GO
