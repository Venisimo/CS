using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sem3_pract3._2
{
    public class Transport : IComparable<Transport>, ICloneable
    {
        private string firma;
        private int power;
        public string Firma
        {
            get { return firma; }
            set
            {
                if (value.Length < 2)
                {
                    throw new Exception("Введено некорректное значение фирмы. ");
                }
                else firma = value;
            }
        }
        public int Power
        {
            get { return power; }
            set
            {
                if (value < 180 || value > 3600)
                {
                    throw new Exception("Мощность указана неверно.");
                }
                else power = value;
            }
        }

        public Transport(string t_firma = "Firma", int t_power = 500)
        {
            Power = t_power;
            Firma = t_firma;
        }
        public override string ToString()
        {
            return $" Машина {Firma} с мощностью {Power} ";
        }

        public int CompareTo(Transport other)
        {
            if (other == null) return 1;

            int result = Power.CompareTo(other.Power);
            if (result != 0) return result;

            return string.Compare(Firma, other.Firma);
        }

        public object Clone() => new Transport(Firma, Power);
    }
}