using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    class MenuManager
    {
        public static void Run()
        {
            Cafe cafe = new Cafe();

            while (true)
            {
                try
                {
                    MainMenu.Start(cafe);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите корректное число!");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка выбора: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
