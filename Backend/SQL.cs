using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.Common;
using System.Text;
using MySql.Data; 
using MySql.Data.MySqlClient;


namespace Backend
{
    public static class SQL
    {
        private static MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder();
        private static MySqlConnection SqlConnection;
        public static string ConnectionStatus = "unavailable";


        public static void SetupSQL(string u, string p, string ip)
        {
            ConnectionStringBuilder.Port = 3306;
            ConnectionStringBuilder.Server = ip;
            ConnectionStringBuilder.Database = "opskrifter";
            ConnectionStringBuilder.UserID = u;
            ConnectionStringBuilder.Password = p;
            p = ""; 
            SqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
        }

        public static Recipe GetRecipe(string recipeTitle) // jeg mangler at sætte twists også!
        {
            Recipe recipe = new Recipe(recipeTitle, true);
            List<string> recipedetails = GetRecipeDetails(recipeTitle);
            recipe.ID = Convert.ToInt32( recipedetails[0] );
            recipe.Notes = recipedetails[1];
            recipe.NumberOfServings = Convert.ToInt32(recipedetails[2]);
            recipe.TotalTime = Convert.ToInt32(recipedetails[3]);
            recipe.PreparationTime = Convert.ToInt32( recipedetails[4] );
            recipe.RecipeType = recipedetails[5];
            recipe.Ingredients = GetIngredients(recipeTitle);
            recipe.Twists = GetTwists(recipeTitle);
            recipe.UsesLeftovers = GetUsedLeftovers(recipeTitle);
            recipe.ProducesLeftovers = GetProducedLeftovers(recipeTitle);
            recipe.Tags = GetTags(recipeTitle);
            return recipe;
        }

