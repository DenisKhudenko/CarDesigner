
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Builders;

public class CarBuilder : ICarBuilder
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public List<Part> Parts { get; set; } = new List<Part>();

    public CarBuilder SetId(string id)
    {
        Id = id;
        return this;
    }
    
    public CarBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public CarBuilder AddBody(string idBody)
    {
        return AddPart(idBody, PartType.Body);;
    }

    public CarBuilder AddEngine(string idEngine, int partQuantity = 1)
    {
        return AddPart(idEngine, PartType.Engine, partQuantity);
    }

    public CarBuilder AddTires(string idTire, int partQuantity = 1)
    {
        return AddPart(idTire, PartType.Tires, partQuantity);
    }

    public CarBuilder AddLight(string idLight, int partQuantity = 1)
    {
        return AddPart(idLight, PartType.Light, partQuantity);
    }

    public CarBuilder AddPart(string id, PartType type, int partQuantity = 1)
    {
        var part = GetPart(type, id);
        for (int i = 0; i < partQuantity; i++) Parts.Add(part);
        return this;    
    }
    
    public CarBuilder Reset()
    {
        Name = null;
        Parts.Clear();

        return this;
    }
    
    public IReadOnlyCollection<CarDesignerException> Validate()
    {
        var errors = new List<CarDesignerException>();
        if (!CheckPartInBuilder(PartType.Body)) errors.Add(new MissingRequiredPartException("Кузов"));
        if (!CheckPartInBuilder(PartType.Engine)) errors.Add(new MissingRequiredPartException("Двигатель"));
        if (!CheckPartInBuilder(PartType.Tires)) errors.Add(new MissingRequiredPartException("Колеса"));
        
        return errors;
    }
    
    public Car? Build()
    {
        var errors = Validate();
        if (errors.Count > 0) throw errors.FirstOrDefault();
        
        Car car = new Car()
        {
            Id = Guid.NewGuid().ToString(),
            Name = Name,
            Parts = new List<Part>().Concat(Parts).ToList()
        };

        // Обновляем параметры в новом авто
        foreach (var part in car.Parts)
        {
            if (part == null) continue;
            part.UpdateCarParameters(car);    
        }
        
        return car;
    }
    
    private Part? GetPart(PartType type, string id)
    {
        var dictionary = PartsCatalog.getDictionary();
        if (!dictionary.ContainsKey(type)) throw new PartNotFoundException(id, type.ToString());

        return dictionary[type].GetValueOrDefault(id);
    }
    
    private bool CheckPartInBuilder(PartType type)
    {
        return Parts.FirstOrDefault(part => part.PartType == type) != null;
    }
}