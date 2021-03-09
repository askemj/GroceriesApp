using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        public static void AddToLooseItems(GroceryItem item)
        {
            LooseItems.Add(item);
        }

        public static List<GroceryItem> GetLooseItems()
        {
            return LooseItems;
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
                allGroceryItems.AddRange(recipe.Twists);
                menu += recipe.Name + "\n";
            }

            allGroceryItems.AddRange(LooseItems.ToArray());

            List<GroceryItem> reducedGroceryItemsList = getReducedGroceryItemsList(allGroceryItems); 

            List<string> categories = reducedGroceryItemsList.Select(x => x.Category).Distinct().ToList();

            List<string> categoriesOrdered = orderCategories(categories);

            foreach(string categoryName in categoriesOrdered)
            {
                string groceryItemsInCategory = String.Join("\n", reducedGroceryItemsList.Where(x => x.Category == categoryName && x.Quantity != 0).Select(item => $"{item.Quantity.ToString()} {item.Unit} {item.Name}") );
                
                string groceryItemsInCategoryWOUnit = String.Join("\n", reducedGroceryItemsList.Where(x => x.Category == categoryName && x.Quantity == 0).Select(item => $"{item.Name}"));

                categoryAndGroceries += categoryName;

                if (groceryItemsInCategory != "")
                {
                    categoryAndGroceries += "\n" + groceryItemsInCategory;
                }
                if (groceryItemsInCategoryWOUnit != "")
                {
                    categoryAndGroceries += "\n" + groceryItemsInCategoryWOUnit;
                }
                categoryAndGroceries += "\n"
                    + "\n";
            }

            shopListString = "Menu \n" +
                menu + "\n" +
                categoryAndGroceries;

            Clipboard.SetText(shopListString);

            return shopListString;
        }

        private static List<string> orderCategories(List<string> categories)
        {
            List<string> orderedcategories = new List<string>();
            
            // setup sort directions as array 
            var categoriesArray = new[]
            {
               new {Category = "Frugt & Grønt", Order = 1 },
               new {Category = "Brød", Order = 2},
               new {Category = "Kød & Fisk", Order = 3},
               new {Category = "Tørvarer", Order = 4},
               new {Category = "Drikkevarer", Order = 5},
               new {Category = "Pålæg", Order = 6},
               new {Category = "Mejeri", Order = 7},
               new {Category = "Frost", Order = 8},
               new {Category = "Personlig Pleje", Order = 9},
               new {Category = "Konserves", Order = 10},
               new {Category = "Husholdning", Order = 11},
               new {Category = "Diverse", Order = 12}
            };

            foreach (var cat in categoriesArray.OrderBy(c => c.Order))
            {
                if (categories.Contains(cat.Category))
                {
                    Console.WriteLine("Categories contained " + cat.Category);
                    orderedcategories.Add(cat.Category);
                }
            }
            return orderedcategories;
        }

        private static List<GroceryItem> getReducedGroceryItemsList(List<GroceryItem> itemList)
        {
            List<GroceryItem> reducedItemsList = new List<GroceryItem>();

            foreach (GroceryItem item in itemList)
            {
                Console.WriteLine("Item selected: " + item.Name);
                if ( reducedItemsList.Exists(i => i.Name == item.Name & i.Unit == item.Unit) )
                {
                    reducedItemsList.Find(i => i.Name == item.Name & i.Unit == item.Unit).Quantity += item.Quantity;
                    Console.WriteLine("item is the reduced items list, the quantity is " + reducedItemsList.Find(i => i.Name == item.Name & i.Unit == item.Unit).Quantity.ToString());
                }
                else
                {
                    Console.WriteLine("item is not in the reduced items list");
                    reducedItemsList.Add(item);
                }
            }

            //IEnumerable<object> uniqueItemTypes = itemList.Select(item => new {item.Name, item.Unit}).Distinct()
            //foreach (object uType in uniqueItemTypes)
            //{
            //    itemList.Where(item => item.Name == uType.Name.ToString());
            //};

            //double total = myList.Where(item => item.Name == "Eggs").Sum(item => item.Amount);

            

            return reducedItemsList;
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
