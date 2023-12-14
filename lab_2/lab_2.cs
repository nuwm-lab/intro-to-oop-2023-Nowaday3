using System;

class PlaneTransformation
{
    double a1, b1, c1, a2, b2, c2;
    public PlaneTransformation(double a1, double b1, double c1, double a2, double b2, double c2)
    {
        this.a1 = a1;
        this.b1 = b1;
        this.c1 = c1;
        this.a2 = a2;
        this.b2 = b2;
        this.c2 = c2;
    }
    public bool ArePointsTransformed(double x, double y, double e, double n)
    {
        double X = a1 * x + b1 * y + c1;
        double Y = a2 * x + b2 * y + c2;
        return (Math.Abs(X - e) < 0.0001) && (Math.Abs(Y - n) < 0.0001);
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Значення a1 = 1, b1 = 0, c1 = 0, a2 = 0, b2 = 1, c2 = 0");
        double a1 = 1;
        double b1 = 0;
        double c1 = 0;
        double a2 = 0;
        double b2 = 1;
        double c2 = 0;
        PlaneTransformation transformation = new PlaneTransformation(a1, b1, c1, a2, b2, c2);
        Console.WriteLine("Введіть координати точки (x, y):");
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть координати точки (epsilon, eta):");
        double e = double.Parse(Console.ReadLine());
        double n = double.Parse(Console.ReadLine());
        bool areTransformed = transformation.ArePointsTransformed(x, y, e, n);
        if (areTransformed)
            Console.WriteLine("Точки перетворюються одна в одну.");
        else
            Console.WriteLine("Точки не перетворюються одна в одну.");
    }
}
