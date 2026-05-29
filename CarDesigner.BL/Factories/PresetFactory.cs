
using CarDesigner.BL.Exceptions;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories
{
	public class PresetFactory: IPresetFactory
	{
		private readonly IReadOnlyDictionary<string, ICarFactory> _factories;

		public PresetFactory(IEnumerable<ICarFactory> factories)
		{
			_factories = factories.ToDictionary(f => f.CarType);	
		}
		
		public Car? Create(string carType)
		{
			if (!_factories.TryGetValue(carType, out var factory))
				throw new UndefinedCarTypeException(carType);
			
			return factory.BuildCar();
		}

		public IReadOnlyCollection<string> GetPressets() => _factories.Keys.ToList();
	}
}