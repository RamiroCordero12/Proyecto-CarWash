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
    Marca        VARCHAR(50) NOT NULL,
    Color        VARCHAR(50) NOT NULL,
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
-- Estado guarda el nombre del enum EstadoTurno (BE):
-- 'Pendiente', 'Asignado', 'EnLavado', 'LavadoTerminado', 'Entregado', 'Cancelado'
CREATE TABLE TurnoWash (
    IdTurno           INT IDENTITY(1,1) PRIMARY KEY,
    IdVehiculo        INT NOT NULL,
    IdServicio        INT NOT NULL,
    IdOperario        INT NOT NULL,
    IdUsuarioRegistro INT NOT NULL, -- usuario del sistema que cargó el turno (para auditoría en Bitacora)
    FechaHora         DATETIME NOT NULL,
    Estado            VARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- CAMBIO: antes 'EnEspera'
    Precio            DECIMAL(18,2) NOT NULL, -- monto final cobrado, fijado al momento de crear el turno
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdServicio) REFERENCES ServicioLavado(IdServicio),
    FOREIGN KEY (IdOperario) REFERENCES Operarios(IdOperario),
    FOREIGN KEY (IdUsuarioRegistro) REFERENCES Usuario(IdUsuario)
);
GO

-- ALERTA DE ENTREGA (Observer: disparado cuando el turno pasa a LavadoTerminado)
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
        SET Estado = 'LavadoTerminado' -- CAMBIO: antes 'Finalizado'
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
-- 6. USUARIOS ADMINISTRADORES PARA LOGIN DE PRUEBAS
-- =============================================
-- Crea el rol si no existe y asigna el usuario a ese rol.
-- Los permisos se conceden al final, cuando ya existen las hojas.
IF NOT EXISTS (SELECT 1 FROM Roles WHERE NombreRol = 'AdminBasico')
BEGIN
    INSERT INTO Roles (NombreRol, DescRol)
    VALUES ('AdminBasico', 'Administrador con acceso completo');
END;
GO

DECLARE @CodRolAdmin INT;
SET @CodRolAdmin = (SELECT TOP 1 CodRol FROM Roles WHERE NombreRol = 'AdminBasico' ORDER BY CodRol);

IF EXISTS (SELECT 1 FROM Usuario WHERE NombreUsuario = 'ramiro')
BEGIN
    UPDATE Usuario
    SET Contrasena = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '1234'), 2)),
        CodRol = @CodRolAdmin
    WHERE NombreUsuario = 'ramiro';
END
ELSE
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Email, NombreUsuario, Contrasena, CodRol)
    VALUES ('Ramiro', 'Cordero', 'cordero14@gmail.com', 'ramiro',
            LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '1234'), 2)),
            @CodRolAdmin);
END;

-- Crear o actualizar a Joaquin con el mismo rol y clave de prueba.
IF EXISTS (SELECT 1 FROM Usuario WHERE NombreUsuario = 'joaquin')
BEGIN
    UPDATE Usuario
    SET Contrasena = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '1234'), 2)),
        CodRol = @CodRolAdmin
    WHERE NombreUsuario = 'joaquin';
END
ELSE
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Email, NombreUsuario, Contrasena, CodRol)
    VALUES ('Joaquin', 'Usuario', NULL, 'joaquin',
            LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '1234'), 2)),
            @CodRolAdmin);
END;
GO

-- =============================================
-- 7. DATOS DE PRUEBA
-- =============================================
GO
INSERT INTO Clientes (DNI, Nombre, Apellido, Telefono) VALUES
('30111222', 'Juan', 'Perez', '1155551111'),
('28999888', 'Maria', 'Gomez', '1166662222');

-- OJO: TipoVehiculo tiene que ser exactamente 'Sedan' o 'SUV_Camioneta' (VehiculoMPP los reconoce por ese texto)
INSERT INTO Vehiculos (Patente, TipoVehiculo, Marca, Color, DNI) VALUES
('ABC123',  'Sedan',         'Toyota', 'Gris',  '30111222'),
('AB123CD', 'SUV_Camioneta', 'Ford',   'Negro', '28999888');

INSERT INTO ServicioLavado (Nombre, PrecioBase, EsCombo) VALUES
('Lavado Exterior',          800, 0),   -- Id 1
('Aspirado',                 400, 0),   -- Id 2
('Limpieza de Tapizados',   1200, 0),   -- Id 3
('Encerado de Carroceria',  1000, 0),   -- Id 4
('Lavado Integral Premium', 2500, 1);   -- Id 5 (combo con precio promocional)

