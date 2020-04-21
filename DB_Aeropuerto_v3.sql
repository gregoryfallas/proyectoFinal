USE [master]

GO

CREATE DATABASE [DB_AEROPUERTO]


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [DB_AEROPUERTO]

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Estados]
		(
			[IdEstado] [char] (1) NOT NULL,			
			[Descripcion] [varchar](25) NOT NULL,
	
			CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
			(
				[IdEstado] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Estados]
		ADD CONSTRAINT UC_Descripcion_Est UNIQUE ([Descripcion])


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Paises]
		(
			[IdPais] [int] IDENTITY(1,1) NOT NULL,	
			[NombrePais] [varchar](85) NOT NULL,
			[CodigoISOPais] [char](4) NOT NULL,
			[CodigoAreaPais] [char](5) NOT NULL,			
			[IdEstado] [char] (1) NOT NULL,
	
			CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
			(
				[IdPais] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Paises]
		ADD CONSTRAINT UC_NombrePais UNIQUE ([NombrePais])

GO

		ALTER TABLE [dbo].[T_Paises]  WITH NOCHECK ADD  CONSTRAINT FK_Paises_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)


GO

		ALTER TABLE [dbo].[T_Paises] CHECK CONSTRAINT FK_Paises_Estados

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_CategoriasVuelos]
		(
			[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
			[DescCategoria] [varchar](90) NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_CategoriasVuelos] PRIMARY KEY CLUSTERED 
			(
				[IdCategoria] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_CategoriasVuelos]
		ADD CONSTRAINT UC_DescCategoria UNIQUE ([DescCategoria])


GO

		ALTER TABLE [dbo].[T_CategoriasVuelos]  WITH NOCHECK ADD  CONSTRAINT FK_CategoriasVuelos_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)


GO

		ALTER TABLE [dbo].[T_CategoriasVuelos] CHECK CONSTRAINT FK_CategoriasVuelos_Estados

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Aerolineas]
		(
			[IdAerolinea] [int] IDENTITY(1,1) NOT NULL,
			[NombreAerolinea] [varchar](90) NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_Aerolineas] PRIMARY KEY CLUSTERED 
			(
				[IdAerolinea] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Aerolineas]
		ADD CONSTRAINT UC_NombreAerolinea UNIQUE ([NombreAerolinea])


GO

		ALTER TABLE [dbo].[T_Aerolineas]  WITH NOCHECK ADD  CONSTRAINT FK_Aerolineas_Estados FOREIGN KEY([IdEstado])
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Aerolineas] CHECK CONSTRAINT FK_Aerolineas_Estados

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_TiposEmpleados]
		(
			[IdTipoEmpleado] [int] IDENTITY(1,1) NOT NULL,
			[DescTipo] [varchar](150) NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_IdTiposEmpleados] PRIMARY KEY CLUSTERED 
			(
				[IdTipoEmpleado] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_TiposEmpleados]
		ADD CONSTRAINT UC_Tipo_Emp UNIQUE ([DescTipo])


GO

		ALTER TABLE [dbo].[T_TiposEmpleados]  WITH NOCHECK ADD  CONSTRAINT FK_TiposEmpleados_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_TiposEmpleados] CHECK CONSTRAINT FK_TiposEmpleados_Estados


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

		CREATE TABLE [dbo].[T_Empleados]
		(
			[IdEmpleado] [varchar](7) NOT NULL,
			[Cedula] [varchar](11) NOT NULL,
			[Nombre] [varchar](25) NOT NULL,
			[Apellidos] [varchar](150) NOT NULL,			
			[Direccion] [varchar](150) NOT NULL,
			[Edad] [int] NOT NULL,
			[Telefono_Casa] [varchar](9) NOT NULL,			
			[Telefono_Referencia] [varchar](9) NOT NULL,			
			[Celular] [varchar](9) NOT NULL,			
			[Salario] [decimal](18,2) NOT NULL,
			[IdTipoEmpleado] [int] NOT NULL,
			[IdAerolinea] [int] NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_IdEmpledo] PRIMARY KEY CLUSTERED 
			(
				[IdEmpleado] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Empleados]
		ADD CONSTRAINT UC_Empleado UNIQUE ([Cedula])


GO

		ALTER TABLE [dbo].[T_Empleados]  WITH NOCHECK ADD  CONSTRAINT FK_Empleados_TiposEmpleados FOREIGN KEY([IdTipoEmpleado])
		REFERENCES [dbo].[T_TiposEmpleados] ([IdTipoEmpleado])

GO

		ALTER TABLE [dbo].[T_Empleados] CHECK CONSTRAINT FK_Empleados_TiposEmpleados

GO

		ALTER TABLE [dbo].[T_Empleados]  WITH NOCHECK ADD  CONSTRAINT FK_Empleados_Aerolineas FOREIGN KEY([IdAerolinea])
		REFERENCES [dbo].[T_Aerolineas] ([IdAerolinea])

GO

		ALTER TABLE [dbo].[T_Empleados] CHECK CONSTRAINT FK_Empleados_Aerolineas

