using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    public struct Volume
    {
        private double ml;
        private const double MIN_VOLUME_ML = 100;
        private const double MAX_VOLUME_ML = 1000;
        public double Ml
        {
            get { return ml; }
            set
            {
                if (value < MIN_VOLUME_ML)
                {
                    Console.WriteLine($"Объем увеличен до минимального: {MIN_VOLUME_ML} мл");
                    ml = MIN_VOLUME_ML;
                }
                else if (value > MAX_VOLUME_ML)
                {
                    Console.WriteLine($"Объем уменьшен до максимального: {MAX_VOLUME_ML} мл");
                    ml = MAX_VOLUME_ML;
                }
                else ml = value;
            }
        }
        public override string ToString()
        {
            return $"Объем: {Ml} мл";
        }
    }
}
