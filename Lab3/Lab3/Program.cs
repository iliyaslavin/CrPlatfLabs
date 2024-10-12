using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Читання даних з файлу INPUT.TXT
        string[] inputLines = File.ReadAllLines(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\INPUT.txt");

        // Перший рядок містить розміри поля
        string[] dimensions = inputLines[0].Split(' ');
        int N = int.Parse(dimensions[0]); // Кількість рядків
        int M = int.Parse(dimensions[1]); // Кількість стовпців

        // Решта рядків - це поле гри
        char[,] grid = new char[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                grid[i, j] = inputLines[i + 1][j];
            }
        }

        // Змінні для підрахунку кораблів
        int intactShips = 0;
        int hitShips = 0;
        int sunkShips = 0;

        // Допоміжна матриця для відвіданих клітинок
        bool[,] visited = new bool[N, M];

        // Функція для обробки корабля
        void ProcessShip(int x, int y, ref bool hasHits, ref bool hasIntact)
        {
            // Виходимо за межі або клітинка вже відвідана
            if (x < 0 || x >= N || y < 0 || y >= M || visited[x, y] || grid[x, y] == '-')
                return;

            // Відзначаємо клітинку як відвідану
            visited[x, y] = true;

            // Перевіряємо тип клітинки
            if (grid[x, y] == 'X')
            {
                hasHits = true; // Є підбиті клітини
            }
            else if (grid[x, y] == 'S')
            {
                hasIntact = true; // Є непідбиті клітини
            }

            // Рекурсивно обходимо всіх сусідів
            ProcessShip(x + 1, y, ref hasHits, ref hasIntact);
            ProcessShip(x - 1, y, ref hasHits, ref hasIntact);
            ProcessShip(x, y + 1, ref hasHits, ref hasIntact);
            ProcessShip(x, y - 1, ref hasHits, ref hasIntact);
        }

        // Основна логіка підрахунку кораблів
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if ((grid[i, j] == 'S' || grid[i, j] == 'X') && !visited[i, j])
                {
                    bool hasHits = false;
                    bool hasIntact = false;

                    // Обробляємо корабель
                    ProcessShip(i, j, ref hasHits, ref hasIntact);

                    // Якщо всі клітини підбиті — знищений корабель
                    if (hasHits && !hasIntact)
                    {
                        sunkShips++;
                    }
                    // Якщо є підбиті і непідбиті — підбитий корабель
                    else if (hasHits && hasIntact)
                    {
                        hitShips++;
                    }
                    // Якщо всі клітини непідбиті — цілий корабель
                    else if (!hasHits && hasIntact)
                    {
                        intactShips++;
                    }
                }
            }
        }




        // Виводимо результат
        string result = $"{intactShips} {hitShips} {sunkShips}";
        Console.WriteLine(result); // Діагностика в консоль
        File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\OUTPUT.txt", result);
    }
}
