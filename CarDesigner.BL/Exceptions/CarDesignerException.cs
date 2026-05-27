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