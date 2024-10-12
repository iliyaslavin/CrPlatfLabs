using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.IO;
using Xunit;

namespace Lab2.Tests
{
    public class Lab2Tests
    {
        [Fact]
        public void Test_SingleCustomer()
        {
            // Arrange: Налаштовуємо вхідні дані
            string input = "1\n55 10 155\n1\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\INPUT.txt", input);

            // Act: Викликаємо основну програму
            Program.Main(new string[0]);

            // Assert: Перевіряємо, що результат правильний
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\OUTPUT.txt");
            Assert.Equal("55", output.Trim());
        }

        [Fact]
        public void Test_TwoCustomers()
        {
            // Arrange
            string input = "2\n55 10 155\n1 2\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\INPUT.txt", input);

            // Act
            Program.Main(new string[0]);

            // Assert
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\OUTPUT.txt");
            Assert.Equal("65", output.Trim());
        }

        [Fact]
        public void Test_ThreeCustomers()
        {
            // Arrange
            string input = "3\n55 10 155\n1 2 3\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\INPUT.txt", input);

            // Act
            Program.Main(new string[0]);

            // Assert
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab2\Lab2\OUTPUT.txt");
            Assert.Equal("220", output.Trim());
        }
    }
}
