using TestTask.Lib.Abstractions;

namespace TestTask.Lib.Models;

public class Triangle : Figure, ICanBeRectangular
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public Triangle(double a, double b, double c)
    {
        if (a <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), "Сторона не может быть меньше или равна 0");
        }
        
        if (b <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(b), "Сторона не может быть меньше или равна 0");
        }
        
        if (c <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(c), "Сторона не может быть меньше или равна 0");
        }

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("Треугольника с такими сторонам не может существовать");
        }
        
        _a = a;
        _b = b;
        _c = c;
    }

    public override double GetSquare()
    {
        var halfPerimeter = (_a + _b + _c) / 2;

        return Math.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
    }

    public bool IsRectangular()
    {
        var sides = new List<double>
        {
            _a, _b, _c
        };

        var hypotenuse = sides.Max();
        if (sides.Count(i => Math.Abs(i - hypotenuse) < 0.01) > 1)
        {
            throw new InvalidOperationException("Треугольник с 2 одинаковыми гипотинузами не может существовать");
        }
        
        sides.Remove(hypotenuse);

        var cathetsSum = sides.Select(i => Math.Pow(i, 2)).Sum();
        var hypotenuseResult = Math.Pow(hypotenuse, 2);

        return Math.Abs(hypotenuseResult - cathetsSum) < 0.01;
    }
}