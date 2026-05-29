using CarDesigner.BL.DTO;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Extensions;

public static class CarDesignerExtension
{
    public static CatalogResponseDTO MapDictionaryPartToCatalogResponseDto(
        this IReadOnlyDictionary<string, Part> dictionary, string name)
    {
        return PartResponseFromPart(name, dictionary);
    }
    
    public static CarResponseDTO MapCarToResponseDTO(this Car car)
    {
        return CarResponseFromCar(car);
    }

    private static CatalogResponseDTO PartResponseFromPart(string name, IReadOnlyDictionary<string, Part>  dictionary)
    {
        return new CatalogResponseDTO
        {
            Name = name,
            Part = dictionary.ToDictionary(kvp => kvp.Key,
                kvp => new PartResponseDTO()
                {
                    Id = kvp.Value.Id,
                    Name = kvp.Value.Name,
                    Price = kvp.Value.Price,
                    Weight = kvp.Value.Weight  
                })
        };
    }

    private static CarResponseDTO CarResponseFromCar(Car car)
    {
        return new CarResponseDTO()
        {
            Name = car.Name,
            Horsepower = car.Horsepower,
            Weight = car.Weight,
            Price = car.Price
        };
    }
}