GO

		ALTER TABLE [dbo].[T_Empleados]  WITH NOCHECK ADD  CONSTRAINT FK_Empleados_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Empleados] CHECK CONSTRAINT FK_Empleados_Estados

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_TiposClientes]
		(
			[IdTipoCliente] [int] IDENTITY(1,1) NOT NULL,
			[TipoCliente] [varchar](50) NOT NULL,
			[Descripcion] [varchar](150) NOT NULL,
			[IdEstado] [char] (1) NOT NULL,
			CONSTRAINT [PK_TiposClientes] PRIMARY KEY CLUSTERED 
			(
				[IdTipoCliente] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_TiposClientes]
		ADD CONSTRAINT UC_Tipo_Client UNIQUE ([TipoCliente])


GO

		ALTER TABLE [dbo].[T_TiposClientes]  WITH NOCHECK ADD  CONSTRAINT FK_TiposClientes_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_TiposClientes] CHECK CONSTRAINT FK_TiposClientes_Estados


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Clientes]
		(
			[IdCliente] [varchar](7) NOT NULL,
			[Cedula] [varchar](11) NOT NULL,
			[Nombre] [varchar](25) NOT NULL,
			[Apellidos] [varchar](150) NOT NULL,						
			[Telefono] [varchar](9) NOT NULL,	
			[IdTipoCliente] [int] NOT NULL,
			[IdEstado] [char] (1) NOT NULL,
	
			CONSTRAINT [PK_IdCliente] PRIMARY KEY CLUSTERED 
			(
				[IdCliente] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Clientes]
		ADD CONSTRAINT UC_Cliente UNIQUE ([Cedula])


GO

		ALTER TABLE [dbo].[T_Clientes]  WITH NOCHECK ADD  CONSTRAINT FK_Clientes_TiposClientes FOREIGN KEY([IdTipoCliente])
		REFERENCES [dbo].[T_TiposClientes] ([IdTipoCliente])

GO

		ALTER TABLE [dbo].[T_Clientes] CHECK CONSTRAINT FK_Clientes_TiposClientes

GO

		ALTER TABLE [dbo].[T_Clientes]  WITH NOCHECK ADD  CONSTRAINT FK_Clientes_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Clientes] CHECK CONSTRAINT FK_Clientes_Estados


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_TiposAviones]
		(
			[IdTipoAvion] [varchar](7) NOT NULL,
			[NombreTipoAvion] [varchar](90) NOT NULL,
			[DescTipoAvion] [varchar](90) NOT NULL,
			[CapacidadPasajeros] [int] NOT NULL,
			[CapacidadPeso] [decimal](18,2) NOT NULL,		
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_TiposAviones] PRIMARY KEY CLUSTERED 
			(
				[IdTipoAvion] ASC
			)
		) ON [PRIMARY]
		
GO

		ALTER TABLE [dbo].[T_TiposAviones]
		ADD CONSTRAINT UC_NombreTipoAvion UNIQUE ([NombreTipoAvion])

GO

		ALTER TABLE [dbo].[T_TiposAviones] WITH NOCHECK ADD  CONSTRAINT FK_TiposAviones_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_TiposAviones] CHECK CONSTRAINT FK_TiposAviones_Estados



-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Aviones]
		(
			[IdAvion] [varchar](7) NOT NULL,
			[NomAvion] [varchar](57) NOT NULL,
			[DescAvion] [varchar](120) NOT NULL,
			[IdAerolinea] [int] NOT NULL,	
			[IdTipoAvion] [varchar](7) NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_Aviones] PRIMARY KEY CLUSTERED 
			(
				[IdAvion] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Aviones]
		ADD CONSTRAINT UC_NomAvion UNIQUE ([NomAvion])


GO

		ALTER TABLE [dbo].[T_Aviones]  WITH NOCHECK ADD  CONSTRAINT FK_Aviones_Aerolineas FOREIGN KEY([IdAerolinea])
		REFERENCES [dbo].[T_Aerolineas] ([IdAerolinea])

GO

		ALTER TABLE [dbo].[T_Aviones] CHECK CONSTRAINT FK_Aviones_Aerolineas

GO

		ALTER TABLE [dbo].[T_Aviones]  WITH NOCHECK ADD  CONSTRAINT FK_Aviones_TiposAviones FOREIGN KEY([IdTipoAvion])
		REFERENCES [dbo].[T_TiposAviones] ([IdTipoAvion])

GO

		ALTER TABLE [dbo].[T_Aviones] CHECK CONSTRAINT FK_Aviones_TiposAviones

GO

		ALTER TABLE [dbo].[T_Aviones] WITH NOCHECK ADD  CONSTRAINT FK_Aviones_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Aviones] CHECK CONSTRAINT FK_Aviones_Estados


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Destinos]
		(
			[IdDestino] [varchar](5) NOT NULL,
			[IdAerolinea] [int] NOT NULL,
			[NomDestino] [varchar](57) NOT NULL,
			[PaisSalida] [int] NOT NULL,
			[PaisLlegada] [int] NOT NULL,							
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_Destinos] PRIMARY KEY CLUSTERED 
			(
				[IdDestino] ASC, [IdAerolinea] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Destinos]
		ADD CONSTRAINT UC_NomDestino UNIQUE ([NomDestino])


GO

		ALTER TABLE [dbo].[T_Destinos]  WITH NOCHECK ADD  CONSTRAINT FK_Destinos_Aerolineas FOREIGN KEY([IdAerolinea])
		REFERENCES [dbo].[T_Aerolineas] ([IdAerolinea])

