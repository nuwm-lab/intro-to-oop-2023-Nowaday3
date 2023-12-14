using System;

public class LinearInequalitiesSystem
{
    protected double a11, a12, b1, a21, a22, b2;

    public LinearInequalitiesSystem(double a11, double a12, double b1, double a21, double a22, double b2)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.b1 = b1;
        this.a21 = a21;
        this.a22 = a22;
        this.b2 = b2;
        Console.WriteLine("Конструктор системи лінійних нерівностей.");
    }
    public void DisplayCoefficients()
    {
        Console.WriteLine("Коефіцієнти:");
        Console.WriteLine($"a11: {a11}, a12: {a12}, b1: {b1}");
        Console.WriteLine($"a21: {a21}, a22: {a22}, b2: {b2}");
    }
    public bool CheckSolution(double x1, double x2)
    {
        bool inequality1 = a11 * x1 + a12 * x2 <= b1;
        bool inequality2 = a21 * x1 + a22 * x2 <= b2;

        return inequality1 && inequality2;
    }
}
public class ThreeLinearInequalitiesSystem : LinearInequalitiesSystem
{
    private double a13, a23, a31, a32, a33, b3;

    public ThreeLinearInequalitiesSystem(double a11, double a12, double a13, double b1, double a21, double a22, double a23, double b2, double a31, double a32, double a33, double b3)
        : base(a11, a12, b1, a21, a22, b2)
    {
        this.a13 = a13;
        this.a23 = a23;
        this.a31 = a31;
        this.a32 = a32;
        this.a33 = a33;
        this.b3 = b3;

        Console.WriteLine("Конструктор системи трьогранної системи нерівностей.");
    }

    public new bool CheckSolution(double x1, double x2, double x3)
    {
        bool inequality3 = a31 * x1 + a32 * x2 + a33 * x3 <= b3;
        return base.CheckSolution(x1, x2) && inequality3;
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        ThreeLinearInequalitiesSystem system3D = new ThreeLinearInequalitiesSystem(2, -1, 1, 8, -3, 1, -2, 6, 1, -2, 1, 3);
        system3D.DisplayCoefficients();
        Console.Write("Введіть значення для x1: ");
        double userX1 = double.Parse(Console.ReadLine());
        Console.Write("Введіть значення для x2: ");
        double userX2 = double.Parse(Console.ReadLine());
        Console.Write("Введіть значення для x3: ");
        double userX3 = double.Parse(Console.ReadLine());

        if (system3D.CheckSolution(userX1, userX2, userX3))
        {
            Console.WriteLine("Введений вектор задовольняє систему нерівностей.");
        }
        else
        {
            Console.WriteLine("Введений вектор не задовольняє систему нерівностей.");
        }
    }
}
