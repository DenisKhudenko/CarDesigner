namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных билдера запчастей
/// </summary>
public class PartResponse
{
    /// <summary>
    /// Id запчасти
    /// </summary>
    public string Id;
    
    /// <summary>
    /// Наименование запчасти
    /// </summary>
    public string Name;
    
    /// <summary>
    /// Вес запчасти
    /// </summary>
    public int Weight;
    
    /// <summary>
    /// Стоимость запчасти
    /// </summary>
    public int Price;
}