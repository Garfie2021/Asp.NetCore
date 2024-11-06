using Dapper;
using System.Data.SQLite;
using WebApplication1.Consts;
using WebApplication1.Models;

namespace WebApplication1.Sqls
{
    public static class Sql内閣
    {
        public static List<M内閣> SelectAll()
        {
            using (var sqliteConnection = new SQLiteConnection(StaticData.ConnectionString))
            {
                const string query = "SELECT * FROM 内閣";

                sqliteConnection.Open();
                return sqliteConnection.Query<M内閣>(query).AsList();
            }
        }

    }
}
