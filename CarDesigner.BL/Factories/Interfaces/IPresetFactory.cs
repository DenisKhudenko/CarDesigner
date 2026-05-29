using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories.Interfaces;

public interface IPresetFactory
{
    public Car? Create(string name);
}