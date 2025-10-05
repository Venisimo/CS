using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    interface IDrink
    {
        string Name { get; }
        decimal Price { get; }
        Volume Volume { get; }
        void Drinking();
    }
}
