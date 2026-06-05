using CarDesigner.BL.Builders;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories;

public class SportcarFactory : ICarFactory
{
    public string Name => "Sport car";
    
    public string CarType => "sport";
    
    public Car? BuildCar()
    {
        return new CarBuilder()
            .SetName(Name)
            .AddBody(CarType)
            .AddEngine("w16")
            .AddTires("sport", 4)
            .AddLight("headLed", 2)
            .AddLight("backLed", 2)
            .Build();
    }
}