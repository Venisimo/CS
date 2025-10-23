using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Sem3_laba1cs;

namespace laba1.Tests
{
    [TestClass]
    public class TransportTests
    {
        //Конструктор. Рабочие данные - результат не вызывает исключений
        [TestMethod]
        public void Transport_Constructor_ValidData_ShouldWork()
        {
            var transport = new Transport("BMW", 1000);

            Assert.AreEqual("BMW", transport.Firma);
            Assert.AreEqual(1000, transport.Power);
        }

        [TestMethod]
        public void Transport_Constructor_DefaultValues_ShouldWork()
        {
            var transport = new Transport();

            Assert.AreEqual("Firma", transport.Firma);
            Assert.AreEqual(500, transport.Power);
        }

        //Конструктор. Нерабочие данные - результат должен вызывать исключение
        [DataTestMethod]
        // Невалидный вес
        [DataRow("Xiaomi", 50, 50, 3000, 100000, typeof(ArgumentException), "Максимальная нагрузка указана неверно.")]
        [DataRow("Xiaomi", 151, 50, 3000, 100000, typeof(ArgumentException), "Максимальная нагрузка указана неверно.")]

        // Невалидная скорость
        [DataRow("Xiaomi", 80, 10, 3000, 100000, typeof(ArgumentException), "Максимальная скорость указана неверно.")]
        [DataRow("Xiaomi", 80, 100, 3000, 100000, typeof(ArgumentException), "Максимальная скорость указана неверно.")]

        // Невалидная цена
        [DataRow("Xiaomi", 80, 50, 3000, 10000, typeof(ArgumentException), "Цена указана неверно.")]
        [DataRow("Xiaomi", 80, 50, 3000, 250000, typeof(ArgumentException), "Цена указана неверно.")]
        public void ElScooter_Constructor_InvalidData_ShouldThrowException(string firma, int weight, int speed, int power, int price, Type exceptionType, string expectedMessage)
        {
            Exception exception;
            
            if (exceptionType == typeof(ArgumentException))
            {
                exception = Assert.ThrowsException<ArgumentException>(() => new ElScooter(firma, weight, speed, power, price));
            }
            else
            {
                throw new NotImplementedException($"Тип исключения {exceptionType} не поддерживается");
            }

            StringAssert.Contains(exception.Message, expectedMessage);
        }

        //ToString
        [TestMethod]
        public void Transport_ToString_ShouldReturnCorrectFormat()
        {
            var transport = new Transport("BMW", 1000);

            var result = transport.ToString();

            Assert.AreEqual("Транспорт: BMW, Мощность: 1000", result);
        }

        //Print
        [TestMethod]
        public void Transport_Print_ShouldOutputToConsole()
        {
            var transport = new Transport("Audi", 1500);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            transport.Print();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Производитель: Audi"));
            Assert.IsTrue(output.Contains("Мощность: 1500"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        //ChangeMenu
        [TestMethod]
        public void Transport_ChangeMenu_ShouldDisplayCorrectOptions()
        {
            var transport = new Transport();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            transport.ChangeMenu();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("1 - фирму"));
            Assert.IsTrue(output.Contains("2 - мощность"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        // GetNoChangeOption
        [TestMethod]
        public void Transport_GetNoChangeOption_ShouldReturnThree()
        {
            var transport = new Transport();

            var result = transport.GetNoChangeOption();

            Assert.AreEqual(3, result);
        }

        // Change
        [TestMethod]
        public void Transport_Change_ShouldDisplayCorrectOptions()
        {
            var transport = new Transport();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(new StringReader("3")); 

            transport.Change(); 

            var output = stringWriter.ToString();
            Console.WriteLine($"Вывод метода = {output}");
            Assert.IsTrue(output.Contains("3 - не менять"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        //Changing. Рабочие данные - результат не вызывает исключений
        [DataTestMethod]
        [DataRow(1, "BMW", "Firma", "BMW")]        // фирма
        [DataRow(2, "1000", "Power", 1000)]        // мощность
        public void Transport_Change_ValidData_ShouldWork(int choice, string input, string property, object expected)
        {
            var transport = new Transport();
            Console.SetIn(new StringReader(input));
            transport.Changing(choice);

            var actual = transport.GetType().GetProperty(property)?.GetValue(transport);
            Assert.AreEqual(expected, actual);
        }

        //Changing. Нерабочие данные - результат должен вызывать исключение
        [DataTestMethod]
        [DataRow(1, "", typeof(ArgumentNullException), "Название фирмы не может быть пустым! (Parameter 'Фирма')")]
        [DataRow(1, "    ", typeof(ArgumentNullException), "Название фирмы не может быть пустым! (Parameter 'Фирма')")]
        [DataRow(1, "A", typeof(ArgumentException), "Название фирмы должно быть от 2 до 20 символов.")]
        [DataRow(1, "TooooooooooooooooLong", typeof(ArgumentException), "Название фирмы должно быть от 2 до 20 символов.")]
        [DataRow(2, "100", typeof(ArgumentException), "Мощность указана неверно.")]
        [DataRow(2, "4000", typeof(ArgumentException), "Мощность указана неверно.")]
        public void Transport_Change_InvalidData_ShouldThrowException(int choice, string input, Type exceptionType, string expectedMessage)
        {
            var transport = new Transport();
            Console.SetIn(new StringReader(input));
            Exception exception;

            if (exceptionType == typeof(ArgumentNullException))
            {
                exception = Assert.ThrowsException<ArgumentNullException>(() => transport.Changing(choice));
            }
            else if (exceptionType == typeof(ArgumentException))
            {
                exception = Assert.ThrowsException<ArgumentException>(() => transport.Changing(choice));
            }
            else
            {
                throw new NotImplementedException($"Тип исключения {exceptionType} не поддерживается");
            }

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}