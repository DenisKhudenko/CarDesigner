using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders.Interfaces;

public interface ICarBuilder
{
    string Id { get; set; }
    
    string? Name { get; set; }
    
    Body? Body  { get; set; }
    
    List<Part> Engines { get; set; }
    
    List<Part> Tires { get; set; }
    
    List<Part> Lights { get; set; }
    
    CarBuilder SetId (string id);
    
    CarBuilder SetName(string name);
    
    CarBuilder SetBody(string idBody);
    
    CarBuilder AddEngine(string idEngine, int partQuantity = 1);
    
    CarBuilder AddTires(string idTire, int partQuantity = 1);
    
    CarBuilder AddLight(string idLight, int partQuantity = 1);
    
    CarBuilder AddPart(Part part, List<Part> parts, int partQuantity = 1);
    
    CarBuilder Reset();
    
    IReadOnlyCollection<CarDesignerException> Validate();

    Car Build();
}