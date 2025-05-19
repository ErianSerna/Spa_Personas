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

INSERT INTO TipoUsuario (Nombre)
VALUES ('Cliente'), ('Empleado'),('Administrador');

INSERT INTO [Usuario] (Nombre, Cedula, Telefono, Correo_electronico, IdTipoUsuario)
VALUES ('Carlos Rodríguez', '1234567890', '3104567890', 'carlos.rodriguez@email.com', 1);

SELECT * FROM Ciudad
SELECT * FROM Sede
SELECT * FROM TipoUsuario
SELECT * FROM Usuario