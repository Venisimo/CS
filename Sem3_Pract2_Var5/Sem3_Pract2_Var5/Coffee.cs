using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    public class Coffee : Drink<CoffeType>, IHotDrink
    {
        public bool IsBrewed { get; private set; }
        private int sugar;
        public int Sugar
        {
            get { return sugar; }
            set
            {
                if (value < 0) sugar = 0;
                else sugar = value;
            }
        }
        public Coffee(Volume Volume, CoffeType Type, decimal Price, string Name) : base(Volume, Type, Price, Name)
        {
            Sugar = 0;
        }
        public static implicit operator Coffee((Volume volume, CoffeType type, decimal price, string name) data)
        {
            return new Coffee(data.volume, data.type, data.price, data.name);
        }
        public static Coffee operator ++(Coffee coffee)
        {
            coffee.Sugar++;
            return coffee;
        }
        public void Brew()
        {
            if (IsBrewed) Console.WriteLine("Кофе уже заварен!");
            else
            { 
                IsBrewed = true;
                Console.WriteLine($"Завариваем кофе {Type}");
            }           
        }
        public override void Drinking()
        {
            if (!IsBrewed) Console.WriteLine("Невозможно выпить незаваренный кофе!");
            else Console.WriteLine($"Пьем {Name} объемом {Volume.Ml} мл");
        }

        public void AddSugar()
        {
            Sugar++;
        }
        public string PrintQuantity()
        {
            return $"\nСахара: {Sugar} ложек";
        }
        public override string ToString()
        {
            return base.ToString() + PrintQuantity();
        }

    }
}
