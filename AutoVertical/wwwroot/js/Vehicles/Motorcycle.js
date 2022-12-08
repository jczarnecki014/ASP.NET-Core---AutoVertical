class Motorcycle extends Vehicle{
    constructor(){
        super();
        this.brands = [
            "Aprillia",
            "BMW",
            "Ducati",
            "Harley Davidson",
            "Honda",
            "KTM",
            "MV Agusta",
            "Suzuki",
            "Yamacha",
          ]
        this.fuel = ["Petrol","Diesel","Electric"] ;
        this.numberOfDoors = ["3 - Doors", "5 - Doors"];
        this.gearBox = ["Automatic","Stepless","Manual","Semi-automatic"];
        this.drive = ["Chain","Drive belt","Cardan shaft"];
        this.bodyType = ["Chopper","Cruiser","Enduro","Cross","Motoped","Naked","Quad","Scooter","Sport","Tourist"];
}

}