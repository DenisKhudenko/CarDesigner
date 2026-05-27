namespace CarDesigner.DAL.Models.Catalog;

public static class PartsCatalog
{
    // Кузова
    public static readonly IReadOnlyDictionary<string, Body> Bodies = new Dictionary<string, Body>
        {
            ["coupe"] = new()
            {
                Id = "coupe", Name = "Купе",  Weight = 150, Price = 500000, Type = BodyType.Coupe
            },
            ["sedan"] = new()
            {
                Id = "sedan", Name = "Седан", Weight = 180, Price = 700000, Type = BodyType.Sedan
            },
            ["suv"] = new()
            {
                Id = "suv", Name = "Кроссовер", Weight = 250, Price = 1000000, Type = BodyType.SUV
            },
            ["roadster"] = new()
            {
                Id = "roadster", Name = "Родстер", Weight = 110, Price = 400000, Type = BodyType.Roadster
            },
            ["pickup"] = new()
            {
                Id = "pickup", Name = "Пикап", Weight = 280, Price = 850000, Type = BodyType.Pickup
            },
            ["wagon"] = new()
            {
                Id = "wagon", Name = "Универсал", Weight = 200, Price = 750000, Type = BodyType.Wagon
            }
        };
    
    // Двигатели
    public static readonly IReadOnlyDictionary<string, Engine> Engines = new Dictionary<string, Engine>
        {
            ["v4"] = new()
            {
                Id = "v4", Name = "4 цилиндра", Weight = 200, Price = 200000, 
                Horsepower = 150, Cylinders = 4, FuelType = FuelType.Diesel
            },
            ["v6"] = new()
            {
                Id = "v6", Name = "6 цилиндров", Weight = 180, Price = 200000, 
                Horsepower = 280, Cylinders = 6, FuelType = FuelType.Petrol
            },
            ["v8"] = new() { 
                Id = "v8", Name = "8 цилиндров", Weight = 240, Price = 400000, 
                Horsepower = 420, Cylinders = 8, FuelType = FuelType.Petrol 
            },
            ["w16"] = new() { 
                Id = "w16", Name = "16 цилиндров", Weight = 400, Price = 1000000, 
                Horsepower = 1001, Cylinders = 16, FuelType = FuelType.Petrol 
            },
            ["electric"] = new()
            {
                Id = "electric", Name = "Электрический", Weight = 150, Price = 300000, 
                Cylinders = 0, Horsepower = 600, FuelType = FuelType.Electric
            }
        };

    // Шины
    public static readonly IReadOnlyDictionary<string, Tires> Tires = new Dictionary<string, Tires>
        {
            ["sport"] = new()
            {
                Id = "sport", Name = "Спорт", Weight = 30, Price = 120000, Radius = 18, Type = TyresType.Sport
            },
            ["allseason"] = new()
            {
                Id = "allseason", Name = "Всесезонная", Weight = 35, Price = 50000, Type = TyresType.AllSeason, Radius = 16
            },
            ["offroad"] = new()
            {
                Id = "offroad", Name = "Внедорожная", Weight = 50, Price = 30000, Type = TyresType.Offroad, Radius = 16
            },
            ["slick"] = new()
            {
                Id = "slick", Name = "Слик", Weight = 30, Price = 150000, Type = TyresType.Sport, Radius = 20
            },
            ["summer"] = new()
            {
                Id = "summer", Name = "Летняя", Weight = 30, Price = 40000, Type = TyresType.Summer, Radius = 18
            },
            ["winter"] = new()
            {
                Id = "winter", Name = "Зимняя", Weight = 30, Price = 40000, Type = TyresType.Winter, Radius = 18
            }
        };
    
    // Фары
    public static readonly IReadOnlyDictionary<string, Light> Lights = new Dictionary<string, Light>
    {
        ["headGalogen"] = new() { 
            Id = "headGalogen", Name = "Передняя галоген", Weight = 30, Price = 10000, 
            LightType = LightType.Galogen, Position = InstallationPosition.Head 
        },
        ["backGalogen"] = new() { 
            Id = "backGalogen", Name = "Задняя галоген", Weight = 35, Price = 5000, 
            LightType =  LightType.Galogen, Position = InstallationPosition.Back 
        },
        ["headLed"] = new() { 
            Id = "headLed", Name = "Передняя лед", Weight = 50, Price = 50000,
            LightType = LightType.LED, Position = InstallationPosition.Head 
        },
        ["backLed"] = new() { 
            Id = "backLed", Name = "Задняя лед", Weight = 30, Price = 30000,
            LightType = LightType.LED, Position = InstallationPosition.Back 
        },
        ["xenon"] = new()
        {
            Id = "xenon", Name = "Ксенон", Weight = 30, Price = 20000,
            LightType = LightType.Xenon, Position = InstallationPosition.Head
        }
    };
    
}