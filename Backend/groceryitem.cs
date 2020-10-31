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
        public string Category { get; set; } 
        public GroceryItem(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
