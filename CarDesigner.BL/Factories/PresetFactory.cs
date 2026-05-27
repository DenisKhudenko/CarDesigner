
using CarDesigner.BL.Builders;
using CarDesigner.BL.Exceptions;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Factories
{
	public class CreateSportCar: IBuildingCar
	{
		public Car? BuildCar(string name)
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
	}
	
	public class CreateSUVCar: IBuildingCar
	{
		public Car? BuildCar(string name)
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
	}
	
	public class CreateCoupeCar: IBuildingCar
	{
		public Car? BuildCar(string name)
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
	}
	
	public class PresetFactory: IPresetFactory
	{
		public IBuildingCar Create(string carType) => carType.ToLower() switch
		{
			"sport" => new CreateSportCar(),
			"suv" => new CreateSUVCar(),
			"coupe" => new CreateCoupeCar(),
			_ => throw new UndefinedCarTypeException(carType)
		};
	}
}