using CarDesigner.DAL.Models;

namespace CarDesigner.BL.Builders;

public class CarBuilder
{
    private string _name;
    private Body? _body;
    private List<Engine> _engine;
    private List<Tires> _tires;
    private List<Light> _light;
    
    public CarBuilder Reset()
    {
        _body = null;
        _engine.Clear();
        _tires.Clear();
        _light.Clear();

        return this;
    }
}