GO

		ALTER TABLE [dbo].[T_Destinos] CHECK CONSTRAINT FK_Destinos_Aerolineas

GO

		ALTER TABLE [dbo].[T_Destinos]  WITH NOCHECK ADD  CONSTRAINT FK_Destinos_PaisSalida FOREIGN KEY([PaisSalida])
		REFERENCES [dbo].[T_Paises] ([IdPais])

GO

		ALTER TABLE [dbo].[T_Destinos] CHECK CONSTRAINT FK_Destinos_PaisSalida

GO

		ALTER TABLE [dbo].[T_Destinos]  WITH NOCHECK ADD  CONSTRAINT FK_Destinos_PaisLlegada FOREIGN KEY([PaisLlegada])
		REFERENCES [dbo].[T_Paises] ([IdPais])

GO

		ALTER TABLE [dbo].[T_Destinos] CHECK CONSTRAINT FK_Destinos_PaisSalida

GO

		ALTER TABLE [dbo].[T_Destinos] WITH NOCHECK ADD  CONSTRAINT FK_Destinos_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Destinos] CHECK CONSTRAINT FK_Destinos_Estados

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		CREATE TABLE [dbo].[T_Vuelos]
		(
			[IdVuelo] [varchar](5) NOT NULL,
			[IdDestino] [varchar](5) NOT NULL,
			[IdAerolinea] [int] NOT NULL,
			[IdAvion] [varchar](7) NOT NULL,
			[FechaHoraSalida] [datetime] NOT NULL,				
			[FechaHoraLlegada] [datetime] NOT NULL,
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_Vuelos] PRIMARY KEY CLUSTERED 
			(
				[IdVuelo] ASC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Vuelos]  WITH NOCHECK ADD  CONSTRAINT FK_VuelosDestinos FOREIGN KEY([IdDestino], [IdAerolinea])
		REFERENCES [dbo].[T_Destinos] ([IdDestino], [IdAerolinea])

GO

		ALTER TABLE [dbo].[T_Vuelos] CHECK CONSTRAINT FK_VuelosDestinos

GO

		ALTER TABLE [dbo].[T_Vuelos]  WITH NOCHECK ADD  CONSTRAINT FK_VuelosAviones FOREIGN KEY([IdAvion])
		REFERENCES [dbo].[T_Aviones] ([IdAvion])

GO

		ALTER TABLE [dbo].[T_Vuelos] CHECK CONSTRAINT FK_VuelosAviones

GO

		ALTER TABLE [dbo].[T_Vuelos] WITH NOCHECK ADD  CONSTRAINT FK_Vuelos_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Vuelos] CHECK CONSTRAINT FK_Vuelos_Estados

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

		CREATE TABLE [dbo].[T_Usuarios]
		(			
			[Username] [varchar](15) NOT NULL,
			[Password] [varchar](8) NOT NULL,
			[IdEmpleado] [varchar](7) NOT NULL,					
			[IdEstado] [char] (1) NOT NULL,

			CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
			(				
				[Username] DESC
			)
		) ON [PRIMARY]

GO

		ALTER TABLE [dbo].[T_Usuarios]
		ADD CONSTRAINT UC_Username UNIQUE ([Username])


GO

		ALTER TABLE [dbo].[T_Usuarios]  WITH NOCHECK ADD  CONSTRAINT FK_Usuarios_Empleados FOREIGN KEY([IdEmpleado])
		REFERENCES [dbo].[T_Empleados] ([IdEmpleado])

GO

		ALTER TABLE [dbo].[T_Usuarios] CHECK CONSTRAINT FK_Usuarios_Empleados

GO		

		ALTER TABLE [dbo].[T_Usuarios]  WITH NOCHECK ADD  CONSTRAINT FK_Usuarios_Estados FOREIGN KEY(IdEstado)
		REFERENCES [dbo].[T_Estados] (IdEstado)

GO

		ALTER TABLE [dbo].[T_Usuarios] CHECK CONSTRAINT FK_Usuarios_Estados


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO


--STORED PROCEDURES

-- LISTAR

CREATE PROCEDURE [dbo].[SP_Listar_Aerolineas]
AS
	BEGIN
		SELECT [IdAerolinea],
			[NombreAerolinea],
			[IdEstado]
		FROM [dbo].[T_Aerolineas]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Aviones]
AS
	BEGIN
		SELECT [IdAvion],
			[NomAvion],
			[DescAvion],
			[IdAerolinea],
			[IdTipoAvion],
			[IdEstado]
		FROM [dbo].[T_Aviones]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_CategoriasVuelos]
AS
	BEGIN
		SELECT [IdCategoria],
			[DescCategoria],
			[IdEstado]
		FROM [dbo].[T_CategoriasVuelos]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Clientes]
AS
	BEGIN
		SELECT [IdCliente],
			[Cedula],
			[Nombre],
			[Apellidos],
			[Telefono],
			[IdTipoCliente],
			[IdEstado]
		FROM [dbo].[T_Clientes]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Destinos]
