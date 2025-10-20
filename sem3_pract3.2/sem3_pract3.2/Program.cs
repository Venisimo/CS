using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using sem3_pract3._2;

namespace sem3_pract3._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MenuManager.Run();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Неверный ввод: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Некорректное значение: {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}