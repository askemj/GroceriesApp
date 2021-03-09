using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class GroceryItem
    {
        public string Name { get; set;}
        public string Unit { get; set; }
        public float Quantity { get; set; }
        public string Category { get; set; } 
        public bool BasicItem { get; set; }
        public GroceryItem(string name)
        {
            Name = name;
        }
    }
}
