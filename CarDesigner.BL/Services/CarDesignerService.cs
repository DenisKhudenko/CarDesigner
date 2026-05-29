using CarDesigner.BL.DTO;
using CarDesigner.BL.Extensions;
using CarDesigner.BL.Services.Interfaces;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Services;

public class CarDesignerService : ICarDesignerService
{
    public async Task<IReadOnlyCollection<CatalogResponseDTO>> GetCatalog()
    {
        var result = PartsCatalog.getDictionary()
            .Select(kvp => kvp.Value.MapDictionaryPartToCatalogResponseDto(kvp.Key))
            .ToList();
        
        return await Task.FromResult(result);
    }

    public Task<IReadOnlyCollection<PresetResponseDTO>> GetPresets()
    {
        throw new NotImplementedException();
    }

    public Task<BuildRequestDTO?> CreateBuilder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BuildResponseDTO?> Build(int id, BuildResponseDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<BuildResponseDTO?> ResetBuilder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BuildResponseDTO> Preset(BuildResponseDTO dto)
    {
        throw new NotImplementedException();
    }
}