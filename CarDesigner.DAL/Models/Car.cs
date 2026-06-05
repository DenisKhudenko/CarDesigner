
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
		public int Horsepower { get; set; }

		// Вес
		public int Weight { get; set; }

		// Стоимость
		public int Price { get; set; }
	}
}

