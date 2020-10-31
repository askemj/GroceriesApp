using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public static class shopList
    {
        private static List<Recipe> SelectedRecipes = new List<Recipe>();
        private static List<GroceryItem> LooseItems = new List<GroceryItem>();

        private static List<string> valgteRetter = new List<string>();
        private static List<List<string>> vareListe = new List<List<string>>();

        public static void AddRecipe(Recipe recipe)
        {
            SelectedRecipes.Add(recipe);
        }

        public static string GenerateShopList()
        {
            string shopListString = "";
            string menu = "";
            string categoryAndGroceries = "";

            List<GroceryItem> allGroceryItems = new List<GroceryItem>();
            foreach (Backend.Recipe recipe in SelectedRecipes)
            {
                allGroceryItems.AddRange(recipe.Ingredients);
                menu += recipe.Name + "\n";
            }

            IEnumerable<string> categories = allGroceryItems.Select(x => x.Category).Distinct();
            // introduce sorting of categories to match supermarket, sort according to pattern 
            foreach(string categoryName in categories)
            {
                string groceryItemsInCategory = String.Join("\n", allGroceryItems.Where(x => x.Category == categoryName).Select(x => x.Name));
                
                categoryAndGroceries += categoryName + "\n" + 
                    groceryItemsInCategory + "\n" + 
                    "\n";
            }

            shopListString = "Menu \n" +
                menu + "\n" +
                categoryAndGroceries;

            return shopListString;
        }

        public static void addRet(string retNavn)
        {
            valgteRetter.Add(retNavn);
        }

        public static int noRecOnShopList()
        {
            int N = valgteRetter.Count();
            return N;
        }

        //public static string genShopList()
        //{
        //    foreach (string ret in valgteRetter)
        //    {
        //        vareListe[0].AddRange( Backend.SQL.getIngredienser(ret)[0] );
        //        vareListe[1].AddRange(Backend.SQL.getIngredienser(ret)[1]);
        //        vareListe[2].AddRange(Backend.SQL.getIngredienser(ret)[2]);
        //    }

        //    vareListe[1].Sort(); 

        //    string shopListString = "Indkøbsliste \n"; // + String.Join(" \n", varer);

        //    for (int n = 0; n < vareListe[0].Count; n++)
        //    {
        //        Console.WriteLine(n.ToString());
        //        Console.WriteLine(vareListe[0][n].ToString());
        //        shopListString += vareListe[0][n].ToString() + "\n";
        //        // List<string> groccats in vareListe.GetRange(0, 3))
        //        //Console.WriteLine("genSopList method : " + String.Join(" ", groccats));
        //        //shopListString += String.Join(" ", groccats) + "\n";
        //            //groccats[0].ToString() + " " + groccats[1].ToString() + " " + groccats[2].ToString() + "\n";
        //        //Console.WriteLine(shopListString);
        //    }

        //    //string shopListString = "Indkøbsliste \n"; // + String.Join(" \n", varer);
        //    return shopListString;
        //}


        //public static string genShopListOld()
        //{
        //    List<string> varer = new List<string>();

        //    foreach (string ret in valgteRetter)
        //    {
        //        //varer.AddRange( Backend.SQL.getIngredienser(ret) );
        //    }

        //    string shopListString = "Indkøbsliste \n" + String.Join(" \n", varer);
        //    return shopListString;
        //}

    }
}
