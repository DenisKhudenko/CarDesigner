
namespace CarDesigner.DAL.Models
{
	public abstract class Part
	{
		// Идентификатор запчасти
		public required string Id { get; init; }

		// Имя запчасти
		public required string Name { get; init; }

		// Вес запчасти
		public required int Weight { get; init; }

		// Стоимость запчасти
		public required int Price { get; init; }
		
		// Тип запчасти
		public required PartType PartType { get; set; }

		// Метод расчета параметров авто
		public abstract void UpdateCarParameters(Car car);
	}

    public class Body : Part
    {
        // Тип кузова
        public required BodyType Type { get; init; }
        
        // Метод расчета параметров авто
        public override void UpdateCarParameters(Car car)
        {
	        car.Weight += Weight;
	        car.Price += Price;
        }
    }

    public class Engine : Part
    {
	    public Engine() { PartType = PartType.Engine; }
	    
        // Мощность в лошадиных силах
        public required int Horsepower { get; init; }

        // Вид топлива
        public required FuelType FuelType { get; init; }

        // Количество цилиндров
        public int Cylinders { get; init; }
        
        // Метод расчета параметров авто
        public override void UpdateCarParameters(Car car)
        {
	        car.Horsepower += Horsepower;
	        car.Weight += Weight;
	        car.Price += Price;
        }
    }

    public class Tires : Part
	{
		public Tires() { PartType = PartType.Tires; }
		
		// Радиус шины
		public required int Radius { get; init; }

		// Тип шины (зимняя, летняя, всесезонная)
		public required TyresType Type { get; init; }
		
		// Метод расчета параметров авто
		public override void UpdateCarParameters(Car car)
		{
			car.Weight += Weight;
			car.Price += Price;
		}
	}

    public class Light : Part
    {
	    public Light() { PartType = PartType.Light; }
	    
        // Тип лампочек
        public required LightType LightType { get; init; }

        // Позиция установки
        public required InstallationPosition Position { get; init; }
        
        // Метод расчета параметров авто
        public override void UpdateCarParameters(Car car)
        {
	        car.Weight += Weight;
	        car.Price += Price;
        }
    }

    public enum PartType
    {
	    Body, // Кузов
	    Engine, // Двигатель
	    Tires, // Колеса
	    Light // Фары
    }

    public enum TyresType
	{
		Summer, // Летняя
		Winter, // Зимняя
		AllSeason, // Всесезонная
		Sport, // Спортивная
		Offroad // Внедорожная
	}

	public enum FuelType
	{
		Petrol, // Бензин
		Diesel, // Дизель
		Electric // Электричество
	}

	public enum LightType
    {
		Galogen, // Галоген
		Xenon, // Ксенон
		LED // Лэд
	}

	public enum InstallationPosition
    {
		Head, // Спереди
		Back // Сзади
	}

	public enum BodyType
	{
		Sedan, // Седан
		Roadster, // Родстер
		Coupe, // Купе
		SUV, // Кроссовер
		Pickup, // Пикап
		Wagon // Универсал 
	}
}