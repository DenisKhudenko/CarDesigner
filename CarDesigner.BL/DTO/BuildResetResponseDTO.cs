namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных для сброса билдера авто
/// </summary>
public class BuildResetResponseDTO
{
    /// <summary>
    /// Id билдера
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Наименование билдера
    /// </summary>
    public string Name { get; set; } 
}