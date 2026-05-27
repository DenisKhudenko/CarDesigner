namespace CarDesigner.BL.Exceptions;

public class CarDesignerException : Exception
{
    public string Code { get; init; }
    
    public CarDesignerException(string message, string code)
    {
        Code = code;
    }
}

public class MissingRequiredPartException : CarDesignerException
{
    public string PartName { get; init; }
    
    public MissingRequiredPartException(string partName) 
        : base($"Обязательная деталь отсутствует: {partName}", "MissingRequiredPart")
    {
        PartName = partName;            
    }
}

public class PartNotFoundException : CarDesignerException
{
    public string PartId { get; init; }
    public string CategoryName { get; init; }
    
    public PartNotFoundException(string partId, string categoryName) 
        : base($"Деталь {partId} не найдена в каталоге: {categoryName}", "PartNotFound")
    {
        PartId = partId; 
        CategoryName = categoryName;
    }
}

public class UndefinedCarTypeException : CarDesignerException
{
    public string CarType { get; init; }
    
    public UndefinedCarTypeException(string carType) 
        : base($"Неизвестный тип авто {carType}", "UndefinedCarType")
    {
        CarType = carType;
    }
}