using System;

public interface ILinearInequalitiesSystem
{
    void DisplayCoefficients();
    bool CheckSolution(params double[] values);
}
public class LinearInequalitiesSystem : ILinearInequalitiesSystem
{
    private double a11, a12, b1, a21, a22, b2;

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

    public bool CheckSolution(params double[] values)
    {
        if (values.Length < 2)
        {
            throw new ArgumentException("Недостатньо значень для перевірки рішення.");
        }

        bool inequality1 = a11 * values[0] + a12 * values[1] <= b1;
        bool inequality2 = a21 * values[0] + a22 * values[1] <= b2;

        return inequality1 && inequality2;
    }
}
public class ThreeLinearInequalitiesSystem : ILinearInequalitiesSystem
{
    private double a11, a12, a13, b1, a21, a22, a23, b2, a31, a32, a33, b3;

    public ThreeLinearInequalitiesSystem(double a11, double a12, double a13, double b1, double a21, double a22, double a23, double b2, double a31, double a32, double a33, double b3)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.a13 = a13;
        this.b1 = b1;
        this.a21 = a21;
        this.a22 = a22;
        this.a23 = a23;
        this.b2 = b2;
        this.a31 = a31;
        this.a32 = a32;
        this.a33 = a33;
        this.b3 = b3;

        Console.WriteLine("Конструктор системи трьогранної системи нерівностей.");
    }

    public void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти:\n" +
              $"a11: {a11}, a12: {a12}, a13: {a13}, b1: {b1}\n" +
              $"a21: {a21}, a22: {a22}, a23: {a23}, b2: {b2}\n" +
              $"a32: {a32}, a33: {a33}, a31: {a31}, b3: {b3}");
    }

    public bool CheckSolution(params double[] values)
    {
        if (values.Length < 3)
        {
            throw new ArgumentException("Недостатньо значень для перевірки рішення.");
        }

        bool inequality3 = a31 * values[0] + a32 * values[1] + a33 * values[2] <= b3;
        return new LinearInequalitiesSystem(a11, a12, b1, a21, a22, b2).CheckSolution(values[0], values[1]) && inequality3;
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

        ILinearInequalitiesSystem system;
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
