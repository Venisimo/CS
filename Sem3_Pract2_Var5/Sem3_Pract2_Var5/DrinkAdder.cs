using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    static class DrinkAdder
    {
        public static void AddDrink(Cafe cafe)
        {
            Console.WriteLine("Что добавить?");
            Console.WriteLine("1. Чай");
            Console.WriteLine("2. Кофе");
            Console.WriteLine("3. Назад");

            int choice = Validator.GetValidInput(1, 3);

            switch (choice)
            {
                case 1:
                    AddTea(cafe);
                    break;
                case 2:
                    AddCoffee(cafe);
                    break;
                case 3:
                    return;
            }
        }

        private static void AddTea(Cafe cafe)
        {
            Console.Write("Напишите название чая: ");
            string name = Console.ReadLine() ?? "Неизвестный чай";

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                throw new ArgumentException("Название должно содержать минимум 2 символа");

            Console.Write("Напишите цену (от 100 до 1000) в рублях: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Напишите объем (от 100 до 1000) в мл: ");
            double ml = Convert.ToDouble(Console.ReadLine());

            Volume volume = new Volume { Ml = ml };

            Console.WriteLine("Выберите вид чая:");
            Console.WriteLine("1. Black");
            Console.WriteLine("2. Green");
            Console.WriteLine("3. Herbal");
            Console.WriteLine("4. Oolong");

            int choiceType = Validator.GetValidInput(1, 4);
            TeaType type = choiceType switch
            {
                1 => TeaType.Black,
                2 => TeaType.Green,
                3 => TeaType.Herbal,
                4 => TeaType.Oolong,
                _ => throw new InvalidOperationException("Неверный выбор типа чая")
            };

            Tea newTea = new Tea(volume, type, price, name);
            cafe.AddDrink(newTea);
            Console.WriteLine("Чай успешно добавлен в меню!");
        }

        private static void AddCoffee(Cafe cafe)
        {
            Console.Write("Напишите название кофе: ");
            string name = Console.ReadLine() ?? "Неизвестный кофе";

            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
                throw new ArgumentException("Название должно содержать минимум 2 символа");

            Console.Write("Напишите цену (от 100 до 1000) в рублях: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Напишите объем (от 100 до 1000) в мл: ");
            double ml = Convert.ToDouble(Console.ReadLine());

            Volume volume = new Volume { Ml = ml };

            Console.WriteLine("Выберите вид кофе:");
            Console.WriteLine("1. Americano");
            Console.WriteLine("2. Latte");
            Console.WriteLine("3. Espresso");
            Console.WriteLine("4. FlateWhite");

            int choiceType = Validator.GetValidInput(1, 4);
            CoffeType type = choiceType switch
            {
                1 => CoffeType.Americano,
                2 => CoffeType.Latte,
                3 => CoffeType.Espresso,
                4 => CoffeType.FlateWhite,
                _ => throw new InvalidOperationException("Неверный выбор типа кофе")
            };

            Coffee newCoffee = new Coffee(volume, type, price, name);
            cafe.AddDrink(newCoffee);
            Console.WriteLine("Кофе успешно добавлен в меню!");
        }
    }
}
