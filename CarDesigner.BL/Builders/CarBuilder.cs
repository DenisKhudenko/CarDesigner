using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders;

public class CarBuilder
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

    public CarBuilder SetBody(Body body)
    {
        _body = body;
        return this;
    }

    public CarBuilder AddEngine(Engine engine, int partQuantity = 1)
    {
        return AddPart(engine, _engines, partQuantity);
    }

    public CarBuilder AddTires(Tires tire, int partQuantity = 1)
    {
        return AddPart(tire, _tires, partQuantity);
    }

    public CarBuilder AddLight(Light light, int partQuantity = 1)
    {
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
}