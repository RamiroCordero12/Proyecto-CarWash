-- =============================================
-- PROYECTO 15: CARWASH
-- BASE DE DATOS: CarWashDB
-- Script completo según diagrama entidad-relación final
-- =============================================
CREATE DATABASE CarWashDB;
GO
USE CarWashDB;
GO

-- =============================================
-- 1. DOMINIO DEL NEGOCIO
-- =============================================

-- CLIENTES
CREATE TABLE Clientes (
    DNI       VARCHAR(20) PRIMARY KEY,
    Nombre    VARCHAR(100) NOT NULL,
    Apellido  VARCHAR(100) NOT NULL,
    Telefono  VARCHAR(50)
);
GO

-- VEHICULOS
CREATE TABLE Vehiculos (
    IdVehiculo   INT IDENTITY(1,1) PRIMARY KEY,
    Patente      VARCHAR(50) UNIQUE NOT NULL,
    TipoVehiculo VARCHAR(50) NOT NULL, -- 'Sedan', 'SUV'
    DNI          VARCHAR(20) NOT NULL,
    FOREIGN KEY (DNI) REFERENCES Clientes(DNI)
);
GO

-- SERVICIOS DE LAVADO (Composite: combos que agrupan servicios individuales)
CREATE TABLE ServicioLavado (
    IdServicio  INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      VARCHAR(100) NOT NULL,
    PrecioBase  DECIMAL(18,2) NOT NULL,
    EsCombo     BIT NOT NULL
);
GO

-- JERARQUIA DE COMBOS (Composite: relación reflexiva N:M sobre ServicioLavado)
CREATE TABLE LavadoJerarquia (
    IdServicio INT NOT NULL,
    IdCombo    INT NOT NULL,
    PRIMARY KEY (IdServicio, IdCombo),
    FOREIGN KEY (IdServicio) REFERENCES ServicioLavado(IdServicio),
    FOREIGN KEY (IdCombo)    REFERENCES ServicioLavado(IdServicio),
    CHECK (IdServicio <> IdCombo) -- un servicio no puede ser combo de sí mismo
);
GO

-- OPERARIOS
CREATE TABLE Operarios (
    IdOperario         INT IDENTITY(1,1) PRIMARY KEY,
    Nombre             VARCHAR(100) NOT NULL,
    PorcentajeComision DECIMAL(5,2) NOT NULL DEFAULT 0 -- ej: 15.00 = 15%
);
GO

-- =============================================
-- 2. DOMINIO DE SEGURIDAD (Composite de permisos)
-- =============================================

-- ROLES
CREATE TABLE Roles (
    CodRol    INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(100) NOT NULL,
    DescRol   VARCHAR(255)
);
GO

-- FAMILIA (nodo compuesto del Composite de permisos)
CREATE TABLE Familia (
    CodFam        INT IDENTITY(1,1) PRIMARY KEY,
    NombreFamilia VARCHAR(100) NOT NULL,
    DescFamilia   VARCHAR(255)
);
GO

-- FAM_FAM (familias anidadas: una familia puede contener otras familias)
CREATE TABLE Fam_Fam (
    CodFamPadre INT NOT NULL,
    CodFamHijo  INT NOT NULL,
    PRIMARY KEY (CodFamPadre, CodFamHijo),
    FOREIGN KEY (CodFamPadre) REFERENCES Familia(CodFam),
    FOREIGN KEY (CodFamHijo)  REFERENCES Familia(CodFam),
    CHECK (CodFamPadre <> CodFamHijo) -- una familia no puede ser hija de sí misma
);
GO

-- HOJAS (nodo hoja del Composite de permisos: patentes/permisos individuales)
CREATE TABLE Hojas (
    CodHoja    INT IDENTITY(1,1) PRIMARY KEY,
    NombreHoja VARCHAR(100) NOT NULL,
    DescHoja   VARCHAR(255)
);
GO

-- ROL_FAM (un rol puede tener familias completas asignadas)
CREATE TABLE Rol_Fam (
    CodRol INT NOT NULL,
    CodFam INT NOT NULL,
    PRIMARY KEY (CodRol, CodFam),
    FOREIGN KEY (CodRol) REFERENCES Roles(CodRol),
    FOREIGN KEY (CodFam) REFERENCES Familia(CodFam)
);
GO

