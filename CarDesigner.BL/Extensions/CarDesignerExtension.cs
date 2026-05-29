using CarDesigner.BL.Builders;
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.DTO;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Extensions;

public static class CarDesignerExtension
{
    public static CatalogResponseDTO MapDictionaryPartToCatalogResponseDto(
        this IReadOnlyDictionary<string, Part> dictionary, string name)
    {
        return PartResponseFromCatalog(name, dictionary);
    }
    
    public static CarResponseDTO MapCarToResponseDTO(this Car car)
    {
        return CarResponseFromCar(car);
    }
    
    public static BuildResponseDTO MapCarBuilderToResponseDTO(this ICarBuilder carBuilder)
    {
        return CarBuilderResponseFromCarBuilder(carBuilder);
    }
    
    public static PartResponseDTO MapPartToResponseDTO(this Part part)
    {
        return PartResponseFromPart(part);
    }
    
    public static BuildResetResponseDTO MapBuilderResetToResponseDTO(this ICarBuilder carBuilder)
    {
        return new BuildResetResponseDTO(){ Id = carBuilder.Id, Name = carBuilder.Name };
    }

    public static ICarBuilder CreateBuilderFromRequestDTO(this BuildRequestDTO buildRequest)
    {
        CarBuilder carBuilder = new CarBuilder();
        return carBuilder.AddToBuilderFromRequestDTO(buildRequest);
    }
    
    public static ICarBuilder AddToBuilderFromRequestDTO(this ICarBuilder carBuilder, BuildRequestDTO buildRequest)
    {
        carBuilder
            .SetName(buildRequest.Name)
            .SetId(buildRequest.Id)
            .SetBody(buildRequest.BodyId);

        foreach (var engineId in buildRequest.EngineId)
        {
            carBuilder.AddEngine(engineId);    
        }
        
        foreach (var tireId in buildRequest.TiresId)
        {
            carBuilder.AddTires(tireId);    
        }
        
        foreach (var lightId in buildRequest.LightId)
        {
            carBuilder.AddLight(lightId);    
        }
        
        return carBuilder;
    }

    private static CatalogResponseDTO PartResponseFromCatalog(string name, IReadOnlyDictionary<string, Part>  dictionary)
    {
        return new CatalogResponseDTO
        {
            Name = name,
            Part = dictionary.ToDictionary(kvp => kvp.Key,
                kvp => PartResponseFromPart(kvp.Value))
        };
    }
    
    private static PartResponseDTO PartResponseFromPart(Part part)
    {
        return new PartResponseDTO()
        {
            Id = part.Id,
            Name = part.Name,
            Price = part.Price,
            Weight = part.Weight
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
    
    private static BuildResponseDTO CarBuilderResponseFromCarBuilder(ICarBuilder carBuilder)
    {
        return new BuildResponseDTO()
        {
            Id = carBuilder.Id,
            Name = carBuilder.Name,
            Body = carBuilder.Body.MapPartToResponseDTO(),
            Engines = carBuilder.Engines.Select(part => part.MapPartToResponseDTO()).ToList(),
            Tires = carBuilder.Tires.Select(part => part.MapPartToResponseDTO()).ToList(),
            Lights = carBuilder.Lights.Select(part => part.MapPartToResponseDTO()).ToList()
        };
    }
}