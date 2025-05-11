using System;

namespace examPractick
{
    abstract class Fruit
    {
        public Fruit(string name)
        {
            this.Name = name; 
        }
        public string Name { get; protected set; }
        public abstract int Ammount();
    }
    class Banana : Fruit
    {
        public Banana() : base("Банан"){ }
        public override int Ammount()
        {
           return 2;
        }
    }
    class Apple : Fruit
    {
        public Apple() : base("Яблоко") { }
        public override int Ammount()
        {
            return 5;
        }
    }
    abstract class Decorator : Fruit
    {
        protected Fruit fruit;
        public Decorator(string name, Fruit fruit) : base(name)
        {
            this.fruit = fruit;
        }
    }
    class Sticker : Decorator
    {
        public Sticker(Fruit fruit) : base(fruit.Name + ", c наклейкой ", fruit)
        { }
        public override int Ammount()
        {
            return fruit.Ammount();
        }
    }
    class Worm : Decorator
    {
        public Worm(Fruit fruit) : base(fruit.Name + ", c червяком ", fruit)
        { }
        public override int Ammount()
        {
            return fruit.Ammount();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fruit apple1 = new Apple();
            apple1 = new Worm(apple1);
            Fruit banana1 = new Banana();
            banana1 = new Sticker(banana1);
            Console.Write("У нас есть ");
            Console.Write(apple1.Name);
            Console.Write("в количестве ");
            Console.WriteLine(apple1.Ammount());
            Console.Write("У нас есть ");
            Console.Write(banana1.Name);
            Console.Write("В количестве ");
            Console.WriteLine(banana1.Ammount());

            Fruit apple2 = new Apple();
            apple2 = new Sticker(apple2);
            Fruit banana2 = new Banana();
            banana2 = new Worm(banana2);
            Console.Write("У нас есть ");
            Console.Write(apple2.Name);
            Console.Write("В количестве ");
            Console.WriteLine(apple2.Ammount());
            Console.Write("У нас есть ");
            Console.Write(banana2.Name);
            Console.Write("В количестве ");
            Console.WriteLine(banana2.Ammount());
        }
    }
}
