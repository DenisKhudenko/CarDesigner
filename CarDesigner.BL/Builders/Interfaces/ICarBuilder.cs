using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders.Interfaces;

public interface ICarBuilder
{
    string Id { get; set; }
    
    string? Name { get; set; }
    
    List<Part> Parts { get; set; }
    
    CarBuilder SetId (string id);
    
    CarBuilder SetName(string name);
    
    CarBuilder AddBody(string idBody);
    
    CarBuilder AddEngine(string idEngine, int partQuantity = 1);
    
    CarBuilder AddTires(string idTire, int partQuantity = 1);
    
    CarBuilder AddLight(string idLight, int partQuantity = 1);
    
    CarBuilder AddPart(string id, PartType type, int partQuantity = 1);
    
    CarBuilder Reset();
    
    IReadOnlyCollection<CarDesignerException> Validate();

    Car Build();
}