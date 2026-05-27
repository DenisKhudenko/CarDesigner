using CarDesigner.BL.Exceptions;
using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders;

public class CarBuilder
{
    private string? _name;
    private Body? _body;
    private List<Engine> _engine = new List<Engine>();
    private List<Tires> _tires = new List<Tires>();
    private List<Light> _light = new List<Light>();

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
        for (int i = 0; i < partQuantity; i++) _engine.Add(engine);    
        return this;
    }

    public CarBuilder AddTires(Tires tires, int partQuantity = 1)
    {
        for (int i = 0; i < partQuantity; i++) _tires.Add(tires);
        return this;
    }

    public CarBuilder AddLight(Light light, int partQuantity = 1)
    {
        for (int i = 0; i < partQuantity; i++) _light.Add(light);
        return this;
    }
    
    public CarBuilder Reset()
    {
        _name = null;
        _body = null;
        _engine.Clear();
        _tires.Clear();
        _light.Clear();

        return this;
    }

    private int CalcHorsepower()
    {
        return _engine.Sum(x => x.Horsepower);
    }
    
    private int CalcWeight()
    {
        return _body.Weight 
               + new List<Part>()
                    .Union(_engine)
                    .Union(_tires)
                    .Union(_light)
                    .Sum(x => x.Weight);
    }
    
    private int CalcPrice()
    {
        return _body.Price 
               + new List<Part>()
                   .Union(_engine)
                   .Union(_tires)
                   .Union(_light)
                   .Sum(x => x.Price);
    }

    public IReadOnlyList<CarDesignerException> Validate()
    {
        var errors = new List<CarDesignerException>();
        if (_body == null) errors.Add(new MissingRequiredPartException("Кузов"));
        if (_engine.Count == 0) errors.Add(new MissingRequiredPartException("Двигатель"));
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
                .Union(_engine)
                .Union(_tires)
                .Union(_light)
                .ToList()
        };
    }
}