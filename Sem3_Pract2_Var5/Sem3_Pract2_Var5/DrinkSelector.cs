using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    static class DrinkSelector
    {
        public static void ShowMenuAndInteract(Cafe cafe)
        {
            if (cafe.DrinkCount == 0)
            {
                Console.WriteLine("Меню пусто! Сначала добавьте напитки.");
                return;
            }

            cafe.ShowDrinks();
            Console.WriteLine($"Выберите напиток (1-{cafe.DrinkCount}): ");

            int choice = Validator.GetValidInput(1, cafe.DrinkCount);
            IDrink selectedDrink = cafe[choice - 1];

            if (selectedDrink is Drink<CoffeType>) DrinkInteractor.InteractionWithCoffee(selectedDrink);
            else if (selectedDrink is Drink<TeaType>) DrinkInteractor.InteractionWithTea(selectedDrink);
        }
    }
}
