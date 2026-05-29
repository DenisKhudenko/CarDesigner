using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories.Interfaces;

public interface IPresetFactory
{
    Car? Create(string carType);

    IReadOnlyCollection<string> GetPressets();
}