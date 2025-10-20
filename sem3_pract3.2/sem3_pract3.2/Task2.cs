using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class Task2
    {
        // ЗАДАНИЕ 2: Обобщенные коллекции (char)
        public static void Run()
        {
            Console.WriteLine("\n=== ЗАДАНИЕ 2: Обобщенные коллекции (char) ===");

            // 2a - Создаем обобщенную коллекцию List<T> с типом char и выводим в консоль
            List<char> charList = new List<char> { 'A', 'B', 'C', 'D', 'E' };
            Console.WriteLine("Первая коллекция (List<char>):");
            for (int i = 0; i < charList.Count; i++)
            {
                Console.WriteLine($"Index {i}: {charList[i]}");
            }

            // 2b - Удаляем n элементов
            int n = 2;
            Console.WriteLine($"\nУдаляем {n} элементов:");
            charList.RemoveRange(0, n);
            for (int i = 0; i < charList.Count; i++)
            {
                Console.WriteLine($"Index {i}: {charList[i]}");
            }

            // 2c - Добавляем другие элементы
            Console.WriteLine("\nДобавляем элементы разными методами:");

            charList.Add('F');                    // Добавление в конец
            Console.WriteLine("После Add('F'): " + string.Join(", ", charList));

            charList.Insert(0, 'Z');              // Добавление в начало
            Console.WriteLine("После Insert(0, 'Z'): " + string.Join(", ", charList));

            charList.AddRange(new char[] { 'X', 'Y' }); // Добавление коллекции
            Console.WriteLine("После AddRange(['X', 'Y']): " + string.Join(", ", charList));

            // 2d - Создаем вторую коллекцию Dictionary<TKey, TValue> и заполняем данными из первой
            Dictionary<int, char> charDictionary = new Dictionary<int, char>();
            for (int i = 0; i < charList.Count; i++)
            {
                charDictionary.Add(i, charList[i]); // Генерируем ключи
            }

            // 2e - Выводим вторую коллекцию в консоль
            Console.WriteLine("\nВторая коллекция (Dictionary<int, char>):");
            foreach (var pair in charDictionary)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }

            // 2f - Находим во второй коллекции заданное значение
            char searchChar = 'X';
            var foundPair = charDictionary.FirstOrDefault(x => x.Value == searchChar);
            if (foundPair.Value == searchChar)
            {
                Console.WriteLine($"\nНайдено значение '{searchChar}' с ключом {foundPair.Key}");
            }
            else
            {
                Console.WriteLine($"\nЗначение '{searchChar}' не найдено");
            }

            // 2f - Поиск несуществующего значения
            searchChar = 'Q';
            foundPair = charDictionary.FirstOrDefault(x => x.Value == searchChar);
            if (foundPair.Value == searchChar)
            {
                Console.WriteLine($"Найдено значение '{searchChar}' с ключом {foundPair.Key}");
            }
            else
            {
                Console.WriteLine($"Значение '{searchChar}' не найдено");
            }
        }
    }
}
