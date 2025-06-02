CREATE DATABASE DBSpaPersonas
USE DBSpaPersonas

--TABLA “TipoUsuario” 
CREATE TABLE [TipoUsuario] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(50) NOT NULL --Empleado, cliente
);
GO


--TABLA "TipoProducto"
CREATE TABLE [TipoProducto](
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL
);
GO

--TABLA "TipoServicio"
CREATE TABLE [TipoServicio](
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL
);
GO

--TABLA "Ciudad"
CREATE TABLE [Ciudad](
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30) NOT NULL,
	CodigoPostal NVARCHAR(30) NOT NULL
);
GO

--TABLA "Proveedor"
CREATE TABLE [Proveedor](
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(30),
	Teléfono VARCHAR(10) NOT NULL, 
	Correo_electronico VARCHAR(100) NOT NULL,
	Nit NVARCHAR(10),
	Direccion NVARCHAR(30),
);
GO

--TABLA "Sede"
CREATE TABLE [Sede] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(250) NOT NULL,
    Direccion NVARCHAR(250) NOT NULL,
    IdCiudad INT NOT NULL, 
    FOREIGN KEY (IdCiudad) REFERENCES [Ciudad](Id),
);
GO

--TABLA “Usuario” 
CREATE TABLE [Usuario] (
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Nombre NVARCHAR(50) NOT NULL, 
	Cedula NVARCHAR(10) NOT NULL, 
	Telefono NVARCHAR(10) NOT NULL, 
	Correo_electronico NVARCHAR(100) NOT NULL, 
	IdTipoUsuario INT NOT NULL,
	FOREIGN KEY (IdTipoUsuario) REFERENCES [TipoUsuario](Id)
);
GO

--TABLA "Servicio"
CREATE TABLE [Servicio] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(250) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Duracion INT NOT NULL, --En minutos puede ser
    IdSede INT NOT NULL, -- Sede en la que se brinda ese servicio
	IdTipoServicio INT NOT NULL, -- Servicio que se brinda 
    FOREIGN KEY (IdSede) REFERENCES [Sede](Id), 
	FOREIGN KEY (IdTipoServicio) REFERENCES [TipoServicio](Id)
)
GO

--TABLA "Reserva"
CREATE TABLE [Reserva] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Codigo NVARCHAR(20) NOT NULL,
	FechaInicio DATETIME NOT NULL,
    FechaExpiracion DATETIME NOT NULL,
    IdServicio INT NOT NULL,
    IdUsuario INT NOT NULL, 
    FOREIGN KEY (IdUsuario) REFERENCES [Usuario](Id),
    FOREIGN KEY (IdServicio) REFERENCES [Servicio](Id)
);
GO

-- TABLA "Producto"
CREATE TABLE [Producto] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(250) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
	Descripcion NVARCHAR(250) NOT NULL,
    IdProveedor INT NOT NULL,
    IdTipoProducto INT NOT NULL, 
    FOREIGN KEY (IdTipoProducto) REFERENCES [TipoProducto](Id),
    FOREIGN KEY (IdProveedor) REFERENCES [Proveedor](Id)
);
GO

--TABLA "Factura":
CREATE TABLE [Factura]( 
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Fecha DateTime, 
	Total DECIMAL(10,2), 
	Id_Usuario INT NOT NULL, 
	TotalConDescuento DECIMAL(10,2), 
	Id_Reservas INT NOT NULL,
	FOREIGN KEY (Id_Usuario) REFERENCES [Usuario](Id),
	FOREIGN KEY (Id_Reservas) REFERENCES [Reserva](Id),
);
GO



--TABLA "Inventario"
CREATE TABLE [Inventario] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Stock INT NOT NULL,
	UltimoRestock DATETIME NOT NULL,
	IdProducto INT NOT NULL,
	IdSede INT NOT NULL,
	FOREIGN KEY (IdProducto) REFERENCES [Producto](Id),
	FOREIGN KEY (IdSede) REFERENCES [Sede](Id)
)
GO

--TABLA "Servicio_Sede"
CREATE TABLE [Servicio_Sede] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdServicio INT NOT NULL,
	IdSede INT NOT NULL,
	FOREIGN KEY (IdServicio) REFERENCES [Servicio](Id),
	FOREIGN KEY (IdSede) REFERENCES [Sede](Id)
)
GO

