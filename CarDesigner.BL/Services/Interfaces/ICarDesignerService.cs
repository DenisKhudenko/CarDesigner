using CarDesigner.BL.DTO;

namespace CarDesigner.BL.Services.Interfaces;

public interface ICarDesignerService
{
    Task<IReadOnlyCollection<CatalogResponseDTO>> GetCatalog();
    
    Task<IReadOnlyCollection<PresetResponseDTO>> GetPresets();

    Task<BuildRequestDTO?> CreateBuilder(int id);

    Task<BuildResponseDTO?> Build(int id, BuildResponseDTO dto);
    
    Task<BuildResponseDTO?> ResetBuilder(int id);
    
    Task<BuildResponseDTO> Preset(BuildResponseDTO dto);
}