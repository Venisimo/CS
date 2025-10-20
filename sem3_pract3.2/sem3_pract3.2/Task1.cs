using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class Task1
    {
        // ЗАДАНИЕ 1: Необобщенная коллекция ArrayList
        public static void Run()
        {
            Console.WriteLine("\n=== ЗАДАНИЕ 1: ArrayList ===");

            // 1a - Создаем необобщенную коллекцию ArrayList и заполняем 5-ю случайными целыми числами
            ArrayList arrayList = new ArrayList();
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(rnd.Next(1, 100));
            }

            Console.WriteLine("Коллекция заполненная 5-ю случайными числами:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // 1b - Добавляем строку
            arrayList.Add("строка");
            Console.WriteLine("\nКоллекци после добавления строки:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // 1c - Удаляем заданный элемент
            if (arrayList.Count > 1)
            {
                Console.WriteLine($"\nУдаляем элемент с индексом 1: {arrayList[1]}");
                arrayList.RemoveAt(1);
            }

            // 1d - Выводим количество элементов и коллекцию на консоль
            Console.WriteLine($"\nКоличество элементов: {arrayList.Count}");
            Console.WriteLine("Коллекция после удаления элемента:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // 1e - Выполняем поиск в коллекции заданного значения
            string searchValue = "строка";
            bool containsValue = arrayList.Contains(searchValue);
            Console.WriteLine($"\nКоллекция содержит '{searchValue}': {containsValue}");

            // 1e - Выполняем поиск в коллекции заданного значения
            int searchNumber = 50;
            containsValue = arrayList.Contains(searchNumber);
            Console.WriteLine($"Коллекция содержит {searchNumber}: {containsValue}");
        }
    }
}
