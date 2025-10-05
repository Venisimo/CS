using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    static class MainMenu
    {
        public static void Start(Cafe cafe)
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1. Показать меню");
            Console.WriteLine("2. Добавить в меню");
            Console.WriteLine("3. Выход");

            int choice = Validator.GetValidInput(1, 3);

            switch (choice)
            {
                case 1:
                    DrinkSelector.ShowMenuAndInteract(cafe);
                    break;
                case 2:
                    DrinkAdder.AddDrink(cafe);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
