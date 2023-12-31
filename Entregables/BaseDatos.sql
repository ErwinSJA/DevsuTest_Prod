USE [master]
GO

CREATE DATABASE DBPersona
GO

USE DBPersona
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Persona]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[Persona]
END;
GO

CREATE TABLE [dbo].[Persona]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.Persona
    Descripción             :	Almacenará los datos de persona
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBPersona
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	intIdPersona			INT IDENTITY(1,1)	NOT NULL,
	vchNombre				VARCHAR(100)		NOT NULL DEFAULT(''),
	tinGenero				TINYINT				NOT NULL DEFAULT((0)),
	intEdad					INT					NOT NULL DEFAULT((0)),
	vchIdentificacion		VARCHAR(25)			NOT NULL DEFAULT(''),
	vchDireccion			VARCHAR(150)		NOT NULL DEFAULT(''),
	vchTelefono				VARCHAR(20)			NOT NULL DEFAULT('')
 CONSTRAINT [PK_Persona_intIdPersona] PRIMARY KEY CLUSTERED 
(
	intIdPersona ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX idx_Persona_vchIdentificacion ON dbo.Persona (vchIdentificacion)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena datos de persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'intIdPersona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'vchNombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica el genero 1:Masculino | 2:Femenino | 3:Prefiero No Especificar (Tabla: DBTransact.dbo.ParametroSistema, Codigo: 1000)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'tinGenero'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica la edad de la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'intEdad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de documento que identifica a la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'vchIdentificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'vchDireccion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de teléfono de la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Persona', @level2type=N'COLUMN',@level2name=N'vchTelefono'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.Persona TO [public]
GO


IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[PersonaHist]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[PersonaHist]
END;
GO

CREATE TABLE [dbo].[PersonaHist]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.PersonaHist
    Descripción             :	Almacenará los datos historicos de Persona
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBPersona
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	intIdPersonaHist		INT IDENTITY(1,1)	NOT NULL,
	intIdPersona			INT					NOT NULL,
	vchNombre				VARCHAR(100)		NOT NULL DEFAULT(''),
	tinGenero				TINYINT				NOT NULL DEFAULT((0)),
	intEdad					INT					NOT NULL DEFAULT((0)),
	vchIdentificacion		VARCHAR(25)			NOT NULL DEFAULT(''),
	vchDireccion			VARCHAR(150)		NOT NULL DEFAULT(''),
	vchTelefono				VARCHAR(20)			NOT NULL DEFAULT(''),
	dtmFechaMod				DATETIME			NOT NULL
 CONSTRAINT [PK_PersonaHist_intIdPersonaHist] PRIMARY KEY CLUSTERED 
(
	intIdPersonaHist ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena datos historicos de Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.PersonaHist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'intIdPersonaHist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'intIdPersona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'vchNombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica el genero 1:Masculino | 2:Femenino | 3:Prefiero No Especificar (Tabla: DBTransact.dbo.ParametroSistema, Código: 1000)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'tinGenero'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica la edad de la Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'intEdad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de documento que identifica a la Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'vchIdentificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de la Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'vchDireccion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de teléfono de la Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'vchTelefono'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en que se modificó la persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PersonaHist', @level2type=N'COLUMN',@level2name=N'dtmFechaMod'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.PersonaHist TO [public]
GO


IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Cliente]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[Cliente]
END;
GO

CREATE TABLE [dbo].[Cliente]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.Cliente
    Descripción             :	Almacenará los datos de Cliente
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBPersona
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	intIdCliente		INT IDENTITY(100,1)	NOT NULL,
	intIdPersona		INT	UNIQUE			NOT NULL,
	vchPasswordSalt		VARCHAR(400)		NOT NULL DEFAULT(''),
	vchPasswordHash		VARCHAR(400)		NOT NULL DEFAULT(''),
	bitEstado			BIT					NOT NULL DEFAULT((1))
 CONSTRAINT [PK_Cliente_intIdCliente] PRIMARY KEY CLUSTERED 
(
	intIdCliente ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena datos de Cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.Cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'intIdCliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.Persona' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'intIdPersona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Salt de la contraseña' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'vchPasswordSalt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Hash de la contraseña' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'vchPasswordHash'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del cliente (1:Activo | 0:Inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente', @level2type=N'COLUMN',@level2name=N'bitEstado'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.Cliente TO [public]
GO

CREATE DATABASE DBTransact
GO

USE DBTransact
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[ParametroSistema]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[ParametroSistema]
END;
GO

CREATE TABLE [dbo].[ParametroSistema]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.ParametroSistema
    Descripción             :	Almacenará las descripciones de los parametros especificados en las otras tablas.
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBTransact
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	intIdParametroSistema	INT IDENTITY(1,1)	NOT NULL,
	vchParamCodigo			VARCHAR(4)			NOT NULL DEFAULT(''),
	tinParamValor			TINYINT				NOT NULL DEFAULT((0)),
	vchParamDescripcion		VARCHAR(100)		NOT NULL DEFAULT('')
 CONSTRAINT [PK_ParametroSistema_intIdParametroSistema] PRIMARY KEY CLUSTERED 
(
	intIdParametroSistema ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX idx_ParametroSistema_vchParamCodigo_tinParamValor ON dbo.ParametroSistema (vchParamCodigo, tinParamValor)
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena descripción de los parametros del sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParametroSistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBTransact.dbo.ParametroSistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParametroSistema', @level2type=N'COLUMN',@level2name=N'intIdParametroSistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código que identifica a un grupo de parametros (Ej: 1000 - Genero | 1001: Tipo Cuenta | 1002: Tipo Movimiento)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParametroSistema', @level2type=N'COLUMN',@level2name=N'vchParamCodigo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica el valor que identifica al parametro en específico (Ej: 1: Masculino | 2: Femenino | 3:Prefiere No Especificar)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParametroSistema', @level2type=N'COLUMN',@level2name=N'tinParamValor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del parámetro (Ej: Masculino, Femeninino, Ahorros, Corriente, Retiro, Deposito)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParametroSistema', @level2type=N'COLUMN',@level2name=N'vchParamDescripcion'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.ParametroSistema TO [public]
GO


IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Cuenta]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[Cuenta]
END;
GO

CREATE TABLE [dbo].[Cuenta]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.Cuenta
    Descripción             :	Almacenará los datos de las cuentas de clientes
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBTransact
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	bigIdCuenta			BIGINT IDENTITY(100000,1)	NOT NULL,
	intIdCliente		INT							NOT NULL,
	tinTipoCuenta		TINYINT						NOT NULL DEFAULT((0)),
	monSaldo			MONEY						NOT NULL DEFAULT((0)),
	dtmFechaMod			DATETIME					NOT NULL,
	bitEstado			BIT							NOT NULL DEFAULT((1))
 CONSTRAINT [PK_Cuenta_bigIdCuenta] PRIMARY KEY CLUSTERED 
(
	bigIdCuenta ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena datos de la Cuenta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBTransact.dbo.Cuenta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'bigIdCuenta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBPersona.dbo.Cliente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'intIdCliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de cuenta 1:Ahorros | 2:Corriente (Tabla DBTransact.dbo.ParametroSistema, Código: 1001)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'tinTipoCuenta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo actual de la cuenta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'monSaldo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de la ultima modificación realizada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'dtmFechaMod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del Cuenta (1:Activo | 0:Inactivo)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cuenta', @level2type=N'COLUMN',@level2name=N'bitEstado'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.Cuenta TO [public]
GO


IF EXISTS (SELECT 1 FROM sys.objects WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Movimiento]') AND type = (N'U'))
BEGIN
	DROP TABLE [dbo].[Movimiento]
END;
GO

CREATE TABLE [dbo].[Movimiento]
/*	-----------------------------------------------------------------------------------------------
    Sistema                 :	TechnicalTest Devsu
    Objeto                  :	dbo.Movimiento
    Descripción             :	Almacenará los movimientos de las cuentas de clientes
    Fecha de Creación       :	30/10/2023
    Autor                   :	Erwin Joao Sanchez Aranda (EJSA)
    Base de datos           :	DBTransact
	-----------------------------------------------------------------------------------------------
	Bitácora de Revisiones :
	Nombre		Fecha			Descripción
--------------------------------------------------------------------------------------------- */
(
	bigIdMovimiento		BIGINT IDENTITY(1,1)	NOT NULL,
	bigIdCuenta			BIGINT					NOT NULL,
	dtmFecha			DATETIME				NOT NULL,
	tinTipoMovimiento	TINYINT					NOT NULL DEFAULT((0)),
	monSaldoInicial		MONEY					NOT NULL DEFAULT((0)),
	monValor			MONEY					NOT NULL DEFAULT((0)),
	monSaldoMovimiento	MONEY					NOT NULL DEFAULT((0)),
	bitEstado			BIT						NOT NULL DEFAULT((1))
 CONSTRAINT [PK_Movimiento_bigIdMovimiento] PRIMARY KEY CLUSTERED 
(
	bigIdMovimiento ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX idx_Movimiento_bigIdCuenta ON dbo.Movimiento (bigIdCuenta)
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacena los movimientos de las cuentas de clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBTransact.dbo.Movimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'bigIdMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la tabla DBTransact.dbo.Cuenta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'bigIdCuenta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que se realiza la transacción' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'dtmFecha'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Movimiento 1:Deposito | 2:Retiro (Tabla DBTransact.dbo.ParametroSistema, Código: 1002)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'tinTipoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo de la cuenta antes de la transacción' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'monSaldoInicial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto|Importe|Valor del movimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'monValor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo de la cuenta despues de la transacción' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'monSaldoMovimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la transacción esta 1:activa o si fue 0:extornada/anulada/eliminada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Movimiento', @level2type=N'COLUMN',@level2name=N'bitEstado'
GO

GRANT SELECT, UPDATE, DELETE, INSERT ON dbo.Movimiento TO [public]
GO


USE DBTransact
GO
TRUNCATE TABLE dbo.ParametroSistema
GO
INSERT INTO dbo.ParametroSistema (vchParamCodigo, tinParamValor, vchParamDescripcion)
VALUES 
('1000',1,'Masculino'),
('1000',2,'Femenino'),
('1000',3,'Prefiero NoEspecificar'),
('1001',1,'Ahorros'),
('1001',2,'Corriente'),
('1002',1,'Deposito'),
('1002',2,'Retiro')
GO

USE DBPersona
GO
TRUNCATE TABLE dbo.Persona
GO
TRUNCATE TABLE dbo.PersonaHist
GO
INSERT INTO dbo.Persona (vchNombre, tinGenero, intEdad, vchIdentificacion, vchDireccion, vchTelefono)
VALUES
('Juan Altamirano Manrique', 1, 20, '18407645', 'Los Cipreses 145 Dpto 205', '947842115'),
('Rosa Guevara Lopez', 2, 25, '49523412', 'Calle Aramburu Lote 505', '987496527'),
('Leandro Jara Valverde', 3, 30, '17384922', 'Urb Dressrosa 4870', '978357918')
GO
TRUNCATE TABLE dbo.Cliente
GO
INSERT INTO dbo.Cliente (intIdPersona, vchPasswordSalt, vchPasswordHash, bitEstado)
VALUES
(1, '','',1),
(2, '','',1),
(3, '','',1)
GO

USE DBTransact
GO
TRUNCATE TABLE dbo.Cuenta
GO
INSERT INTO dbo.Cuenta (intIdCliente, tinTipoCuenta, monSaldo, dtmFechaMod, bitEstado)
VALUES
(100, 2, 1500, GETDATE(), 1),
(101, 1, 750, GETDATE(), 1),
(102, 1, 300, GETDATE(), 1)
GO


USE DBPersona
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspPersonaInsertar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspPersonaInsertar]
GO

CREATE PROCEDURE [dbo].[uspPersonaInsertar]
	@pevchNombre			VARCHAR(100),
	@petinGenero			TINYINT,
	@peintEdad				INT,
	@pevchIdentificacion	VARCHAR(25),
	@pevchDireccion			VARCHAR(150),
	@pevchTelefono			VARCHAR(20)
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspPersonaInsertar																
	Descripción			: Procedimiento para insertar datos de una persona
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pevchNombre			VARCHAR(100)		Nombre de la persona
	@petinGenero			TINYINT				Indica el genero 1:Masculino | 2:Femenino | 3:Prefiero No Especificar (Tabla: DBTransact.dbo.ParametroSistema)
	@peintEdad				INT					Indica la edad de la persona
	@pevchIdentificacion	VARCHAR(25)			Número de documento que identifica a la persona
	@pevchDireccion			VARCHAR(150)		Dirección de la persona
	@pevchTelefono			VARCHAR(20)			Número de teléfono de la persona
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspPersonaInsertar 'Gerardo Lopez',1,24,'18407649','EJEMPLO DIR','111111111'
	SELECT * FROM DBPersona.dbo.Persona
	SELECT * FROM DBPersona.dbo.PersonaHist
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vintIdPersona INT = 0
		DECLARE @vbitTransaction BIT = 0

	BEGIN TRY		
		IF EXISTS(SELECT 1 FROM dbo.Persona WHERE vchIdentificacion = @pevchIdentificacion)
			THROW 51000, 'Ya existe un cliente con la misma identificacion', 1;		
		ELSE
		BEGIN
			BEGIN TRANSACTION trx_PersonaInsertar
			SET @vbitTransaction = 1

			INSERT INTO dbo.Persona (vchNombre, tinGenero, intEdad, vchIdentificacion, vchDireccion, vchTelefono)
			VALUES (@pevchNombre, @petinGenero,	@peintEdad,	@pevchIdentificacion, @pevchDireccion, @pevchTelefono)

			SET @vintIdPersona = CAST(SCOPE_IDENTITY() AS INT)

			INSERT INTO dbo.PersonaHist (intIdPersona, vchNombre, tinGenero, intEdad, vchIdentificacion, vchDireccion, vchTelefono, dtmFechaMod)
			VALUES (@vintIdPersona, @pevchNombre, @petinGenero,	@peintEdad,	@pevchIdentificacion, @pevchDireccion, @pevchTelefono, GETDATE())

			COMMIT TRANSACTION trx_PersonaInsertar

			SELECT @vintIdPersona AS intIdPersona

		END
	END TRY
	BEGIN CATCH
		IF @vbitTransaction = 1	ROLLBACK TRANSACTION trx_PersonaInsertar;
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspPersonaInsertar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspPersonaDatosModificar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspPersonaDatosModificar]
GO

CREATE PROCEDURE [dbo].[uspPersonaDatosModificar]
	@pevchIdentificacion	VARCHAR(25),
	@pevchNombre			VARCHAR(100),
	@petinGenero			TINYINT,
	@peintEdad				INT,
	@pevchDireccion			VARCHAR(150),
	@pevchTelefono			VARCHAR(20)
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspPersonaDatosModificar																
	Descripción			: Procedimiento para modificar datos generales de la persona
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pevchIdentificacion	VARCHAR(25)			Número de documento que identifica a la persona
	@pevchNombre			VARCHAR(100)		Nombre de la persona
	@petinGenero			TINYINT				Indica el genero 1:Masculino | 2:Femenino | 3:Prefiero No Especificar (Tabla: DBTransact.dbo.ParametroSistema)
	@peintEdad				INT					Indica la edad de la persona
	@pevchDireccion			VARCHAR(150)		Dirección de la persona
	@pevchTelefono			VARCHAR(20)			Número de teléfono de la persona
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspPersonaDatosModificar '18407645','Nombre nuevo',3,25,'EJEMPLO MODIF DIR','222222222'
	SELECT * FROM DBPersona.dbo.Persona
	SELECT * FROM DBPersona.dbo.PersonaHist
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vintIdPersona INT = 0
	DECLARE @vbitTransaction BIT = 0

	BEGIN TRY		
		IF NOT EXISTS(SELECT 1 FROM dbo.Persona WHERE vchIdentificacion = @pevchIdentificacion)
			THROW 51000, 'No existe persona con el número de identificación ingresado', 1;		
		ELSE
		BEGIN
			BEGIN TRANSACTION trx_PersonaDatosModificar
			SET @vbitTransaction = 1

			UPDATE dbo.Persona SET @vintIdPersona = intIdPersona, vchNombre = @pevchNombre, tinGenero = @petinGenero, intEdad = @peintEdad, 
								   vchDireccion = @pevchDireccion, vchTelefono = @pevchTelefono
			WHERE vchIdentificacion = @pevchIdentificacion

			INSERT INTO dbo.PersonaHist(intIdPersona, vchNombre, tinGenero, intEdad, vchIdentificacion, vchDireccion, vchTelefono, dtmFechaMod)
			VALUES (@vintIdPersona, @pevchNombre, @petinGenero, @peintEdad, @pevchIdentificacion, @pevchDireccion, @pevchTelefono, GETDATE())

			COMMIT TRANSACTION trx_PersonaDatosModificar
		END
	END TRY
	BEGIN CATCH
		IF @vbitTransaction = 1	ROLLBACK TRANSACTION trx_PersonaDatosModificar;
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspPersonaDatosModificar TO [public]
GO


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspPersonaObtener]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspPersonaObtener]
GO

CREATE PROCEDURE [dbo].[uspPersonaObtener]
	@pevchIdentificacion	VARCHAR(25)
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspPersonaObtener																
	Descripción			: Procedimiento para obtener datos de una persona
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pevchIdentificacion	VARCHAR(25)			Número de documento que identifica a la persona
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspPersonaObtener '49523412'
	SELECT * FROM DBPersona.dbo.Persona
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		DECLARE @vintIdPersona INT = 0

		SELECT @vintIdPersona = intIdPersona FROM dbo.Persona WHERE vchIdentificacion = @pevchIdentificacion
		IF @vintIdPersona = 0
			THROW 51000, 'No existe una persona con la identificacion ingresada', 1;
		ELSE
		BEGIN
			SELECT PER.intIdPersona, PER.vchNombre, PER.tinGenero, PSIST.vchParamDescripcion AS vchGenero, PER.intEdad, PER.vchIdentificacion, PER.vchDireccion, PER.vchTelefono 
			FROM dbo.Persona PER
			INNER JOIN DBTransact.dbo.ParametroSistema PSIST ON PSIST.vchParamCodigo = '1000' AND PSIST.tinParamValor = PER.tinGenero
			WHERE PER.intIdPersona = @vintIdPersona
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspPersonaObtener TO [public]
GO


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspPersonaListar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspPersonaListar]
GO

CREATE PROCEDURE [dbo].[uspPersonaListar]
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspPersonaListar																
	Descripción			: Procedimiento para listar a todas las personas
	Fecha de Creación	: 01/11/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspPersonaListar
	SELECT * FROM DBPersona.dbo.Persona
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON

	SELECT PER.intIdPersona, PER.vchNombre, PER.tinGenero, PSIST.vchParamDescripcion AS vchGenero, PER.intEdad, PER.vchIdentificacion, PER.vchDireccion, PER.vchTelefono 
	FROM dbo.Persona PER
	INNER JOIN DBTransact.dbo.ParametroSistema PSIST ON PSIST.vchParamCodigo = '1000' AND PSIST.tinParamValor = PER.tinGenero
END
GO

GRANT EXECUTE ON dbo.uspPersonaListar TO [public]
GO


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspClienteInsertar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspClienteInsertar]
GO

