using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem3_laba1cs;

namespace laba1.Tests
{
    [TestClass]
    public class AutoTests
    {

        //Конструктор. Рабочие данные - результат не вызывает исключений
        [TestMethod]
        public void Auto_Constructor_ValidData_ShouldWork()
        {
            var auto = new Auto("BMW", "X5", 1000, 200, 343);

            Assert.AreEqual("BMW", auto.Firma);
            Assert.AreEqual(1000, auto.Power);
            Assert.AreEqual("X5", auto.Model);
            Assert.AreEqual(200, auto.Volume_bak);
            Assert.AreEqual(343, auto.Number);
        }

        [TestMethod]
        public void Auto_Constructor_DefaultValues_ShouldWork()
        {
            var auto = new Auto();

            Assert.AreEqual("Audi", auto.Firma);
            Assert.AreEqual(500, auto.Power);
            Assert.AreEqual("Q7", auto.Model);
            Assert.AreEqual(100, auto.Volume_bak);
            Assert.AreEqual(123, auto.Number);
        }

        //Конструктор. Нерабочие данные - результат должен вызывать исключение
        [DataTestMethod]
        // Невалидная модель
        [DataRow("BMW", "", 500, 60, 123, typeof(ArgumentNullException), "Название модели не может быть пустым!")]
        [DataRow("BMW", "   ", 500, 60, 123, typeof(ArgumentNullException), "Название модели не может быть пустым!")]
        [DataRow("BMW", "A", 500, 60, 123, typeof(ArgumentException), "Название модели должно быть от 2 до 15 символов.")]
        [DataRow("BMW", "ToooooooooooLong", 500, 60, 123, typeof(ArgumentException), "Название модели должно быть от 2 до 15 символов.")]

        // Невалидный объем бака
        [DataRow("BMW", "X5", 500, 10, 123, typeof(ArgumentException), "Введено некорректное значение объема бака.")]
        [DataRow("BMW", "X5", 500, 210, 123, typeof(ArgumentException), "Введено некорректное значение объема бака.")]

        // Невалидный номер
        [DataRow("BMW", "X5", 500, 60, 10, typeof(ArgumentException), "Номер введен неверно.")]
        [DataRow("BMW", "X5", 500, 60, 1000, typeof(ArgumentException), "Номер введен неверно.")]
        public void Auto_Constructor_InvalidData_ShouldThrowException(string firma, string model, int power, int volume, int number, Type exceptionType, string expectedMessage)
        {
            Exception exception;

            if (exceptionType == typeof(ArgumentNullException))
            {
                exception = Assert.ThrowsException<ArgumentNullException>(() => new Auto(firma, model, power, volume, number));
            }
            else if (exceptionType == typeof(ArgumentException))
            {
                exception = Assert.ThrowsException<ArgumentException>(() => new Auto(firma, model, power, volume, number));
            }
            else
            {
                throw new NotImplementedException($"Тип исключения {exceptionType} не поддерживается");
            }

            StringAssert.Contains(exception.Message, expectedMessage);
        }

        //ToString
        [TestMethod]
        public void Auto_ToString_ShouldReturnCorrectFormat()
        {
            var auto = new Auto("BMW", "X5", 1000, 200, 343);

            var result = auto.ToString();

            Assert.AreEqual("Машина: BMW, Модель: X5, Мощность: 1000, Номер: 343, Объем бака: 200", result);
        }

        //Print
        [TestMethod]
        public void Auto_Print_ShouldOutputToConsole()
        {
            var auto = new Auto("BMW", "X5", 1000, 200, 343);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            auto.Print();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("Производитель: BMW"));
            Assert.IsTrue(output.Contains("Мощность: 1000"));
            Assert.IsTrue(output.Contains("Модель: X5"));
            Assert.IsTrue(output.Contains("Номер: 343"));
            Assert.IsTrue(output.Contains("Объем бака: 200"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        // GetNoChangeOption
        [TestMethod]
        public void Auto_GetNoChangeOption_ShouldReturnThree()
        {
            var auto = new Auto();

            var result = auto.GetNoChangeOption();

            Assert.AreEqual(6, result);
        }

        // Change
        [TestMethod]
        public void Auto_Change_ShouldDisplayCorrectOptions()
        {
            var auto = new Auto();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(new StringReader("6"));

            auto.Change();

            var output = stringWriter.ToString();
            Console.WriteLine($"Вывод метода = {output}");
            Assert.IsTrue(output.Contains("6 - не менять"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
        //ChangeMenu
        [TestMethod]
        public void Auto_ChangeMenu_ShouldDisplayCorrectOptions()
        {
            var auto = new Auto();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            auto.ChangeMenu();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("1 - фирму"));
            Assert.IsTrue(output.Contains("2 - мощность"));
            Assert.IsTrue(output.Contains("3 - модель"));
            Assert.IsTrue(output.Contains("4 - объём"));
            Assert.IsTrue(output.Contains("5 - номер"));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }


        //Changing. Рабочие данные - результат не вызывает исключений
        [DataTestMethod]
        [DataRow(3, "X5", "Model", "X5")]        // модель
        [DataRow(4, "50", "Volume_bak", 50)]     // объём
        [DataRow(5, "111", "Number", 111)]       // номер
        public void Auto_Change_ValidData_ShouldWork(int choice, string input, string property, object expected)
        {
            var auto = new Auto();
            Console.SetIn(new StringReader(input));
            auto.Changing(choice);

            var actual = auto.GetType().GetProperty(property)?.GetValue(auto);
            Assert.AreEqual(expected, actual);
        }

        //Changing. Нерабочие данные - результат должен вызывать исключение
        [DataTestMethod]
        [DataRow(3, "", typeof(ArgumentNullException), "Название модели не может быть пустым! (Parameter 'Модель')")]
        [DataRow(3, "   ", typeof(ArgumentNullException), "Название модели не может быть пустым! (Parameter 'Модель')")]
        [DataRow(3, "A", typeof(ArgumentException), "Название модели должно быть от 2 до 15 символов.")]
        [DataRow(3, "ToooooooooooLong", typeof(ArgumentException), "Название модели должно быть от 2 до 15 символов.")]
        [DataRow(4, "10", typeof(ArgumentException), "Введено некорректное значение объема бака.")]
        [DataRow(4, "210", typeof(ArgumentException), "Введено некорректное значение объема бака.")]
        [DataRow(5, "10", typeof(ArgumentException), "Номер введен неверно.")]
        [DataRow(5, "1000", typeof(ArgumentException), "Номер введен неверно.")]
        public void Auto_Change_InvalidData_ShouldThrowException(int choice, string input, Type exceptionType, string expectedMessage)
        {
            var auto = new Auto();
            Console.SetIn(new StringReader(input));
            Exception exception;

            if (exceptionType == typeof(ArgumentNullException))
            {
                exception = Assert.ThrowsException<ArgumentNullException>(() => auto.Changing(choice));
            }
            else if (exceptionType == typeof(ArgumentException))
            {
                exception = Assert.ThrowsException<ArgumentException>(() => auto.Changing(choice));
            }
            else
            {
                throw new NotImplementedException($"Тип исключения {exceptionType} не поддерживается");
            }

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}