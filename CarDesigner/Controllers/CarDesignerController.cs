using CarDesigner.BL.DTO;
using CarDesigner.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarDesigner.Controllers;

/// <summary>
/// Получение данных для конструктора авто
/// </summary>
[ApiController]
[Route("carDesigner")]
public class CarDesignerController : ControllerBase
{
    private readonly ILogger<CarDesignerController> _logger;
    
    private readonly ICarDesignerService _service;

    public CarDesignerController(ILogger<CarDesignerController> logger
        , ICarDesignerService carDesigner)
    {
        _logger = logger;
        _service = carDesigner;
    }
    
    /// <summary>
    /// Получение списка каталогов
    /// </summary>
    [HttpGet("catalogs")]
    [SwaggerResponse(statusCode: 200, description: "Получение списка каталогов", type: typeof(IReadOnlyCollection<PartResponseDTO>))]
    public async Task<IActionResult> GetCatalog()
        => Ok(await _service.GetCatalog());
    
    /// <summary>
    /// Получение списка пресетов
    /// </summary>
    [HttpGet("presets")]
    [SwaggerResponse(statusCode: 200, description: "Получение списка пресетов", type: typeof(IReadOnlyCollection<string>))]
    public async Task<IActionResult> GetPresets()
        => Ok(await _service.GetPresets());
    
    /// <summary>
    /// Создание авто по пресету
    /// </summary>
    [HttpPost]
    [SwaggerResponse(statusCode: 200, description: "Создание авто по пресету", type: typeof(CarResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось создать авто по пресету")]
    public async Task<IActionResult> Create([FromQuery] string preset)
    {
        var created = await _service.BuildPreset(preset);
        return created is null ? NotFound() : Ok(created);
    }

}

