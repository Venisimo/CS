using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class Task3
    {
        // ЗАДАНИЕ 3: Пользовательский тип (Transport)
        public static void Run()
        {
            Console.WriteLine("\n=== ЗАДАНИЕ 3: Пользовательский тип Transport ===");

            // Создаем коллекцию Transport
            List<Transport> transports = new List<Transport>();
            transports.Add(new Transport("BMW", 500));
            transports.Add(new Transport("Mercedes", 300));
            transports.Add(new Transport("Audi", 350));
            transports.Add(new Transport("ВАЗ", 200));
            transports.Add(new Transport("Toyota", 400));
            transports.Add(new Transport("Cherry", 320));

            Console.WriteLine("Исходная коллекция Transport:");
            foreach (var transport in transports)
            {
                Console.WriteLine(transport);
            }

            // Создание Dictionary из List
            Console.WriteLine("\nСоздаем Dictionary из List<Transport>:");
            var transportDictionary = new Dictionary<int, Transport>();
            for (int i = 0; i < transports.Count; i++)
            {
                transportDictionary.Add(i, transports[i]);
            }

            foreach (var transport in transportDictionary)
            {
                Console.WriteLine($"key: {transport.Key}  value: {transport.Value}");
            }

            // Демонстрация IComparable
            Console.WriteLine("\nДемонстрация IComparable - сортировка по мощности:");
            transports.Sort();
            foreach (var transport in transports)
            {
                Console.WriteLine(transport);
            }

            // Демонстрация IComparer
            Console.WriteLine("\nДемонстрация IComparer - сортировка через TransportComparer:");
            transports.Sort(new TransportComparer());
            foreach (var transport in transports)
            {
                Console.WriteLine(transport);
            }

            // Демонстрация ICloneable
            Console.WriteLine("\nДемонстрация ICloneable - глубокое копирование:");
            var original = new Transport("BMW", 500);
            var clone = (Transport)original.Clone();
            clone.Firma = "Toyota";

            Console.WriteLine($"Оригинал: {original}");
            Console.WriteLine($"Клон: {clone}");

            // Поиск в коллекции
            Console.WriteLine("\nПоиск в коллекции Transport:");
            string searchFirma = "Audi";
            var foundTransport = transports.FirstOrDefault(t => t.Firma == searchFirma);
            if (foundTransport != null)
            {
                Console.WriteLine($"Найден транспорт: {foundTransport}");
            }
            else
            {
                Console.WriteLine($"Транспорт с фирмой '{searchFirma}' не найден");
            }
        }
    }
}
