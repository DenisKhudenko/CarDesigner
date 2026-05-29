
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Builders;

public class CarBuilder : ICarBuilder
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public Body? Body { get; set; }
    public List<Part> Engines { get; set; }
    public List<Part> Tires { get; set; }
    public List<Part> Lights { get; set; }

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

    public CarBuilder SetBody(string idBody)
    {
        Body = (Body?) GetPart("body", idBody);
        return this;
    }

    public CarBuilder AddEngine(string idEngine, int partQuantity = 1)
    {
        if (Engines == null) Engines = new List<Part>();
        
        var engine = (Engine?) GetPart("engine", idEngine);
        return AddPart(engine, Engines, partQuantity);
    }

    public CarBuilder AddTires(string idTire, int partQuantity = 1)
    {
        if (Tires == null) Tires = new List<Part>();
        
        var tire = (Tires?) GetPart("tire", idTire);
        return AddPart(tire, Tires, partQuantity);
    }

    public CarBuilder AddLight(string idLight, int partQuantity = 1)
    {
        if (Lights == null) Lights = new List<Part>();
        
        var light = (Light?) GetPart("light", idLight);
        return AddPart(light, Lights, partQuantity);
    }

    public CarBuilder AddPart(Part part, List<Part> parts, int partQuantity = 1)
    {
        for (int i = 0; i < partQuantity; i++) parts.Add(part);
        return this;    
    }
    
    public CarBuilder Reset()
    {
        Name = null;
        Body = null;
        Engines.Clear();
        Tires.Clear();
        Lights.Clear();

        return this;
    }
    
    public IReadOnlyCollection<CarDesignerException> Validate()
    {
        var errors = new List<CarDesignerException>();
        if (Body == null) errors.Add(new MissingRequiredPartException("Кузов"));
        if (Engines.Count == 0) errors.Add(new MissingRequiredPartException("Двигатель"));
        if (Tires.Count == 0) errors.Add(new MissingRequiredPartException("Колеса"));
        
        if(Engines.Contains(null)) errors.Add(new PartNotFoundException("null", "Двигатели"));
        if(Tires.Contains(null)) errors.Add(new PartNotFoundException("null", "Шины"));
        if(Lights.Contains(null)) errors.Add(new PartNotFoundException("null", "Фары"));
        
        return errors;
    }
    
    public Car? Build()
    {
        var errors = Validate();
        if (errors.Count > 0) throw errors.FirstOrDefault();
        
        return new Car()
        {
            Id = Guid.NewGuid().ToString(),
            Name = Name,
            Horsepower = CalcHorsepower(),
            Weight = CalcWeight(),
            Price = CalcPrice(),
            Parts = new List<Part>()
                .Union(Engines)
                .Union(Tires)
                .Union(Lights)
                .ToList()
        };
    }
    
    private Part? GetPart(string type, string id)
    {
        var dictionary = PartsCatalog.getDictionary();
        if (!dictionary.ContainsKey(type)) throw new PartNotFoundException(id, type);

        return dictionary[type].GetValueOrDefault(id);
    }

    private int CalcHorsepower()
    {
        return Engines.OfType<Engine>().Sum(x => x.Horsepower);
    }
    
    private int CalcWeight()
    {
        return Body.Weight 
               + new List<Part>()
                    .Union(Engines)
                    .Union(Tires)
                    .Union(Lights)
                    .Sum(x => x.Weight);
    }
    
    private int CalcPrice()
    {
        return Body.Price 
               + new List<Part>()
                   .Union(Engines)
                   .Union(Tires)
                   .Union(Lights)
                   .Sum(x => x.Price);
    }
}