using TestTask.Lib.Models;
using static NUnit.Framework.Assert;

namespace TestProject1.Tests;

[TestFixture]
public class TriangleTests
{
    [Test]
    public void GetSquare_Sides5()
    {
        var triangle = new Triangle(5, 5, 5);

        var exceptedResult = 10.82;

        var result= triangle.GetSquare();
        
        That(result, Is.EqualTo(exceptedResult).Within(0.01));
    }
    
    [Test]
    public void GetSquare_SidesMinus5_ThrowException()
    {
        Catch<ArgumentOutOfRangeException>(() =>
        {
            var triangle = new Triangle(-5, -5, -5);
            var square = triangle.GetSquare();
        }, "Исключение не было вызвано");
    }

    [Test]
    public void IsRectangular_Sides3_4_5_ReturnTrue()
    {
        // Пифагорова тройка.
        var triangle = new Triangle(3, 4, 5);

        var isRectangular = triangle.IsRectangular();
        
        IsTrue(isRectangular);
    }

    [Test]
    public void IsRectangular_Sides3_6_4_ReturnFalse()
    {
        var triangle = new Triangle(3, 6, 4);

        var isRectangular = triangle.IsRectangular();
        
        IsFalse(isRectangular);
    }
}