using NUnit.Framework;
using TestTask.Lib.Models;

namespace TestProject1.Tests;

[TestFixture]
public class CircleTests
{
    [Test]
    public void GetSquare_Radius5_Return78_53()
    {
        var circle = new Circle(5);
        
        var exceptedResult = 78.53;

        var result = circle.GetSquare();
        Assert.That(result, Is.EqualTo(exceptedResult).Within(0.01));
    }
    
    [Test]
    public void GetSquare_RadiusMinus5_ThrowException()
    {
        Assert.Catch<ArgumentOutOfRangeException>(() =>
        {
            var circle = new Circle(-5);
            var square = circle.GetSquare();
        }, "Исключение не было вызвано");
    }
}