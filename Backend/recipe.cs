using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Recipe
    {
        public int ID { get; set; }
        public bool ExistsInDatabase { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int PreparationTime { get; set; }
        public int TotalTime { get; set; }
        public int NumberOfServings { get; set; }
        public string RecipeType { get; set; }
        public List<string> Tags { get; set; }
        public List<GroceryItem> Ingredients { get; set; }
        public List<GroceryItem> Twists { get; set; }
        public List<string> UsesLeftovers { get; set; }
        public List<string> ProducesLeftovers { get; set; }
        public Recipe(string name, bool existsInDB)
        {
            ExistsInDatabase = existsInDB;
            ID = 0;
            Name = name;
            Tags = new List<string>();
            Ingredients = new List<GroceryItem>();
            Twists = new List<GroceryItem>();
            UsesLeftovers = new List<string>();
            ProducesLeftovers = new List<string>();
        }
    }
}
