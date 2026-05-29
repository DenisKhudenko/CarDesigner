
namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных билдера авто
/// </summary>
public class BuildResponseDTO
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
    /// Маппер данных кузова авто
    /// </summary>
    public PartResponseDTO? Body  { get; set; }
    
    /// <summary>
    /// Лист маппера двигателей
    /// </summary>
    public IReadOnlyCollection<PartResponseDTO?> Engines  { get; set; }
    
    /// <summary>
    /// Лист маппера колес
    /// </summary>
    public IReadOnlyCollection<PartResponseDTO?> Tires   { get; set; }
    
    /// <summary>
    /// Лист маппера фар
    /// </summary>
    public IReadOnlyCollection<PartResponseDTO?> Lights  { get; set; }
}