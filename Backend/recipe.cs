using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public string PreparationTime { get; set; }

        public string Notes { get; set; }
        public List<GroceryItem> Ingredients { get; set; } 
        public Recipe(string name)
        {
            Name = name;
            Ingredients = Backend.SQL.GetIngredients(name);
            Tags = Backend.SQL.GetTags(Name);
            PreparationTime = Backend.SQL.GetPreparationTime(name);
            // Notes not yet implemented 
        }
    }
}
