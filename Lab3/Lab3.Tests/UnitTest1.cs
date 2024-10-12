using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;
using Xunit;

namespace Lab3.Tests
{
    public class Lab3Tests
    {
        [Fact]
        public void Test_SingleIntactShip()
        {
            // Arrange: налаштовуємо вхідні дані
            string input = "3 8\n---SSS--\n--XX--S-\n-SXXS--S\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\INPUT.txt", input);

            // Act: запускаємо програму
            Program.Main(new string[0]);

            // Assert: перевіряємо, що результат правильний
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\OUTPUT.txt");
            Assert.Equal("2 1 1", output.Trim());
        }

        [Fact]
        public void Test_MultipleShips()
        {
            // Arrange
            string input = "3 8\n---SSS--\n--XXSXX-\n-S---S--\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\INPUT.txt", input);

            // Act
            Program.Main(new string[0]);

            // Assert
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\OUTPUT.txt");
            Assert.Equal("1 2 0", output.Trim());
        }

        [Fact]
        public void Test_AllSunkShips()
        {
            // Arrange
            string input = "3 8\n---XX---\n--XX--X-\n-XXXXXX-\n";
            File.WriteAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\INPUT.txt", input);

            // Act
            Program.Main(new string[0]);

            // Assert
            string output = File.ReadAllText(@"C:\Users\Elijah Soul\Desktop\KNU MATERAL\3курс 1сем\кросплатформа\Labs\Lab3\Lab3\OUTPUT.txt");
            Assert.Equal("0 0 3", output.Trim());
        }
    }
}