CREATE PROCEDURE [dbo].[uspClienteInsertar]
	@peintIdPersona			INT,
	@pevchPasswordSalt		VARCHAR(400),
	@pevchPasswordHash		VARCHAR(400)
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspClienteInsertar																
	Descripción			: Procedimiento para insertar un cliente
	Fecha de Creación	: 30/10/2023
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdPersona			INT					Código de persona
	@pevchPasswordSalt		VARCHAR(400)		Valor Salt de la contraseña
	@pevchPasswordHash		VARCHAR(400)		Valor Hash de la contraseña
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspClienteInsertar 4,'PRUEBA SALT CLIENTE INSERCION','PRUEBA HASH CLIENTE INSERCION'
	SELECT * FROM DBPersona.dbo.Persona
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vintIdCliente	INT = 0
	DECLARE @vbitEstadoCliente BIT = 0
	DECLARE @vvchMsgError	VARCHAR(200) = ''

	BEGIN TRY
		
		SELECT @vintIdCliente = intIdCliente, @vbitEstadoCliente = bitEstado FROM dbo.Cliente WHERE intIdPersona = @peintIdPersona

		IF @vintIdCliente > 0
		BEGIN
			SET @vvchMsgError = 'Cliente ya existe. Su estado es:' + CAST(@vbitEstadoCliente AS VARCHAR);
			THROW 51000, @vvchMsgError, 1;
		END
		ELSE
			INSERT INTO dbo.Cliente(intIdPersona, vchPasswordSalt, vchPasswordHash, bitEstado)
			VALUES (@peintIdPersona, @pevchPasswordSalt, @pevchPasswordHash, 1)

			SELECT CAST(SCOPE_IDENTITY() AS INT) AS intIdCliente
	END TRY
	BEGIN CATCH		
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspClienteInsertar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspClienteObtener]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspClienteObtener]
GO

