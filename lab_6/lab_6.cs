using System;

public abstract class AbstractLinearInequalitiesSystem
{
    protected double a11, a12, b1, a21, a22, b2;
    public AbstractLinearInequalitiesSystem(double a11, double a12, double b1, double a21, double a22, double b2)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.b1 = b1;
        this.a21 = a21;
        this.a22 = a22;
        this.b2 = b2;
        Console.WriteLine("Конструктор системи лінійних нерівностей.");
    }
    public virtual void DisplayCoefficients()
    {
        Console.WriteLine("Коефіцієнти:");
        Console.WriteLine($"a11: {a11}, a12: {a12}, b1: {b1}");
        Console.WriteLine($"a21: {a21}, a22: {a22}, b2: {b2}");
    }
    public virtual bool CheckSolution(double x1, double x2)
    {
        bool inequality1 = a11 * x1 + a12 * x2 <= b1;
        bool inequality2 = a21 * x1 + a22 * x2 <= b2;

        return inequality1 && inequality2;
    }
}
public class LinearInequalitiesSystem : AbstractLinearInequalitiesSystem
{
    public LinearInequalitiesSystem(double a11, double a12, double b1, double a21, double a22, double b2)
        : base(a11, a12, b1, a21, a22, b2)
    {
    }
}
public class ThreeLinearInequalitiesSystem : AbstractLinearInequalitiesSystem
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
    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти:\n" +
              $"a11: {a11}, a12: {a12}, a13: {a13}, b1: {b1}\n" +
              $"a21: {a21}, a22: {a22}, a23: {a23}, b2: {b2}\n" +
              $"a32: {a32}, a33: {a33}, a31: {a31}, b3: {b3}");
    }
    public bool CheckSolution(double x1, double x2, double x3)
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
        Console.Write("Напишіть '1' якщо хочете працювати з двовимірною системою рівнянь, або '2' " +
            "якщо з тригранною системою : ");
        char userChoose = Console.ReadLine()[0];

        AbstractLinearInequalitiesSystem system;
        if (userChoose == '1')
        {
            system = new LinearInequalitiesSystem(2, -1, 3, -3, 1, 5);
        }
        else
        {
            system = new ThreeLinearInequalitiesSystem(2, -1, 1, 8, -3, 1, -2, 6, 1, -2, 1, 10);
        }
        system.DisplayCoefficients();
        Console.Write("Введіть значення для x1: ");
        double userX1 = double.Parse(Console.ReadLine());
        Console.Write("Введіть значення для x2: ");
        double userX2 = double.Parse(Console.ReadLine());
        if (system is ThreeLinearInequalitiesSystem threeDSystem)
        {
            Console.Write("Введіть значення для x3: ");
            double userX3 = double.Parse(Console.ReadLine());
            if (threeDSystem.CheckSolution(userX1, userX2, userX3))
            {
                Console.WriteLine("Введений вектор задовольняє систему нерівностей.");
            }
            else
            {
                Console.WriteLine("Введений вектор не задовольняє систему нерівностей.");
            }
        }
        else
        {
            if (system.CheckSolution(userX1, userX2))
            {
                Console.WriteLine("Введений вектор задовольняє систему нерівностей.");
            }
            else
            {
                Console.WriteLine("Введений вектор не задовольняє систему нерівностей.");
            }
        }
    }
}
