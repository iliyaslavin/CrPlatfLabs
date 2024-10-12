using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Зчитуємо всі рядки з файлу INPUT.TXT 
        string[] inputLines = File.ReadAllLines(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\INPUT.txt");

        // Перша лінія містить кількість покупок
        int N = int.Parse(inputLines[0]);

        // Друга лінія містить часи для одного, двох та трьох покупців у групі
        int[] times = inputLines[1].Split(' ').Select(int.Parse).ToArray();

        // Третя лінія містить номери покупців, які об'єднуються в групи
        int[] customers = inputLines[2].Split(' ').Select(int.Parse).ToArray();

        // Ініціалізуємо змінну для зберігання загального мінімального часу
        int totalTime = 0;

        // Перебираємо кожного покупця у черзі
        for (int i = 0; i < customers.Length; i++)
        {
            // Визначаємо кількість покупців в групі: 1, 2 або 3
            int groupSize = customers[i];

            // В залежності від кількості людей у групі додаємо відповідний час
            if (groupSize == 1)
            {
                totalTime += times[0]; // Ai для 1 покупця
            }
            else if (groupSize == 2)
            {
                totalTime += times[1]; // Bi для 2 покупців
            }
            else if (groupSize == 3)
            {
                totalTime += times[2]; // Ci для 3 покупців
            }
        }

        // Виводимо мінімальний час, за який могли обслужити всіх покупців
        Console.WriteLine(totalTime);

        // Записуємо результат у файл OUTPUT.TXT
        File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\OUTPUT.txt", totalTime.ToString());
    }
}
