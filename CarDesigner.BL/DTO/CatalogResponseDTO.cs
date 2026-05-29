namespace CarDesigner.BL.DTO;

public class CatalogResponseDTO
{
    /// <summary>
    /// Наименование каталога
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание запчасти
    /// </summary>
    public IReadOnlyDictionary<string, PartResponseDTO> Part { get; set; }
}