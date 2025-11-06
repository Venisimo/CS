using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    public class MenuManager
    {
        public static void TestMonthsQueries()
        {
            int n = 5;
            Console.WriteLine("\n=== ТЕСТ МЕСЯЦЕВ (ОПЕРАТОРЫ ЗАПРОСОВ) ===");
            IMonthLINQ months = new QueriesByMonths();

            Console.WriteLine($"\n1. Месяцы с длиной названия {n}:");
            foreach (var month in months.GetMonthsByLength(n))
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n2. Летние месяцы:");
            foreach (var month in months.GetOnlySummerMonths())
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n3. Зимние месяцы:");
            foreach (var month in months.GetOnlyWinterMonths())
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n4. Месяцы в алфавитном порядке:");
            foreach (var month in months.GetMonthsAlphabetically())
                Console.WriteLine($"  - {month}");

            Console.WriteLine($"\n5. Количество месяцев с буквой 'u' и длиной >= 4: {months.CountMonthsWithULong()}");
        }

        public static void TestMonthsExpansion()
        {
            int n = 5;
            Console.WriteLine("\n=== ТЕСТ МЕСЯЦЕВ (МЕТОДЫ РАСШИРЕНИЯ) ===");
            IMonthLINQ months = new ExpansionByMonths();

            Console.WriteLine($"\n1. Месяцы с длиной названия {n}:");
            foreach (var month in months.GetMonthsByLength(5))
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n2. Летние месяцы:");
            foreach (var month in months.GetOnlySummerMonths())
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n3. Зимние месяцы:");
            foreach (var month in months.GetOnlyWinterMonths())
                Console.WriteLine($"  - {month}");

            Console.WriteLine("\n4. Месяцы в алфавитном порядке:");
            foreach (var month in months.GetMonthsAlphabetically())
                Console.WriteLine($"  - {month}");

            Console.WriteLine($"\n5. Количество месяцев с буквой 'u' и длиной >= 4: {months.CountMonthsWithULong()}");
        }

        public static void TestStudentsQueries()
        {
            Console.WriteLine("\n=== ТЕСТ СТУДЕНТОВ (ОПЕРАТОРЫ ЗАПРОСОВ) ===");
            IStudentCollectionLINQ students = new QueriesStudentCollection();

            Console.WriteLine("\n1. Студенты 1 курса:");
            foreach (var student in students.GetStudentsByCourse(1))
                Console.WriteLine($"  - {student}");

            Console.WriteLine($"\n2. Самый молодой студент:\n  - {students.GetYoungestStudent()}");

            Console.WriteLine($"\n3. Количество студентов в группе ЛА-101: {students.GetStudentCountByGroup("ЛА-101")}");

            Console.WriteLine($"\n4. Первый студент с именем Иван:\n  - {students.GetFirstStudentByName("Иван")}");

            Console.WriteLine("\n5. Сортировка по фамилии (А-Я):");
            foreach (var student in students.SortStudentsBySurname(true))
                Console.WriteLine($"  - {student}");

            Console.WriteLine("\n6. Сортировка по фамилии (Я-А):");
            foreach (var student in students.SortStudentsBySurname(false))
                Console.WriteLine($"  - {student}");
        }

        public static void TestStudentsExpansion()
        {
            Console.WriteLine("\n=== ТЕСТ СТУДЕНТОВ (МЕТОДЫ РАСШИРЕНИЯ) ===");
            IStudentCollectionLINQ students = new ExpansionStudentCollection();

            Console.WriteLine("\n1. Студенты 1 курса:");
            foreach (var student in students.GetStudentsByCourse(1))
                Console.WriteLine($"  - {student}");

            Console.WriteLine($"\n2. Самый молодой студент:\n  - {students.GetYoungestStudent()}");

            Console.WriteLine($"\n3. Количество студентов в группе ЛА-101: {students.GetStudentCountByGroup("ЛА-101")}");

            Console.WriteLine($"\n4. Первый студент с именем Иван:\n  - {students.GetFirstStudentByName("Иван")}");

            Console.WriteLine("\n5. Сортировка по фамилии (А-Я):");
            foreach (var student in students.SortStudentsBySurname(true))
                Console.WriteLine($"  - {student}");

            Console.WriteLine("\n6. Сортировка по фамилии (Я-А):");
            foreach (var student in students.SortStudentsBySurname(false))
                Console.WriteLine($"  - {student}");
        }

        public static void TestAll()
        {
            TestMonthsQueries();
            TestMonthsExpansion();
            TestStudentsQueries();
            TestStudentsExpansion();
        }
    }
}
