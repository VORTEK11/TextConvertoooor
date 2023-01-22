using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Amogus
    {
        public static void Load()
        {
            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.Escape) GavnoKod.Close();
            else if (button.Key == ConsoleKey.F1) Pivo.Save();
            else
            {
                Console.Clear();
                GavnoKod.PathToFile(Pivo.dir);
            }
        }
    }
}
