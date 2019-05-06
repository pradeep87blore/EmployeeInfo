using Npgsql;
using System;
using Logging;

namespace EmployeePGSQLDBCreator
{
    // This project shall create the Employee DB and the associated tables.
    class Program
    {
        static string connStr = "Server=localhost;Port=5432;User Id=postgres;Password=pradeep;";
        static string dbName = "EmployeeDB";

        const string CREATE_DB = "CREATE DATABASE \"EmployeeDB\" WITH OWNER = \"postgres\" ENCODING = 'UTF8' CONNECTION LIMIT = -1;";
        const string EMPLOYEE_DB_COMMENT = "COMMENT ON DATABASE \"EmployeeDB\" IS 'A DB containing the Employee info';";

        static void Main(string[] args)
        {
            if(CreateEmployeeDB())
            {
                AddTables();
            }
            else
            {
                Logger.AddLog("Failed to create the Employee DB table");
            }
        }

        // TODO: Check how this can also be generalized
        static bool CheckIfDBExists(string strDBName)
        {
            bool dbExists = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string cmdText = "SELECT 1 FROM pg_database WHERE datname='" + strDBName + "'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn))
                {
                    dbExists = cmd.ExecuteScalar() != null;
                }
            }

            return dbExists;
        }

        // TODO: Check how this can also be generalized
        static bool CheckIfTableExists(string strTableName)
        {
            bool tableExists = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string cmdText = "SELECT * FROM information_schema.tables WHERE table_name = '" + strTableName + "'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn))
                {
                    tableExists = cmd.ExecuteScalar() != null;
                }
            }

            return tableExists;
        }

        // Use the cmdStr and run it as a SQL command
        static void RunSQLCommandExecNonQuery(string cmdStr)
        {
            var conn = new NpgsqlConnection(connStr);
            var cmd = new NpgsqlCommand(cmdStr, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        static bool CreateEmployeeDB()
        {
            try
            {
                if (CheckIfDBExists(dbName) == true)
                {
                    Logger.AddLog("EmployeeDB already exists");
                    return true;
                }

                RunSQLCommandExecNonQuery(CREATE_DB);
                RunSQLCommandExecNonQuery(EMPLOYEE_DB_COMMENT);
                Logger.AddLog("EmployeeDB created");
                return true;
            }
            catch (Exception ex)
            {
                Logger.AddLog(ex.ToString());
            }

            return false;
        }

        static bool AddTables()
        {
            // Add the Employee table, salary table, dept table, salary revision table, insurance plan table, benifits table, employee grade codes table

            // Set the employee number to be auto generated whenever a new employee is added

            // Add the appopriate relations between the tables and add indices where possible
            return false;
        }
    }
}
