using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories.Interfaces;

public interface IBuildingCar
{
    Car BuildCar(string name);
}