--TABLA "Proveedor_Producto"
CREATE TABLE [Proveedor_Producto](
	Id INT PRIMARY KEY IDENTITY(1,1),
	Id_Proveedor INT,
	Id_Producto INT,
	FOREIGN KEY (Id_Proveedor) REFERENCES [Proveedor](Id),
    FOREIGN KEY (Id_Producto) REFERENCES [Producto](Id)
);
GO

--TABLA "Detalle_Factura"
CREATE TABLE [Detalle_factura] ( 
    Id INT PRIMARY KEY IDENTITY(1,1),
	CantidadProducto INT NOT NULL,
	CantidadServicio INT NOT NULL,
    IdProducto INT NOT NULL,
	IdFactura INT NOT NULL,
	IdServicio INT NOT NULL,
    FOREIGN KEY (IdProducto) REFERENCES [Producto](Id),
	FOREIGN KEY (IdFactura) REFERENCES [Factura](Id),
    FOREIGN KEY (IdServicio) REFERENCES [Servicio](Id) 	
);
GO

INSERT INTO Ciudad VALUES ('Medellin','050042');
INSERT INTO Sede VALUES ('Fraternidad','Cl. 54a #30-01',1)

INSERT INTO [TipoUsuario] (Nombre)
VALUES ('Cliente'), ('Empleado'),('Administrador');


SELECT * FROM Usuario
SELECT * FROM Proveedor

INSERT INTO [Usuario] (Nombre, Cedula, Telefono, Correo_electronico, IdTipoUsuario)
VALUES ('Carlos Rodríguez', '1234567890', '3104567890', 'carlos.rodriguez@email.com', 1);

INSERT INTO [Proveedor] VALUES ('Make Up Medellin','3135658644','MakeUpMed@gmail.com','83007057-2','Cra 72a #94-118')

SELECT * FROM Producto
SELECT * FROM TipoProducto

INSERT INTO [TipoProducto] (Nombre)
VALUES ('Maquillaje'), ('Cuidado Facial');

INSERT INTO [Producto] (Nombre, Precio, Descripcion, IdProveedor, IdTipoProducto)
VALUES ('Base Líquida Tonalizante', 45000.00, 'Base ligera de cobertura media con acabado natural', 1, 1), 
	   ('Crema Hidratante con Ácido Hialurónico', 52000.00, 'Crema ligera que hidrata profundamente y mejora la elasticidad de la piel', 1,2)

SELECT  * FROM Servicio
SELECT * FROM TipoServicio

INSERT INTO [TipoServicio] (Nombre)
VALUES ('Masaje Relajante'), ('Limpieza Facial');

INSERT INTO [Servicio] (Descripcion, Precio, Duracion, IdSede, IdTipoServicio)
VALUES ('Masaje de cuerpo completo con aceites esenciales para reducir el estrés', 80000.00, 60, 1, 1);

SELECT * FROM Reserva

INSERT INTO [Reserva] (Codigo, FechaInicio, FechaExpiracion, IdServicio, IdUsuario)
VALUES ('RSV-20250601', '2025-06-01 15:00:00', '2025-06-01 16:00:00', 1, 1);

-- Facturas

SELECT * FROM Factura

INSERT INTO Factura (Fecha, Total, TotalConDescuento, Id_Usuario, Id_Reservas)
VALUES ('2025-06-03 16:05:00', 80000.00, 72000.00, 1, 1);

SELECT * FROM Servicio_Sede
SELECT * FROM Detalle_factura
SELECT * FROM Proveedor_Producto

--El servicio con Id = 1 (Masaje) se ofrece en la sede Id = 1 (Fraternidad):
INSERT INTO Servicio_Sede (IdServicio, IdSede)
VALUES (1, 1);

--El proveedor Id = 1 (Make Up Medellin) vende el producto Id = 2 (Crema Hidratante):
INSERT INTO Proveedor_Producto (Id_Proveedor, Id_Producto)
VALUES (1, 2);

SELECT * FROM Producto
SELECT * FROM Factura
SELECT * FROM Servicio

-- En la factura Id = 1 se vendió: 20 unidades del producto Id = 1 (Base Líquida), y además fue 1 servicio de masaje (id=1).
INSERT INTO Detalle_factura (CantidadProducto, CantidadServicio, IdProducto, IdFactura, IdServicio)
VALUES (20, 1, 1, 1, 1);





USE DBSpaPersonas
	SELECT * FROM Ciudad
	SELECT * FROM Sede
	SELECT * FROM TipoUsuario
	SELECT * FROM Usuario
	SELECT * FROM Proveedor


	-- DBCC CHECKIDENT ('Proveedor', RESEED, 0); Este comando reinicia el id desde 1 de la tabla que se le especifique