AS
	BEGIN
		SELECT [IdDestino],
			[IdAerolinea],
			[NomDestino],
			[PaisSalida],
			[PaisLlegada],
			[IdEstado]
		FROM [dbo].[T_Destinos]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Empleados]
AS
	BEGIN
		SELECT [IdEmpleado],
			[Cedula], 
			[Nombre], 
			[Apellidos], 
			[Direccion], 
			[Edad], 
			[Telefono_Casa], 
			[Telefono_Referencia], 
			[Celular], 
			[Salario], 
			[IdTipoEmpleado], 
			[IdAerolinea], 
			[IdEstado]
		FROM [dbo].[T_Empleados]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Estados]
AS
	BEGIN
		SELECT [IdEstado],
			[Descripcion]
		FROM [dbo].[T_Estados]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Paises]
AS
	BEGIN
		SELECT [IdPais], 
			[NombrePais], 
			[CodigoISOPais], 
			[CodigoAreaPais], 
			[IdEstado]
		FROM [dbo].[T_Paises]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_TiposAviones]
AS
	BEGIN
		SELECT [IdTipoAvion], 
			[NombreTipoAvion], 
			[DescTipoAvion], 
			[CapacidadPasajeros], 
			[CapacidadPeso], 
			[IdEstado]
		FROM [dbo].[T_TiposAviones]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_TiposClientes]
AS
	BEGIN
		SELECT [IdTipoCliente], 
			[TipoCliente], 
			[Descripcion], 
			[IdEstado]
		FROM [dbo].[T_TiposClientes]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_TiposEmpleados]
AS
	BEGIN
		SELECT [IdTipoEmpleado], 
			[DescTipo], 
			[IdEstado]
		FROM [dbo].[T_TiposEmpleados]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Usuarios]
AS
	BEGIN
		SELECT [Username], 
			[Password], 
			[IdEmpleado], 
			[IdEstado]
		FROM [dbo].[T_Usuarios]
	END
GO

CREATE PROCEDURE [dbo].[SP_Listar_Vuelos]
AS
	BEGIN
		SELECT [IdVuelo], 
			[IdDestino], 
			[IdAerolinea], 
			[IdAvion], 
			[FechaHoraSalida], 
			[FechaHoraLlegada], 
			[IdEstado]
		FROM [dbo].[T_Vuelos]
	END
GO

-- FILTRAR

CREATE PROCEDURE [dbo].[SP_Filtrar_Aerolineas]
(
	@filtro VARCHAR(90)
)
AS
	BEGIN
	SELECT [IdAerolinea],
		[NombreAerolinea],
		[IdEstado]
	FROM [dbo].[T_Aerolineas]
	WHERE UPPER([NombreAerolinea]) LIKE UPPER('%' + @filtro + '%') 
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Aviones]
(
	@filtro VARCHAR(120)
)
AS
	BEGIN
		SELECT [IdAvion],
			[NomAvion],
			[DescAvion],
			[IdAerolinea],
			[IdTipoAvion],
			[IdEstado]
		FROM [dbo].[T_Aviones]
		WHERE UPPER([NomAvion]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_CategoriasVuelos]
(
	@filtro VARCHAR(90)
)
AS
	BEGIN
		SELECT [IdCategoria],
			[DescCategoria],
			[IdEstado]
		FROM [dbo].[T_CategoriasVuelos]
		WHERE UPPER([DescCategoria]) LIKE UPPER('%' + @filtro + '%')
	END
GO
	
CREATE PROCEDURE [dbo].[SP_Filtrar_Clientes]
(
	@filtro VARCHAR(11)
)
AS
	BEGIN
		SELECT [IdCliente],
			[Cedula],
			[Nombre],
			[Apellidos],
			[Telefono],
			[IdTipoCliente],
			[IdEstado]
		FROM [dbo].[T_Clientes]
		WHERE UPPER([Cedula]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Destinos]
(
	@filtro VARCHAR(57)
)
AS
	BEGIN
		SELECT [IdDestino],
			[IdAerolinea],
			[NomDestino],
			[PaisSalida],
			[PaisLlegada],
			[IdEstado]
		FROM [dbo].[T_Destinos]
		WHERE UPPER([NomDestino]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Empleados]
(
	@filtro VARCHAR(11)
)
AS
	BEGIN
		SELECT [IdEmpleado],
			[Cedula], 
			[Nombre], 
			[Apellidos], 
			[Direccion], 
			[Edad], 
			[Telefono_Casa], 
			[Telefono_Referencia], 
			[Celular], 
			[Salario], 
			[IdTipoEmpleado], 
			[IdAerolinea], 
			[IdEstado]
		FROM [dbo].[T_Empleados]
		WHERE UPPER([Cedula]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Estados]
(
	@filtro VARCHAR(25)
)
AS
	BEGIN
		SELECT [IdEstado],
			[Descripcion]
		FROM [dbo].[T_Estados]
		WHERE UPPER([IdEstado]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Paises]
(
	@filtro VARCHAR(85)
)
AS
	BEGIN
		SELECT [IdPais], 
			[NombrePais], 
			[CodigoISOPais], 
			[CodigoAreaPais], 
			[IdEstado]
		FROM [dbo].[T_Paises]
		WHERE UPPER([NombrePais]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_TiposAviones]
