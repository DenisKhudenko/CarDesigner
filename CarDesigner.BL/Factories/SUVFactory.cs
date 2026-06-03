using CarDesigner.BL.Builders;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories;

public class SUVFactory : ICarFactory
{
    public string Name => "SUV";
    
    public string CarType => "suv";
    
    public Car? BuildCar()
    {
        return new CarBuilder()
            .SetName(Name)
            .AddBody(CarType)
            .AddEngine("v8")
            .AddTires("offroad", 4)
            .AddLight("headGalogen", 2)
            .AddLight("backGalogen", 2)
            .Build();
    }
}