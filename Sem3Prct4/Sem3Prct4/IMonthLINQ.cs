using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Интерфейс к заданию 1
    public interface IMonthLINQ
    {
        IEnumerable<string> GetMonthsByLength(int n);
        IEnumerable<string> GetOnlySummerMonths();
        IEnumerable<string> GetOnlyWinterMonths();
        IEnumerable<string> GetMonthsAlphabetically();
        int CountMonthsWithULong();
    }
}