(
	@filtro VARCHAR(90)
)
AS
	BEGIN
		SELECT [IdTipoAvion], 
			[NombreTipoAvion], 
			[DescTipoAvion], 
			[CapacidadPasajeros], 
			[CapacidadPeso], 
			[IdEstado]
		FROM [dbo].[T_TiposAviones]
		WHERE UPPER([NombreTipoAvion]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_TiposClientes]
(
	@filtro VARCHAR(50)
)
AS
	BEGIN
		SELECT [IdTipoCliente], 
			[TipoCliente], 
			[Descripcion], 
			[IdEstado]
		FROM [dbo].[T_TiposClientes]
		WHERE UPPER([IdTipoCliente]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_TiposEmpleados]
(
	@filtro VARCHAR(150)
)
AS
	BEGIN
		SELECT [IdTipoEmpleado], 
			[DescTipo], 
			[IdEstado]
		FROM [dbo].[T_TiposEmpleados]
		WHERE UPPER([DescTipo]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Usuarios]
(
	@filtro VARCHAR(15)
)
AS
	BEGIN
		SELECT [Username], 
			[Password], 
			[IdEmpleado], 
			[IdEstado]
		FROM [dbo].[T_Usuarios]
		WHERE UPPER([Username]) LIKE UPPER('%' + @filtro + '%')
	END
GO

CREATE PROCEDURE [dbo].[SP_Filtrar_Vuelos]
(
	@filtro VARCHAR(5)
)
AS
	BEGIN
		SELECT [IdVuelo], 
			[IdDestino], 
			[IdAerolinea], 
			[IdAvion], 
			[FechaHoraSalida], 
			[FechaHoraLlegada], 
			[IdEstado]
		FROM [dbo].[T_Vuelos]
		WHERE UPPER([IdVuelo]) LIKE UPPER('%' + @filtro + '%')
	END
GO

-- BORRAR

CREATE PROCEDURE [dbo].[SP_Borrar_Aerolineas]
(
	@IdAerolinea INT
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Aerolineas]
		WHERE [IdAerolinea] =  @IdAerolinea
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Aviones]
(
	@IdAvion VARCHAR(7)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Aviones]
		WHERE [IdAvion] = @IdAvion
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_CategoriasVuelos]
(
	@IdCategoria INT
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_CategoriasVuelos]
		WHERE [IdCategoria] = @IdCategoria
	END
GO
	
CREATE PROCEDURE [dbo].[SP_Borrar_Clientes]
(
	@IdCliente VARCHAR(7)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Clientes]
		WHERE [IdCliente] = @IdCliente
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Destinos]
(
	@IdDestino VARCHAR(5)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Destinos]
		WHERE [IdDestino] = @IdDestino
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Empleados]
(
	@IdEmpleado VARCHAR(7)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Empleados]
		WHERE [IdEmpleado] = @IdEmpleado
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Estados]
(
	@IdEstado CHAR(1)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Estados]
		WHERE [IdEstado] = @IdEstado
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Paises]
(
	@IdPais INT
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Paises]
		WHERE [IdPais] = @IdPais
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_TiposAviones]
(
	@IdtipoAvion VARCHAR(7)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_TiposAviones]
		WHERE [IdTipoAvion] = @IdtipoAvion
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_TiposClientes]
(
	@IdTipoCliente INT
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_TiposClientes]
		WHERE [IdTipoCliente] = @IdTipoCliente
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_TiposEmpleados]
(
	@IdTipoEmpleado INT
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_TiposEmpleados]
		WHERE [IdTipoEmpleado] = @IdTipoEmpleado
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Usuarios]
(
	@Username VARCHAR(15)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Usuarios]
		WHERE [Username] = @Username
	END
GO

CREATE PROCEDURE [dbo].[SP_Borrar_Vuelos]
(
	@IdVuelo VARCHAR(5)
)
AS
	BEGIN
		DELETE
		FROM [dbo].[T_Vuelos]
		WHERE [IdVuelo] = @IdVuelo
	END
GO

-- INSERTAR

CREATE PROCEDURE [dbo].[SP_Insertar_Aerolineas]
(
	@NombreAerolinea VARCHAR(90),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Aerolineas]
		(
			[NombreAerolinea],
			[IdEstado]
		)
		VALUES
		(
			@NombreAerolinea, @IdEstado
		);
		SELECT MAX ([IdAerolinea])
		FROM [dbo].[T_Aerolineas]
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Aviones]
(
	@IdAvion VARCHAR(7),
	@NomAvion VARCHAR(57),
	@DescAvion VARCHAR(120),
	@IdAerolinea INT,
	@IdTipoAvion VARCHAR(7),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Aviones]
		(
			[IdAvion],
			[NomAvion],
			[DescAvion],
			[IdAerolinea],
			[IdTipoAvion],
			[IdEstado]
		)
		VALUES
		(
			@IdAvion, @NomAvion, @DescAvion, @IdAerolinea, @IdTipoAvion, @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_CategoriasVuelos]
