
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
	}

    public class Body : Part
    {
        // Тип кузова
        public required BodyType Type { get; init; }
    }

    public class Engine : Part
    {
        // Мощность в лошадиных силах
        public required int Horsepower { get; init; }

        // Вид топлива
        public required FuelType FuelType { get; init; }

        // Количество цилиндров
        public int Cylinders { get; init; }
    }

    public class Tires : Part
	{
		// Радиус шины
		public required int Radius { get; init; }

		// Тип шины (зимняя, летняя, всесезонная)
		public required TyresType Type { get; init; }
	}

    public class Light : Part
    {
        // Тип лампочек
        public required LightType LightType { get; init; }

        // Позиция установки
        public required InstallationPosition Position { get; init; }
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