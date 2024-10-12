using Xunit;
using Lab1; // Простір імен, у якому знаходиться клас Program

namespace Lab1.Tests
{
    public class Lab1Tests
    {
        [Fact]
        public void Test_LosingPairs_FirstPair()
        {
            // Налаштовуємо вхідні дані для тесту
            var expectedPair = (0, 0); // Очікувана перша пара

            // Викликаємо метод
            var result = Program.GetLosingPair(0);

            // Перевіряємо результат
            Assert.Equal(expectedPair, result);
        }

        [Fact]
        public void Test_LosingPairs_SecondPair()
        {
            // Тестуємо іншу пару
            var expectedPair = (1, 1);
            var result = Program.GetLosingPair(1);
            Assert.Equal(expectedPair, result);
        }
    }
}
