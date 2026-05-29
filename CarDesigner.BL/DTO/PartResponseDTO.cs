namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных билдера запчастей
/// </summary>
public class PartResponseDTO
{
    /// <summary>
    /// Id запчасти
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Наименование запчасти
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Вес запчасти
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Стоимость запчасти
    /// </summary>
    public int Price { get; set; }
}