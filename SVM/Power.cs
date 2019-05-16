using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM
{
    class Power
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public Power(string name, double price, string category, string description)
        {
            Name = name;
            Price = price;
            Category = category;
            Description = description;
        }
    }
}