-- ROL_PAT (un rol puede tener permisos sueltos asignados directamente)
CREATE TABLE Rol_Pat (
    CodRol  INT NOT NULL,
    CodHoja INT NOT NULL,
    PRIMARY KEY (CodRol, CodHoja),
    FOREIGN KEY (CodRol)  REFERENCES Roles(CodRol),
    FOREIGN KEY (CodHoja) REFERENCES Hojas(CodHoja)
);
GO

-- PAT_FAM (una familia agrupa permisos individuales)
CREATE TABLE Pat_Fam (
    CodFam  INT NOT NULL,
    CodHoja INT NOT NULL,
    PRIMARY KEY (CodFam, CodHoja),
    FOREIGN KEY (CodFam)  REFERENCES Familia(CodFam),
    FOREIGN KEY (CodHoja) REFERENCES Hojas(CodHoja)
);
GO

-- USUARIO
CREATE TABLE Usuario (
    IdUsuario     INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        VARCHAR(100) NOT NULL,
    Apellido      VARCHAR(100) NOT NULL,
    Email         VARCHAR(150),
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Contrasena    VARCHAR(256) NOT NULL, -- hash SHA-256, no la contraseña en texto plano
    CodRol        INT NOT NULL,
    FOREIGN KEY (CodRol) REFERENCES Roles(CodRol)
);
GO

-- =============================================
-- 3. TABLAS DE NEGOCIO QUE DEPENDEN DE USUARIO
-- =============================================

-- TURNOS (tabla central del negocio)
CREATE TABLE TurnoWash (
    IdTurno           INT IDENTITY(1,1) PRIMARY KEY,
    IdVehiculo        INT NOT NULL,
    IdServicio        INT NOT NULL,
    IdOperario        INT NOT NULL,
    IdUsuarioRegistro INT NOT NULL, -- usuario del sistema que cargó el turno (para auditoría en Bitacora)
    FechaHora         DATETIME NOT NULL,
    Estado            VARCHAR(50) NOT NULL DEFAULT 'EnEspera', -- 'EnEspera', 'Finalizado'
    Precio            DECIMAL(18,2) NOT NULL, -- monto final cobrado, fijado al momento de crear el turno
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdServicio) REFERENCES ServicioLavado(IdServicio),
    FOREIGN KEY (IdOperario) REFERENCES Operarios(IdOperario),
    FOREIGN KEY (IdUsuarioRegistro) REFERENCES Usuario(IdUsuario)
);
GO

-- ALERTA DE ENTREGA (Observer: disparado cuando el turno se marca Finalizado)
CREATE TABLE AlertaEntregaWash (
    IdAlerta        INT IDENTITY(1,1) PRIMARY KEY,
    IdTurno         INT NOT NULL,
    Patente         VARCHAR(50) NOT NULL,
    FechaCompletado DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdTurno) REFERENCES TurnoWash(IdTurno)
);
GO

-- =============================================
-- 4. AUDITORÍA
-- =============================================

CREATE TABLE Bitacora (
    IdBitacora INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario  INT NULL,
    Accion     VARCHAR(255) NOT NULL,
    FechaHora  DATETIME NOT NULL DEFAULT GETDATE(),
    Modulo     VARCHAR(100) NOT NULL,
    Criticidad VARCHAR(20) NOT NULL, -- 'Alta', 'Media', 'Baja'
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);
GO

-- =============================================
-- 5. PROCEDIMIENTOS ALMACENADOS (TRANSACCIONALES)
-- =============================================
CREATE PROCEDURE sp_CompletarServicioLavado
    @IdTurno INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE TurnoWash
        SET Estado = 'Finalizado'
        WHERE IdTurno = @IdTurno;

        INSERT INTO AlertaEntregaWash (IdTurno, Patente)
        SELECT T.IdTurno, V.Patente
        FROM TurnoWash T
        INNER JOIN Vehiculos V ON T.IdVehiculo = V.IdVehiculo
        WHERE T.IdTurno = @IdTurno;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW 50015, 'Error al completar el servicio de lavado.', 1;
    END CATCH
END;
GO
-- =============================================
-- 6. USUARIO BASICO PARA LOGIN DE PRUEBAS
-- =============================================
INSERT INTO Roles (NombreRol, DescRol)
VALUES ('AdminBasico', 'Rol creado para las pruebas')
GO

INSERT INTO Usuario (Nombre, Apellido, Email, NombreUsuario,
    Contrasena, CodRol)
VALUES ('Ramiro', 'Cordero', 'cordero14@gmail.com', 'ramiro',
    '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1)
GO