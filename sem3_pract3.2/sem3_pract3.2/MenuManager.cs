using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class MenuManager
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== ВЫБЕРИТЕ ЗАДАНИЕ ===");
                Console.WriteLine("1 - Необобщенная коллекция ArrayList");
                Console.WriteLine("2 - Обобщенные коллекции (char)");
                Console.WriteLine("3 - Пользовательский тип (Transport)");
                Console.WriteLine("4 - Наблюдаемая коллекция ObservableCollection");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1.Run();
                        break;
                    case "2":
                        Task2.Run();
                        break;
                    case "3":
                        Task3.Run();
                        break;
                    case "4":
                        Task4.Run();
                        break;
                    case "0":
                        return;
                    default:
                        throw new ArgumentOutOfRangeException("Ожидался ввод числа от 0 до 4");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
