using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public static class testing
    {
        public static Backend.GroceryItem GenerateDummyGroceryItem()
        {
            Backend.GroceryItem groceryItem = new Backend.GroceryItem("banan");
            groceryItem.Category = "Frugt & Grønt";
            groceryItem.Quantity = 1;
            groceryItem.Unit = "stk";
            return groceryItem;
        }

        public static Backend.Recipe GenerateDummyRecipe()
        {
            Backend.Recipe recipe = new Backend.Recipe("Banankage", false);
            recipe.NumberOfServings = 5;
            recipe.RecipeType = "Dessert";
            recipe.Notes = "Rør ikke for længe i dejen, så bliver kagen gummiagtigt";
            recipe.ID = 1;
            recipe.PreparationTime = 20;
            recipe.TotalTime = 60;

            recipe.Ingredients.Add( new GroceryItem("banan") { Category = "Frugt & Grønt", Quantity = 2, Unit = "stk." });
            recipe.Ingredients.Add(new GroceryItem("mel") { Category = "Tørvarer", Quantity = 500, Unit = "g" });
            recipe.Ingredients.Add(new GroceryItem("sukker") { Category = "Tørvarer", Quantity = 300, Unit = "g" });
            recipe.Ingredients.Add(new GroceryItem("æg") { Category = "Mejeri", Quantity = 2, Unit = "stk." });

            recipe.Twists.Add(new GroceryItem("chokolade") { Category = "Diverse", Quantity = 250, Unit = "g" });

            recipe.UsesLeftovers.Add("bananmos");
            recipe.Tags.Add("svampet");
            recipe.Tags.Add("nemt");
            return recipe;
        }

    }
}
