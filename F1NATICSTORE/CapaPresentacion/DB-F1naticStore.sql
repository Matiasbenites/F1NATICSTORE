CREATE DATABASE F1naticStore;
GO
USE F1naticStore;
GO

CREATE TABLE Categoria (
    IdCategoria INT IDENTITY PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL,
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Producto (
    IdProducto INT IDENTITY PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL UNIQUE,
    Nombre NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(255),
    IdCategoria INT NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    PrecioCompra DECIMAL(10,2) NOT NULL CHECK (PrecioCompra >= 0),
    PrecioVenta DECIMAL(10,2) NOT NULL CHECK (PrecioVenta >= 0),
    Estado BIT DEFAULT 1,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);

CREATE TABLE Proveedor (
    IdProveedor INT IDENTITY PRIMARY KEY,
    Documento NVARCHAR(20) NOT NULL UNIQUE,
    RazonSocial NVARCHAR(150) NOT NULL,
    Correo NVARCHAR(150),
    Telefono NVARCHAR(20),
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Cliente (
    IdCliente INT IDENTITY PRIMARY KEY,
    Documento NVARCHAR(20) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Correo NVARCHAR(150),
    Telefono NVARCHAR(20),
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Rol (
    IdRol INT IDENTITY PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Permiso (
    IdPermiso INT IDENTITY PRIMARY KEY,
    IdRol INT NOT NULL,
    NombreMenu NVARCHAR(100) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY PRIMARY KEY,
    Documento NVARCHAR(20) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Correo NVARCHAR(150) NOT NULL UNIQUE,
    Clave NVARCHAR(255) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);


CREATE TABLE Compra (
    IdCompra INT IDENTITY PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdProveedor INT NOT NULL,
    TipoDocumento NVARCHAR(50) NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    MontoTotal DECIMAL(12,2) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdProveedor) REFERENCES Proveedor(IdProveedor)
);

CREATE TABLE Detalle_Compra (
    IdDetalleCompra INT IDENTITY PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    PrecioCompra DECIMAL(10,2) NOT NULL CHECK (PrecioCompra >= 0),
    PrecioVenta DECIMAL(10,2) NOT NULL CHECK (PrecioVenta >= 0),
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    Total DECIMAL(12,2) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdCompra) REFERENCES Compra(IdCompra),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

CREATE TABLE Venta (
    IdVenta INT IDENTITY PRIMARY KEY,
    IdUsuario INT NOT NULL,
    TipoDocumento NVARCHAR(50) NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    DocumentoCliente NVARCHAR(20),
    NombreCliente NVARCHAR(150),
    MontoPago DECIMAL(12,2) NOT NULL,
    MontoCambio DECIMAL(12,2) NOT NULL,
    MontoTotal DECIMAL(12,2) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Detalle_Venta (
    IdDetalleVenta INT IDENTITY PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL CHECK (PrecioVenta >= 0),
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    SubTotal DECIMAL(12,2) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);