(
	@DescCategoria VARCHAR(90),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_CategoriasVuelos]
		(
			[DescCategoria],
			[IdEstado]
		)
		VALUES
		(
			@DescCategoria, @IdEstado
		);
		SELECT MAX ([IdCategoria])
		FROM [dbo].[T_CategoriasVuelos]
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Clientes]
(
	@IdCliente VARCHAR(7),
	@Cedula VARCHAR(11),
	@Nombre VARCHAR(25),
	@Apellidos VARCHAR(150),
	@Telefono VARCHAR(9),
	@IdTipoCliente INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Clientes]
		(
			[IdCliente],
			[Cedula],
			[Nombre],
			[Apellidos],
			[Telefono],
			[IdTipoCliente],
			[IdEstado]
		)
		VALUES
		(
			@IdCliente, @Cedula, @Nombre, @Apellidos, @Telefono, @IdTipoCliente , @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Destinos]
(
	@IdDestino VARCHAR(5),
	@IdAerolinea INT,
	@NomDestino VARCHAR(57),
	@PaisSalida INT,
	@PaisLlegada INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Destinos]
		(
			[IdDestino],
			[IdAerolinea],
			[NomDestino],
			[PaisSalida],
			[PaisLlegada],
			[IdEstado]
		)
		VALUES
		(
			@IdDestino, @IdAerolinea, @NomDestino, @PaisSalida, @PaisLlegada, @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Empleados]
(
	@IdEmpleado VARCHAR(7),
	@Cedula VARCHAR(11), 
	@Nombre VARCHAR(25), 
	@Apellidos VARCHAR(150), 
	@Direccion VARCHAR(150), 
	@Edad INT, 
	@Telefono_Casa VARCHAR(9), 
	@Telefono_Referencia VARCHAR(9), 
	@Celular VARCHAR(9), 
	@Salario DECIMAL(18,2), 
	@IdTipoEmpleado INT, 
	@IdAerolinea INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Empleados]
		(
			[IdEmpleado],
			[Cedula], 
			[Nombre], 
			[Apellidos], 
			[Direccion], 
			[Edad], 
			[Telefono_Casa], 
			[Telefono_Referencia], 
			[Celular], 
			[Salario], 
			[IdTipoEmpleado], 
			[IdAerolinea],
			[IdEstado]
		)
		VALUES
		(
			@IdEmpleado, @Cedula, @Nombre, @Apellidos, @Direccion, @Edad, @Telefono_Casa, @Telefono_Referencia, @Celular, @Salario, @IdTipoEmpleado, @IdAerolinea, @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Estados]
(
	@IdEstado CHAR(1),
	@Descripcion VARCHAR(25)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Estados]
		(
			[IdEstado],
			[Descripcion]
		)
		VALUES
		(
			@IdEstado, @Descripcion
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Paises]
(
	@NombrePais VARCHAR(85), 
	@CodigoISOPais CHAR(4), 
	@CodigoAreaPais CHAR(5),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Paises]
		(
			[NombrePais], 
			[CodigoISOPais], 
			[CodigoAreaPais], 
			[IdEstado]
		)
		VALUES
		(
			@NombrePais, @CodigoISOPais, @CodigoAreaPais, @IdEstado
		);
		SELECT MAX ([IdPais])
		FROM [dbo].[T_Paises]
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_TiposAviones]
(
	@IdTipoAvion VARCHAR(7), 
	@NombreTipoAvion VARCHAR(90), 
	@DescTipoAvion VARCHAR(90), 
	@CapacidadPasajeros INT, 
	@CapacidadPeso DECIMAL (18,2),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_TiposAviones]
		(
			[IdTipoAvion], 
			[NombreTipoAvion], 
			[DescTipoAvion], 
			[CapacidadPasajeros], 
			[CapacidadPeso],
			[IdEstado]
		)
		VALUES
		(
			@IdTipoAvion, @NombreTipoAvion, @DescTipoAvion, @CapacidadPasajeros, @CapacidadPeso, @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_TiposClientes]
(
	@TipoCliente VARCHAR(50), 
	@Descripcion VARCHAR(150),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_TiposClientes]
		(
			[TipoCliente], 
			[Descripcion],
			[IdEstado]
		)
		VALUES
		(
			@TipoCliente, @Descripcion, @IdEstado
		);
		SELECT MAX ([IdTipoCliente])
		FROM [dbo].[T_TiposClientes]
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_TiposEmpleados]
(
	@DescTipo VARCHAR(150),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_TiposEmpleados]
		(
			[DescTipo],
			[IdEstado]
		)
		VALUES
		(
			@DescTipo, @IdEstado
		);
		SELECT MAX ([IdTipoEmpleado])
		FROM [dbo].[T_TiposEmpleados]
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Usuarios]
(
	@Username VARCHAR(15), 
	@Password VARCHAR(8), 
	@IdEmpleado VARCHAR(7),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Usuarios]
		(
			[Username], 
			[Password], 
			[IdEmpleado],
			[IdEstado]
		)
		VALUES
		(
			@Username, @Password, @IdEmpleado, @IdEstado
		);
	END
GO

