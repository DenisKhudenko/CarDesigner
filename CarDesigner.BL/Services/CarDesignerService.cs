using CarDesigner.BL.DTO;
using CarDesigner.BL.Extensions;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.BL.Services.Interfaces;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Services;

public class CarDesignerService : ICarDesignerService
{
    private readonly IPresetFactory _presetFactory;
    
    public CarDesignerService(IPresetFactory factory)
    {
        _presetFactory = factory;
    }
    
    public async Task<IReadOnlyCollection<CatalogResponseDTO>> GetCatalog()
    {
        var result = PartsCatalog.getDictionary()
            .Select(kvp => kvp.Value.MapDictionaryPartToCatalogResponseDto(kvp.Key))
            .ToList();
        
        return await Task.FromResult(result);
    }

    public async Task<IReadOnlyCollection<string>> GetPresets()
    {
        var result = _presetFactory.GetPressets()
            .Select(key => key)
            .ToList();

        return await Task.FromResult(result);
    }

    public async Task<CarResponseDTO> BuildPreset(string presetName)
    {
        var result = _presetFactory.Create(presetName);
        if (result is null) return null;
        
        return await Task.FromResult(result.MapCarToResponseDTO());
    }
    
    public async Task<BuildResponseDTO?> CreateBuilder(BuildRequestDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<CarResponseDTO?> Build(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BuildResponseDTO?> ResetBuilder(int id)
    {
        throw new NotImplementedException();
    }
}