CREATE PROCEDURE [dbo].[uspClienteObtener]
	@peintIdCliente	INT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspClienteObtener																
	Descripción			: Procedimiento para obtener datos de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdCliente			INT					Identificador de cliente (Tabla DBPersona.dbo.Cliente)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspClienteObtener 102
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		
		DECLARE @peintIdPersona	  INT = 0
		DECLARE @vvchPasswordSalt VARCHAR(400) = ''
		DECLARE @vvchPasswordHash VARCHAR(400) = ''
		DECLARE @vbitEstado		  BIT = 0

		SELECT @peintIdPersona = intIdPersona, @vvchPasswordSalt = vchPasswordSalt, @vvchPasswordHash = vchPasswordHash, @vbitEstado = bitEstado FROM dbo.Cliente WHERE intIdCliente = @peintIdCliente
		IF @peintIdPersona = 0
			THROW 51000, 'No existe un cliente con el código ingresado', 1;
		ELSE
		BEGIN
			SELECT @peintIdCliente AS intIdCliente, @peintIdPersona AS intIdPersona, @vvchPasswordSalt AS vchPasswordSalt, @vvchPasswordHash AS vchPasswordHash, @vbitEstado AS bitEstado,
			vchNombre, tinGenero, PAR.vchParamDescripcion AS vchGenero, intEdad, vchIdentificacion, vchDireccion, vchTelefono
			FROM dbo.Persona P
			INNER JOIN DBTransact.dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1000' AND PAR.tinParamValor = P.tinGenero
			WHERE intIdPersona = @peintIdPersona
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspClienteObtener TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspClienteListar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspClienteListar]
GO

