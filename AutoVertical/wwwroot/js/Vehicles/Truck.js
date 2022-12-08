class Truck extends Vehicle{
    constructor(){
        super();
        this.brands = [
            "Mercedes-Benz",
            "MAN",
            "Volvo",
            "Scania",
            "Isuzu",
            "Tata",
            "Iveco",
            "DAF",
            "Ford",
            "RAM TRUCKS",
            "Chevrolet",
          ]
        this.fuel = ["Petrol","LPG","CNG","Diesel","Electric","LNG"] ;
        this.gearBox = ["Automatic","Manual"];
        this.bodyType = ["Box","Cab and chassis","Chassis-mounted camper","Crew cab","Crew-cab service truck","Cube van","Dump","Extended cab"]
}
}