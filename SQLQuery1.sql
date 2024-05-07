create database SistemaGestion;

use SistemaGestion;

create table admon(
	ID INT PRIMARY KEY IDENTITY,
	[user] NVARCHAR(50),
	[password] NVARCHAR(50));

SELECT * FROM admon;

insert into admon ([user],[password])
values ('admon', 'Ryzen2020');

UPDATE admon
SET ID = 1
WHERE [user] = 'admon';

drop table Inventario;


CREATE TABLE Inventario (
    IDProd INT PRIMARY KEY IDENTITY,
    Codigo NVARCHAR(50),--
    Foto NVARCHAR(100),--
    Marca NVARCHAR(50),--
    Descripcion NVARCHAR(50),--
    Vehiculo NVARCHAR(50),--
    Anio NVARCHAR(50),--
    Calidad NVARCHAR(50),--
    Tipo NVARCHAR(50),--
    Precio DECIMAL(10, 2), --
	Iva DECIMAL(5, 2), --
	PrecioIva DECIMAL(10, 2), --
    Costo DECIMAL(10, 2), --
    Ganancia DECIMAL(10, 2),
    Proveedor NVARCHAR(100),--
    FechaIngreso DATE,
    FechaModificacion DATETIME,
    Stock INT,--
    Ubicacion NVARCHAR(100),--
    CodigoBarras NVARCHAR(50),--
    Estado NVARCHAR(50),--
    Notas NVARCHAR(MAX),--
    Descuento DECIMAL(5, 2), --
    Categoria NVARCHAR(50)--
);


select * from Inventario;



CREATE TABLE Empleados (
    IDEmpl INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
	FechaNac DATE,
	Telefono INT,
	Correo NVARCHAR(100),
	Dui INT,
    Cargo NVARCHAR(100),
    FechaContratacion DATE,
    Salario DECIMAL(10, 2),
    Departamento NVARCHAR(100)
);

select * from Empleados;





CREATE TABLE Compras (
    IDComp INT PRIMARY KEY IDENTITY,
    IDCien INT,
    FechaHoraCompra DATETIME,
    MontoTotal DECIMAL(10, 2),
    MetodoPago VARCHAR(50),
    EstadoCompra VARCHAR(50),
    IDProd INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Descuento DECIMAL(5, 2),
    Impuestos DECIMAL(8, 2),
    DireccionEnvio VARCHAR(100),
    IDEmpl INT,
	FOREIGN KEY (IDProd) REFERENCES Inventario (IDProd),
	FOREIGN KEY (IDEmpl) REFERENCES Empleados (IDEmpl)
);

select * from Compras;