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
    [HttpGet]
    [SwaggerResponse(statusCode: 200, description: "Получение списка прогнозов погоды", type: typeof(IReadOnlyCollection<PartResponseDTO>))]
    public async Task<IActionResult> GetCatalog()
        => Ok(await _service.GetCatalog());

}

