
namespace CarDesigner.DAL.Models
{
	public class Car
	{
        // Идентификатор машины
        public required string Id { get; init; }

		// Идентификатор машины
		public required string Name { get; init; }

		// Список запчастей
		public IReadOnlyList<Part> Parts { get; init; }

		// Мощность в лошадиных силах
		public int Horsepower { get; init; }

		// Вес
		public int Weight { get; init; }

		// Стоимость
		public int Price { get; init; }
	}
}

