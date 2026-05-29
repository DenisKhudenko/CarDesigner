
namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных билдера авто
/// </summary>
public class BuildResponseDTO
{
    /// <summary>
    /// Наименование билдера
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Маппер данных кузова авто
    /// </summary>
    public PartResponseDTO Body  { get; set; }
    
    /// <summary>
    /// Лист маппера двигателей
    /// </summary>
    public IReadOnlyList<PartResponseDTO> Engines  { get; set; }
    
    /// <summary>
    /// Лист маппера колес
    /// </summary>
    public IReadOnlyList<PartResponseDTO> Tires   { get; set; }
    
    /// <summary>
    /// Лист маппера фар
    /// </summary>
    public IReadOnlyList<PartResponseDTO> Lights  { get; set; }
}