using CarDesigner.BL.DTO;

namespace CarDesigner.BL.Services.Interfaces;

public interface ICarDesignerService
{
    Task<IReadOnlyCollection<CatalogResponseDTO>> GetCatalog();
    
    Task<IReadOnlyCollection<string>> GetPresets();
    
    Task<CarResponseDTO> BuildPreset(string presetName);

    Task<BuildResponseDTO?> CreateBuilder(BuildRequestDTO dto);

    Task<CarResponseDTO?> Build(int id);
    
    Task<BuildResponseDTO?> ResetBuilder(int id);
}