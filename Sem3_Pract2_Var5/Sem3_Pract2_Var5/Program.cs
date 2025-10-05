using Sem3_Pract2_Var5;
using System;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace Sem3_Pract_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                MenuManager.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex}");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }

    }
}