CREATE PROCEDURE [dbo].[uspClienteListar]
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspClienteListar																
	Descripción			: Procedimiento para listar los clientes
	Fecha de Creación	: 01/11/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdCliente			INT					Identificador de cliente (Tabla DBPersona.dbo.Cliente)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspClienteListar
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON

	SELECT CLI.intIdCliente, CLI.intIdPersona, CLI.bitEstado, PER.vchNombre, PER.tinGenero, PAR.vchParamDescripcion AS vchGenero, PER.intEdad, PER.vchIdentificacion, 
	PER.vchDireccion, PER.vchTelefono	
	FROM dbo.Cliente CLI
	INNER JOIN dbo.Persona PER ON PER.intIdPersona = CLI.intIdPersona
	INNER JOIN DBTransact.dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1000' AND PAR.tinParamValor = PER.tinGenero
	
END
GO

GRANT EXECUTE ON dbo.uspClienteListar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspClientePasswordModificar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspClientePasswordModificar]
GO

CREATE PROCEDURE [dbo].[uspClientePasswordModificar]
	@peintIdCliente			INT,
	@pevchPasswordSalt		VARCHAR(400),
	@pevchPasswordHash		VARCHAR(400)
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspClientePasswordModificar																
	Descripción			: Procedimiento para modificar la contraseña (salt y hash) de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdCliente			INT					Codigo de cliente
	@pevchPasswordSalt		VARCHAR(400)		Valor Salt de la contraseña
	@pevchPasswordHash		VARCHAR(400)		Valor Hash de la contraseña
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspClientePasswordModificar 100,'PRUEBA MODIFICACION SALT','PRUEBA MODIFICACION HASH'
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		
		IF NOT EXISTS( SELECT 1 FROM dbo.Cliente WHERE intIdCliente = @peintIdCliente)
			THROW 51000, 'No existe cliente con el código ingresado', 1;		
		ELSE
		BEGIN
			UPDATE dbo.Cliente SET vchPasswordSalt = @pevchPasswordSalt, vchPasswordHash = @pevchPasswordHash
			WHERE intIdCliente = @peintIdCliente
		END
	END TRY
	BEGIN CATCH		
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspClientePasswordModificar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspClienteEstadoModificar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspClienteEstadoModificar]
GO

