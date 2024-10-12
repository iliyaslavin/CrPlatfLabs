using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Читання даних з файлу INPUT.TXT
        string[] lines = File.ReadAllLines(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab1\Lab1\INPUT.txt");
        int N = int.Parse(lines[0]); // кількість тестів

        // Перевіряємо, чи достатньо даних для всіх тестів
        if (lines.Length - 1 < N)
        {
            Console.WriteLine("Помилка: кількість тестів перевищує кількість доступних індексів.");
            return;
        }

        var losingPairs = new List<(int, int)>();

        // Генеруємо програшні пари
        for (int a = 0; a <= 109; a++)
        {
            for (int b = 0; b <= a; b++) // b <= a, щоб уникнути дублікатів
            {
                // Програшна позиція: коли сума a + b парна або a == b
                if ((a == b) || ((a + b) % 2 == 0))
                {
                    losingPairs.Add((a, b));
                }
            }
        }

        // Сортуємо всі пари в лексикографічному порядку
        losingPairs.Sort();

        // Проходимо по всіх тестах
        for (int i = 1; i <= N; i++)
        {
            int k = int.Parse(lines[i]); // номер пари для пошуку

            // Виводимо k-ту пару (враховуємо, що індекси починаються з 0)
            if (k < losingPairs.Count)
            {
                var result = losingPairs[k];
                Console.WriteLine($"{result.Item1} {result.Item2}");
            }
            else
            {
                Console.WriteLine("Невірний номер пари");
            }
        }
    }
}