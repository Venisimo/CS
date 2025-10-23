using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_laba1cs
{
    public class Auto : Transport
    {
        private string model;
        private int volume_bak, number;

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Модель", "Название модели не может быть пустым!");
                else if (value.Length < 2 || value.Length > 15) 
                    throw new ArgumentException("Название модели должно быть от 2 до 15 символов.");
                else model = value;
            }
        }
        public int Volume_bak
        {
            get { return volume_bak; }
            set
            {
                if (value < 50 || value > 200) throw new ArgumentException("Введено некорректное значение объема бака.");
                else volume_bak = value;
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 100 || value > 999) throw new ArgumentException("Номер введен неверно.");
                else number = value;
            }
        }

        public Auto(string firma = "Audi", string model = "Q7", int Power = 500, int volume_bak = 100, int number = 123)
        {
            Model = model;
            Number = number;
            Firma = firma;
            Volume_bak = volume_bak;
            this.Power = Power;
        }

        public override string ToString()
        {
            return $"Машина: {Firma}, Модель: {Model}, Мощность: {Power}, Номер: {Number}, Объем бака: {Volume_bak}";
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Номер: {Number}");
            Console.WriteLine($"Объем бака: {Volume_bak}");

        }

        public override void ChangeMenu()
        {
            base.ChangeMenu();
            Console.WriteLine("3 - модель");
            Console.WriteLine("4 - объём");
            Console.WriteLine("5 - номер");
        }

        public override void Changing(int choice)
        {
            switch (choice)
            {
                case 3:
                    Console.Write("Введите новое название модели: ");
                    Model = Console.ReadLine();
                    Console.WriteLine("Модель изменена.");
                    break;
                case 4:
                    Console.Write("Введите новое значение объема: ");
                    Volume_bak = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Объём изменён.");
                    break;
                case 5:
                    Console.Write("Введите новый номер: ");
                    Number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Номер изменён.");
                    break;
                case 6:
                    Console.WriteLine("Поля не изменены.");
                    break;
                default:
                    base.Changing(choice);
                    break;
            }
        }

        public override int GetNoChangeOption() => 6;

        public override void Change()
        {
            base.Change();
        }
    }
}