CREATE PROCEDURE [dbo].[uspClienteEstadoModificar]
	@peintIdCliente			INT,
	@pebitEstado			BIT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspClienteEstadoModificar																
	Descripción			: Procedimiento para cambiar estado (eliminación lógica o activación) de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBPersona
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdCliente			INT					Codigo de cliente
	@pebitEstado			BIT					1: Activar | 0: Eliminar (lógicamente)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBPersona.dbo.uspClienteEstadoModificar 101, 0
	SELECT * FROM DBPersona.dbo.Cliente
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		
		IF NOT EXISTS( SELECT 1 FROM dbo.Cliente WHERE intIdCliente = @peintIdCliente)
			THROW 51000, 'No existe cliente con el código ingresado', 1;		
		ELSE
		BEGIN
			UPDATE dbo.Cliente SET bitEstado = @pebitEstado
			WHERE intIdCliente = @peintIdCliente
		END
	END TRY
	BEGIN CATCH		
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspClienteEstadoModificar TO [public]
GO



USE DBTransact
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspCuentaInsertar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspCuentaInsertar]
GO

CREATE PROCEDURE [dbo].[uspCuentaInsertar]
	@peintIdCliente			INT,
	@petinTipoCuenta		TINYINT,
	@pemonSaldo				MONEY
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspCuentaInsertar																
	Descripción			: Procedimiento para insertar una cuenta de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@peintIdCliente			INT					Identificador de la tabla DBPersona.dbo.Cliente
	@petinTipoCuenta		TINYINT				Tipo de cuenta 1:Ahorros | 2:Corriente (Tabla DBTransact.dbo.ParametroSistema)
	@pemonSaldo				MONEY				Saldo de la cuenta
	@pedtmFecha				DATETIME			Fecha de registro
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspCuentaInsertar 100, 2, 1000
	SELECT * FROM DBPersona.dbo.Cliente
	SELECT * FROM DBTransact.dbo.Cuenta
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vintIdPersona	INT = 0
	DECLARE @vbitEstadoCliente BIT = 0

	BEGIN TRY
		
		SELECT @vintIdPersona = intIdPersona, @vbitEstadoCliente = bitEstado FROM DBPersona.dbo.Cliente WHERE intIdCliente = @peintIdCliente

		IF @vintIdPersona = 0
			THROW 51000, 'No existe un cliente con el código ingresado', 1;		
		ELSE
		BEGIN
			IF @vbitEstadoCliente = 0
				THROW 51000, 'Cliente no se encuentra activo', 1;
			ELSE
			BEGIN
				INSERT INTO dbo.Cuenta (intIdCliente, tinTipoCuenta, monSaldo, dtmFechaMod, bitEstado)
				VALUES (@peintIdCliente, @petinTipoCuenta, @pemonSaldo, GETDATE(), 1)

				SELECT CAST(SCOPE_IDENTITY() AS BIGINT) AS bigIdCuenta

			END			
		END
	END TRY
	BEGIN CATCH		
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspCuentaInsertar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspCuentaObtener]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspCuentaObtener]
GO

