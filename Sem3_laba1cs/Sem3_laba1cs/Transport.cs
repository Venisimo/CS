using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_laba1cs
{
    public class Transport
    {
	    private string firma;
        private int power;
        public string Firma
        {
            get { return firma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Фирма", "Название фирмы не может быть пустым!");
                else if (value.Length < 2 || value.Length > 20)
                    throw new ArgumentException("Название фирмы должно быть от 2 до 20 символов.");
                else firma = value;
            }
        }
        public int Power
        {
            get { return power; }
            set 
            {
                if (value < 180 || value > 3600) throw new ArgumentException("Мощность указана неверно.");
                else power = value;

            }
        }

        public Transport(string firma = "Firma", int power = 500)
        {
            Firma = firma;
            Power = power;
        }
        public override string ToString()
        {
            return $"Транспорт: {Firma}, Мощность: {Power}";
        }

        public virtual void Print()
        {
            Console.WriteLine($"Производитель: {Firma}");
            Console.WriteLine($"Мощность: {Power}");
        }
        public virtual void ChangeMenu()
        {
            Console.WriteLine("Выберите поле для изменения:");
            Console.WriteLine("1 - фирму");
            Console.WriteLine("2 - мощность");
        }
        public virtual void Changing(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите новое название фирмы: ");
                    Firma = Console.ReadLine();
                    Console.WriteLine("Фирма изменена.");
                    break;
                case 2:
                    Console.WriteLine("Введите новое значение мощности: ");
                    Power = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Мощность изменена.");
                    break;
                case 3:
                    Console.WriteLine("Поля не изменены.");
                    break;
                default:
                    Console.WriteLine("Неправильный ввод выбора. Поля не изменены.");
                    break;
            }
        }
        public virtual int GetNoChangeOption() => 3;

        public virtual void Change()
        {
            ChangeMenu();
            Console.WriteLine($"{GetNoChangeOption()} - не менять");
            Console.Write("Ваш выбор: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Changing(choice);
        }
    }
}
