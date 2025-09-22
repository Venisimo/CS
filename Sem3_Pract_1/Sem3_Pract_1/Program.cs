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
        class Frame()
        {
            public static void Create_Space(int num)
            {
                for (int i = 0; i < num; i++) Console.Write(" ");
            }
            public static void Create_HorizontalLine(int num)
            {
                for (int i = 0; i < num; i++) Console.Write("\u2550");
            }
            public static void Create_VerticalLine(int num)
            {
                for (int i = 0; i < num; i++) Console.Write("\u2551");
            }
            public static void Create_ThinHorizontalLine(int num)
            {
                for (int i = 0; i < num; i++) Console.Write("\u2500");
            }
            public static void Footer(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write("\u2551");
                    Console.Write("..");
                    Create_Space(12);
                    Console.Write("КАТАЛОГ  11.10.02  19:48");
                    Console.Write("\u2551");
                    Console.Write(" ");
                }
            }
        }
        class Title()
        {

            public static void Selection(int BeforeSpace, string name, int AfterSpace, char nextSymbol)
            {
                Frame.Create_Space(BeforeSpace);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(name);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Frame.Create_Space(AfterSpace);
                if (nextSymbol == '\u2551')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                } 
                Console.Write(nextSymbol);
            }
        }

        class Files()
        {
            public static void Name(string name, string extension, char nextSymb)
            {
                const int maxLen = 12;
                int space = maxLen - name.Length - extension.Length;
                Console.Write(name);
                Frame.Create_Space(space);
                Console.Write(extension);
                Console.Write(nextSymb);
            }
            public static void Date(string date)
            {
                Console.Write(date);
                Console.Write('\u2502');
            }
            public static void Size(string size)
            {
                const int maxLen = 9;
                int space = maxLen - size.Length;
                Frame.Create_Space(space);
                Console.Write(size);
                Console.Write('\u2502');
            }
            public static void Time(string time)
            {
                const int maxLen = 6;
                int space = maxLen - time.Length;
                Frame.Create_Space(space);
                Console.Write(time);
            }
            // Декодирование Unicode escape-последовательностей
            public static string DecodeUnicodeEscapes(string input)
            {
                return Regex.Replace(input, @"\\u([0-9A-Fa-f]{4})",
                    match => ((char)Convert.ToInt32(match.Groups[1].Value, 16)).ToString());
            }

        }
        class ButtomMenu()
        {
            public static void Create_Button(int number, string text)
            {
                Console.Write(number);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(text);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Frame.Create_Space(1);
            }
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Green;
            const int h = 25, w = 100;
            Console.SetWindowSize(w, h);
            Console.Title = "Task 1";

            Frame.Create_Space(4);
            Console.Write("Л");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("евая");
            Frame.Create_Space(4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ф");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("айл");
            Frame.Create_Space(4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Д");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("иск");
            Frame.Create_Space(4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("К");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("оманды");
            Frame.Create_Space(4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("П");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("рава");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\u2554");
            Frame.Create_HorizontalLine(15);
            Console.Write(" С:/NC ");
            Frame.Create_HorizontalLine(16);
            Console.Write("\u2557");

            Console.Write(" ");
            Console.Write("\u2554");
            Frame.Create_HorizontalLine(15);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" С:/NC ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Frame.Create_HorizontalLine(16);
            Console.WriteLine("\u2557");

            Frame.Create_VerticalLine(1);
            Title.Selection(0, "C:| Имя", 5, '\u2502');
            Title.Selection(4, "Имя", 5, '\u2502');
            Title.Selection(4, "Имя", 5, '\u2551');
            Frame.Create_Space(1);

            Frame.Create_VerticalLine(1);
            Title.Selection(0, "C:| Имя", 5, '\u2502');
            Title.Selection(2, "Размер", 1, '\u2502');
            Title.Selection(2, "Дата", 2, '\u2502');
            Title.Selection(0, "Время", 1, '\u2551');

            Console.WriteLine("");

            string path = "files.txt";
            string[] files = File.ReadAllLines(path, Encoding.UTF8);
            string[] partsFile;

            int count = 0;
            bool firstLine = true;

            foreach (string file in files)
            {
                string decodedFile = Files.DecodeUnicodeEscapes(file);

                ++count;
                int dotCount = decodedFile.Count(c => c == '.');

                if (dotCount == 1) partsFile = decodedFile.Split(['.'], 2);
                else partsFile = [decodedFile, ""];
          
                switch (count)
                {
                    case 1:
                        Frame.Create_VerticalLine(1);
                        Files.Name(partsFile[0], partsFile[1], '\u2502');
                        break;
                    case 3:
                        Files.Name(partsFile[0], partsFile[1], '\u2551');
                        Frame.Create_Space(1);
                        Frame.Create_VerticalLine(1);
                        if (firstLine == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        break;
                    case 5:
                        Files.Size(partsFile[0]);
                        break;
                    case 6:
                        Files.Date(partsFile[0]);
                        break;
                    case 7:
                        Files.Time(partsFile[0]);
                        if (firstLine == true)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            firstLine = false;
                        }
                        Frame.Create_VerticalLine(1);
                        Console.WriteLine("");
                        count = 0;
                        break;
                    default:
                        Files.Name(partsFile[0], partsFile[1], '\u2502');
                        break;
                }
            }

            Console.Write("\u255F");

            Frame.Create_ThinHorizontalLine(12);
            Console.Write("\u2534");
            Frame.Create_ThinHorizontalLine(12);
            Console.Write("\u2534");
            Frame.Create_ThinHorizontalLine(12);
            Console.Write("\u2562");

            Frame.Create_Space(1);
            Console.Write("\u255F");

            Frame.Create_ThinHorizontalLine(12);
            Console.Write("\u2534");
            Frame.Create_ThinHorizontalLine(9);
            Console.Write("\u2534");
            Frame.Create_ThinHorizontalLine(8);
            Console.Write("\u2534");
            Frame.Create_ThinHorizontalLine(6);
            Console.Write("\u2562");

            Console.WriteLine("");

            Frame.Footer(2);

            Console.WriteLine("");
            Console.Write("\u255A");
            Frame.Create_HorizontalLine(38);
            Console.Write("\u255D");

            Frame.Create_Space(1);
            Console.Write("\u255A");
            Frame.Create_HorizontalLine(38);
            Console.Write("\u255D");

            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("C:/NC>\u2584");


            ButtomMenu.Create_Button(1, "Помощь");
            ButtomMenu.Create_Button(2, "Вызов ");
            ButtomMenu.Create_Button(3, "Чтение");
            ButtomMenu.Create_Button(4, "Правка");
            ButtomMenu.Create_Button(5, "Копия ");
            ButtomMenu.Create_Button(6, "НовИмя");
            ButtomMenu.Create_Button(7, "НовКат");
            ButtomMenu.Create_Button(8, "Удал-е");
            ButtomMenu.Create_Button(9, "Меню   ");
            ButtomMenu.Create_Button(10, "Выход ");

        }
    }
}