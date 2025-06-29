--INSERTANDO EN USUARIOS
INSERT INTO Usuarios(Email, Pass, Nombre, Apellido, Admin)
VALUES 
('test1@email.com',123456,'Leonel','Messi',1),
('test2@email.com',222222,'Angel','Di Maria',0),
('test3@email.com',111111,'Emiliano','Martinez',0);

GO
-- Insertando en Categorias
INSERT INTO Categorias (Descripcion) VALUES 
('Electrónica'),
('Hogar'),
('Juguetería'),
('Ferretería'),
('Jardinería'),
('Deportes')
GO

-- Insertando en Marcas
INSERT INTO Marcas (Descripcion) VALUES ('Samsung'),
('Philips'),
('Hasbro'),
('Bosch'),
('Black+Decker'),
('Adidas');
GO
-- Insertando en Clientes
INSERT INTO Clientes (Nombre, Email, Direccion, CuilCuit, Telefono)
VALUES 
('Juan Pérez', 'juan.perez@email.com', 'Av. Siempre Viva 123', '20123456789', '011-1234-5678'),
('Ana Gómez', 'ana.gomez@email.com', 'Calle Falsa 456', '27876543210', '011-8765-4321'),
('Carlos Ramírez', 'carlos.ramirez@email.com', 'Mitre 789', '20112233440', '0341-1234567'),
('Lucía Fernández', 'lucia.fernandez@email.com', 'Santa Fe 321', '27443322115', '011-5555-6666'),
('Federico López', 'federico.lopez@email.com', 'Belgrano 654', '23998877661', '0261-444-5555');

-- Insertando en Proveedores
INSERT INTO Proveedores (Nombre, Email, Direccion, CuilCuit, Telefono)
VALUES 
('ElectroMayorista SA', 'contacto@electromayorista.com', 'Paraná 123', '30112233445', '011-1111-2222'),
('Distribuidora General SRL', 'ventas@distribgeneral.com', 'Av. Córdoba 456', '30998877663', '011-3333-4444'),
('TodoHerramientas SA', 'ventas@todoherramientas.com', 'Av. San Martín 1000', '30554433226', '011-7777-8888'),
('MundoJardin SRL', 'contacto@mundojardin.com', 'Boulogne Sur Mer 800', '30667788990', '0342-222-3333'),
('DeporteMax SA', 'info@deportemax.com', 'Av. Libertador 2000', '30101010109', '011-9999-0000');

GO
--INSERTAR PRODUCTOSXPROVEEDOR
INSERT INTO ProductosXProveedor(IDProducto,IDProveedor)
VALUES
(1,1),
(2,1),
(3,2),
(4,3),
(5,4),
(6,5)
GO
-- Insertando en Productos
-- Supongamos que:
-- IDCategoria: 1 = Electrónica, 2 = Hogar, 3 = Juguetería
-- IDMarca: 1 = Samsung, 2 = Philips, 3 = Hasbro

INSERT INTO Productos (CodProd, Nombre, Descripcion, IDCategoria, IDMarca, Precio, StockMinimo, StockActual, Ganancia, PrecioCompra)
VALUES 
('ELEC001', 'Televisor 42"', 'Televisor LED Full HD Samsung 42 pulgadas', 1, 1, 200000, 5, 10, 30.00, 153846),
('HOG001', 'Licuadora', 'Licuadora Philips 500W con vaso de vidrio', 2, 2, 45000, 2, 7, 25.00, 36000),
('JUG001', 'Muñeca Elsa', 'Muñeca original de Frozen Hasbro', 3, 3, 15000, 3, 15, 40.00, 10714),
('FER001', 'Taladro Bosch', 'Taladro eléctrico Bosch 600W', 4, 4, 75000, 2, 6, 20.00, 62500),
('JAR001', 'Cortacésped', 'Cortacésped Black+Decker 1200W', 5, 5, 120000, 1, 3, 25.00, 96000),
('DEP001', 'Pelota de fútbol', 'Pelota Adidas oficial tamaño 5', 6, 6, 30000, 5, 20, 20.00, 25000);

GO

--INSERT EN VENTAS
INSERT INTO Ventas (IDCliente, Fecha, Total, Factura) VALUES
(1, GETDATE(), 490000, 'V-0001');

--INSERT ITEM VENTA
INSERT INTO ItemVenta (IDVenta, IDProducto, Cantidad, PrecioUnidad) 
VALUES
(1,1,2,200000),
(1, 2, 2, 45000);
