using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    static class DrinkInteractor
    {
        public static void InteractionWithCoffee(IDrink drink)
        {
            if (drink is not Coffee coffee) throw new InvalidCastException("Ожидался объект типа Coffee");

            Console.WriteLine("Действия с кофе:");
            Console.WriteLine("1. Заварить");
            Console.WriteLine("2. Добавить сахар");
            Console.WriteLine("3. Выпить");
            Console.WriteLine("4. Вывести информацию");
            Console.WriteLine("5. Назад");

            int choice = Validator.GetValidInput(1, 5);

            switch (choice)
            {
                case 1:
                    coffee.Brew();
                    break;
                case 2:
                    coffee.AddSugar();
                    break;
                case 3:
                    coffee.Drinking();
                    break;
                case 4:
                    Console.WriteLine(coffee);
                    break;
                case 5:
                    return;
            }
        }

        public static void InteractionWithTea(IDrink drink)
        {
            if (drink is not Tea tea)
                throw new InvalidCastException("Ожидался объект типа Tea");

            Console.WriteLine("Действия с чаем:");
            Console.WriteLine("1. Заварить");
            Console.WriteLine("2. Добавить пакетик");
            Console.WriteLine("3. Убрать пакетик");
            Console.WriteLine("4. Выпить");
            Console.WriteLine("5. Вывести информацию");
            Console.WriteLine("6. Назад");

            int choice = Validator.GetValidInput(1, 6);

            switch (choice)
            {
                case 1:
                    tea.Brew();
                    break;
                case 2:
                    tea.AddPackage();
                    break;
                case 3:
                    tea.RemovePackage();
                    break;
                case 4:
                    tea.Drinking();
                    break;
                case 5:
                    Console.WriteLine(tea);
                    break;
                case 6:
                    return;
            }
        }
    }
}
