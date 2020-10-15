using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public static class shopList
    {
        private static List<string> valgteRetter = new List<string>(); 

        public static void addRet(string retNavn)
        {
            valgteRetter.Add(retNavn);
        }

        public static int noRecOnShopList()
        {
            int N = valgteRetter.Count();
            return N;
        }

        public static string genShopList()
        {
            List<string> varer = new List<string>();

            foreach (string ret in valgteRetter)
            {
                varer.AddRange( Backend.SQL.getIngredienser(ret) );
            }

            string shopListString = "Indkøbsliste \n" + String.Join(" \n", varer);
            return shopListString;
        }

    }
}
