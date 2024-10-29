using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserRepository
    {
        private readonly string? _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Usr> GetAllUsers()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Usr>("SELECT * FROM Usr;");
            }
        }

        public Usr? GetUserById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Usr>("SELECT * FROM Usr WHERE Id = @Id", new { Id = id });
            }
        }

        public void AddUser(Usr user)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Usr (Name, Age) VALUES (@Name, @Age)", user);
            }
        }

        public void UpdateUser(Usr user)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Usr SET Name = @Name, Age = @Age WHERE Id = @Id", user);
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Usr WHERE Id = @Id", new { Id = id });
            }
        }
    }
}

