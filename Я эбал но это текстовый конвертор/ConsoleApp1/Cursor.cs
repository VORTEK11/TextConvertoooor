using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Cursor
    {
        public static int Set(ConsoleKey button, int max, int next)
        {
            if (button == ConsoleKey.UpArrow)
            {
                if (next == 0) next = max;
                else next -= 1;
            }
            else if (button == ConsoleKey.DownArrow)
            {
                if (next == max) next = 0;
                else next += 1;
            }
            return next;
        }
        public static void Load(int start, int next)
        {
            Console.SetCursorPosition(0, start + next);
            Console.WriteLine("->");
        }
    }
}
