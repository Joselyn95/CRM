USE [master]
GO
/****** Object:  Database [CRM]    Script Date: 2/23/2019 9:02:11 PM ******/
CREATE DATABASE [CRM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CRM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CRM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CRM] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRM] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRM] SET  MULTI_USER 
GO
ALTER DATABASE [CRM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRM] SET QUERY_STORE = OFF
GO
USE [CRM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CRM]
GO
/****** Object:  Table [dbo].[Canton]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canton](
	[Id_Canton] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Provincia] [int] NULL,
 CONSTRAINT [PK_Canton] PRIMARY KEY CLUSTERED 
(
	[Id_Canton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[Id_Contacto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido1] [varchar](100) NULL,
	[Apellido2] [varchar](100) NULL,
	[Puesto] [varchar](100) NULL,
	[Empresa] [int] NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[Id_Contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Correo]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Correo](
	[Id_Correo] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](100) NULL,
	[Contacto] [int] NULL,
 CONSTRAINT [PK_Correo] PRIMARY KEY CLUSTERED 
(
	[Id_Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[Id_Distrito] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Canton] [int] NOT NULL,
 CONSTRAINT [PK_Distrito] PRIMARY KEY CLUSTERED 
(
	[Id_Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dominio]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dominio](
	[Id_Dominio] [int] IDENTITY(1,1) NOT NULL,
	[Dominio] [varchar](200) NULL,
	[ServicioEmpresa] [int] NULL,
 CONSTRAINT [PK_Dominio] PRIMARY KEY CLUSTERED 
(
	[Id_Dominio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Correo] [varchar](100) NULL,
	[Cedula] [varchar](30) NULL,
	[Pais] [varchar](100) NULL,
	[Id_Provincia] [int] NULL,
	[Id_Canton] [int] NULL,
	[Id_Distrito] [int] NULL,
	[Otras_Señas] [varchar](300) NOT NULL,
	[Codigo_Postal] [int] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadodeCuenta]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadodeCuenta](
	[Id_Estado] [int] NOT NULL,
	[Id_Credito_Disponible] [int] NULL,
	[Empresa] [int] NULL,
 CONSTRAINT [PK_EstadodeCuenta] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marketing]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marketing](
	[Id_Marketing] [int] IDENTITY(1,1) NOT NULL,
	[ServicioAdquirido] [int] NULL,
	[Empresa] [int] NULL,
	[Sugerencia] [int] NULL,
	[URL] [varchar](200) NULL,
 CONSTRAINT [PK_Marketing] PRIMARY KEY CLUSTERED 
(
	[Id_Marketing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedioPublicitario]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedioPublicitario](
	[Id_Medio_Publicitario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_MedioPublicitario] PRIMARY KEY CLUSTERED 
(
	[Id_Medio_Publicitario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id_Movimiento] [int] NOT NULL,
	[Tipo] [varchar](100) NULL,
	[Monto] [float] NULL,
	[Detalle] [varchar](200) NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Id_Movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[Id_Provincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[Id_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicidad]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicidad](
	[Id_Publicidad] [int] IDENTITY(1,1) NOT NULL,
	[Medio] [int] NULL,
	[Empresa] [int] NULL,
	[Credito] [int] NULL,
	[Fecha_Inicio] [date] NULL,
	[Fecha_Caducidad] [date] NULL,
	[Costo] [float] NULL,
 CONSTRAINT [PK_Publicidad] PRIMARY KEY CLUSTERED 
(
	[Id_Publicidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recordatorio]    Script Date: 2/23/2019 9:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recordatorio](
	[Id_Recordatorio] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](200) NULL,
	[Fecha] [date] NULL,
	[Hora] [int] NULL,
	[Minutos] [int] NULL,
	[Abreviatura] [varchar](10) NULL,
	[Detalle] [varchar](200) NOT NULL,
	[Empresa] [int] NULL,
 CONSTRAINT [PK_Recordatorio] PRIMARY KEY CLUSTERED 
(
	[Id_Recordatorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id_Rol] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[Id_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Codigo] [varchar](10) NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[Id_Servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicioEmpresa]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicioEmpresa](
	[Id_Servicio_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Fecha_Creacion] [date] NULL,
	[Primer_Pago] [date] NULL,
	[Renovacion] [date] NOT NULL,
	[Empresa] [int] NULL,
	[Servicio] [int] NULL,
 CONSTRAINT [PK_ServicioEmpresa] PRIMARY KEY CLUSTERED 
(
	[Id_Servicio_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servidor]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servidor](
	[Id_Servidor] [int] IDENTITY(1,1) NOT NULL,
	[Direccion_Web] [varchar](200) NULL,
	[Correo] [varchar](100) NULL,
	[Usuario] [varchar](100) NULL,
	[Contraseña] [varchar](100) NULL,
	[Observaciones] [varchar](200) NOT NULL,
	[ServicioEmpresa] [int] NULL,
 CONSTRAINT [PK_Servidor] PRIMARY KEY CLUSTERED 
(
	[Id_Servidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[Id_Telefono] [int] IDENTITY(1,1) NOT NULL,
	[Telefono] [int] NULL,
	[Contacto] [int] NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[Id_Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/23/2019 9:02:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido1] [varchar](100) NULL,
	[Apellido2] [varchar](100) NULL,
	[Correo] [varchar](100) NULL,
	[Contraseña] [varchar](100) NULL,
	[Fecha_Creacion] [date] NULL,
	[Empresa] [int] NULL,
	[Rol] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Canton_Canton] FOREIGN KEY([Provincia])
REFERENCES [dbo].[Provincia] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Canton_Canton]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Empresa]
GO
ALTER TABLE [dbo].[Correo]  WITH CHECK ADD  CONSTRAINT [FK_Correo_Contacto] FOREIGN KEY([Contacto])
REFERENCES [dbo].[Contacto] ([Id_Contacto])
GO
ALTER TABLE [dbo].[Correo] CHECK CONSTRAINT [FK_Correo_Contacto]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Canton] FOREIGN KEY([Canton])
REFERENCES [dbo].[Canton] ([Id_Canton])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Canton]
GO
ALTER TABLE [dbo].[Dominio]  WITH CHECK ADD  CONSTRAINT [FK_Dominio_ServicioEmpresa] FOREIGN KEY([ServicioEmpresa])
REFERENCES [dbo].[ServicioEmpresa] ([Id_Servicio_Empresa])
GO
ALTER TABLE [dbo].[Dominio] CHECK CONSTRAINT [FK_Dominio_ServicioEmpresa]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Canton] FOREIGN KEY([Id_Canton])
REFERENCES [dbo].[Canton] ([Id_Canton])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Canton]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Distrito] FOREIGN KEY([Id_Distrito])
REFERENCES [dbo].[Distrito] ([Id_Distrito])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Distrito]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Provincia] FOREIGN KEY([Id_Provincia])
REFERENCES [dbo].[Provincia] ([Id_Provincia])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Provincia]
GO
ALTER TABLE [dbo].[EstadodeCuenta]  WITH CHECK ADD  CONSTRAINT [FK_EstadodeCuenta_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[EstadodeCuenta] CHECK CONSTRAINT [FK_EstadodeCuenta_Empresa]
GO
ALTER TABLE [dbo].[Marketing]  WITH CHECK ADD  CONSTRAINT [FK_Marketing_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Marketing] CHECK CONSTRAINT [FK_Marketing_Empresa]
GO
ALTER TABLE [dbo].[Marketing]  WITH CHECK ADD  CONSTRAINT [FK_Marketing_Servicio] FOREIGN KEY([ServicioAdquirido])
REFERENCES [dbo].[Servicio] ([Id_Servicio])
GO
ALTER TABLE [dbo].[Marketing] CHECK CONSTRAINT [FK_Marketing_Servicio]
GO
ALTER TABLE [dbo].[Marketing]  WITH CHECK ADD  CONSTRAINT [FK_Marketing_Servicio1] FOREIGN KEY([Sugerencia])
REFERENCES [dbo].[Servicio] ([Id_Servicio])
GO
ALTER TABLE [dbo].[Marketing] CHECK CONSTRAINT [FK_Marketing_Servicio1]
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicidad_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Publicidad] CHECK CONSTRAINT [FK_Publicidad_Empresa]
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicidad_EstadodeCuenta] FOREIGN KEY([Credito])
REFERENCES [dbo].[EstadodeCuenta] ([Id_Estado])
GO
ALTER TABLE [dbo].[Publicidad] CHECK CONSTRAINT [FK_Publicidad_EstadodeCuenta]
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicidad_MedioPublicitario] FOREIGN KEY([Medio])
REFERENCES [dbo].[MedioPublicitario] ([Id_Medio_Publicitario])
GO
ALTER TABLE [dbo].[Publicidad] CHECK CONSTRAINT [FK_Publicidad_MedioPublicitario]
GO
ALTER TABLE [dbo].[Recordatorio]  WITH CHECK ADD  CONSTRAINT [FK_Recordatorio_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Recordatorio] CHECK CONSTRAINT [FK_Recordatorio_Empresa]
GO
ALTER TABLE [dbo].[ServicioEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ServicioEmpresa_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[ServicioEmpresa] CHECK CONSTRAINT [FK_ServicioEmpresa_Empresa]
GO
ALTER TABLE [dbo].[ServicioEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_ServicioEmpresa_Servicio] FOREIGN KEY([Servicio])
REFERENCES [dbo].[Servicio] ([Id_Servicio])
GO
ALTER TABLE [dbo].[ServicioEmpresa] CHECK CONSTRAINT [FK_ServicioEmpresa_Servicio]
GO
ALTER TABLE [dbo].[Servidor]  WITH CHECK ADD  CONSTRAINT [FK_Servidor_ServicioEmpresa] FOREIGN KEY([ServicioEmpresa])
REFERENCES [dbo].[ServicioEmpresa] ([Id_Servicio_Empresa])
GO
ALTER TABLE [dbo].[Servidor] CHECK CONSTRAINT [FK_Servidor_ServicioEmpresa]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Contacto] FOREIGN KEY([Contacto])
REFERENCES [dbo].[Contacto] ([Id_Contacto])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Contacto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empresa]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([Rol])
REFERENCES [dbo].[Rol] ([Id_Rol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [CRM] SET  READ_WRITE 
GO