        public static void RemoveItems(Recipe recipe)
        {
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing remove items query");
                SqlConnection.Open();

                foreach (GroceryItem ingredient in recipe.Ingredients)
                {
                    string sqlQueryStr = "DELETE FROM RetVare WHERE RetVare.Ret_ret_id = " + recipe.ID.ToString() +
                        " AND RetVare.Vare_vare_id = (SELECT vare_id FROM Vare WHERE vare_navn = \"" + ingredient.Name + "\"); ";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                foreach (GroceryItem ingredient in recipe.Twists)
                {
                    string sqlQueryStr = "DELETE FROM Twist WHERE Twist.Ret_ret_id = " + recipe.ID.ToString() +
                        " AND Twist.Vare_vare_id = (SELECT vare_id FROM Vare WHERE vare_navn = \"" + ingredient.Name + "\"); ";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                foreach (string tag in recipe.Tags)
                {
                    string sqlQueryStr = "DELETE FROM RetTag WHERE RetTag.Ret_ret_id = " + recipe.ID.ToString() +
                        " AND RetTag.Tag_tag_id = (SELECT tag_id FROM Tag WHERE tag_tekst = \"" + tag + "\"); ";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                foreach (string rest in recipe.ProducesLeftovers)
                {
                    string sqlQueryStr = "DELETE FROM RetLaverRest WHERE RetLaverRest.Ret_ret_id = " + recipe.ID.ToString() +
                        " AND RetLaverRest.Rest_rest_id = (SELECT rest_id FROM Rest WHERE rest_navn = \"" + rest + "\"); ";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                foreach (string rest in recipe.UsesLeftovers)
                {
                    string sqlQueryStr = "DELETE FROM RetBrugerRest WHERE RetBrugerRest.Ret_ret_id = " + recipe.ID.ToString() +
                        " AND RetBrugerRest.Rest_rest_id = (SELECT rest_id FROM Rest WHERE rest_navn = \"" + rest + "\"); ";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                    sqlCommand.ExecuteNonQuery();
                }

                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
        }
        
        public static List<string> GetRecipeDetails(string recipeTitle) // SQL updated to 1.0
        {
            List<string> recipeDetails = new List<string>(); // problem med SQL quersy string når en værdi i "Ret" er null! 
            string sqlQueryStr = "SELECT Ret.ret_id, Ret.noter, Ret.antal_portioner, Tilberedningstid.tilberedningstid_tid, " + 
                "Arbejdstid.arbejdstid_tid, Opskriftstype.opskriftstype_tekst " +
                "FROM Ret, Tilberedningstid, Arbejdstid, Opskriftstype " + 
                "WHERE Ret.Tilberedningstid_tilberedningstid_id = Tilberedningstid.tilberedningstid_id " +
                "AND Ret.Arbejdstid_arbejdstid_id = Arbejdstid.arbejdstid_id " + 
                "AND Ret.Opskriftstype_opskriftstype_id = Opskriftstype.opskriftstype_id " + 
                "AND Ret.ret_navn = \"" + recipeTitle + "\";";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    recipeDetails.Add(reader[0].ToString());
                    recipeDetails.Add(reader[1].ToString());
                    recipeDetails.Add(reader[2].ToString());
                    recipeDetails.Add(reader[3].ToString());
                    recipeDetails.Add(reader[4].ToString());
                    recipeDetails.Add(reader[5].ToString());
                    Console.WriteLine(reader[0].ToString());

                    //foreach (object entry in reader) // det synes at readeren er tom ?? writeline giver intet, men der er ikke sql fejl...
                    //{
                    //    recipeDetails.Add(entry.ToString());
                    //}
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return recipeDetails;
        }

        public static string testConnection()
        {
            string serverInfo = "N/A";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);

            try
            {
                Console.WriteLine("Testing MySQL connection ...");
                mySqlConnection.Open();
                ConnectionStatus = "available";
                serverInfo = mySqlConnection.ServerVersion + " " + mySqlConnection.State.ToString(); 
                Console.WriteLine("MySQL connection is live: " + serverInfo);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                ConnectionStatus = "unavailable";
            }
            finally
            {
                if (mySqlConnection.State.ToString() == "Open")
                {
                    mySqlConnection.Close();
                }
            }
            return serverInfo;
        }

        private static string SqlStringQuery(string queryString)
        {
            string queryResultString = "";

            try
            {
                Console.WriteLine("GroceryApp: Opening SQL connection and executing query: \"" + queryString);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(queryString, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    queryResultString = reader[0].ToString();
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return queryResultString;
        }
        private static List<string> SqlListQuery(string queryString)
        {
            List<string> queryResList = new List<string>();

            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + queryString);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(queryString, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    queryResList.Add(reader[0].ToString());
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return queryResList;
        }

        private static string SqlScalarQuery(string queryString)
        {
            string queryResult = "";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection for scalarquery using SQL-query: " + queryString);
                SqlConnection.Open();

                MySqlCommand sqlCommand = new MySqlCommand(queryString, SqlConnection);
                Object qRes = sqlCommand.ExecuteScalar();
                if (qRes != null)
                {
                    queryResult = qRes.ToString();
                }

                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return queryResult;
        }

        public static List<string> GetRecipes() // SQL updated to 1.0
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT ret_navn FROM Ret";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }
        public static List<GroceryItem> GetIngredients(string recipeName)
        {
            List<GroceryItem> ingredientsList = new List<GroceryItem>();
            string sqlQueryStr = "SELECT RetVare.maengde, Enhed.enhed_navn, Vare.vare_navn, Varetype.varetype_tekst, Vare.basisvare " + //, Vare.basisvare " + 
            "FROM Ret, RetVare, Enhed, Vare, Varetype " +
            "WHERE Ret.ret_id = RetVare.Ret_ret_id " +
            "AND Vare.vare_id = RetVare.Vare_vare_id " + 
            "AND Enhed.enhed_id = RetVare.Enhed_enhed_id " +
            "AND Vare.Varetype_varetype_id = Varetype.varetype_id " +
            "AND Ret.ret_navn = \"" + recipeName + "\";";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemQuantity = reader[0].ToString();
                    string itemUnit = reader[1].ToString();
                    string itemName = reader[2].ToString();
                    string itemCategory = reader[3].ToString();
                    bool basicItem = Convert.ToBoolean( reader[4] ) ;
                    GroceryItem item = new GroceryItem(itemName);
                    item.Quantity = Convert.ToSingle(itemQuantity);
                    item.Unit = itemUnit;
                    item.Name = itemName;
                    item.Category = itemCategory;
                    item.BasicItem = basicItem; 
                    ingredientsList.Add(item);
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return ingredientsList;
        }

        public static List<GroceryItem> GetBasicItems()
        {
            List<GroceryItem> ingredientsList = new List<GroceryItem>();
            string sqlQueryStr = "SELECT Vare.vare_navn, Varetype.varetype_tekst FROM Vare, Varetype, Dagligvarer " +
                "WHERE Vare.vare_id = Dagligvarer.dagligvare_id " +
                "AND Varetype.varetype_id = Vare.Varetype_varetype_id;";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemName = reader[0].ToString();
                    string itemCategory = reader[1].ToString();

                    GroceryItem item = new GroceryItem(itemName);
                    item.Category = itemCategory;
                    ingredientsList.Add(item);
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return ingredientsList;
        }

        public static List<GroceryItem> GetTwists(string recipeName)
        {
            List<GroceryItem> ingredientsList = new List<GroceryItem>();
            string sqlQueryStr = "SELECT Twist.maengde, Enhed.enhed_navn, Vare.vare_navn, Varetype.varetype_tekst " + // ,Vare.basisvare
            "FROM Ret, Twist, Enhed, Vare, Varetype " +
            "WHERE Ret.ret_id = Twist.Ret_ret_id " +
            "AND Vare.vare_id = Twist.Vare_vare_id " +
            "AND Enhed.enhed_id = Twist.Enhed_enhed_id " +
            "AND Vare.Varetype_varetype_id = Varetype.varetype_id " +
            "AND Ret.ret_navn = \"" + recipeName + "\";";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemQuantity = reader[0].ToString();
                    string itemUnit = reader[1].ToString();
                    string itemName = reader[2].ToString();
                    string itemCategory = reader[3].ToString();
                    //bool itemIsBasic = Convert.ToBoolean(reader[4].ToString());
                    GroceryItem item = new GroceryItem(itemName);
                    item.Quantity = Convert.ToSingle(itemQuantity);
                    item.Unit = itemUnit;
                    item.Name = itemName;
                    item.Category = itemCategory;
                    //item.BasicItem = itemIsBasic;
                    ingredientsList.Add(item);
                }
                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
            return ingredientsList;
        }

        public static List<string> GetUsedLeftovers(string recipeName)
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Rest.rest_navn FROM Rest, RetBrugerRest, Ret " +
                "WHERE Ret.ret_id = RetBrugerRest.Ret_ret_id " + "" +
                "AND Rest.rest_id = RetBrugerRest.Rest_rest_id " + "" +
                "AND Ret.ret_navn = \"" + recipeName + "\";";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }
        public static List<string> GetProducedLeftovers(string recipeName)
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Rest.rest_navn FROM Rest, RetLaverRest, Ret " +
                "WHERE Ret.ret_id = RetLaverRest.Ret_ret_id " + "" +
                "AND Rest.rest_id = RetLaverRest.Rest_rest_id " + "" +
                "AND Ret.ret_navn = \"" + recipeName + "\";";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }
        public static List<string> GetPreparationTimeOptions()
        {
            string sqlString = "SELECT Arbejdstid.arbejdstid_tid FROM Arbejdstid; ";
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> GetTotalTimeOptions()
        {
            string sqlString = "SELECT Tilberedningstid.tilberedningstid_tid FROM Tilberedningstid;";
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> GetRecipeTypeOptions()
        {
            string sqlString = "SELECT Opskriftstype.opskriftstype_tekst FROM Opskriftstype;";
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> GetGroceryCategoryOptions()
        {
            string sqlString = "SELECT varetype_tekst FROM Varetype;";
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static void UpdateRecipeDatabase(Backend.Recipe recipe) //updated 1.0 but not fixed for leftovers nor tested 
        {
            string recipeID = recipe.ID.ToString(); ///// 
            if (recipeID != "0")
            {
                //RemoveItems(recipe);
            }
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and inserting recipe: " + recipe.Name);
                SqlConnection.Open();

                string sqlDefineVars = "SET @'retnavn' = \"" + recipe.Name + "\", " +
                "@'noter' = \"" + recipe.Notes + "\", " +
                "@'tilberedningstidID' = (SELECT tilberedningstid_id FROM Tilberedningstid WHERE tilberedningstid_tid = " + recipe.PreparationTime.ToString() + "), " +
                "@'arbejdstidID' = (SELECT arbejdstid_id FROM Arbejdstid WHERE arbejdstid_tid = " + recipe.TotalTime.ToString() + "), " +
                "@'antalPortioner' = " + recipe.NumberOfServings.ToString() + ", " +
                "@'opskriftstypeID' = (SELECT opskriftstype_id FROM Opskriftstype WHERE opskriftstype_tekst = \"" + recipe.RecipeType + "\"); ";

                string sqlInsertRecipeStr = ""; 
                if (recipeID == "0")
                {
                    sqlInsertRecipeStr = "INSERT INTO Ret(Ret.ret_navn, Ret.noter, Ret.Tilberedningstid_tilberedningstid_id, " +
                        "Ret.Arbejdstid_arbejdstid_id, Ret.antal_portioner, Ret.Opskriftstype_opskriftstype_id) " +
                        "VALUES(@'retnavn', @'noter', @'tilberedningstidID', @'arbejdstidID', @'antalPortioner', @'opskriftstypeID') " +
                        "ON DUPLICATE KEY UPDATE " +
                        "Ret.ret_navn = @'retnavn', " +
                        "Ret.noter = @'noter', " +
                        "Ret.Tilberedningstid_tilberedningstid_id = @'tilberedningstidID', " +
                        "Ret.Arbejdstid_arbejdstid_id = @'arbejdstidID', " +
                        "Ret.antal_portioner = @'antalPortioner', " +
                        "Ret.Opskriftstype_opskriftstype_id = @'opskriftstypeID'; ";
                }

                else
                {
                    sqlInsertRecipeStr = "UPDATE Ret " + 
                        "SET Ret.ret_navn = @'retnavn', " + 
                        "Ret.noter = @'noter', " + 
                        "Ret.Tilberedningstid_tilberedningstid_id = @'tilberedningstidID', " + 
                        "Ret.Arbejdstid_arbejdstid_id = @'arbejdstidID', " + 
                        "Ret.antal_portioner = @'antalPortioner', " +
                        "Ret.Opskriftstype_opskriftstype_id = @'opskriftstypeID' " +
                        "WHERE ret_id = " + recipeID + "; ";
                }

                Console.WriteLine("DEBUG: sqlInsertStr is : " + sqlInsertRecipeStr);
                 
                string sqlGetRecipeID = "SELECT ret_id FROM Ret WHERE ret_navn = @'retnavn'; ";

                MySqlCommand sqlCommand = new MySqlCommand(sqlDefineVars, SqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = sqlInsertRecipeStr;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = sqlGetRecipeID;

                Object queryResult = sqlCommand.ExecuteScalar(); // FIXME FIXME FIXME jeg skal bruge ExecuteNonQuery i stedet tror jeg      
                if (queryResult != null)
                {
                    recipeID = queryResult.ToString();
                }

                Console.WriteLine("Recipe info inserted ok!");
                Console.WriteLine("Recipe ID is " + recipeID);

                if (recipeID != "")
                {
                    foreach (string tag in recipe.Tags)
                    {
                        Console.WriteLine("Tagteksten er " + tag);
                        string sqlDefineVaribles = "SET @'tag' = \"" + tag + "\", " +
                            "@'opskriftsID' = " + recipeID + "; ";
                        string sqlTagInsertString = "INSERT INTO Tag(Tag.tag_tekst) " +
                            "VALUES(@'tag') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Tag.tag_tekst = @'tag';"; // denne linje virker helt korrekt koert i mysql workbench
                        //Console.WriteLine(sqlTagInsertString);
                        string sqlSetTagIDString = "SET @'tagID' = (SELECT tag_id FROM Tag WHERE tag_tekst = @'tag');";
                        string sqlLinkTagRecipeString = "INSERT INTO RetTag(Ret_ret_id, Tag_tag_id) " +
                            "VALUES(@'opskriftsID', @'tagID') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "RetTag.Ret_ret_id = @'opskriftsID', " +
                                "RetTag.Tag_tag_id = @'tagID';";
                        MySqlCommand sqlTagCommand = new MySqlCommand(sqlDefineVaribles, SqlConnection);
                        int nRowsAffected = sqlTagCommand.ExecuteNonQuery();
                        //Console.WriteLine("Number of rows affected is: " + nRowsAffected.ToString());

                        sqlTagCommand.CommandText = sqlTagInsertString;
                        nRowsAffected = sqlTagCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected on inserting '" + tag + "' is: " + nRowsAffected.ToString());

                        sqlTagCommand.CommandText = sqlSetTagIDString;
                        nRowsAffected = sqlTagCommand.ExecuteNonQuery();
                        //Console.WriteLine("Number of rows affected is: " + nRowsAffected.ToString());

                        sqlTagCommand.CommandText = sqlLinkTagRecipeString;
                        nRowsAffected = sqlTagCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking '" + tag + "'  is: " + nRowsAffected.ToString());
                    }
                    Console.WriteLine("Recipe Tags inserted ok!");
                }

                //inserting groceryitem
                if (recipeID != "")
                {
                    foreach (GroceryItem item in recipe.Ingredients)
                    {
                        Console.WriteLine("Inserting ingredient named " + item.Name );
                        string sqlDefineVariablesString = "SET @'retID' = " + recipeID + ", " +
                            "@'varenavn' = \"" + item.Name + "\", " +
                            "@'varetypeID' = (SELECT varetype_id FROM Varetype WHERE varetype_tekst = \"" + item.Category + "\"), " +
                            "@'enhed' = \"" + item.Unit + "\", " +
                            "@'basisvare' = " + Convert.ToInt32(item.BasicItem) + ", " +
                            "@'maengde' = " + item.Quantity.ToString( CultureInfo.CreateSpecificCulture("en-GB") ) + ";";
                        Console.WriteLine("DEBUG: Quantity for " + item.Name + " is " + item.Quantity.ToString());

                        string sqlInsertNewGroceryItemString = "INSERT INTO Vare(vare_navn, Varetype_varetype_id, Vare.basisvare) " + //,Vare.basisvare
                            "VALUES(@'varenavn', @'varetypeID', @'basisvare') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Vare.vare_navn = @'varenavn', " +
                                "Vare.VareType_varetype_id = @'varetypeID', " +
                                "Vare.basisvare = @'basisvare'; " + 
                            "SET @'vareID' = (SELECT vare_id FROM Vare WHERE vare_navn = @'varenavn'); ";

                        string sqlInsertNewUnitString = "INSERT INTO Enhed(enhed_navn) " +
                            "VALUES(@'enhed') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Enhed.enhed_navn = @'enhed'; " +
                            "SET @'enhedID' = (SELECT enhed_id FROM Enhed WHERE enhed_navn = @'enhed'); ";

                        string sqlLinkRecipeGroceryString = "INSERT INTO RetVare(maengde, Enhed_enhed_id, Ret_ret_id, Vare_vare_id) " +
                            "VALUES(@'maengde', @'enhedID', @'retID', @'vareID') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "RetVare.maengde = @'maengde', " +
                                "RetVare.Enhed_enhed_id = @'enhedID', " +
                                "RetVare.Ret_ret_id = @'retID', " +
                                "RetVare.Vare_vare_id = @'vareID'; ";

                        MySqlCommand sqlGroceryItemCommand = new MySqlCommand(sqlDefineVariablesString, SqlConnection);
                        sqlGroceryItemCommand.ExecuteNonQuery();

                        sqlGroceryItemCommand.CommandText = sqlInsertNewGroceryItemString;
                        int nRowsAffected = sqlGroceryItemCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when inserting '" + item.Name + "'  is: " + nRowsAffected.ToString());

                        sqlGroceryItemCommand.CommandText = sqlInsertNewUnitString;
                        nRowsAffected = sqlGroceryItemCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when inserting '" + item.Unit + "'  is: " + nRowsAffected.ToString());

                        sqlGroceryItemCommand.CommandText = sqlLinkRecipeGroceryString;
                        nRowsAffected = sqlGroceryItemCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking grocery item and recipe is: " + nRowsAffected.ToString());
                    }
                    Console.WriteLine("Recipe ingredients inserted ok!");
                }

                //inserting twists
                if (recipeID != "")
                {
                    foreach (GroceryItem twist in recipe.Twists)
                    {
                        sqlDefineVars = "SET @'retID' = " + recipeID + ", " +
                            "@'varenavn' = \"" + twist.Name + "\", " +
                            "@'varetypeID' = (SELECT varetype_id FROM Varetype WHERE varetype_tekst = \"" + twist.Category + "\"), " +
                            "@'enhed' = \"" + twist.Unit + "\", " +
                            "@'basisvare' = " + Convert.ToInt32(twist.BasicItem) + ", " +
                            "@'maengde' = " + twist.Quantity.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + " ; ";

                        string sqlGroceryItemInsertString = "INSERT INTO Vare(vare_navn, Varetype_varetype_id, Vare.basisvare) " +
                            "VALUES(@'varenavn', @'varetypeID', @'basisvare') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Vare.vare_navn = @'varenavn', " +
                                "Vare.VareType_varetype_id = @'varetypeID' " +
                                "Vare.basisvare = @'basisvare'; " +
                            "SET @'vareID' = (SELECT vare_id FROM Vare WHERE vare_navn = @'varenavn'); ";

                        string sqlUnitInsertString = "INSERT INTO Enhed(enhed_navn) " +
                            "VALUES(@'enhed') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Enhed.enhed_navn = @'enhed'; " +
                            "SET @'enhedID' = (SELECT enhed_id FROM Enhed WHERE enhed_navn = @'enhed'); ";

                        string sqlTwistInsertString = "INSERT INTO Twist(maengde, Enhed_enhed_id, Ret_ret_id, Vare_vare_id) " +
                            "VALUES(@'maengde', @'enhedID', @'retID', @'vareID') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Twist.maengde = @'maengde', " +
                                "Twist.Enhed_enhed_id = @'enhedID', " +
                                "Twist.Ret_ret_id = @'retID', " +
                                "Twist.Vare_vare_id = @'vareID'; ";

                        MySqlCommand sqlTwistCommand = new MySqlCommand(sqlDefineVars, SqlConnection);
                        int nRowsAffected = sqlTwistCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking twist item is: " + nRowsAffected.ToString());

                        sqlTwistCommand.CommandText = sqlGroceryItemInsertString;
                        nRowsAffected = sqlTwistCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking twist item is: " + nRowsAffected.ToString());

                        sqlTwistCommand.CommandText = sqlUnitInsertString;
                        nRowsAffected = sqlTwistCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking twist item is: " + nRowsAffected.ToString());

                        sqlTwistCommand.CommandText = sqlTwistInsertString;
                        nRowsAffected = sqlTwistCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when linking twist item is: " + nRowsAffected.ToString());
                    }
                }

                //inserting leftover
                if (recipeID != "")
                {
                    foreach (string leftover in recipe.UsesLeftovers)
                    {
                        string sqlLeftoverInsertString = "SET @'rest' = \"" + leftover + "\", " +
                            "@'retID' = " + recipeID + "; " +

                            "INSERT INTO Rest(rest_navn) " +
                            "VALUES(@'rest') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Rest.rest_navn = @'rest'; " +
                            "SET @'restID' = (SELECT rest_id FROM Rest WHERE rest_navn = @'rest'); " +

                            "INSERT INTO RetBrugerRest(Ret_ret_id, Rest_rest_id) " +
                            "VALUES(@'retID', @'restID') " +
                            "ON DUPLICATE KEY UPDATE " +
                            "RetBrugerRest.Ret_ret_id = @'retID', " +
                            "RetBrugerRest.Rest_rest_id = @'restID'; ";

                        MySqlCommand sqlLeftoverCommand = new MySqlCommand(sqlLeftoverInsertString, SqlConnection);
                        int nRowsAffected = sqlLeftoverCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when inserting leftover used is: " + nRowsAffected.ToString());
                    }

                    foreach (string leftover in recipe.ProducesLeftovers)
                    {
                        string sqlLeftoverInsertString = "SET @'rest' = \"" + leftover + "\", " +
                            "@'retID' = " + recipeID + "; " +

                            "INSERT INTO Rest(rest_navn) " +
                            "VALUES(@'rest') " +
                            "ON DUPLICATE KEY UPDATE " +
                                "Rest.rest_navn = @'rest'; " +
                            "SET @'restID' = (SELECT rest_id FROM Rest WHERE rest_navn = @'rest'); " +

                            "INSERT INTO RetLaverRest(Ret_ret_id, Rest_rest_id) " +
                            "VALUES(@'retID', @'restID') " +
                            "ON DUPLICATE KEY UPDATE " +
                            "RetLaverRest.Ret_ret_id = @'retID', " +
                            "RetLaverRest.Rest_rest_id = @'restID'; ";

                        MySqlCommand sqlLeftoverCommand = new MySqlCommand(sqlLeftoverInsertString, SqlConnection);
                        int nRowsAffected = sqlLeftoverCommand.ExecuteNonQuery();
                        Console.WriteLine("Number of rows affected when inserting leftover produced is: " + nRowsAffected.ToString());
                    }

                }

                Console.WriteLine("GroceryApp: Query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (SqlConnection.State.ToString() == "Open")
                {
                    SqlConnection.Close();
                }
            }
        }

        //public static void UpdateRecipe(Backend.Recipe recipe)
        //{
        //    string recipeID;
        //    try
        //    {
        //        Console.WriteLine("GroceryApp: opening SQL connection and inserting recipe: " + recipe.Name);
        //        SqlConnection.Open();

        //        string sqlInsertRecipeStr = "INSERT INTO Ret (Ret.ret_navn, Ret.noter, Ret.Tilberedningstid_tilberedningstid_id, " +
        //            "Ret.Arbejdstid_arbejdstid_id, Ret.antal_portioner, Ret.OpskriftsType_opskriftstype_id ) " +
        //            "VALUES('TEST Pastinakfad', 'En velsmagende test', " +
        //            "(SELECT Tilberedningstid.tilberedningstid_id WHERE Tilberedningstid.tilberednigstid_tid = " + recipe.TotalTime.ToString() + "), " +
        //            "(SELECT Arbejdstid.arbejdstid_id WHERE Arbejdstid.arbejdstid_tid = " + recipe.PreparationTime.ToString() + "), " +
        //            recipe.NumberOfServings.ToString() + ", " +
        //            "(SELECT Opskriftstype.opskriftstype_id WHERE Opskriftstype.opskriftstype_tekst = " + recipe.RecipeType + ")); " +
        //        "SELECT last_insert_id(); ";

        //        MySqlCommand sqlCommand = new MySqlCommand(sqlInsertRecipeStr, SqlConnection);
        //        Object queryResult = sqlCommand.ExecuteScalar();
        //        if (queryResult != null)
        //        {
        //            recipeID = queryResult.ToString();
        //        }


        //        foreach (string tagtxt in tagTexts)
        //        {
        //            string sqlQueryString = "SET @tagtekst = " + tagtxt + "; " +
        //                "INSERT INTO Tag (Tag.tag_tekst) " +
        //                "VALUES (@tagtekst); " +
        //                "ON DUPLICATE KEY UPDATE " +
        //                "Tag.tag_tekst = @tagtekst;";
        //            MySqlCommand sqlCommand = new MySqlCommand(sqlQueryString, SqlConnection);
        //            Object queryResult = sqlCommand.ExecuteScalar();
        //            if (queryResult != null)
        //            {
        //                tagIDs.Add(queryResult.ToString());
        //            }
        //        }
        //        Console.WriteLine("GroceryApp: Query OK");
        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine(Ex.ToString());
        //    }
        //    finally
        //    {
        //        if (SqlConnection.State.ToString() == "Open")
        //        {
        //            SqlConnection.Close();
        //        }
        //    }

        //}
        public static List<string> GetTagIDs(List<string> tagTexts)
        {
            List<string> tagIDs = new List<string>();

            //try
            //{
            //    Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
            //    SqlConnection.Open();

            //    foreach (string tagtxt in tagTexts)
            //    {
            //        string sqlQueryString = "SET @tagtekst = " + tagtxt + "; " +
            //            "INSERT INTO Tag (Tag.tag_tekst) " +
            //            "VALUES (@tagtekst); " +
            //            "ON DUPLICATE KEY UPDATE " +
            //            "Tag.tag_tekst = @tagtekst;";
            //        MySqlCommand sqlCommand = new MySqlCommand(sqlQueryString, SqlConnection);
            //        Object queryResult = sqlCommand.ExecuteScalar(); 
            //        if (queryResult != null)
            //        {
            //            tagIDs.Add(queryResult.ToString());
            //        }
            //    }
            //    Console.WriteLine("GroceryApp: Query OK");
            //}
            //catch (Exception Ex)
            //{
            //    Console.WriteLine(Ex.ToString());
            //}
            //finally
            //{
            //    if (SqlConnection.State.ToString() == "Open")
            //    {
            //        SqlConnection.Close();
            //    }
            //}
            return tagIDs;
        }
        public static List<string> GetTags(string recipeName)   
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Tag.tag_tekst " +
            "FROM Ret, RetTag, Tag " + 
            "WHERE Ret.ret_id = RetTag.Ret_ret_id " + 
            "AND Tag.tag_id = RetTag.Tag_tag_id " +
            "AND Ret.ret_navn = \"" + recipeName + "\"";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> GetAllTags()
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Tag.tag_tekst " +
            "FROM Tag;";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }
        public static string GetPreparationTime(string recipeName)
        {
            string sqlResult = "";
            string sqlString = "SELECT Tilberedningstid.Tilberedningstid FROM Tilberedningstid, Ret " +
                "WHERE Tilberedningstid.idTilberedningstid = Ret.Tilberedningstid_idTilberedningstid " +
                "AND Ret.Retnavn = " + "\"" + recipeName + "\"";
            sqlResult = SqlStringQuery(sqlString);
            return sqlResult;
        }
        public static List<string> SearchRecipe(string key)
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Ret.ret_navn FROM Ret, Tag, RetTag " +
                "WHERE Ret.ret_id = RetTags.Ret_ret_id " +
                "AND Tag.tag_id = RetTags.Tags_tag_id " +
                "AND Tag.tag_tekst LIKE \"%" + key + "%\" " +
                "UNION " +
                "SELECT Ret.ret_navn FROM Ret " +
                "WHERE ret_navn LIKE \"%" + key + "%\" " +
                "UNION " +
                "SELECT Ret.ret_navn " +
                "FROM Ret, Vare, RetVare " +
                "WHERE Ret.ret_id = RetVare.Ret_ret_id " +
                "AND Vare.vare_id = RetVare.Vare_vare_id " +
                "AND Vare.vare_navn LIKE \"%" + key + "%\";";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> SearchTag(string testTag)
        {
            string sqlString = "SELECT Tag.tag_tekst FROM Tag " +
                "WHERE tag_tekst LIKE \"%" + testTag + "%\";";
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> SearchRecipeName(string testRetNavn)
        {
            string sqlString = "SELECT Ret.ret_navn FROM Ret " +
                "WHERE ret_navn LIKE " + testRetNavn;
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<string> SearchIngredient(string testIngrediens)
        {
            string sqlString = "SELECT Vare.vare_navn FROM Vare " +
                "WHERE vare_navn LIKE " + testIngrediens;
            List<string> sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }
    }
}


//private static List< List<string> > sql2DListQuery(string queryStr)
//{
//    List<List<string>> queryResList = new List<List<string>>();
//    List<string> subListVare = new List<string>();
//    List<string> subListKategori = new List<string>();
//    List<string> subListRet = new List<string>();

//    try
//    {
//        Console.WriteLine("GROCAPP: Åbner SQL forbindelse og udfører query: \"" + queryStr);
//        sqlCon.Open();
//        MySqlCommand sqlCmd = new MySqlCommand(queryStr, sqlCon);
//        MySqlDataReader rdr = sqlCmd.ExecuteReader();
//        while (rdr.Read())
//        {
//            subListVare.Add(rdr[0].ToString());
//            subListKategori.Add(rdr[1].ToString());
//            subListRet.Add(rdr[2].ToString());
//        }

//        queryResList.Add(subListVare);
//        queryResList.Add(subListKategori);
//        queryResList.Add(subListRet);
//        Console.WriteLine("GROCAPP: query OK");
//    }
//    catch (Exception Ex)
//    {
//        Console.WriteLine(Ex.ToString());
//    }
//    finally
//    {
//        if (sqlCon.State.ToString() == "Open")
//        {
//            sqlCon.Close();
//        }
//    }
//    return queryResList;
//}


//private static string sqlStrQuery(string queryStr)
//{
//    string queryResStr="";

//    try
//    {
//        Console.WriteLine("GROCAPP: Åbner SQL forbindelse og udfører query: \"" + queryStr);
//        sqlCon.Open();
//        MySqlCommand sqlCmd = new MySqlCommand(queryStr, sqlCon);
//        MySqlDataReader rdr = sqlCmd.ExecuteReader();
//        while (rdr.Read())
//        {
//            queryResStr = rdr[0].ToString();
//        }
//        Console.WriteLine("GROCAPP: query OK");
//    }
//    catch (Exception Ex)
//    {
//        Console.WriteLine(Ex.ToString());
//    }
//    finally
//    {
//        if (sqlCon.State.ToString() == "Open")
//        {
//            sqlCon.Close();
//        }
//    }
//    return queryResStr;
//}

//private static string[,] sqlArrQuery(string dimQueryStr, string dataQueryStr)
//{
//    int arrLength;

//    try
//    { 
//        Console.WriteLine("grocapp: åbner sql forbindelse og sætter resultat array op");
//        sqlCon.Open();
//        MySqlCommand sqldimcmd = new MySqlCommand(dimQueryStr, sqlCon);

//        object dimqueryres = sqldimcmd.ExecuteScalar();
//        if (dimqueryres != null)
//        {
//            arrLength = Convert.ToInt32(dimqueryres);
//        }
//        else
//        {
//            arrLength = 1;
//        }
//    }
//    catch
//    {
//        arrLength = 1;
//    }

//    string[,] queryResArr = new string[2, arrLength];


//    try
//    {
//        Console.WriteLine("GROCAPP: Åbner SQL forbindelse og udfører array-query: \"" + dataQueryStr);
//        sqlCon.Open();

//        MySqlCommand sqlCmd = new MySqlCommand(dataQueryStr, sqlCon);
//        MySqlDataReader rdr = sqlCmd.ExecuteReader();
//        for (int n = 0; n < arrLength; n += 1)
//        {
//            rdr.Read();
//            queryResArr[0, n] = rdr[0].ToString();
//            queryResArr[1, n] = rdr[1].ToString();
//            Console.WriteLine(queryResArr[0, n] + ", " + queryResArr[1, n]);
//        }
//        //while (rdr.Read())
//        //{
//        //    queryResArr[1, 1] = rdr[0].ToString();
//        //}
//        Console.WriteLine("GROCAPP: query OK");
//    }
//    catch (Exception Ex)
//    {
//        Console.WriteLine(Ex.ToString());
//    }
//    finally
//    {
//        if (sqlCon.State.ToString() == "Open")
//        {
//            sqlCon.Close();
//        }
//    }
//    return queryResArr;
//}


//public static List<string> getIngredienserOld(string retNavn)
//{
//    List<string> sqlRes = new List<string>();
//    string sqlStr = "SELECT Vare.VareNavn FROM Ret, Vare, RetVare " +
//        "WHERE Ret.idRet = RetVare.Ret_idRet " +
//        "AND Vare.idVare = RetVare.Vare_idVare " +
//        "AND Ret.Retnavn = " + "\"" + retNavn + "\"";
//    sqlRes = sqlListQuery(sqlStr);
//    return sqlRes;
//}

//public static List<List<string>> getIngredienser(string retNavn)
//{
//    List<List<string>> sqlRes = new List<List<string>>();
//    string sqlQueryStr = "SELECT Vare.VareNavn, VareType.VareTypeTekst, Ret.Retnavn " +
//        "FROM Ret, Vare, RetVare, VareType " +
//        "WHERE Ret.idRet = RetVare.Ret_idRet " +
//        "AND Vare.idVare = RetVare.Vare_idVare " +
//        "AND Vare.VareType_idVareType = VareType.idVareType " +
//        "AND Ret.Retnavn = " + "\"" + retNavn + "\";";
//    sqlRes = sql2DListQuery(sqlQueryStr);
//    int N = sqlRes[0].Count;
//    Console.WriteLine("Database opslag på retten " + retNavn + " gav " + N.ToString() + " indgange");
//    return sqlRes;
//}