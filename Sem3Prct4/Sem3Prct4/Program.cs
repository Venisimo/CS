using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                while (true)
                {
                    Console.WriteLine("=== ТЕСТИРОВАНИЕ ПРОГРАММЫ ===");
                    Console.WriteLine("1. Тест месяцев - операторы запросов");
                    Console.WriteLine("2. Тест месяцев - методы расширения");
                    Console.WriteLine("3. Тест студентов - операторы запросов");
                    Console.WriteLine("4. Тест студентов - методы расширения");
                    Console.WriteLine("5. Полный тест всех функций");
                    Console.WriteLine("0. Выход");
                    Console.Write("Выберите тест: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            MenuManager.TestMonthsQueries();
                            break;
                        case "2":
                            MenuManager.TestMonthsExpansion();
                            break;
                        case "3":
                            MenuManager.TestStudentsQueries();
                            break;
                        case "4":
                            MenuManager.TestStudentsExpansion();
                            break;
                        case "5":
                            MenuManager.TestAll();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор!");
                            break;
                    }

                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
            catch (ArgumentNullException ex) 
            {
                Console.WriteLine($"Значение отсутсвует: {ex.Message}");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Некорректное значение: {ex.Message}");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }
    }
}