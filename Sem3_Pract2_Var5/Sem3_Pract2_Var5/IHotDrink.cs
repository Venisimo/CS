using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    interface IHotDrink
    {
        bool IsBrewed { get; }
        void Brew();
    }
}
