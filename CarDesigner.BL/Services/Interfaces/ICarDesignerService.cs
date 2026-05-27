using CarDesigner.BL.DTO;

namespace CarDesigner.BL.Services.Interfaces;

public interface ICarDesignerService
{
    Task<IReadOnlyCollection<PartResponse>> GetCatalog();

    Task<BuildRequest?> CreateBuilder(int id);

    Task<BuildResponse> Preset(BuildResponse dto);

    Task<BuildResponse?> Build(int id, BuildResponse dto);
}