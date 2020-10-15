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
        private static MySqlConnectionStringBuilder connstrbuild = new MySqlConnectionStringBuilder();
        private static MySqlConnection sqlCon; 

        public static void setupSQL(string u, string p, string ip)
        {
            connstrbuild.Port = 3306;
            connstrbuild.Server = ip;
            connstrbuild.Database = "opskrifter";
            connstrbuild.UserID = u;
            connstrbuild.Password = p;
            p = ""; 
            sqlCon = new MySqlConnection(connstrbuild.ConnectionString);
        }
        
        public static bool testConnection()
        {
            bool isConn = false;
            MySqlConnection mySqlConnection = new MySqlConnection(connstrbuild.ConnectionString);

            try
            {
                Console.WriteLine("Tester MySQL-forbindelse ...");
                mySqlConnection.Open();
                Console.WriteLine("MySQL forbindelse virker korrekt");
                isConn = true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (mySqlConnection.State.ToString() == "Open")
                {
                    mySqlConnection.Close();
                }
            }
            return isConn;
        }

        private static List<string> sqlListQuery(string queryStr)
        {
            List<string> queryResList = new List<string>();

            try
            {
                Console.WriteLine("GROCAPP: Åbner SQL forbindelse og udfører query: \"" + queryStr);
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand(queryStr, sqlCon);
                MySqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    queryResList.Add(rdr[0].ToString());
                }
                Console.WriteLine("GROCAPP: query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (sqlCon.State.ToString() == "Open")
                {
                    sqlCon.Close();
                }
            }
            return queryResList;
        }

        private static string sqlStrQuery(string queryStr)
        {
            string queryResStr="";

            try
            {
                Console.WriteLine("GROCAPP: Åbner SQL forbindelse og udfører query: \"" + queryStr);
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand(queryStr, sqlCon);
                MySqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    queryResStr = rdr[0].ToString();
                }
                Console.WriteLine("GROCAPP: query OK");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            finally
            {
                if (sqlCon.State.ToString() == "Open")
                {
                    sqlCon.Close();
                }
            }
            return queryResStr;
        }

        public static List<string> getRetter()
        {
            List<string> sqlRes = new List<string>();
            string sqlStr = "SELECT Retnavn FROM Ret";
            sqlRes = sqlListQuery(sqlStr);
            return sqlRes;
        }
        public static List<string> getIngredienser(string retNavn)
        {
            List<string> sqlRes = new List<string>();
            string sqlStr = "SELECT Vare.VareNavn FROM Ret, Vare, RetVare " +
                "WHERE Ret.idRet = RetVare.Ret_idRet " +
                "AND Vare.idVare = RetVare.Vare_idVare " +
                "AND Ret.Retnavn = " + "\"" + retNavn + "\"";
            sqlRes = sqlListQuery(sqlStr);
            return sqlRes;
        }
        public static List<string> getTags(string retNavn)
        {
            List<string> sqlRes = new List<string>();
            string sqlStr = "SELECT Tags.TagTekst FROM Ret, Tags, RetTags " +
                "WHERE Ret.idRet = RetTags.Ret_idRet " +
                "AND Tags.idTags = RetTags.Tags_idTags " +
                "AND Ret.Retnavn = " + "\"" + retNavn + "\"";
            sqlRes = sqlListQuery(sqlStr);
            return sqlRes;
        }
        public static string getPrepTime(string retNavn)
        {
            string sqlRes = "";
            string sqlStr = "SELECT Tilberedningstid.Tilberedningstid FROM Tilberedningstid, Ret " +
                "WHERE Tilberedningstid.idTilberedningstid = Ret.Tilberedningstid_idTilberedningstid " +
                "AND Ret.Retnavn = " + "\"" + retNavn + "\"";
            sqlRes = sqlStrQuery(sqlStr);
            return sqlRes;
        }
        public static List<string> searchRet(string key)
        {
            List<string> sqlRes = new List<string>();
            string sqlStr = "SELECT Ret.Retnavn FROM Ret, Tags, RetTags " +
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
            sqlRes = sqlListQuery(sqlStr);
            return sqlRes;
        }
    }
}