INSERT INTO LavadoJerarquia (IdServicio, IdCombo) VALUES (1,5), (2,5), (3,5), (4,5);

INSERT INTO Operarios (Nombre, PorcentajeComision) VALUES
('Carlos Lopez', 15),
('Lucia Fernandez', 12);
GO


-- =============================================
-- 8. COMPOSITE DE SEGURIDAD (HOJAS, FAMILIAS Y ROLES)
-- =============================================
INSERT INTO Hojas (NombreHoja, DescHoja) VALUES
('Clientes', 'Gestión y consulta de clientes'),
('Vehiculos', 'Gestión y consulta de vehículos'),
('Servicios', 'Gestión de servicios de lavado y combos'),
('Turnos', 'Gestión y registro de turnos de lavado'),
('TableroEntregas', 'Tablero de entregas y aviso de lavados finalizados'),
('Operarios', 'Gestión de operarios y comisiones'),
('Bitacora', 'Consulta y filtrado de auditoría'),
('Estadisticas', 'Gráficos de facturación y servicios del mes'),
('Seguridad', 'Gestión de roles, permisos y usuarios'),
('Backup', 'Copia de seguridad y restauración de base de datos');
GO

INSERT INTO Familia (NombreFamilia, DescFamilia) VALUES
('Operaciones', 'Operaciones diarias de lavado y turnos'),
('Administracion', 'Control administrativo completo del lavadero');
GO

-- Asignar hojas a Familia Operaciones
INSERT INTO Pat_Fam (CodFam, CodHoja)
SELECT (SELECT CodFam FROM Familia WHERE NombreFamilia = 'Operaciones'), CodHoja 
FROM Hojas WHERE NombreHoja IN ('Clientes', 'Vehiculos', 'Servicios', 'Turnos', 'TableroEntregas');
GO

-- Asignar Operaciones a Administracion (Fam_Fam)
INSERT INTO Fam_Fam (CodFamPadre, CodFamHijo)
VALUES ((SELECT CodFam FROM Familia WHERE NombreFamilia = 'Administracion'),
        (SELECT CodFam FROM Familia WHERE NombreFamilia = 'Operaciones'));
GO

-- Asignar hojas administrativas a Administracion
INSERT INTO Pat_Fam (CodFam, CodHoja)
SELECT (SELECT CodFam FROM Familia WHERE NombreFamilia = 'Administracion'), CodHoja
FROM Hojas WHERE NombreHoja IN ('Operarios', 'Bitacora', 'Estadisticas', 'Seguridad', 'Backup');
GO

-- Rol Operador
INSERT INTO Roles (NombreRol, DescRol) VALUES ('Operador', 'Operador de pista con acceso a turnos y clientes');
GO

-- Asignar Administracion al Rol AdminBasico
INSERT INTO Rol_Fam (CodRol, CodFam)
VALUES ((SELECT CodRol FROM Roles WHERE NombreRol = 'AdminBasico'),
        (SELECT CodFam FROM Familia WHERE NombreFamilia = 'Administracion'));
GO

-- Asignar Operaciones al Rol Operador
INSERT INTO Rol_Fam (CodRol, CodFam)
VALUES ((SELECT CodRol FROM Roles WHERE NombreRol = 'Operador'),
        (SELECT CodFam FROM Familia WHERE NombreFamilia = 'Operaciones'));
GO

-- =============================================
-- 9. ACCESO COMPLETO PARA EL ROL ADMINBASICO
-- =============================================
-- La tabla Hojas ya está cargada. Asignamos todas las hojas
-- directamente al rol, sin duplicar relaciones existentes.
DECLARE @CodRolAdmin INT;
SET @CodRolAdmin = (SELECT TOP 1 CodRol FROM Roles WHERE NombreRol = 'AdminBasico' ORDER BY CodRol);

INSERT INTO Rol_Pat (CodRol, CodHoja)
SELECT @CodRolAdmin, H.CodHoja
FROM Hojas AS H
WHERE NOT EXISTS (
    SELECT 1 FROM Rol_Pat AS RP
    WHERE RP.CodRol = @CodRolAdmin AND RP.CodHoja = H.CodHoja
);
GO

-- Comprobación: usuario, rol y permisos directos asignados
SELECT U.NombreUsuario, R.NombreRol, COUNT(DISTINCT RP.CodHoja) AS PermisosDirectos
FROM Usuario AS U
INNER JOIN Roles AS R ON U.CodRol = R.CodRol
LEFT JOIN Rol_Pat AS RP ON RP.CodRol = R.CodRol
WHERE U.NombreUsuario IN ('ramiro', 'joaquin')
GROUP BY U.NombreUsuario, R.NombreRol;
GO
