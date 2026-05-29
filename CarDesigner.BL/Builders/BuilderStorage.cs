using System.Collections.Immutable;
using CarDesigner.BL.Builders.Interfaces;

namespace CarDesigner.BL.Builders;

public class BuilderStorage
{
    public Dictionary<string, ICarBuilder> Builders { get; } = new();
}