using System;
using System.Collections.Generic;
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

        public static List<string> GetRecipes()
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Retnavn FROM Ret";
            sqlResult = SqlListQuery(sqlString);
            return sqlResult;
        }

        public static List<GroceryItem> GetIngredients(string recipeName)
        {
            List<GroceryItem> ingredientsList = new List<GroceryItem>();
            string sqlQueryStr = "SELECT Vare.VareNavn, VareType.VareTypeTekst, Ret.Retnavn " +
                "FROM Ret, Vare, RetVare, VareType " +
                "WHERE Ret.idRet = RetVare.Ret_idRet " +
                "AND Vare.idVare = RetVare.Vare_idVare " +
                "AND Vare.VareType_idVareType = VareType.idVareType " +
                "AND Ret.Retnavn = " + "\"" + recipeName + "\";";
            try
            {
                Console.WriteLine("GroceryApp: opening SQL connection and executing query: \"" + sqlQueryStr);
                SqlConnection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryStr, SqlConnection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string itemname = reader[0].ToString();
                    string itemcategory = reader[1].ToString();
                    GroceryItem item = new GroceryItem(itemname, itemcategory);
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
        public static List<string> GetTags(string recipeName)   
        {
            List<string> sqlResult = new List<string>();
            string sqlString = "SELECT Tags.TagTekst FROM Ret, Tags, RetTags " +
                "WHERE Ret.idRet = RetTags.Ret_idRet " +
                "AND Tags.idTags = RetTags.Tags_idTags " +
                "AND Ret.Retnavn = " + "\"" + recipeName + "\"";
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
            string sqlString = "SELECT Ret.Retnavn FROM Ret, Tags, RetTags " +
                "WHERE Ret.idRet = RetTags.Ret_idRet " +
                "AND Tags.idTags = RetTags.Tags_idTags " +
                "AND Tags.TagTekst LIKE \"%" + key + "%\" " +
                "UNION " +
                "SELECT Ret.Retnavn FROM Ret " +
                "WHERE Retnavn LIKE \"%" + key + "%\" " +
                "UNION " +
                "SELECT Ret.Retnavn " +
                "FROM Ret, Vare, RetVare " +
                "WHERE Ret.idRet = RetVare.Ret_idRet " +
                "AND Vare.idVare = RetVare.Vare_idVare " +
                "AND Vare.VareNavn LIKE \"%" + key + "%\";";
            sqlResult = SqlListQuery(sqlString);
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