using Dapper;
using IveComeToBook.Domain.Enums;
using Microsoft.Data.SqlClient;

namespace IveComeToBook.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrate(DatabaseType databaseType, string connectionString)
        {
            if (databaseType == DatabaseType.MySql)
            {
                EnsureDatabaseCreated_MySql(connectionString);
            }
            else if (databaseType == DatabaseType.SqlServer)
            {
                EnsureDatabaseCreated_SqlServer(connectionString);
            }
            else if (databaseType == DatabaseType.PgSql)
            {
                EnsureDatabaseCreated_PgSql(connectionString);
            }
        }

        public static void EnsureDatabaseCreated_MySql(string connectionString)
        {
            var connectionStringBuilder = new MySqlConnector.MySqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new MySqlConnector.MySqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();

            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

            if (!records.Any())
            {
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
            }
        }

        public static void EnsureDatabaseCreated_SqlServer(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();

            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (!records.Any())
            {
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
            }
        }

        public static void EnsureDatabaseCreated_PgSql(string connectionString)
        {
            var connectionStringBuilder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            var databaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Database = "postgres";

            using var dbConnection = new Npgsql.NpgsqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM pg_database WHERE datname = @name", parameters);

            if (!records.Any())
            {
                dbConnection.Execute($"CREATE DATABASE \"{databaseName}\"");
            }
        }
    }
}
