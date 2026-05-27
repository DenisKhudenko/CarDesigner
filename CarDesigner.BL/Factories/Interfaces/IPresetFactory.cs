namespace CarDesigner.BL.Factories.Interfaces;

public interface IPresetFactory
{
    IBuildingCar Create(string name);
}