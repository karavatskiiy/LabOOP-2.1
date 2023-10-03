using System;
using System.Linq;

class Program
{
    static double Function1(double x)
    {
        if (x <= 2)
        {
            Console.WriteLine("Помилка: x має бути більше за 2");
            return double.NaN;
        }
        return Math.Sqrt(Math.Log(x * x - 4));
    }

    static void Завдання1()
    {
        Console.WriteLine("Завдання 1: Обчислити y = √(ln(x^2-4))");
        Console.WriteLine("Введіть значення x:");
        double x = double.Parse(Console.ReadLine());
        double result1 = Function1(x);
        Console.WriteLine($"Результат: y = {result1}");
    }

    static int[] Function2(int n, int[][] matrix)
    {
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int lastNegativeIndex = -1;
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] < 0)
                {
                    lastNegativeIndex = j;
                }
                else if (lastNegativeIndex != -1)
                {
                    result[i] += matrix[i][j];
                }
            }

            if (lastNegativeIndex == -1)
            {
                result[i] = -1;
            }
        }

        return result;
    }

    static void Завдання2()
    {
        Console.WriteLine("Завдання 2: Побудувати послідовність b_k для матриці");
        Console.WriteLine("Введіть розмір матриці n:");
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть рядок {i + 1} матриці (через пробіл):");
            matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
        int[] result2 = Function2(n, matrix);
        Console.WriteLine("Результат: b_k = " + string.Join(", ", result2));
    }

    static (int, int) ReduceFraction(int numerator, int denominator)
    {
        int gcd = GCD(numerator, denominator);
        return (numerator / gcd, denominator / gcd);
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static (int, int) AddRationalNumbers((int, int) fraction1, (int, int) fraction2)
    {
        int numerator = fraction1.Item1 * fraction2.Item2 + fraction2.Item1 * fraction1.Item2;
        int denominator = fraction1.Item2 * fraction2.Item2;
        return ReduceFraction(numerator, denominator);
    }

    static (int, int) MultiplyRationalNumbers((int, int) fraction1, (int, int) fraction2)
    {
        int numerator = fraction1.Item1 * fraction2.Item1;
        int denominator = fraction1.Item2 * fraction2.Item2;
        return ReduceFraction(numerator, denominator);
    }

    static void Завдання3()
    {
        Console.WriteLine("Завдання 3: Визначити функцію скорочення та операції з раціональними числами");

        Console.WriteLine("Введіть чисельник і знаменник першого раціонального числа:");
        int numerator1 = int.Parse(Console.ReadLine());
        int denominator1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть чисельник і знаменник другого раціонального числа:");
        int numerator2 = int.Parse(Console.ReadLine());
        int denominator2 = int.Parse(Console.ReadLine());

        (int, int) result3a = ReduceFraction(numerator1, denominator1);
        (int, int) result3b = AddRationalNumbers((numerator1, denominator1), (numerator2, denominator2));
        (int, int) result3c = MultiplyRationalNumbers((numerator1, denominator1), (numerator2, denominator2));

        Console.WriteLine($"Результат (скорочення): {result3a.Item1}/{result3a.Item2}");
        Console.WriteLine($"Результат (додавання): {result3b.Item1}/{result3b.Item2}");
        Console.WriteLine($"Результат (множення): {result3c.Item1}/{result3c.Item2}");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // укр мова

        Console.WriteLine("Оберіть завдання:");
        Console.WriteLine("1. Обчислити y = √(ln(x^2-4))");
        Console.WriteLine("2. Побудувати послідовність b_k для матриці");
        Console.WriteLine("3. Визначити функцію скорочення та операції з раціональними числами");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Завдання1();
                break;

            case 2:
                Завдання2();
                break;

            case 3:
                Завдання3();
                break;

            default:
                Console.WriteLine("Неправильний вибір завдання.");
                break;
        }
    }
}
