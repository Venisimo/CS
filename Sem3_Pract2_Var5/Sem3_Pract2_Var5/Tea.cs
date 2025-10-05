using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    public class Tea : Drink<TeaType>, IHotDrink
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            { 
                if (value < 0) quantity = 0;
                else quantity = value;
            } 
        }

        public bool IsBrewed { get; private set; }
        public Tea(Volume Volume, TeaType Type, decimal Price, string Name) : base(Volume, Type, Price, Name)
        {
            IsBrewed = false;
            Quantity = 0;
        }
        public static implicit operator Tea((Volume volume, TeaType type, decimal Price, string Name) data)
        {
            return new Tea(data.volume, data.type, data.Price, data.Name);
        }
        public static Tea operator ++(Tea tea)
        {
            tea.Quantity++;
            return tea;
        }
        public static Tea operator --(Tea tea)
        {
            if (tea.Quantity > 0) tea.Quantity--;
            else Console.WriteLine("Пакетиков уже 0!");

            return tea;
        }
        public void Brew()
        {
            if (IsBrewed == true) Console.WriteLine("Чай не может быть заварен повторно!");

            if (Quantity == 0) Console.WriteLine("В чае нет пакетиков для заваривания!");
            else
            {
                IsBrewed = true;
                Console.WriteLine($"Завариваем чай {Type}");
            } 
        }
        public override void Drinking()
        {
            if (IsBrewed == false) Console.WriteLine("Невозможно выпить незаваренный чай!");
            else Console.WriteLine($"Пьем {Name} объемом {Volume.Ml} мл");
        }
        public void RemovePackage()
        {
            if (Quantity > 0) Quantity--;
            else Console.WriteLine("Пакетиков уже 0!");
        }
        public void AddPackage()
        {
            Quantity++;
        }
        public string PrintQuantity()
        {
            return $"\nПакетиков: {Quantity}";
        }
        public override string ToString()
        {
            return base.ToString() + PrintQuantity();
        }
    }
}
