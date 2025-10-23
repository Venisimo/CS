using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem3_laba1cs;

namespace laba1.Tests
{
    [TestClass]
    public class ElScooterTests
    {
        //Конструктор. Рабочие данные - результат не вызывает исключений
        [TestMethod]
        public void ElScooter_Constructor_ValidData_ShouldWork()
        {
            var scooter = new ElScooter("Xiaomi", 80, 50, 3000, 100000);

            Assert.AreEqual("Xiaomi", scooter.Firma);
            Assert.AreEqual(80, scooter.Weight);
            Assert.AreEqual(50, scooter.Speed);
            Assert.AreEqual(3000, scooter.Power);
            Assert.AreEqual(100000, scooter.Price);
        }

        [TestMethod]
        public void ElScooter_Constructor_DefaultValues_ShouldWork()
        {
            var scooter = new ElScooter();

            Assert.AreEqual("Xiaomi", scooter.Firma);
            Assert.AreEqual(80, scooter.Weight);
            Assert.AreEqual(50, scooter.Speed);
            Assert.AreEqual(3000, scooter.Power);
            Assert.AreEqual(100000, scooter.Price);
        }

        //Конструктор. Нерабочие данные - результат должен вызывать исключениеы
        [TestMethod]
        public void ElScooter_Constructor_InvalidWeight_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => new ElScooter("Xiaomi", 50, 50, 3000, 100000));
        }

        [TestMethod]
        public void ElScooter_Constructor_InvalidSpeed_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => new ElScooter("Xiaomi", 80, 10, 3000, 100000));
        }

        [TestMethod]
        public void ElScooter_Constructor_InvalidPrice_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => new ElScooter("Xiaomi", 80, 50, 3000, 10000));
        }

        // ToString
        [TestMethod]
        public void ElScooter_ToString_ShouldReturnCorrectFormat()
        {
            var scooter = new ElScooter("Xiaomi", 80, 50, 3000, 100000);

            var result = scooter.ToString();

            Assert.AreEqual("Электросамокат: Xiaomi, Мощность: 3000, Макс. скорость: 50, Макс. нагрузка: 80, Цена: 100000", result);
        }

        // Print
        [TestMethod]
        public void ElScooter_Print_ShouldOutputToConsole()
        {
            var scooter = new ElScooter("Xiaomi", 80, 50, 3000, 100000);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            scooter.Print();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Производитель: Xiaomi"));
            Assert.IsTrue(output.Contains("Мощность: 3000"));
            Assert.IsTrue(output.Contains("Макс. нагрузка: 80"));
            Assert.IsTrue(output.Contains("Макс. скорость: 50"));
            Assert.IsTrue(output.Contains("Цена: 100000"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        // GetNoChangeOption
        [TestMethod]
        public void Scooter_GetNoChangeOption_ShouldReturnThree()
        {
            var auto = new Auto();

            var result = auto.GetNoChangeOption();

            Assert.AreEqual(6, result);
        }

        // Change
        [TestMethod]
        public void Scooter_Change_ShouldDisplayCorrectOptions()
        {
            var scooter = new ElScooter();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(new StringReader("6"));

            scooter.Change();

            var output = stringWriter.ToString();
            Console.WriteLine($"Вывод метода = {output}");
            Assert.IsTrue(output.Contains("6 - не менять"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        //ChangeMenu
        [TestMethod]
        public void ElScooter_ChangeMenu_ShouldDisplayCorrectOptions()
        {
            var scooter = new ElScooter();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            scooter.ChangeMenu();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("1 - фирму"));
            Assert.IsTrue(output.Contains("2 - мощность"));
            Assert.IsTrue(output.Contains("3 - скорость"));
            Assert.IsTrue(output.Contains("4 - вес"));
            Assert.IsTrue(output.Contains("5 - цена"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }


        //Рабочие данные - результат не вызывает исключений
        [DataTestMethod]
        [DataRow(3, "80", "Speed", 80)]          // скорость
        [DataRow(4, "70", "Weight", 70)]         // нагрузка
        [DataRow(5, "16000", "Price", 16000)]    // цена
        public void Scooter_Change_ValidData_ShouldWork(int choice, string input, string property, object expected)
        {
            var scooter = new ElScooter();
            Console.SetIn(new StringReader(input));
            scooter.Changing(choice);

            var actual = scooter.GetType().GetProperty(property)?.GetValue(scooter);
            Assert.AreEqual(expected, actual);
        }

        //Нерабочие данные - результат должен вызывать исключение
        [DataTestMethod]
        [DataRow(3, "10", typeof(ArgumentException), "Максимальная скорость указана неверно.")]
        [DataRow(3, "210", typeof(ArgumentException), "Максимальная скорость указана неверно.")]
        [DataRow(4, "50", typeof(ArgumentException), "Максимальная нагрузка указана неверно.")]
        [DataRow(4, "200", typeof(ArgumentException), "Максимальная нагрузка указана неверно.")]
        [DataRow(5, "10", typeof(ArgumentException), "Цена указана неверно.")]
        [DataRow(5, "10000000", typeof(ArgumentException), "Цена указана неверно.")]
        public void Scooter_Change_InvalidData_ShouldThrowException(int choice, string input, Type exceptionType, string expectedMessage)
        {
            var scooter = new ElScooter();
            Console.SetIn(new StringReader(input));

            Exception exception;
            if (exceptionType == typeof(ArgumentException))
            {
                exception = Assert.ThrowsException<ArgumentException>(() => scooter.Changing(choice));
            }
            else
            {
                throw new NotImplementedException($"Тип исключения {exceptionType} не поддерживается");
            }

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}
