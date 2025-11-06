using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Класс к заданию 1 для демонстрации работы методов по операторам запросовов LINQ
    public class QueriesByMonths : IMonthLINQ
    {
        private readonly string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


        // Выбрать последовательность месяцев с длиной строки названия равной заданному числу n
        public IEnumerable<string> GetMonthsByLength(int n)
        {
            var SelectMonths = from month in months where month.Length == n select month; 
            return SelectMonths;
        }

        // Выбрать только летние месяцы
        public IEnumerable<string> GetOnlySummerMonths()
        {
            string[] SummerMonths = { "June", "July", "August" };
            var SelectMonths = from month in months where SummerMonths.Contains(month) select month;
            return SelectMonths;
        }

        // Выбрать только зимние месяцы
        public IEnumerable<string> GetOnlyWinterMonths()
        {
            string[] WinterMonths = { "December", "January", "February" };
            var SelectMonths = from month in months where WinterMonths.Contains(month) select month;
            return SelectMonths;
        }

        // Вывести названия месяцев в алфавитном порядке
        public IEnumerable<string>  GetMonthsAlphabetically()
        {
            var SelectMonths = from month in months orderby month select month;
            return SelectMonths;
        }

        // Подсчитать количество месяцев, содержащих в названии букву «u» и длиной имени не менее 4-х символов
        public int CountMonthsWithULong()
        {
            char symbol = 'u';
            int targetLength = 4;

            var selectMonths = (from month in months where month.Contains(symbol) && month.Length >= targetLength select month).Count();

            return selectMonths;
        }

    }
}
