using MySqlConnector;
using NiceWebApplication.Models;
using System.Data;

namespace NiceWebApplication.Core
{
    static class DB
    {
        public static void ExecuteQuery(string sql, Action<MySqlDataReader> action)
        {
            string connectionString = Configs.Configuration.GetConnectionString("Default");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            action(reader);
        }
        public static List<T> GetList<T>(string sql) where T : IModel, new()
        {
            try
            {
                List<T> models = new List<T>();

                Action<MySqlDataReader> action = (reader) =>
                {
                    while (reader.Read())
                    {
                        //id, name, description, genre, author
                        T model = new T();
                        object[] arguments = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            arguments[i] = reader.GetValue(i);
                        }
                        model.Create(arguments);
                        models.Add(model);
                    }
                };

                ExecuteQuery(sql, action);

                return models;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new List<T>();
        }
    }
}
