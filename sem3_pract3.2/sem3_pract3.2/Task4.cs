using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class Task4
    {
        // ЗАДАНИЕ 4: Наблюдаемая коллекция ObservableCollection
        public static void Run()
        {
            Console.WriteLine("\n=== ЗАДАНИЕ 4: ObservableCollection<Transport> ===");

            var transports = new ObservableCollection<Transport>();
            transports.CollectionChanged += TransportManager.CollectionChange;

            Console.WriteLine("Добавляем элементы в коллекцию:");
            transports.Add(new Transport("BMW", 200));
            transports.Add(new Transport("Mercedes", 300));
            transports.Add(new Transport("Audi", 350));
            transports.Add(new Transport("ВАЗ", 200));
            transports.Add(new Transport("Toyota", 400));
            transports.Add(new Transport("Cherry", 320));

            Console.WriteLine("\nУдаляем элемент с индексом 1:");
            transports.RemoveAt(1);

            Console.WriteLine("\nЗаменяем элемент с индексом 2:");
            transports[2] = new Transport("Ferrari", 1000);

            Console.WriteLine("\nТекущее состояние коллекции:");
            foreach (var transport in transports)
            {
                Console.WriteLine(transport);
            }
        }
    }
}
