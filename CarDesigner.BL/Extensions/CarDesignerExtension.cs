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
}