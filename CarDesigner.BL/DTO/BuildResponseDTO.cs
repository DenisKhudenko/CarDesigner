namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных билдера авто
/// </summary>
public class BuildResponseDTO
{
    /// <summary>
    /// Наименование авто
    /// </summary>
    public string Name;
    
    /// <summary>
    /// Количество лошадиных сил
    /// </summary>
    public int Horsepower;
    
    /// <summary>
    /// Вес авто
    /// </summary>
    public int Weight;
    
    /// <summary>
    /// Цена авто
    /// </summary>
    public int Price;
}