CREATE PROCEDURE [dbo].[SP_Insertar_Vuelos]
(
	@IdVuelo VARCHAR(5), 
	@IdDestino VARCHAR(5), 
	@IdAerolinea INT, 
	@IdAvion VARCHAR(7), 
	@FechaHoraSalida DATETIME, 
	@FechaHoraLlegada DATETIME,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		INSERT INTO [dbo].[T_Vuelos]
		(
			[IdVuelo], 
			[IdDestino], 
			[IdAerolinea], 
			[IdAvion], 
			[FechaHoraSalida], 
			[FechaHoraLlegada],
			[IdEstado]
		)
		VALUES
		(
			@IdVuelo, @IdDestino, @IdAerolinea, @IdAvion, @FechaHoraSalida, @FechaHoraLlegada, @IdEstado
		);
	END
GO

-- MODIFICAR

CREATE PROCEDURE [dbo].[SP_Modificar_Aerolineas]
(
	@IdAerolinea INT,
	@NombreAerolinea VARCHAR(90),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Aerolineas]
		SET
			[NombreAerolinea] = @NombreAerolinea,
			[IdEstado] = @IdEstado
		WHERE [IdAerolinea] = @IdAerolinea
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Aviones]
(
	@IdAvion VARCHAR(7),
	@NomAvion VARCHAR(57),
	@DescAvion VARCHAR(120),
	@IdAerolinea INT,
	@IdTipoAvion VARCHAR(7),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Aviones]
		SET
			[NomAvion] = @NomAvion,
			[DescAvion] = @DescAvion,
			[IdAerolinea] = @IdAerolinea,
			[IdTipoAvion] = @IdTipoAvion,
			[IdEstado] = @IdEstado
		WHERE [IdAvion] = @IdAvion
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_CategoriasVuelos]
(
	@IdCategoria INT,
	@DescCategoria VARCHAR(90),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_CategoriasVuelos]
		SET
			[DescCategoria] = @DescCategoria,
			[IdEstado] = @IdEstado
		WHERE [IdCategoria] = @IdCategoria
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Clientes]
(
	@IdCliente VARCHAR(7),
	@Cedula VARCHAR(11),
	@Nombre VARCHAR(25),
	@Apellidos VARCHAR(150),
	@Telefono VARCHAR(9),
	@IdTipoCliente INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Clientes]
		SET
			[Cedula] = @Cedula,
			[Nombre] = @Nombre,
			[Apellidos] = @Apellidos,
			[Telefono] = @Telefono,
			[IdTipoCliente] = @IdTipoCliente,
			[IdEstado] = @IdEstado
		WHERE [IdCliente] = @IdCliente
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Destinos]
(
	@IdDestino VARCHAR(5),
	@IdAerolinea INT,
	@NomDestino VARCHAR(57),
	@PaisSalida INT,
	@PaisLlegada INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Destinos]
		SET
			[IdAerolinea] = @IdAerolinea,
			[NomDestino] = @NomDestino,
			[PaisSalida] = @PaisSalida,
			[PaisLlegada] = @PaisLlegada,
			[IdEstado] = @IdEstado
		WHERE [IdDestino] = @IdDestino
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Empleados]
(
	@IdEmpleado VARCHAR(7),
	@Cedula VARCHAR(11), 
	@Nombre VARCHAR(25), 
	@Apellidos VARCHAR(150), 
	@Direccion VARCHAR(150), 
	@Edad INT, 
	@Telefono_Casa VARCHAR(9), 
	@Telefono_Referencia VARCHAR(9), 
	@Celular VARCHAR(9), 
	@Salario DECIMAL(18,2), 
	@IdTipoEmpleado INT, 
	@IdAerolinea INT,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Empleados]
		SET
			[Cedula] = @Cedula, 
			[Nombre] = @Nombre, 
			[Apellidos] = @Apellidos, 
			[Direccion] = @Direccion, 
			[Edad] = @Edad, 
			[Telefono_Casa] = @Telefono_Casa, 
			[Telefono_Referencia] = @Telefono_Referencia, 
			[Celular] = @Celular, 
			[Salario] = @Salario, 
			[IdTipoEmpleado] = @IdTipoEmpleado, 
			[IdAerolinea] = @IdAerolinea,
			[IdEstado] = @IdEstado
		WHERE [IdEmpleado] = @IdEmpleado
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Estados]
(
	@IdEstado CHAR(1),
	@Descripcion VARCHAR(25)
)
AS
	BEGIN
		UPDATE [dbo].[T_Estados]
		SET
			[Descripcion] = @Descripcion
		WHERE [IdEstado] = @IdEstado
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Paises]
(
	@IdPais INT,
	@NombrePais VARCHAR(85), 
	@CodigoISOPais CHAR(4), 
	@CodigoAreaPais CHAR(5),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Paises]
		SET
			[NombrePais] = @NombrePais, 
			[CodigoISOPais] = @CodigoISOPais, 
			[CodigoAreaPais] = @CodigoAreaPais, 
			[IdEstado] = @IdEstado
		WHERE[IdPais]  = @IdPais
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_TiposAviones]
(
	@IdTipoAvion VARCHAR(7), 
	@NombreTipoAvion VARCHAR(90), 
	@DescTipoAvion VARCHAR(90), 
	@CapacidadPasajeros INT, 
	@CapacidadPeso DECIMAL (18,2),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_TiposAviones]
		SET
			[NombreTipoAvion] = @NombreTipoAvion, 
			[DescTipoAvion] = @DescTipoAvion, 
			[CapacidadPasajeros] = @CapacidadPasajeros, 
			[CapacidadPeso] = @CapacidadPeso,
			[IdEstado] = @IdEstado
		WHERE [IdTipoAvion] = @IdTipoAvion
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_TiposClientes]
(
	@IdTipoCliente INT,
	@TipoCliente VARCHAR(50), 
	@Descripcion VARCHAR(150),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_TiposClientes]
		SET
			[TipoCliente] = @TipoCliente, 
			[Descripcion] = @Descripcion,
			[IdEstado] = @IdEstado
		WHERE [IdTipoCliente] = @IdTipoCliente
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_TiposEmpleados]
(
	@IdTipoEmpleado INT,
	@DescTipo VARCHAR(150),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_TiposEmpleados]
		SET
			[DescTipo] = @DescTipo,
			[IdEstado] = @IdEstado
		WHERE [IdTipoEmpleado] = @IdTipoEmpleado
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Usuarios]
(
	@Username VARCHAR(15), 
	@Password VARCHAR(8), 
	@IdEmpleado VARCHAR(7),
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Usuarios]
		SET
			[Password] = @Password, 
			[IdEmpleado] = @IdEmpleado,
			[IdEstado] = @IdEstado
		WHERE [Username] = @Username
	END
