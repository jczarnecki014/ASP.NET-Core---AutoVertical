﻿// <auto-generated />
using System;
using AutoVertical_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoVerticalData.Migrations
{
    [DbContext(typeof(DbAccess))]
    [Migration("20221214135543_AddVehicleCarTruckMotorcycleToDb")]
    partial class AddVehicleCarTruckMotorcycleToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoVertical_Model.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<bool>("ActiveRecognizedRoadSigns")
                        .HasColumnType("bit");

                    b.Property<bool>("AirBags")
                        .HasColumnType("bit");

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("AndroidAuto")
                        .HasColumnType("bit");

                    b.Property<bool>("AppleCarPlaycd")
                        .HasColumnType("bit");

                    b.Property<bool>("Armrests")
                        .HasColumnType("bit");

                    b.Property<bool>("BlindSpotAssistance")
                        .HasColumnType("bit");

                    b.Property<bool>("BluetoothInterface")
                        .HasColumnType("bit");

                    b.Property<bool>("BrakeAssist")
                        .HasColumnType("bit");

                    b.Property<string>("CarEquipmentToString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DailyLight")
                        .HasColumnType("bit");

                    b.Property<bool>("DigitalKey")
                        .HasColumnType("bit");

                    b.Property<bool>("DuskSensor")
                        .HasColumnType("bit");

                    b.Property<bool>("ESP")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectricFrontWindows")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectricParkingBrake")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectricRearWindows")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectricStearingSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectronicMirrors")
                        .HasColumnType("bit");

                    b.Property<bool>("EmergencyBrakingAssistant")
                        .HasColumnType("bit");

                    b.Property<bool>("FunctionVoiceStering")
                        .HasColumnType("bit");

                    b.Property<bool>("GearChangingInSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("HeadUpDisplay")
                        .HasColumnType("bit");

                    b.Property<bool>("HeatingFrontWindow")
                        .HasColumnType("bit");

                    b.Property<bool>("HeatingSeat")
                        .HasColumnType("bit");

                    b.Property<bool>("HeatingSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("HillHolder")
                        .HasColumnType("bit");

                    b.Property<bool>("InternetAcces")
                        .HasColumnType("bit");

                    b.Property<bool>("Isofix")
                        .HasColumnType("bit");

                    b.Property<bool>("KeyLessEntry")
                        .HasColumnType("bit");

                    b.Property<bool>("KeylessGo")
                        .HasColumnType("bit");

                    b.Property<bool>("LanneAssist")
                        .HasColumnType("bit");

                    b.Property<bool>("LeatherSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("LeavingHomeLight")
                        .HasColumnType("bit");

                    b.Property<bool>("LoudSpeekerSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("MassageSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("MultimediaSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<string>("NumberOfDoor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<bool>("OpeningRoof")
                        .HasColumnType("bit");

                    b.Property<bool>("PanoramicCamera360")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkAssistant")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkingCamera")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkingSensors")
                        .HasColumnType("bit");

                    b.Property<bool>("ProtectionFromAccidentSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("Radio")
                        .HasColumnType("bit");

                    b.Property<bool>("RainDetector")
                        .HasColumnType("bit");

                    b.Property<bool>("RearLedLight")
                        .HasColumnType("bit");

                    b.Property<bool>("RightHandDrive")
                        .HasColumnType("bit");

                    b.Property<bool>("SatelliteNavigationSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("SoundSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("SpeedLimiter")
                        .HasColumnType("bit");

                    b.Property<bool>("SportSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("SportSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("StartStopSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("Tempomat")
                        .HasColumnType("bit");

                    b.Property<bool>("Touchscreen")
                        .HasColumnType("bit");

                    b.Property<bool>("USBSocket")
                        .HasColumnType("bit");

                    b.Property<bool>("VentilatedSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("Webasto")
                        .HasColumnType("bit");

                    b.Property<bool>("WirelessChargingDevices")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoVertical_Model.Models.ImgGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("imgEightUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgFiveUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgFourUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgOneUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgSevenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgSixUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgThreeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgTwoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImgGallery");
                });

            modelBuilder.Entity("AutoVertical_Model.Models.Motorcycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<bool>("Alarm")
                        .HasColumnType("bit");

                    b.Property<bool>("HeatedGrips")
                        .HasColumnType("bit");

                    b.Property<bool>("ImmobilizerTrunk")
                        .HasColumnType("bit");

                    b.Property<string>("MotorcycleEquipmentToString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Radio")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Motorcycles");
                });

            modelBuilder.Entity("AutoVertical_Model.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<bool>("AdjustableSuspension")
                        .HasColumnType("bit");

                    b.Property<bool>("AirBags")
                        .HasColumnType("bit");

                    b.Property<bool>("Alarm")
                        .HasColumnType("bit");

                    b.Property<int>("AllowPackage")
                        .HasColumnType("int");

                    b.Property<bool>("AutomaticAirCondition")
                        .HasColumnType("bit");

                    b.Property<bool>("CD")
                        .HasColumnType("bit");

                    b.Property<bool>("CbRadio")
                        .HasColumnType("bit");

                    b.Property<bool>("CentralLock")
                        .HasColumnType("bit");

                    b.Property<bool>("CruiseControl")
                        .HasColumnType("bit");

                    b.Property<bool>("DVD")
                        .HasColumnType("bit");

                    b.Property<bool>("DoubleRearWheels")
                        .HasColumnType("bit");

                    b.Property<bool>("Drive4x4")
                        .HasColumnType("bit");

                    b.Property<bool>("ESP")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectrisGlasses")
                        .HasColumnType("bit");

                    b.Property<bool>("FactoryRadio")
                        .HasColumnType("bit");

                    b.Property<bool>("Fridge")
                        .HasColumnType("bit");

                    b.Property<bool>("GPSNAV")
                        .HasColumnType("bit");

                    b.Property<bool>("Immobilizer")
                        .HasColumnType("bit");

                    b.Property<bool>("Intarder")
                        .HasColumnType("bit");

                    b.Property<bool>("Kitchen")
                        .HasColumnType("bit");

                    b.Property<bool>("MiniBar")
                        .HasColumnType("bit");

                    b.Property<bool>("MultifunctionSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("NonStandarVehicle")
                        .HasColumnType("bit");

                    b.Property<bool>("NotFactoryRadio")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfAxles")
                        .HasColumnType("int");

                    b.Property<bool>("OnBoardComputer")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkingSensor")
                        .HasColumnType("bit");

                    b.Property<int>("PermissibleGrossWeight")
                        .HasColumnType("int");

                    b.Property<bool>("Retarder")
                        .HasColumnType("bit");

                    b.Property<bool>("SleepingCabing")
                        .HasColumnType("bit");

                    b.Property<bool>("TVTuner")
                        .HasColumnType("bit");

                    b.Property<bool>("Tachography")
                        .HasColumnType("bit");

                    b.Property<bool>("Toilet")
                        .HasColumnType("bit");

                    b.Property<string>("TruckEquipmentToString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Webasto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("AutoVertical_Model.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AsoServiced")
                        .HasColumnType("bit");

                    b.Property<string>("BodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<bool?>("Co2Emision")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CubicCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Damaged")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<bool>("FirstOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GalleryId")
                        .HasColumnType("int");

                    b.Property<string>("GearBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Imported")
                        .HasColumnType("bit");

                    b.Property<bool>("Leasing")
                        .HasColumnType("bit");

                    b.Property<int>("Milage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoAccident")
                        .HasColumnType("bit");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceBrutto")
                        .HasColumnType("int");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("RegDay")
                        .HasColumnType("int");

                    b.Property<int>("RegMonth")
                        .HasColumnType("int");

                    b.Property<int>("RegYear")
                        .HasColumnType("int");

                    b.Property<bool>("RegisteredAsMonument")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("ToNegotiate")
                        .HasColumnType("bit");

                    b.Property<int?>("TruckId")
                        .HasColumnType("int");

                    b.Property<bool>("Tuning")
                        .HasColumnType("bit");

                    b.Property<bool>("VAT")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("GalleryId");

                    b.HasIndex("TruckId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AutoVertical_Model.Models.Vehicle", b =>
                {
                    b.HasOne("AutoVertical_Model.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("AutoVertical_Model.Models.ImgGallery", "Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoVertical_Model.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId");

                    b.Navigation("Car");

                    b.Navigation("Gallery");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
