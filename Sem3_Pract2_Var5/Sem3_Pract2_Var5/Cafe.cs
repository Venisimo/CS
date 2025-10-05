using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    class Cafe : ICafe
    {
        private List<IDrink> drinks = new List<IDrink>();

        public int DrinkCount => drinks.Count;

        public IDrink this[int index]
        {
            get
            {
                if (index < 0 || index >= drinks.Count)
                    throw new IndexOutOfRangeException($"Индекс {index} вне диапазона [0, {drinks.Count - 1}]");
                return drinks[index];
            }
        }

        public void AddDrink(IDrink drink)
        {
            drinks.Add(drink ?? throw new ArgumentNullException(nameof(drink)));
        }

        public void ShowDrinks()
        {
            Console.WriteLine("===== Меню =====");
            if (drinks.Count == 0)
            {
                Console.WriteLine("Меню пусто!");
                return;
            }

            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {drinks[i].Name} - {drinks[i].Price} руб.");
            }
        }
    }
}
