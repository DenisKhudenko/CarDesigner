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
    [HttpPost("createCarFromPreset")]
    [SwaggerResponse(statusCode: 200, description: "Создание авто по пресету", type: typeof(CarResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось создать авто по пресету")]
    public async Task<IActionResult> CreateCarFromPreset([FromQuery] string preset)
    {
        var created = await _service.BuildPreset(preset);
        return created is null ? NotFound() : Ok(created);
    }
    
    /// <summary>
    /// Создание билдера авто
    /// </summary>
    [HttpPost("createBuilder")]
    [SwaggerResponse(statusCode: 200, description: "Создание билдера авто", type: typeof(BuildResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось создать билдер авто")]
    public async Task<IActionResult> CreateBuilder([FromBody] BuildRequestDTO dto)
    {
        var created = await _service.CreateBuilder(dto);
        return created is null ? NotFound() : Ok(created);
    }
    
    /// <summary>
    /// Дополнение билдера авто
    /// </summary>
    [HttpPost("addToBuilder")]
    [SwaggerResponse(statusCode: 200, description: "Дополнение билдера авто", type: typeof(BuildResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось дополнить билдер авто")]
    public async Task<IActionResult> AddToBuilder([FromBody] BuildRequestDTO dto)
    {
        var created = await _service.AddToBuilder(dto);
        return created is null ? NotFound() : Ok(created);
    }
    
    /// <summary>
    /// Запуск сборки билдера
    /// </summary>
    [HttpPost("build")]
    [SwaggerResponse(statusCode: 200, description: "Запуск билдера авто", type: typeof(CarResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось запустить билдер авто")]
    public async Task<IActionResult> Build([FromQuery] string id)
    {
        var created = await _service.Build(id);
        return created is null ? NotFound() : Ok(created);
    }
    
    /// <summary>
    /// Сброс билдера авто
    /// </summary>
    [HttpPost("resetBuilder")]
    [SwaggerResponse(statusCode: 200, description: "Сброс билдера авто", type: typeof(BuildResetResponseDTO))]
    [SwaggerResponse(statusCode: 404, description: "Ошибка, не удалось сбросить билдер авто")]
    public async Task<IActionResult> ResetBuilder([FromQuery] string id)
    {
        var created = await _service.ResetBuilder(id);
        return created is null ? NotFound() : Ok(created);
    }

}

