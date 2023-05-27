using TestTask.Lib.Abstractions;

namespace TestTask.Lib.Models;

public class Triangle : Figure
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
        var hypotenuse = Math.Max(_a, Math.Max(_b, _c));
        
        // Можно заменить на if
        var cathets = new List<double>
        {
            _a, _b, _c
        };
        cathets.Remove(hypotenuse);

        var cathetsSum = Math.Pow(cathets[0], 2) + Math.Pow(cathets[1], 2);
        var hypotenuseResult = Math.Pow(hypotenuse, 2);

        return Math.Abs(hypotenuseResult - cathetsSum) < 0.01;
    }
}