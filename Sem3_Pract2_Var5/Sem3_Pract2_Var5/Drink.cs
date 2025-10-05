using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    public class Drink<TType> : IDrink
    {

        public readonly decimal MIN_PRICE = 100;
        public readonly decimal MAX_PRICE = 1000;

        private Volume volume;
        public Volume Volume 
        {
            get { return volume; }
            set { volume = value; } 
        }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set 
            {
                if (value < MIN_PRICE)
                {
                    Console.WriteLine($"Цена увеличена до минимальной: {MIN_PRICE} рублей");
                    price = MIN_PRICE;
                }
                else if (value > MAX_PRICE)
                {
                    Console.WriteLine($"Цена увеличена до максимальной: {MAX_PRICE} рублей");
                    price = MAX_PRICE;
                } 
                else price = value;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                if (value.Length < 2 || value.Length > 20) name = "Unknown";
                else name = value;
            }
        }
        public TType Type { get; set; }
        public Drink(Volume vol, TType type, decimal price, string name)
        {
            Volume = vol;
            Type = type;
            Price = price;
            Name = name;
        }
        public Drink(int vol, TType type, decimal price, string name)
        {
            volume.Ml = vol;
            Type = type;
            Price = price;
            Name = name;   
        }
        public static implicit operator Drink<TType>((Volume volume, TType type, decimal price, string name) data)
        {
            return new Drink<TType>(data.volume, data.type, data.price, data.name);
        }
        public void Deconstruct(out Volume vol, out TType type, out decimal price, out string name)
        {
            vol = Volume;
            type = Type;
            price = Price;
            name = Name;
        }
        public virtual void Drinking()
        {
            Console.WriteLine($"Пьем {Name} объемом {Volume.Ml} мл");
        }
        public override string ToString()
        {
            return $"Название: {Name}\nЦена: {Price} рублей\n{Volume}\nВид: {Type}";
        }
    }
}