CREATE PROCEDURE [dbo].[uspCuentaObtener]
	@pebigIdCuenta	BIGINT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspCuentaObtener																
	Descripción			: Procedimiento para obtener datos de una cuenta
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdCuenta			BIGINT				Identificador de cuenta (Tabla DBTransact.dbo.Cuenta)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre					Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspCuentaObtener 100003
	SELECT * FROM DBTransact.dbo.Cuenta
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY

		IF NOT EXISTS(SELECT 1 FROM dbo.Cuenta WHERE bigIdCuenta = @pebigIdCuenta)
			THROW 51000, 'No existe una cuenta con el código ingresado', 1;
		ELSE
		BEGIN
			SELECT	CTA.bigIdCuenta, CTA.intIdCliente, CTA.tinTipoCuenta, PAR.vchParamDescripcion AS vchTipoCuenta, CTA.monSaldo,
					FORMAT(CTA.dtmFechaMod, 'dd/MM/yyyy HH:mm:ss') AS strFechaMod, CTA.bitEstado
			FROM dbo.Cuenta CTA
			INNER JOIN DBTransact.dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1001' AND PAR.tinParamValor = CTA.tinTipoCuenta
			WHERE CTA.bigIdCuenta = @pebigIdCuenta
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspCuentaObtener TO [public]
GO


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspCuentaListar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspCuentaListar]
GO

CREATE PROCEDURE [dbo].[uspCuentaListar]
	@peintIdCliente		INT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspCuentaListar																
	Descripción			: Procedimiento para listar las cuentas de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo		Descripción
	@peintIdPersona			INT			Código de Persona (DBPersona.dbo.Persona)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre					Tipo		Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspCuentaListar 108
	SELECT * FROM DBPersona.dbo.Cliente
	SELECT * FROM DBTransact.dbo.Cuenta
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		
		IF NOT EXISTS(SELECT 1 FROM DBPersona.dbo.Cliente WHERE intIdCliente = @peintIdCliente)
			THROW 51000, 'No existe un cliente con el código ingresado', 1;
		ELSE
		BEGIN
			SELECT	CTA.bigIdCuenta, CTA.intIdCliente, CTA.tinTipoCuenta, PAR.vchParamDescripcion AS vchTipoCuenta, CTA.monSaldo, 
					FORMAT(CTA.dtmFechaMod, 'dd/MM/yyyy HH:mm:ss') AS strFechaMod, CTA.bitEstado
			FROM dbo.Cuenta CTA
			INNER JOIN DBTransact.dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1001' AND PAR.tinParamValor = CTA.tinTipoCuenta
			WHERE CTA.intIdCliente = @peintIdCliente
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspCuentaListar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspCuentaEliminar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspCuentaEliminar]
GO

CREATE PROCEDURE [dbo].[uspCuentaEliminar]
	@pebigIdCuenta			BIGINT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspCuentaEliminar																
	Descripción			: Procedimiento para eliminar (lógica) una cuenta de un cliente
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdCuenta			BIGINT				Identificador de la tabla DBTransact.dbo.Cuenta
	@pedtmFecha				DATETIME			Fecha de eliminación
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspCuentaEliminar 100002
	SELECT * FROM DBTransact.dbo.Cuenta
	UPDATE dbo.Cuenta SET monSALDO = 0 WHERE bigIdCuenta = 100002  (EJECUTAR ESTO ANTES EN CASO DEVUELVA ERROR DE SALDO)
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vbigIdCuenta INT = 0
	DECLARE @vmonSaldoCuenta MONEY = 0
	
	BEGIN TRY
		
		SELECT @vbigIdCuenta = bigIdCuenta, @vmonSaldoCuenta = monSaldo FROM DBTransact.dbo.Cuenta WHERE bigIdCuenta = @pebigIdCuenta AND bitEstado = 1

		IF @vbigIdCuenta = 0
			THROW 51000, 'No existe una cuenta con el código ingresado', 1;		
		ELSE
		BEGIN
			--IF @vmonSaldoCuenta > 0.00
			--	THROW 51000, 'La cuenta no puede ser eliminada, aún posee saldo.', 1;
			--ELSE
			--BEGIN
				UPDATE dbo.Cuenta SET dtmFechaMod = GETDATE(), bitEstado = 0
				WHERE bigIdCuenta = @pebigIdCuenta
			--END			
		END
	END TRY
	BEGIN CATCH		
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspCuentaEliminar TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspMovimientoInsertar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspMovimientoInsertar]
GO