GO

CREATE PROCEDURE [dbo].[SP_Modificar_Vuelos]
(
	@IdVuelo VARCHAR(5), 
	@IdDestino VARCHAR(5), 
	@IdAerolinea INT, 
	@IdAvion VARCHAR(7), 
	@FechaHoraSalida DATETIME, 
	@FechaHoraLlegada DATETIME,
	@IdEstado CHAR(1)
)
AS
	BEGIN
		UPDATE [dbo].[T_Vuelos]
		SET
			[IdDestino] = @IdDestino, 
			[IdAerolinea] = @IdAerolinea, 
			[IdAvion] = @IdAvion, 
			[FechaHoraSalida] = @FechaHoraSalida, 
			[FechaHoraLlegada] = @FechaHoraLlegada,
			[IdEstado] = @IdEstado			
		WHERE [IdVuelo] = @IdVuelo
	END
GO

-- LLENAR BASES DE DATOS INCIALES

-- TABLA DE ESTADOS

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('A','Activo')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('I','Inactivo')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('E','Eliminado')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('F','Funcional')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('D','Dañado')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('B','Bloqueado')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('V','Validado')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('L','Libre/vacaciones')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('M','Maternidad/Licencia')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('T','A tiempo')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('R','Retrasado')
GO

INSERT INTO [dbo].[T_Estados]([IdEstado],[Descripcion])
VALUES('S','Suspendido')
GO

-- TABLA DE TIPOS DE AVIONES

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVPAS01','Boeing 747','Avión de pasajeros',550,183500,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVPAS02','Airbus A320','Avión de pasajeros',180,73700,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVPAS03','Túpolev Tu-204','Avión de pasajeros',212,110750,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVPAS04','Ilyushin IL-96','Avión de pasajeros',312,250000,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVPAS05','Aérospatiale-BAC Concorde','Avión de pasajeros',92,186880,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVCAR01','Boeing 747-8F Freighter','Avión de carga',467,449056,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVCAR02','Boeing 747-400F','Avión de carga',568,396890,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVCAR03','Airbus 300-600ST','Avión de carga',250,86500,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVCAR04','Antonov 225 Mriya','Avión de carga',868,285000,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVNEG01','Gulfstream IV','Avión de negocios',19,33800,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVNEG02','Bombardier Global Express','Avión de negocios',19,22600,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVMIL01','A-10 Thunderbolt II','Avión militar',1,11320,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVMIL02','Boeing B-52','Avión militar',160,83250,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVMIL03','F-22 Raptor','Avión militar',1,19700,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVMIL04','Mikoyan MiG-31','Avión militar',2,21820,'A')
GO

INSERT INTO [dbo].[T_TiposAviones]([IdTipoAvion],[NombreTipoAvion],[DescTipoAvion],[CapacidadPasajeros],[CapacidadPeso],[IdEstado])
VALUES('AVMIL05','CASA C-295','Avión militar',71,11000,'A')
GO

-- TIPOS DE CLIENTES

INSERT INTO [dbo].[T_TiposClientes]([TipoCliente],[Descripcion],[IdEstado])
VALUES('Frecuente','Cliente frecuente','A')
GO

INSERT INTO [dbo].[T_TiposClientes]([TipoCliente],[Descripcion],[IdEstado])
VALUES('VIP','Cliente de alta importancia','A')
GO

INSERT INTO [dbo].[T_TiposClientes]([TipoCliente],[Descripcion],[IdEstado])
VALUES('Standard','Cliente poco frecuente','A')
GO

-- TIPOS DE EMPLEADOS

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Gerente','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Bodeguero','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Seguridad','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Mantenimiento','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Tecnico de Taller','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Gerente de Proyectos','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Gerente General','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Administrador','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Piloto','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Sobrecargo','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Ingeniero','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Transporte','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Limpieza','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Oficinista','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('IT','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('DBA','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Controlador','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Operario','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Cocina','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Contador','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Técnico','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Servicio al Cliente','A')
GO

INSERT INTO [dbo].[T_TiposEmpleados]([DescTipo],[IdEstado])
VALUES('Cajero','A')
GO

