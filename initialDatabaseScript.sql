USE [master]
GO
/****** Object:  Database [AutoVertical]    Script Date: 16.02.2023 08:47:53 ******/
CREATE DATABASE [AutoVertical]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoVertical', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AutoVertical.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutoVertical_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AutoVertical_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AutoVertical] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoVertical].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoVertical] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoVertical] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoVertical] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoVertical] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoVertical] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoVertical] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AutoVertical] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoVertical] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoVertical] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoVertical] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoVertical] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoVertical] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoVertical] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoVertical] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoVertical] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AutoVertical] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoVertical] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoVertical] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoVertical] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoVertical] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoVertical] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoVertical] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoVertical] SET RECOVERY FULL 
GO
ALTER DATABASE [AutoVertical] SET  MULTI_USER 
GO
ALTER DATABASE [AutoVertical] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoVertical] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoVertical] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoVertical] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutoVertical] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AutoVertical] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AutoVertical', N'ON'
GO
ALTER DATABASE [AutoVertical] SET QUERY_STORE = OFF
GO
USE [AutoVertical]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advertisements]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[ImageSrc] [nvarchar](max) NOT NULL,
	[Size] [nvarchar](max) NOT NULL,
	[ActiveFrom] [date] NOT NULL,
	[ActiveTo] [date] NOT NULL,
 CONSTRAINT [PK_Advertisements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertStats]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertStats](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[AdvertViewsCount] [int] NULL,
	[PhoneNumberDisplays] [int] NULL,
 CONSTRAINT [PK_AdvertStats] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[AvatarSrc] [nvarchar](max) NULL,
	[Blocked] [bit] NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PostCode] [nvarchar](max) NULL,
	[RegistrationDate] [date] NULL,
	[Street] [nvarchar](50) NULL,
	[StreetNumber] [nvarchar](7) NULL,
	[Surname] [nvarchar](50) NULL,
	[Verificated] [bit] NULL,
	[SoldVehicles] [int] NULL,
	[CompanyId] [int] NULL,
	[CompanyRole] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RightHandDrive] [bit] NOT NULL,
	[NumberOfDoor] [nvarchar](max) NOT NULL,
	[NumberOfSeats] [nvarchar](max) NOT NULL,
	[AppleCarPlaycd] [bit] NOT NULL,
	[BluetoothInterface] [bit] NOT NULL,
	[LoudSpeekerSystem] [bit] NOT NULL,
	[WirelessChargingDevices] [bit] NOT NULL,
	[SoundSystem] [bit] NOT NULL,
	[Touchscreen] [bit] NOT NULL,
	[InternetAcces] [bit] NOT NULL,
	[AndroidAuto] [bit] NOT NULL,
	[Radio] [bit] NOT NULL,
	[USBSocket] [bit] NOT NULL,
	[SatelliteNavigationSystem] [bit] NOT NULL,
	[HeadUpDisplay] [bit] NOT NULL,
	[FunctionVoiceStering] [bit] NOT NULL,
	[AirConditioning] [bit] NOT NULL,
	[HeatingSeat] [bit] NOT NULL,
	[MassageSeats] [bit] NOT NULL,
	[Armrests] [bit] NOT NULL,
	[SportSteeringWheel] [bit] NOT NULL,
	[HeatingSteeringWheel] [bit] NOT NULL,
	[KeyLessEntry] [bit] NOT NULL,
	[Webasto] [bit] NOT NULL,
	[HeatingFrontWindow] [bit] NOT NULL,
	[ElectricRearWindows] [bit] NOT NULL,
	[OpeningRoof] [bit] NOT NULL,
	[ElectricStearingSeats] [bit] NOT NULL,
	[VentilatedSeats] [bit] NOT NULL,
	[SportSeats] [bit] NOT NULL,
	[LeatherSteeringWheel] [bit] NOT NULL,
	[MultimediaSteeringWheel] [bit] NOT NULL,
	[GearChangingInSteeringWheel] [bit] NOT NULL,
	[KeylessGo] [bit] NOT NULL,
	[RainDetector] [bit] NOT NULL,
	[ElectricFrontWindows] [bit] NOT NULL,
	[DigitalKey] [bit] NOT NULL,
	[Tempomat] [bit] NOT NULL,
	[ParkAssistant] [bit] NOT NULL,
	[ParkingCamera] [bit] NOT NULL,
	[BlindSpotAssistance] [bit] NOT NULL,
	[SpeedLimiter] [bit] NOT NULL,
	[ESP] [bit] NOT NULL,
	[HillHolder] [bit] NOT NULL,
	[DuskSensor] [bit] NOT NULL,
	[RearLedLight] [bit] NOT NULL,
	[StartStopSystem] [bit] NOT NULL,
	[ParkingSensors] [bit] NOT NULL,
	[PanoramicCamera360] [bit] NOT NULL,
	[ElectronicMirrors] [bit] NOT NULL,
	[LanneAssist] [bit] NOT NULL,
	[BrakeAssist] [bit] NOT NULL,
	[ABS] [bit] NOT NULL,
	[ActiveRecognizedRoadSigns] [bit] NOT NULL,
	[DailyLight] [bit] NOT NULL,
	[LeavingHomeLight] [bit] NOT NULL,
	[ElectricParkingBrake] [bit] NOT NULL,
	[EmergencyBrakingAssistant] [bit] NOT NULL,
	[AirBags] [bit] NOT NULL,
	[Isofix] [bit] NOT NULL,
	[ProtectionFromAccidentSystem] [bit] NOT NULL,
	[CarEquipmentToString] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[LogoSrc] [nvarchar](max) NOT NULL,
	[WebsiteUrl] [nvarchar](max) NULL,
	[City] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[PostalCode] [nvarchar](max) NOT NULL,
	[StreetName] [nvarchar](max) NOT NULL,
	[StreetNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Fax] [nvarchar](max) NULL,
	[ActiveAdverts] [int] NULL,
	[ActiveAdvertisements] [int] NULL,
	[SoldAverts] [int] NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanysInvitations]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanysInvitations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_CompanysInvitations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversation]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserOneId] [nvarchar](max) NOT NULL,
	[UserTwoId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Conversation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImgGallery]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImgGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[VehicleId] [int] NOT NULL,
 CONSTRAINT [PK_ImgGallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConversationId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motorcycles]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motorcycles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ABS] [bit] NOT NULL,
	[Alarm] [bit] NOT NULL,
	[ImmobilizerTrunk] [bit] NOT NULL,
	[HeatedGrips] [bit] NOT NULL,
	[Radio] [bit] NOT NULL,
	[MotorcycleEquipmentToString] [nvarchar](max) NULL,
 CONSTRAINT [PK_Motorcycles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notyfications]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notyfications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[Event] [nvarchar](max) NOT NULL,
	[UserOfEventId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Notyfications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trucks]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trucks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NonStandarVehicle] [nvarchar](max) NOT NULL,
	[DoubleRearWheels] [nvarchar](max) NOT NULL,
	[NumberOfAxles] [int] NOT NULL,
	[AllowPackage] [int] NOT NULL,
	[PermissibleGrossWeight] [int] NOT NULL,
	[Drive4x4] [bit] NOT NULL,
	[ABS] [bit] NOT NULL,
	[Alarm] [bit] NOT NULL,
	[CbRadio] [bit] NOT NULL,
	[CD] [bit] NOT NULL,
	[CentralLock] [bit] NOT NULL,
	[ParkingSensor] [bit] NOT NULL,
	[DVD] [bit] NOT NULL,
	[ElectrisWindows] [bit] NOT NULL,
	[ESP] [bit] NOT NULL,
	[Immobilizer] [bit] NOT NULL,
	[Intarder] [bit] NOT NULL,
	[SleepingCabing] [bit] NOT NULL,
	[AutomaticAirCondition] [bit] NOT NULL,
	[OnBoardComputer] [bit] NOT NULL,
	[Kitchen] [bit] NOT NULL,
	[Fridge] [bit] NOT NULL,
	[MiniBar] [bit] NOT NULL,
	[GPSNAV] [bit] NOT NULL,
	[Webasto] [bit] NOT NULL,
	[AirBags] [bit] NOT NULL,
	[FactoryRadio] [bit] NOT NULL,
	[NotFactoryRadio] [bit] NOT NULL,
	[AdjustableSuspension] [bit] NOT NULL,
	[Retarder] [bit] NOT NULL,
	[Tachography] [bit] NOT NULL,
	[CruiseControl] [bit] NOT NULL,
	[Toilet] [bit] NOT NULL,
	[TVTuner] [bit] NOT NULL,
	[MultifunctionSteeringWheel] [bit] NOT NULL,
	[TruckEquipmentToString] [nvarchar](max) NULL,
	[ASR] [bit] NOT NULL,
 CONSTRAINT [PK_Trucks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFollowedVehicles]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFollowedVehicles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[VehicleId] [int] NOT NULL,
 CONSTRAINT [PK_UserFollowedVehicles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 16.02.2023 08:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleType] [nvarchar](max) NOT NULL,
	[Imported] [nvarchar](max) NOT NULL,
	[Damaged] [bit] NOT NULL,
	[VinNumber] [nvarchar](max) NOT NULL,
	[Milage] [int] NOT NULL,
	[VehicleRegistrationNumber] [nvarchar](max) NOT NULL,
	[RegDay] [int] NOT NULL,
	[RegMonth] [int] NOT NULL,
	[RegYear] [int] NOT NULL,
	[ProductionYear] [int] NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Fuel] [nvarchar](max) NOT NULL,
	[Power] [int] NOT NULL,
	[CubicCapacity] [int] NOT NULL,
	[GearBox] [nvarchar](max) NOT NULL,
	[Co2Emision] [int] NULL,
	[BodyType] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[ColorType] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[CountryOfOrigin] [nvarchar](max) NOT NULL,
	[FirstOwner] [bit] NOT NULL,
	[AsoServiced] [bit] NOT NULL,
	[Tuning] [bit] NOT NULL,
	[NoAccident] [bit] NOT NULL,
	[RegisteredAsMonument] [bit] NOT NULL,
	[PriceBrutto] [int] NOT NULL,
	[ToNegotiate] [bit] NOT NULL,
	[VAT] [bit] NOT NULL,
	[Leasing] [bit] NOT NULL,
	[CarId] [int] NULL,
	[TruckId] [int] NULL,
	[MotorcycleId] [int] NULL,
	[Drive] [nvarchar](max) NOT NULL,
	[MentionTime] [date] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CreateDate] [date] NOT NULL,
	[ExpireDate] [date] NOT NULL,
	[VehicleDirectoryPath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Advertisements_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Advertisements_UserId] ON [dbo].[Advertisements]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdvertStats_VehicleId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AdvertStats_VehicleId] ON [dbo].[AdvertStats]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 16.02.2023 08:47:54 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_CompanyId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CompanyId] ON [dbo].[AspNetUsers]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 16.02.2023 08:47:54 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CompanysInvitations_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_CompanysInvitations_UserId] ON [dbo].[CompanysInvitations]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Messages_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Messages_UserId] ON [dbo].[Messages]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Notyfications_UserOfEventId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Notyfications_UserOfEventId] ON [dbo].[Notyfications]