CREATE PROCEDURE [dbo].[uspMovimientoInsertar]
	@pebigIdCuenta			BIGINT,
	@pedtmFecha				DATETIME,
	@petinTipoMovimiento	TINYINT,
	@pemonValor				MONEY,
	@pemonSaldoInicial		MONEY
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspMovimientoInsertar																
	Descripción			: Procedimiento para insertar un movimiento de una cuenta de cliente
	Fecha de Creación	: 30/10/2023
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdCuenta			BIGINT				Identificador de la tabla DBTransact.dbo.Cuenta
	@pedtmFecha				DATETIME			Fecha en la que se realiza la transacción
	@petinTipoMovimiento	TINYINT				Tipo de Movimiento 1:Deposito | 2:Retiro (Tabla DBTransact.dbo.ParametroSistema)
	@pemonValor				MONEY				Monto|Importe|Valor del movimiento (+Deposito y -Retiro)
	@pemonSaldoInicial		MONEY				Saldo de la cuenta antes de la transacción
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspMovimientoInsertar 100002, '20231029 02:55:45', 1, 450, 4800
	SELECT * FROM DBTransact.dbo.Cuenta
	SELECT * FROM DBTransact.dbo.Movimiento
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vbigIdCuenta		INT = 0
	DECLARE @vbitTransaction	BIT = 0
	DECLARE @vmonSaldoFinal		MONEY = 0
	DECLARE @vbigIdMovimiento	BIGINT = 0
	BEGIN TRY

		SELECT @vbigIdCuenta = bigIdCuenta, @pemonSaldoInicial = monSaldo FROM DBTransact.dbo.Cuenta WHERE bigIdCuenta = @pebigIdCuenta AND bitEstado = 1

		IF @vbigIdCuenta = 0
			THROW 51000, 'No existe o no esta activa la cuenta con el código ingresado', 1;		
		ELSE
		BEGIN

			SET @vmonSaldoFinal = @pemonSaldoInicial + @pemonValor

			IF (@vmonSaldoFinal) < 0.00
				THROW 51000, 'Saldo no Disponible', 1;
			ELSE
			BEGIN
				
				SET @petinTipoMovimiento = IIF(@pemonValor > 0.00, 1, 2) -- UNICAMENTE PORQUE EL TIPO ES DETERMINADO POR EL SIGNO DEL IMPORTE

				BEGIN TRANSACTION trx_MovimientoInsertar
				SET @vbitTransaction = 1

				INSERT INTO dbo.Movimiento(bigIdCuenta, dtmFecha, tinTipoMovimiento, monSaldoInicial, monValor, monSaldoMovimiento, bitEstado)
				VALUES (@pebigIdCuenta,	@pedtmFecha, @petinTipoMovimiento, @pemonSaldoInicial, @pemonValor,	@vmonSaldoFinal, 1)

				SET @vbigIdMovimiento = CAST(SCOPE_IDENTITY() AS BIGINT)

				UPDATE dbo.Cuenta SET monSaldo = @vmonSaldoFinal, dtmFechaMod = @pedtmFecha WHERE bigIdCuenta = @pebigIdCuenta

				COMMIT TRANSACTION trx_MovimientoInsertar

				SELECT @vbigIdMovimiento AS bigIdMovimiento
			END			
		END
	END TRY
	BEGIN CATCH
		IF @vbitTransaction = 1 ROLLBACK TRANSACTION trx_MovimientoInsertar;
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspMovimientoInsertar TO [public]
GO


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspMovimientoObtener]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspMovimientoObtener]
GO

CREATE PROCEDURE [dbo].[uspMovimientoObtener]
	@pebigIdMovimiento	BIGINT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspMovimientoObtener															
	Descripción			: Procedimiento para obtener datos de un movimiento a traves de su ID
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdMovimiento		BIGINT				Identificador del Movimiento (Tabla DBTransact.dbo.Movimiento)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre					Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspMovimientoObtener 8
	SELECT * FROM DBTransact.dbo.Movimiento
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY

		IF NOT EXISTS(SELECT 1 FROM dbo.Movimiento WHERE bigIdMovimiento = @pebigIdMovimiento)
			THROW 51000, 'No existe un movimiento código ingresado', 1;
		ELSE
		BEGIN
			SELECT	MOV.bigIdMovimiento, MOV.bigIdCuenta, FORMAT(MOV.dtmFecha, 'dd/MM/yyyy HH:mm:ss') AS strFecha, MOV.tinTipoMovimiento, 
					PAR.vchParamDescripcion AS vchTipoMovimiento, MOV.monSaldoInicial, MOV.monValor, MOV.monSaldoMovimiento, MOV.bitEstado 
			FROM dbo.Movimiento MOV
			INNER JOIN DBTransact.dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1002' AND PAR.tinParamValor = MOV.tinTipoMovimiento
			WHERE MOV.bigIdMovimiento = @pebigIdMovimiento
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspMovimientoObtener TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspMovimientoListarxCuenta]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspMovimientoListarxCuenta]
GO

CREATE PROCEDURE [dbo].[uspMovimientoListarxCuenta]
	@pebigIdCuenta	BIGINT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspMovimientoListarxCuenta																
	Descripción			: Procedimiento para listar los movimientos de una cuenta
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdCuenta			BIGINT				Identificador de la cuenta (Tabla DBTransact.dbo.Cuenta)
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre					Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspMovimientoListarxCuenta 100002
	SELECT * FROM DBTransact.dbo.Movimiento
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY

		IF NOT EXISTS(SELECT 1 FROM dbo.Movimiento WHERE bigIdCuenta = @pebigIdCuenta)
			THROW 51000, 'No existen movimientos asociados a la cuenta', 1;
		ELSE
		BEGIN
			SELECT	MOV.bigIdMovimiento, MOV.bigIdCuenta, FORMAT(MOV.dtmFecha, 'dd/MM/yyyy HH:mm:ss') AS strFecha, MOV.tinTipoMovimiento, 
					PAR.vchParamDescripcion AS vchTipoMovimiento, MOV.monSaldoInicial, MOV.monValor, MOV.monSaldoMovimiento, MOV.bitEstado 
			FROM dbo.Movimiento MOV
			INNER JOIN dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1002' AND PAR.tinParamValor = MOV.tinTipoMovimiento
			WHERE MOV.bigIdCuenta = @pebigIdCuenta
			ORDER BY MOV.dtmFecha ASC
		END
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspMovimientoListarxCuenta TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspMovimientoListarxCuentaFecha]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspMovimientoListarxCuentaFecha]
GO

