namespace CarDesigner.BL.DTO;

/// <summary>
/// Предоставляет маппер ответа данных авто
/// </summary>
public class CarResponseDTO
{
    /// <summary>
    /// Наименование авто
    /// </summary>
    public string Name { get; set;  }
    
    /// <summary>
    /// Количество лошадиных сил
    /// </summary>
    public int Horsepower { get; set;  }
    
    /// <summary>
    /// Вес авто
    /// </summary>
    public int Weight { get; set;  }
    
    /// <summary>
    /// Цена авто
    /// </summary>
    public int Price { get; set;  }    
}