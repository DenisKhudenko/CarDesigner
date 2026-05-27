using Microsoft.AspNetCore.Mvc;

namespace CarDesigner.Controllers;

[ApiController]
[Route("[controller]")]
public class CarDesignerController : ControllerBase
{
    private readonly ILogger<CarDesignerController> _logger;
    

    public CarDesignerController(ILogger<CarDesignerController> logger)
    {
        _logger = logger;
    }

}

