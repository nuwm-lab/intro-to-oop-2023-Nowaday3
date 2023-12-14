using System;

public class DestructibleWork
{
    ~DestructibleWork()
    {
        Console.WriteLine("Деструктор");
    }

    public void Create()
    {
        long[,,] maps = new long[1000, 353, 1];
    }
}

class Transformation
{
    private static int count = 0;
    private int transformationNumber;
    private double coefficientA1, coefficientB1, coefficientC1, coefficientA2, coefficientB2, coefficientC2;

    public Transformation(double a1, double b1, double c1, double a2, double b2, double c2)
    {
        this.coefficientA1 = a1;
        this.coefficientB1 = b1;
        this.coefficientC1 = c1;
        this.coefficientA2 = a2;
        this.coefficientB2 = b2;
        this.coefficientC2 = c2;
        count++;
        transformationNumber = count;
        Console.WriteLine($"Створено перетворення площини #{transformationNumber}");
    }
    // Визначення номерів трансформацій
    public int DetermineTransformation(double epsilon, double eta)
    {
        double x = coefficientA1 * epsilon + coefficientB1 * eta + coefficientC1;
        double y = coefficientA2 * epsilon + coefficientB2 * eta + coefficientC2;
        if (x == epsilon && y == eta)
        {
            Console.WriteLine($"Трансформація #{transformationNumber} переводить точку ({epsilon}, {eta}) в себе.");
            return transformationNumber;
        }
        return -1; // Якщо не відповідає умові
    }
    // Переведення точок одна в одну
    public static void DetermineTransformations(Transformation[] transformations, double x, double y, double epsilon, double eta)
    {
        Console.WriteLine($"Задані точки: ({x}, {y}) та ({epsilon}, {eta})");
        for (int i = 0; i < transformations.Length; i++)
        {
            int result1 = transformations[i].DetermineTransformation(x, y);
            int result2 = transformations[i].DetermineTransformation(epsilon, eta);
            if (result1 != -1 && result2 != -1 && result1 == result2)
            {
                Console.WriteLine($"Трансформація #{i + 1} переводить обидві точки одна в одну.");
            }
            else
            {
                Console.WriteLine($"Трансформація #{i + 1} не переводить обидві точки одна в одну");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        int count;
        Console.WriteLine("Введіть кількість трансформацій:");
        count = Convert.ToInt32(Console.ReadLine());

        Transformation[] transformations = new Transformation[count];
        double a1, b1, c1, a2, b2, c2;
        double x = 0, y = 0, epsilon = 0, eta = 0;

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введіть коефіцієнти для трансформації #{i + 1}");
            Console.WriteLine("Введіть a1:");
            a1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть b1:");
            b1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть c1:");
            c1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть a2:");
            a2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть b2:");
            b2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть c2:");
            c2 = Convert.ToDouble(Console.ReadLine());

            transformations[i] = new Transformation(a1, b1, c1, a2, b2, c2);
        }

        Console.WriteLine("Введіть координати для точок:");
        Console.WriteLine("Введіть x:");
        x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введіть y:");
        y = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введіть epsilon:");
        epsilon = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введіть eta:");
        eta = Convert.ToDouble(Console.ReadLine());
        // Визначення трансформацій які переводять точки одна в одну
        Transformation.DetermineTransformations(transformations, x, y, epsilon, eta);

        for (int i = 0; i < count; i++)
        {
            DestructibleWork destrWork = new DestructibleWork();
            destrWork.Create();
        }
    }
}
