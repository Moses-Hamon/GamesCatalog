using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SQLite;
using Dapper;

namespace GamesCatalog
{
    // make the class static
    public static class Database
    {
        const string DB_NAME = "games.db";
        static string DB_PATH;
        static string CONNECTION_STRING;


        static Database()
        {
            var script_path = HttpContext.Current.Server.MapPath("~/App_Data/schema.txt");
            var query = File.ReadAllText(script_path);
            DB_PATH = HttpContext.Current.Server.MapPath($"~/App_Data/{DB_NAME}");
            CONNECTION_STRING = $"Data Source={DB_PATH}";
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(CONNECTION_STRING); // get back to this
        }
    }
}