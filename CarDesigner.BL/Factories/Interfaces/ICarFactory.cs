using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories.Interfaces;

public interface ICarFactory
{
    string Name { get; }
    
    string CarType { get; }
    
    Car? BuildCar();
}