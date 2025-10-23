using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace Sem3_laba1cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transport = new List<Transport>();
            MenuManager.Run(transport);
        }
       
    }
}