namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер запроса данных билдера авто
/// </summary>
public class BuildRequestDTO
{
    /// <summary>
    /// Id авто
    /// </summary>
    public string Id;
    
    /// <summary>
    /// Наименование авто
    /// </summary>
    public string Name;
    
    /// <summary>
    /// Id кузова
    /// </summary>
    public string BodyId;
    
    /// <summary>
    /// Лист id двигателей
    /// </summary>
    public IReadOnlyList<string> EngineId;
    
    /// <summary>
    /// Лист id шин
    /// </summary>
    public IReadOnlyList<string> TiresId;
    
    /// <summary>
    /// Лист id фар
    /// </summary>
    public IReadOnlyList<string> LightId;
}