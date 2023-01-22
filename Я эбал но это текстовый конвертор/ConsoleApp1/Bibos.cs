using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Bibos
    {
        public string Name { get; set; } = "";
        public int Price { get; set; } = 0;
        public Bibos(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
