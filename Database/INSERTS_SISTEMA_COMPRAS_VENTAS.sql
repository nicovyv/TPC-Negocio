--INSERTANDO EN USUARIOS
INSERT INTO Usuarios(Email, Pass, Nombre, Apellido, Admin)
VALUES 
('test1@email.com',123456,'Leonel','Messi',1),
('test2@email.com',222222,'Angel','Di Maria',0),
('test3@email.com',111111,'Emiliano','Martinez',0);

GO
-- Insertando en Categorias
INSERT INTO Categorias (Descripcion) VALUES ('Electrónica'),
('Hogar'),
('Juguetería');
GO

-- Insertando en Marcas
INSERT INTO Marcas (Descripcion) VALUES ('Samsung'),
('Philips'),
('Hasbro');
GO
-- Insertando en Clientes
INSERT INTO Clientes (Nombre, Email, Direccion, CuilCuit, Telefono)
VALUES ('Juan Pérez', 'juan.perez@email.com', 'Av. Siempre Viva 123', '20-12345678-9', '011-1234-5678'),
('Ana Gómez', 'ana.gomez@email.com', 'Calle Falsa 456', '27-87654321-0', '011-8765-4321');

-- Insertando en Proveedores
INSERT INTO Proveedores (Nombre, Email, Direccion, CuilCuit, Telefono)
VALUES ('ElectroMayorista SA', 'contacto@electromayorista.com', 'Paraná 123', '30-11223344-5', '011-1111-2222'),
('Distribuidora General SRL', 'ventas@distribgeneral.com', 'Av. Córdoba 456', '30-99887766-3', '011-3333-4444');
GO
-- Insertando en Productos
-- Supongamos que:
-- IDCategoria: 1 = Electrónica, 2 = Hogar, 3 = Juguetería
-- IDMarca: 1 = Samsung, 2 = Philips, 3 = Hasbro

INSERT INTO Productos (CodProd, Nombre, Descripcion, IDCategoria, IDMarca, Precio, StockMinimo, StockActual, Ganancia, PrecioCompra)
VALUES ('ELEC001', 'Televisor 42"', 'Televisor LED Full HD Samsung 42 pulgadas', 1, 1, 200000, 5, 10, 30.00, 153846),
('HOG001', 'Licuadora', 'Licuadora Philips 500W con vaso de vidrio', 2, 2, 45000, 2, 7, 25.00, 36000),
('JUG001', 'Muñeca Elsa', 'Muñeca original de Frozen Hasbro', 3, 3, 15000, 3, 15, 40.00, 10714);
GO