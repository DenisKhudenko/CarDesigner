namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер запроса данных билдера авто
/// </summary>
public class BuildRequestDTO
{
    /// <summary>
    /// Id билдера
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Наименование билдера
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Id кузова
    /// </summary>
    public string? BodyId { get; set; }
    
    /// <summary>
    /// Лист id двигателей
    /// </summary>
    public IReadOnlyCollection<string?> EngineId { get; set; }
    
    /// <summary>
    /// Лист id шин
    /// </summary>
    public IReadOnlyCollection<string?> TiresId { get; set; }
    
    /// <summary>
    /// Лист id фар
    /// </summary>
    public IReadOnlyCollection<string?> LightId { get; set; }
}