(
	[UserOfEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserFollowedVehicles_VehicleId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_UserFollowedVehicles_VehicleId] ON [dbo].[UserFollowedVehicles]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicles_CarId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicles_CarId] ON [dbo].[Vehicles]
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicles_MotorcycleId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicles_MotorcycleId] ON [dbo].[Vehicles]
(
	[MotorcycleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicles_TruckId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicles_TruckId] ON [dbo].[Vehicles]
(
	[TruckId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vehicles_UserId]    Script Date: 16.02.2023 08:47:54 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicles_UserId] ON [dbo].[Vehicles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[company] ADD  DEFAULT ((0)) FOR [ActiveAdverts]
GO
ALTER TABLE [dbo].[company] ADD  DEFAULT ((0)) FOR [ActiveAdvertisements]
GO
ALTER TABLE [dbo].[company] ADD  DEFAULT ((0)) FOR [SoldAverts]
GO
ALTER TABLE [dbo].[ImgGallery] ADD  DEFAULT ((0)) FOR [VehicleId]
GO
ALTER TABLE [dbo].[Trucks] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ASR]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT (N'') FOR [Drive]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ('0001-01-01') FOR [MentionTime]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ('0001-01-01') FOR [CreateDate]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ('0001-01-01') FOR [ExpireDate]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT (N'') FOR [VehicleDirectoryPath]
GO
ALTER TABLE [dbo].[Advertisements]  WITH CHECK ADD  CONSTRAINT [FK_Advertisements_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Advertisements] CHECK CONSTRAINT [FK_Advertisements_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AdvertStats]  WITH CHECK ADD  CONSTRAINT [FK_AdvertStats_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdvertStats] CHECK CONSTRAINT [FK_AdvertStats_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_company_CompanyId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CompanysInvitations]  WITH CHECK ADD  CONSTRAINT [FK_CompanysInvitations_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanysInvitations] CHECK CONSTRAINT [FK_CompanysInvitations_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Notyfications]  WITH CHECK ADD  CONSTRAINT [FK_Notyfications_AspNetUsers_UserOfEventId] FOREIGN KEY([UserOfEventId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notyfications] CHECK CONSTRAINT [FK_Notyfications_AspNetUsers_UserOfEventId]
GO
ALTER TABLE [dbo].[UserFollowedVehicles]  WITH CHECK ADD  CONSTRAINT [FK_UserFollowedVehicles_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFollowedVehicles] CHECK CONSTRAINT [FK_UserFollowedVehicles_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Cars_CarId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Motorcycles_MotorcycleId] FOREIGN KEY([MotorcycleId])
REFERENCES [dbo].[Motorcycles] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Motorcycles_MotorcycleId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Trucks_TruckId] FOREIGN KEY([TruckId])
REFERENCES [dbo].[Trucks] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Trucks_TruckId]
GO
USE [master]
GO
ALTER DATABASE [AutoVertical] SET  READ_WRITE 
GO
