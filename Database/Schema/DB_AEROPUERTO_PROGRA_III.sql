USE [master]

GO

CREATE DATABASE [DB_AEROPUERTO_PROGRA_III]


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [DB_AEROPUERTO_PROGRA_III]

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