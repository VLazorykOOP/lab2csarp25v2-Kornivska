using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть завдання (1-4):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: Task1(); break;
            case 2: Task2(); break;
            case 3: Task3(); break;
            case 4: Task4(); break;
            default: Console.WriteLine("Невірний вибір."); break;
        }
    }

    // Завдання 1
    static void Task1()
    {
        Console.Write("Введіть розмірність масиву: ");
        int size = int.Parse(Console.ReadLine());

        // Одновимірний масив
        double[] array1D = new double[size];
        Console.WriteLine("Введіть елементи одновимірного масиву:");
        for (int i = 0; i < size; i++)
            array1D[i] = double.Parse(Console.ReadLine());

        double sum1D = 0;
        int count1D = 0;
        foreach (double num in array1D)
        {
            if (num < 0)
            {
                sum1D += num;
                count1D++;
            }
        }

        Console.WriteLine("Середнє від’ємних (1D): " + (count1D > 0 ? sum1D / count1D : 0));

        // Двовимірний масив
        Console.Write("Введіть кількість стовпців для 2D масиву: ");
        int cols = int.Parse(Console.ReadLine());

        double[,] array2D = new double[size, cols];
        Console.WriteLine("Введіть елементи двовимірного масиву:");
        for (int i = 0; i < size; i++)
            for (int j = 0; j < cols; j++)
                array2D[i, j] = double.Parse(Console.ReadLine());

        double sum2D = 0;
        int count2D = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < cols; j++)
                if (array2D[i, j] < 0)
                {
                    sum2D += array2D[i, j];
                    count2D++;
                }

        Console.WriteLine("Середнє від’ємних (2D): " + (count2D > 0 ? sum2D / count2D : 0));
    }

    // Завдання 2
    static void Task2()
    {
        Console.Write("Введіть розмірність масиву: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
            arr[i] = double.Parse(Console.ReadLine());

        double min = arr[0];
        int index = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
                index = i;
            }
        }

        Console.WriteLine($"Індекс першого мінімального елемента: {index}");
    }

    // Завдання 3
    static void Task3()
    {
        Console.Write("Введіть розмірність n (n x n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] array = new int[n, n];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                array[i, j] = int.Parse(Console.ReadLine());

        if (n % 2 == 0)
        {
            int mid1 = n / 2 - 1;
            int mid2 = n / 2;
            for (int j = 0; j < n; j++)
            {
                int temp = array[mid1, j];
                array[mid1, j] = array[mid2, j];
                array[mid2, j] = temp;
            }
        }
        else
        {
            int mid = n / 2;
            for (int j = 0; j < n; j++)
            {
                int temp = array[0, j];
                array[0, j] = array[mid, j];
                array[mid, j] = temp;
            }
        }

        Console.WriteLine("Масив після заміни рядків:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(array[i, j] + "\t");
            Console.WriteLine();
        }
    }

    // Завдання 4
    static void Task4()
    {
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        List<List<int>> jagged = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Скільки елементів у рядку {i + 1}: ");
            int m = int.Parse(Console.ReadLine());
            List<int> row = new List<int>();
            Console.WriteLine($"Введіть {m} елементів:");
            for (int j = 0; j < m; j++)
                row.Add(int.Parse(Console.ReadLine()));
            jagged.Add(row);
        }

        int maxCols = 0;
        foreach (var row in jagged)
            maxCols = Math.Max(maxCols, row.Count);

        List<int?> firstPositives = new List<int?>();

        for (int col = 0; col < maxCols; col++)
        {
            int? firstPositive = null;
            for (int row = 0; row < n; row++)
            {
                if (col < jagged[row].Count && jagged[row][col] > 0)
                {
                    firstPositive = jagged[row][col];
                    break;
                }
            }
            firstPositives.Add(firstPositive);
        }

        Console.WriteLine("Перші додатні елементи по кожному стовпцю:");
        foreach (var val in firstPositives)
            Console.Write((val.HasValue ? val.Value.ToString() : "немає") + "\t");
    }
}
