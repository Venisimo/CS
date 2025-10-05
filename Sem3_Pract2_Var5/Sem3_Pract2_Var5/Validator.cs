using Sem3_Pract2_Var5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sem3_Pract2_Var5
{
    static class Validator
    {
        public static int GetValidInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;

                Console.WriteLine($"Ошибка! Введите число от {min} до {max}: ");
            }
        }
    }
}