CREATE PROCEDURE [dbo].[uspMovimientoListarxCuentaFecha]
	@pebigIdCuenta		BIGINT,
	@pedtmFechaInicio	DATE,
	@pedtmFechaFin		DATE
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspMovimientoListarxCuentaFecha																
	Descripción			: Procedimiento para listar los movimientos de una cuenta en un rango de fecha especifico
	Fecha de Creación	: 30/10/2023								
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdCuenta			BIGINT				Identificador de la cuenta (Tabla DBTransact.dbo.Cuenta)
	@pedtmFechaInicio		DATETIME			Fecha de inicio de movimientos a mostrar
	@pedtmFechaFin			DATETIME			Fecha de fin de movimientos a mostrar
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre					Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspMovimientoListarxCuentaFecha 100000, '20231031 10:45:21', '20231031 01:01:10'
	SELECT * FROM DBTransact.dbo.Movimiento
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY
		SET @pedtmFechaFin = DATEADD(DAY,1,@pedtmFechaFin)
		
		SELECT	MOV.bigIdMovimiento, MOV.bigIdCuenta, FORMAT(MOV.dtmFecha, 'dd/MM/yyyy HH:mm:ss') AS strFecha, MOV.tinTipoMovimiento, 
				PAR.vchParamDescripcion AS vchTipoMovimiento, MOV.monSaldoInicial, MOV.monValor, MOV.monSaldoMovimiento, MOV.bitEstado 
		FROM dbo.Movimiento MOV
		INNER JOIN dbo.ParametroSistema PAR ON PAR.vchParamCodigo = '1002' AND PAR.tinParamValor = MOV.tinTipoMovimiento
		WHERE MOV.bigIdCuenta = @pebigIdCuenta AND MOV.dtmFecha >= @pedtmFechaInicio AND MOV.dtmFecha < @pedtmFechaFin
		ORDER BY MOV.dtmFecha ASC
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspMovimientoListarxCuentaFecha TO [public]
GO



IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[uspMovimientoEliminar]') AND Type IN (N'P', N'PC'))
	DROP PROCEDURE  [dbo].[uspMovimientoEliminar]
GO

CREATE PROCEDURE [dbo].[uspMovimientoEliminar]
	@pebigIdMovimiento		BIGINT
AS
/*	------------------------------------------------------------------------------------------------------
	Sistema				: TechnicalTest Devsu																		
	Objeto				: uspMovimientoEliminar																
	Descripción			: Procedimiento para eliminar (extornar) un movimiento de una cuenta de cliente, 
						  se devolvera el saldo a la cuenta.
	Fecha de Creación	: 30/10/2023
	Autor				: Erwin Joao Sanchez Aranda (EJSA)
	Base de Datos		: DBTransact
	------------------------------------------------------------------------------------------------------
	Parámetros de Entrada																				
	Nombre					Tipo				Descripción
	@pebigIdMovimiento		BIGINT				Identificador de la tabla DBTransact.dbo.Movimiento
	------------------------------------------------------------------------------------------------------
	Parámetros de Salida																				
	Nombre						Tipo				Descripción
	-----------------------------------------------------------------------------------------------------
	EXEC DBTransact.dbo.uspMovimientoEliminar 9
	SELECT * FROM DBTransact.dbo.Cuenta
	SELECT * FROM DBTransact.dbo.Movimiento
	-----------------------------------------------------------------------------------------------------*/
BEGIN

	SET NOCOUNT ON
	
	DECLARE @vbigIdCuenta		  INT = 0
	DECLARE @vmonSaldo			  MONEY = 0
	DECLARE @vmonMontoTransaccion MONEY = 0
	DECLARE @vbitTransaction	  BIT = 0

	BEGIN TRY
		
		SELECT @vbigIdCuenta = bigIdCuenta, @vmonMontoTransaccion = monValor 
		FROM dbo.Movimiento 
		WHERE bigIdMovimiento = @pebigIdMovimiento AND bitEstado = 1

		SELECT @vmonSaldo = monSaldo FROM dbo.Cuenta WHERE bigIdCuenta = @vbigIdCuenta

		IF @vbigIdCuenta = 0
			THROW 51000, 'El movimiento ingresado no existe o ya esta extornado (eliminado)', 1;		
		ELSE
		BEGIN
			IF (@vmonSaldo + @vmonMontoTransaccion*(-1)) < 0.00
				THROW 51000, 'La cuenta no tiene suficiente saldo para revertir esta operación', 1;
			ELSE
			BEGIN
				BEGIN TRANSACTION trx_MovimientoEliminar
				SET @vbitTransaction = 1

				UPDATE dbo.Movimiento SET bitEstado = 0 WHERE bigIdMovimiento = @pebigIdMovimiento

				UPDATE dbo.Cuenta SET monSaldo = monSaldo + @vmonMontoTransaccion*(-1), dtmFechaMod = GETDATE()
				WHERE bigIdCuenta = @vbigIdCuenta

				COMMIT TRANSACTION trx_MovimientoEliminar
			END
		END
	END TRY
	BEGIN CATCH
		IF @vbitTransaction = 1 ROLLBACK TRANSACTION trx_MovimientoEliminar;
		THROW;
	END CATCH
END
GO

GRANT EXECUTE ON dbo.uspMovimientoEliminar TO [public]
GO
