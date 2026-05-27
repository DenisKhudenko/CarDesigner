using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders;

public class CarBuilder
{
    private string? _name;
    private Body? _body;
    private List<Engine> _engine;
    private List<Tires> _tires;
    private List<Light> _light;

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

    public CarBuilder AddEngine(Engine engine)
    {
        _engine.Add(engine);
        return this;
    }

    public CarBuilder AddTires(Tires tires)
    {
        _tires.Add(tires);
        return this;
    }

    public CarBuilder AddLight(Light light)
    {
        _light.Add(light);
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
        return 0;
    }
    
    private int CalcWeight()
    {
        return 0;
    }
    
    private int CalcPrice()
    {
        return 0;
    }

    public bool Validate()
    {
        return true;
    }
    
    public Car? Build()
    {
        bool validated = Validate();
        if (!validated) return null;
        
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