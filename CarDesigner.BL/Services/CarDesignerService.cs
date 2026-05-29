using CarDesigner.BL.Builders;
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.DTO;
using CarDesigner.BL.Extensions;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.BL.Services.Interfaces;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Services;

public class CarDesignerService : ICarDesignerService
{
    private readonly IPresetFactory _presetFactory;
    private readonly Dictionary<string, ICarBuilder> _builders;
    
    public CarDesignerService(IPresetFactory factory, BuilderStorage builderStorage)
    {
        _presetFactory = factory;
        _builders = builderStorage.Builders;
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
        var builder = dto.CreateBuilderFromRequestDTO();
        _builders.Add(builder.Id, builder);

        return await Task.FromResult(builder.MapCarBuilderToResponseDTO());
    }

    public async Task<BuildResponseDTO?> AddToBuilder(BuildRequestDTO dto)
    {
        _builders.TryGetValue(dto.Id, out var builder);
        if (builder is null) return null;
        
        return await Task.FromResult(builder.AddToBuilderFromRequestDTO(dto).MapCarBuilderToResponseDTO());
    }

    public async Task<CarResponseDTO?> Build(string id)
    {
        _builders.TryGetValue(id, out var builder);
        if (builder is null) return null;

        var result = builder.Build().MapCarToResponseDTO();
        return await Task.FromResult(result);
    }

    public async Task<BuildResetResponseDTO> ResetBuilder(string id)
    {
        _builders.TryGetValue(id, out var builder);
        if (builder is null) return null;

        var result = builder.Reset().MapBuilderResetToResponseDTO();
        return await Task.FromResult(result);
    }
}