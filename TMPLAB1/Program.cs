using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace TMPLAB1
{
    internal class Program
    {

        enum Command { CMD_CREATE, CMD_OPEN, CMD_SAVE, CMD_UNKNOWN, CMD_INPUT };
        public static void Create(string fileName)
        {
            FileHeaderPRD fileHeaderPRD = new FileHeaderPRD();

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(fileHeaderPRD.Signature, 0, fileHeaderPRD.Signature.Length);
            }

            Console.WriteLine($"Файл {fileName} создан!");
        }

        static void Open(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, 2);

                string text = Encoding.ASCII.GetString(buffer);
                if (text != "PS")
                {
                    Console.WriteLine("Файл имеет неверную сигнатуру!");
                }
                else Console.WriteLine($"Файл {fileName} открыт успешно!");

            }
        }

        static Command GetCommandType(string cmd)
        {
            if (cmd == "create") return Command.CMD_CREATE;
            if (cmd == "open") return Command.CMD_OPEN;
            if (cmd == "save") return Command.CMD_SAVE;
            if (cmd == "input") return Command.CMD_INPUT;
            return Command.CMD_UNKNOWN;
        }

        static void Input(string fileName)
        {
            Console.WriteLine("Введите данные для записи:");

            string writeData = Console.ReadLine();

            byte[] dataAsBytes = Encoding.UTF8.GetBytes(writeData);

            using (FileStream fs = new FileStream(fileName, FileMode.Append))
            {
                fs.Write(dataAsBytes, 0, dataAsBytes.Length);
            }

            Console.WriteLine("Данные успешно добавлены!");
        }

        public static void Switcher(string fileName, string command)
        {
            switch (GetCommandType(command))
            {
                case Command.CMD_CREATE:
                    Create(fileName);
                    break;
                case Command.CMD_OPEN:
                    Open(fileName);
                    break;
                case Command.CMD_INPUT:
                    Input(fileName);
                    break;
                default:
                    throw new Exception("Неизвестная комманда");
            }
        }

        static void Main(string[] args)
        {
            string command, fileName;
            Console.Write("PS> ");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ');

            command = parts[0];
            fileName = parts[1];

            Switcher(fileName, command);
        }
    }
}