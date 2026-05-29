
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;
using CarDesigner.DAL.Models.Catalog;

namespace CarDesigner.BL.Builders;

public class CarBuilder : ICarBuilder
{
    private string? _name;
    private Body? _body;
    private List<Part> _engines;
    private List<Part> _tires;
    private List<Part> _lights;

    public CarBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CarBuilder SetBody(string idBody)
    {
        _body = (Body?) GetPart("body", idBody);
        return this;
    }

    public CarBuilder AddEngine(string idEngine, int partQuantity = 1)
    {
        var engine = (Engine?) GetPart("engine", idEngine);
        return AddPart(engine, _engines, partQuantity);
    }

    public CarBuilder AddTires(string idTire, int partQuantity = 1)
    {
        var tire = (Tires?) GetPart("tires", idTire);
        return AddPart(tire, _tires, partQuantity);
    }

    public CarBuilder AddLight(string idLight, int partQuantity = 1)
    {
        var light = (Light?) GetPart("light", idLight);
        return AddPart(light, _lights, partQuantity);
    }

    public CarBuilder AddPart(Part part, List<Part> parts, int partQuantity = 1)
    {
        for (int i = 0; i < partQuantity; i++) parts.Add(part);
        return this;    
    }
    
    public CarBuilder Reset()
    {
        _name = null;
        _body = null;
        _engines.Clear();
        _tires.Clear();
        _lights.Clear();

        return this;
    }
    
    public IReadOnlyList<CarDesignerException> Validate()
    {
        var errors = new List<CarDesignerException>();
        if (_body == null) errors.Add(new MissingRequiredPartException("Кузов"));
        if (_engines.Count == 0) errors.Add(new MissingRequiredPartException("Двигатель"));
        if (_tires.Count == 0) errors.Add(new MissingRequiredPartException("Колеса"));
        
        return errors;
    }
    
    public Car? Build()
    {
        var errors = Validate();
        if (errors.Count > 0) throw errors[0];
        
        return new Car()
        {
            Id = Guid.NewGuid().ToString(),
            Name = _name,
            Horsepower = CalcHorsepower(),
            Weight = CalcWeight(),
            Price = CalcPrice(),
            Parts = new List<Part>()
                .Union(_engines)
                .Union(_tires)
                .Union(_lights)
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
        return _engines.OfType<Engine>().Sum(x => x.Horsepower);
    }
    
    private int CalcWeight()
    {
        return _body.Weight 
               + new List<Part>()
                    .Union(_engines)
                    .Union(_tires)
                    .Union(_lights)
                    .Sum(x => x.Weight);
    }
    
    private int CalcPrice()
    {
        return _body.Price 
               + new List<Part>()
                   .Union(_engines)
                   .Union(_tires)
                   .Union(_lights)
                   .Sum(x => x.Price);
    }
}