using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem3_laba1cs;

namespace Sem3_laba1cs
{
    public static class MenuManager
    {
        public static void Run(List<Transport> transports)
        {
            int choice;
            try
            { 
                while (true) 
                {
                    Console.WriteLine("Выберите какое действие желаете совершить:");
                    Console.WriteLine("1 - создать Транспорт");
                    Console.WriteLine("2 - создать электросамокат");
                    Console.WriteLine("3 - создать автомобиль");
                    Console.WriteLine("4 - вывести элементы списка");
                    Console.WriteLine("5 - выход из программы");
                    Console.Write("Ваш выбор: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            var newTransport = CreateTransport();
                            transports.Add(newTransport);
                            ReqToPrint(newTransport);
                            newTransport.Change();
                            break;
                        case 2:
                            var newScooter = CreateElScooter();
                            transports.Add(newScooter);
                            ReqToPrint(newScooter);
                            newScooter.Change();
                            break;
                        case 3:
                            var newAuto = CreateAuto();
                            transports.Add(newAuto);
                            ReqToPrint(newAuto);
                            newAuto.Change();
                            break;
                        case 4:
                            if (transports.Count == 0) Console.WriteLine("Список пуст!");
                            else
                            {
                                Console.WriteLine("=== Список ===");
                                foreach (var transport in transports) { Console.WriteLine(transport); }
                            }
                            break;
                        case 5:
                            return;
                    }
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Отсутсвует значение: {ex.Message}");
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine($"Неверный ввод: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
        private static Transport CreateTransport()
        {
            Console.Write("Введите фирму (более 2 символов): ");
            string firma = Console.ReadLine();

            Console.Write("Введите мощность (от 180 до 3600): ");
            int power = Convert.ToInt32(Console.ReadLine());

            return new Transport { Firma = firma, Power = power };
        }
        private static ElScooter CreateElScooter()
        {
            Console.Write("Введите фирму (более 2 символов): ");
            string firma = Console.ReadLine();

            Console.Write("Введите мощность (от 180 до 3600): ");
            int power = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите макс. нагрузку (от 60 до 150): ");
            int weight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите макс. скорость (от 18 до 90): ");
            int speed = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите цену (от 16000 до 220000): ");
            int price = Convert.ToInt32(Console.ReadLine());

            return new ElScooter { Firma = firma, Power = power, Weight = weight, Price = price, Speed = speed };
        }
        private static Auto CreateAuto()
        {
            Console.Write("Введите фирму (более 2 символов): ");
            string firma = Console.ReadLine();

            Console.Write("Введите модель (от 2 до 15 символов): ");
            string model = Console.ReadLine();

            Console.Write("Введите мощность (от 180 до 3600): ");
            int power = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите номер (от 100 до 999): ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите объём бака (от 50 до 200): ");
            int volume_bak = Convert.ToInt32(Console.ReadLine());

            return new Auto { Firma = firma, Model = model, Power = power, Number = number, Volume_bak = volume_bak };
        }

        private static void ReqToPrint(Transport newTransport)
        {
            Console.WriteLine("Введите 1, чтобы вывести информацию об объекте (0, чтобы не выводить): ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    if (newTransport.GetType().Name == "Transport") Console.WriteLine("Базовый тип: Транспорт");
                    else if (newTransport.GetType().Name == "ElScooter") Console.WriteLine("Производный тип: Электросамокат");
                    else if (newTransport.GetType().Name == "Auto") Console.WriteLine("Производный тип: Машина");
                    newTransport.Print();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Неправильный ввод выбора! Информация не будет выводиться!");
                    break;
            }
        }

    }
}
