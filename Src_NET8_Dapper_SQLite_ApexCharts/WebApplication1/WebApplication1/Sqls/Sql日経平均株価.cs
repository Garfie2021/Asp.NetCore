using Dapper;
using System.Data.SQLite;
using WebApplication1.Consts;
using WebApplication1.Models;

namespace WebApplication1.Sqls
{
    public static class Sql日経平均株価
    {
        public static List<M日経平均株価> SelectAll()
        {
            using (var sqliteConnection = new SQLiteConnection(StaticData.ConnectionString))
            {
                const string query = "SELECT 日付_UnixTimestamp, 終値 FROM 日経平均株価";

                sqliteConnection.Open();
                return sqliteConnection.Query<M日経平均株価>(query).AsList();
            }
        }
    }
}
