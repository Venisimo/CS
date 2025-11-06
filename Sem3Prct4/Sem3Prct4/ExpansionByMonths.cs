using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Класс к заданию 1 для демонстрации работы методов расширения запросовов LINQ
    public class ExpansionByMonths : IMonthLINQ
    {
        private readonly string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        // Выбрать последовательность месяцев с длиной строки названия равной заданному числу n
        public IEnumerable<string> GetMonthsByLength(int n)
        {
            return months.Where(month => month.Length == n);
        }

        // Выбрать только летние месяцы
        public IEnumerable<string> GetOnlySummerMonths()
        {
            string[] SummerMonths = { "June", "July", "August" };

            return months.Where(month => SummerMonths.Contains(month));
        }

        // Выбрать только зимние месяцы
        public IEnumerable<string> GetOnlyWinterMonths()
        {
            string[] WinterMonths = { "December", "January", "February" };

            return months.Where(month => WinterMonths.Contains(month));
        }

        // Вывести названия месяцев в алфавитном порядке
        public IEnumerable<string> GetMonthsAlphabetically()
        {
            return months.OrderBy(month => month);
        }

        // Подсчитать количество месяцев, содержащих в названии букву «u» и длиной имени не менее 4-х символов
        public int CountMonthsWithULong()
        {
            char symbol = 'u';
            int targetLength = 4;
            return months.Count(month => month.Contains(symbol) && month.Length >= targetLength);
        }
    }
}
