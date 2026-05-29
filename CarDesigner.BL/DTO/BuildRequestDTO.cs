namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер запроса данных билдера авто
/// </summary>
public class BuildRequestDTO
{
    /// <summary>
    /// Id авто
    /// </summary>
    public string Id { get; set;  }
    
    /// <summary>
    /// Наименование авто
    /// </summary>
    public string Name { get; set;  }
    
    /// <summary>
    /// Id кузова
    /// </summary>
    public string BodyId { get; set;  }
    
    /// <summary>
    /// Лист id двигателей
    /// </summary>
    public IReadOnlyList<string> EngineId { get; set;  }
    
    /// <summary>
    /// Лист id шин
    /// </summary>
    public IReadOnlyList<string> TiresId { get; set;  }
    
    /// <summary>
    /// Лист id фар
    /// </summary>
    public IReadOnlyList<string> LightId { get; set;  }
}