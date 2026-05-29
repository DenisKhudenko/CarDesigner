
using CarDesigner.BL.Builders;
using CarDesigner.BL.Exceptions;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories
{
	
	public class PresetFactory: IPresetFactory
	{
		public Car? BuildSportCar()
		{
			return new CarBuilder()
				.SetName("Sport car")
				.SetBody("coupe")
				.AddEngine("w16")
				.AddTires("sport", 4)
				.AddLight("headLed", 2)
				.AddLight("backLed", 2)
				.Build();
		}
		
		public Car? BuildSUVCar()
		{
			return new CarBuilder()
				.SetName("SUV car")
				.SetBody("suv")
				.AddEngine("v8")
				.AddTires("offroad", 4)
				.AddLight("headGalogen", 2)
				.AddLight("backGalogen", 2)
				.Build();
		}
		
		public Car? BuildCoupeCar()
		{
			return new CarBuilder()
				.SetName("Coupe car")
				.SetBody("coupe")
				.AddEngine("v6")
				.AddTires("summer", 4)
				.AddLight("Xenon", 2)
				.AddLight("backGalogen", 2)
				.Build();
		}

		public IReadOnlyDictionary<string, Delegate> getFactoryDictionary()
		{
			return new Dictionary<string, Delegate>()
			{
				["sport"] = BuildSportCar,
				["suv"] = BuildSUVCar,
				["coupe"] = BuildCoupeCar
			};	
		}
		
		public Car? Create(string carType)
		{
			var dictionary = getFactoryDictionary();
			if (!dictionary.ContainsKey(carType)) throw new UndefinedCarTypeException(carType);

			return dictionary[carType].Target as Car;
		}
	}
}