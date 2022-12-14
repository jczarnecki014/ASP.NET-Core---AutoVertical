using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoVerticalData.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleCarTruckMotorcycleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightHandDrive = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfDoor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    AppleCarPlaycd = table.Column<bool>(type: "bit", nullable: false),
                    BluetoothInterface = table.Column<bool>(type: "bit", nullable: false),
                    LoudSpeekerSystem = table.Column<bool>(type: "bit", nullable: false),
                    WirelessChargingDevices = table.Column<bool>(type: "bit", nullable: false),
                    SoundSystem = table.Column<bool>(type: "bit", nullable: false),
                    Touchscreen = table.Column<bool>(type: "bit", nullable: false),
                    InternetAcces = table.Column<bool>(type: "bit", nullable: false),
                    AndroidAuto = table.Column<bool>(type: "bit", nullable: false),
                    Radio = table.Column<bool>(type: "bit", nullable: false),
                    USBSocket = table.Column<bool>(type: "bit", nullable: false),
                    SatelliteNavigationSystem = table.Column<bool>(type: "bit", nullable: false),
                    HeadUpDisplay = table.Column<bool>(type: "bit", nullable: false),
                    FunctionVoiceStering = table.Column<bool>(type: "bit", nullable: false),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    HeatingSeat = table.Column<bool>(type: "bit", nullable: false),
                    MassageSeats = table.Column<bool>(type: "bit", nullable: false),
                    Armrests = table.Column<bool>(type: "bit", nullable: false),
                    SportSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    HeatingSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    KeyLessEntry = table.Column<bool>(type: "bit", nullable: false),
                    Webasto = table.Column<bool>(type: "bit", nullable: false),
                    HeatingFrontWindow = table.Column<bool>(type: "bit", nullable: false),
                    ElectricRearWindows = table.Column<bool>(type: "bit", nullable: false),
                    OpeningRoof = table.Column<bool>(type: "bit", nullable: false),
                    ElectricStearingSeats = table.Column<bool>(type: "bit", nullable: false),
                    VentilatedSeats = table.Column<bool>(type: "bit", nullable: false),
                    SportSeats = table.Column<bool>(type: "bit", nullable: false),
                    LeatherSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    MultimediaSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    GearChangingInSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    KeylessGo = table.Column<bool>(type: "bit", nullable: false),
                    RainDetector = table.Column<bool>(type: "bit", nullable: false),
                    ElectricFrontWindows = table.Column<bool>(type: "bit", nullable: false),
                    DigitalKey = table.Column<bool>(type: "bit", nullable: false),
                    Tempomat = table.Column<bool>(type: "bit", nullable: false),
                    ParkAssistant = table.Column<bool>(type: "bit", nullable: false),
                    ParkingCamera = table.Column<bool>(type: "bit", nullable: false),
                    BlindSpotAssistance = table.Column<bool>(type: "bit", nullable: false),
                    SpeedLimiter = table.Column<bool>(type: "bit", nullable: false),
                    ESP = table.Column<bool>(type: "bit", nullable: false),
                    HillHolder = table.Column<bool>(type: "bit", nullable: false),
                    DuskSensor = table.Column<bool>(type: "bit", nullable: false),
                    RearLedLight = table.Column<bool>(type: "bit", nullable: false),
                    StartStopSystem = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSensors = table.Column<bool>(type: "bit", nullable: false),
                    PanoramicCamera360 = table.Column<bool>(type: "bit", nullable: false),
                    ElectronicMirrors = table.Column<bool>(type: "bit", nullable: false),
                    LanneAssist = table.Column<bool>(type: "bit", nullable: false),
                    BrakeAssist = table.Column<bool>(type: "bit", nullable: false),
                    ABS = table.Column<bool>(type: "bit", nullable: false),
                    ActiveRecognizedRoadSigns = table.Column<bool>(type: "bit", nullable: false),
                    DailyLight = table.Column<bool>(type: "bit", nullable: false),
                    LeavingHomeLight = table.Column<bool>(type: "bit", nullable: false),
                    ElectricParkingBrake = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyBrakingAssistant = table.Column<bool>(type: "bit", nullable: false),
                    AirBags = table.Column<bool>(type: "bit", nullable: false),
                    Isofix = table.Column<bool>(type: "bit", nullable: false),
                    ProtectionFromAccidentSystem = table.Column<bool>(type: "bit", nullable: false),
                    CarEquipmentToString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImgGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imgOneUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgTwoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgThreeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgFourUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgFiveUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgSixUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgSevenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgEightUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ABS = table.Column<bool>(type: "bit", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    ImmobilizerTrunk = table.Column<bool>(type: "bit", nullable: false),
                    HeatedGrips = table.Column<bool>(type: "bit", nullable: false),
                    Radio = table.Column<bool>(type: "bit", nullable: false),
                    MotorcycleEquipmentToString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NonStandarVehicle = table.Column<bool>(type: "bit", nullable: false),
                    DoubleRearWheels = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfAxles = table.Column<int>(type: "int", nullable: false),
                    AllowPackage = table.Column<int>(type: "int", nullable: false),
                    PermissibleGrossWeight = table.Column<int>(type: "int", nullable: false),
                    Drive4x4 = table.Column<bool>(type: "bit", nullable: false),
                    ABS = table.Column<bool>(type: "bit", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    CbRadio = table.Column<bool>(type: "bit", nullable: false),
                    CD = table.Column<bool>(type: "bit", nullable: false),
                    CentralLock = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSensor = table.Column<bool>(type: "bit", nullable: false),
                    DVD = table.Column<bool>(type: "bit", nullable: false),
                    ElectrisGlasses = table.Column<bool>(type: "bit", nullable: false),
                    ESP = table.Column<bool>(type: "bit", nullable: false),
                    Immobilizer = table.Column<bool>(type: "bit", nullable: false),
                    Intarder = table.Column<bool>(type: "bit", nullable: false),
                    SleepingCabing = table.Column<bool>(type: "bit", nullable: false),
                    AutomaticAirCondition = table.Column<bool>(type: "bit", nullable: false),
                    OnBoardComputer = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen = table.Column<bool>(type: "bit", nullable: false),
                    Fridge = table.Column<bool>(type: "bit", nullable: false),
                    MiniBar = table.Column<bool>(type: "bit", nullable: false),
                    GPSNAV = table.Column<bool>(type: "bit", nullable: false),
                    Webasto = table.Column<bool>(type: "bit", nullable: false),
                    AirBags = table.Column<bool>(type: "bit", nullable: false),
                    FactoryRadio = table.Column<bool>(type: "bit", nullable: false),
                    NotFactoryRadio = table.Column<bool>(type: "bit", nullable: false),
                    AdjustableSuspension = table.Column<bool>(type: "bit", nullable: false),
                    Retarder = table.Column<bool>(type: "bit", nullable: false),
                    Tachography = table.Column<bool>(type: "bit", nullable: false),
                    CruiseControl = table.Column<bool>(type: "bit", nullable: false),
                    Toilet = table.Column<bool>(type: "bit", nullable: false),
                    TVTuner = table.Column<bool>(type: "bit", nullable: false),
                    MultifunctionSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    TruckEquipmentToString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imported = table.Column<bool>(type: "bit", nullable: false),
                    Damaged = table.Column<bool>(type: "bit", nullable: false),
                    VinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Milage = table.Column<int>(type: "int", nullable: false),
                    VehicleRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDay = table.Column<int>(type: "int", nullable: false),
                    RegMonth = table.Column<int>(type: "int", nullable: false),
                    RegYear = table.Column<int>(type: "int", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CubicCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co2Emision = table.Column<bool>(type: "bit", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstOwner = table.Column<bool>(type: "bit", nullable: false),
                    AsoServiced = table.Column<bool>(type: "bit", nullable: false),
                    Tuning = table.Column<bool>(type: "bit", nullable: false),
                    NoAccident = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredAsMonument = table.Column<bool>(type: "bit", nullable: false),
                    PriceBrutto = table.Column<int>(type: "int", nullable: false),
                    ToNegotiate = table.Column<bool>(type: "bit", nullable: false),
                    VAT = table.Column<bool>(type: "bit", nullable: false),
                    Leasing = table.Column<bool>(type: "bit", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    TruckId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_ImgGallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "ImgGallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarId",
                table: "Vehicles",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_GalleryId",
                table: "Vehicles",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TruckId",
                table: "Vehicles",
                column: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ImgGallery");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
