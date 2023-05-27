using TestTask.Lib.Abstractions;

namespace TestTask.Lib.Models;

public class Circle : Figure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Радиус не может быть меньше 0");
        }
        
        _radius = radius;
    }

    public override double GetSquare()
    {
        return Math.PI * (_radius * _radius);
    }
}