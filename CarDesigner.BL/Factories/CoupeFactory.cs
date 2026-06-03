using CarDesigner.BL.Builders;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories;

public class CoupeFactory : ICarFactory
{
    public string Name => "Coupe";
    public string CarType => "coupe";

    public Car? BuildCar()
    {
        return new CarBuilder()
            .SetName(Name)
            .AddBody(CarType)
            .AddEngine("v6")
            .AddTires("summer", 4)
            .AddLight("xenon", 2)
            .AddLight("backGalogen", 2)
            .Build();
    }
}