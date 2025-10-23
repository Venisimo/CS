using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_laba1cs
{
    public class ElScooter : Transport
    {
        private int weight;
        private int speed;
        private int price;
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 60 || value > 150) throw new ArgumentException("Максимальная нагрузка указана неверно.");
                else weight = value; 
            }
        }

        public int Speed
        {
            get { return speed; }
            set 
            {
                if (value < 18 || value > 90) throw new ArgumentException("Максимальная скорость указана неверно.");
                else speed = value; 
            }
        }
        public int Price
        {
            get { return price; }
            set 
            {
                if (value < 16000 || value > 220000) throw new ArgumentException("Цена указана неверно.");
                else price = value; 
            }
        }
        public ElScooter(string firma = "Xiaomi", int weight = 80, int speed = 50, int power = 3000, int price = 100000)
        {
            Firma = firma;
            Weight = weight;
            Speed = speed;
            Price = price;
            Power = power;

        }
        public override string ToString()
        {
            return $"Электросамокат: {Firma}, Мощность: {Power}, Макс. скорость: {Speed}, Макс. нагрузка: {Weight}, Цена: {Price}";
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Макс. нагрузка: {Weight}");
            Console.WriteLine($"Макс. скорость: {Speed}");
            Console.WriteLine($"Цена: {Price}");
        }

        public override void ChangeMenu()
        {
            base.ChangeMenu();
            Console.WriteLine("3 - скорость");
            Console.WriteLine("4 - вес");
            Console.WriteLine("5 - цена");
        }

        public override void Changing(int choice)
        {
            switch (choice)
            {
                case 3:
                    Console.Write("Введите новую максимальную скорость: ");
                    Speed = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Скорость изменена.");
                    break;
                case 4:
                    Console.Write("Введите новый максимальную нагузку: ");
                    Weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Максимальная нагрузка изменена.");
                    break;
                case 5:
                    Console.Write("Введите новую цену: ");
                    Price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Цена изменена.");
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
