using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using NLog;

namespace SQLConnection
{
    public class SQL : IQueryDatabase, IAlterDatabase
    {
        #region Member Variables
        Logger _log;
        SqlConnection _sqlConnection = null;
        SqlCommand _sqlCommand = null;

        #endregion

        #region Constructor

        public SQL()
        {
            // You need to include or set NLog to all your classes or forms that have the 
            // try...catch so you can record the errors in your log file. 
            LogManager.LoadConfiguration("Nlog.config");
            _log = LogManager.GetCurrentClassLogger();

            // Get the connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // Initialize and create a new SqlConnection object that is
            // needed to connect to a SQL Server
            _sqlConnection = new SqlConnection(connectionString);

        }

        #endregion

        #region Alter Database
        /// <summary>
        ///  This method will alter the specified table on a specified server and database
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="tableStructure">Table Structure</param>
        public void AlterDatabaseTable(string tableName, string tableStructure)
        {
            try
            {
                string sqlQuery = $"ALTER TABLE {tableName} ({tableStructure})";
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery();
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
        }

        public void CreateDatabase()
        {
            //Create a server connectionstring which will only have the data source specified to create database
            string serverConnectionString = $"Data Source = {_sqlConnection.DataSource};" + $"Integrated Security=True";
            //Declare and initialise a string caruable to store our SQL script to create a database
            string sqlQuery =
                            $"IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name='{_sqlConnection.Database}') " +
                            $"CREATE DATABASE  {_sqlConnection.Database}";
            //Create another SqlConnection object using the connection string without the Database name to 
            //eliminate the connection error
            SqlConnection serverConnection = new SqlConnection(serverConnectionString);
            //Create a SqlCOmmand object that is needed to execute SQL script on a specified SQL Database server
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, serverConnection))
            {
                //Check if SqlConnection object is closed before opening, otherwise an error will occur
                if (serverConnection.State == ConnectionState.Closed)
                {
                    serverConnection.Open();
                }
                    // Run the SQL scruot by using the SQL command object
                    sqlCommand.ExecuteNonQuery();

                    //Close the SqlConnection as soon as we are done with it
                    serverConnection.Close();
            }
        }
    /// <summary>
    ///  This will create a ddtabase table on a specified server
    /// </summary>
    /// <param name="tableName"></param> The table name to be created
    /// <param name="tableStructure"></param> The table structure or schema
    public void CreateDatabaseTable(string tableName, string tableStructure)
    {
        try
        {
            // TODO: Modify the query when Profilling.
            // This query will create a database table based on the specified table strucutre.
            string sqlQuery = $"CREATE TABLE {tableName} ({tableStructure})";
            using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
            {
                if(_sqlConnection.State == ConnectionState.Closed)
                    _sqlConnection.Open();
                _sqlCommand.ExecuteNonQuery();
                _sqlConnection.Close();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
        /// <summary>
        /// This method will delete a record in the database
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="pkName">pkName</param>
        /// <param name="pkId">pkId</param>
        public void DeleteRecord(string tableName, string pkName, string pkId)
        {
            // Create and assign a new SQL Query
            string sqlQuery =
                $"DELETE FROM {tableName} WHERE {pkName}={pkId}" +
                "SELECT SCOPE_IDENTITY()";

            // Try to execute the query
            // Catch any errors
            // Finally close the SQL Connection
            try
            {
                // Assign a new SQL Command to _sqlCmd
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    // Check if the SQL Connection is closed
                    // Open the SQL Connection
                    if (_sqlConnection.State == ConnectionState.Closed)
                    {
                        _sqlConnection.Open();
                    }

                    // Execute the query
                    _sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                // Log the error to the console
                // log the error to the logger
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            finally
            {
                // Close the SQL Connection
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// This method will insert a record in the database. 
        /// </summary>
        /// <param name="tableName">Destination table</param>
        /// <param name="columnNames">Column Names</param>
        /// <param name="columnValues">Column Values</param>
        /// <returns>int NewId</returns>
        public int InsertParentRecord(string tableName, string columnNames, string columnValues)
        {
            int Id = 0;

            try
            {
                string sqlQuery = $"INSERT INTO {tableName} ({columnNames}) " +
                    $"VALUES ({columnValues}) " +
                    $"SELECT SCOPE_INDENTITY()";

                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    Id = (int)(decimal)_sqlCommand.ExecuteScalar();
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Id;
        }

        /// <summary>
        /// This method will insert a record in the table.
        /// </summary>
        /// <param name="tableName">Table to insert record into</param> 
        /// <param name="columnNames">Column names of the table</param>
        /// <param name="columnValues">Values of each column of the table</param>
        /// <returns></returns>
        public int InsertRecord(string tableName, string columnNames, string columnValues)
        {
            int id = 0;
            string sqlQuery = 
                $"SET IDENTITY_INSERT {tableName} ON " 
                + $"INSERT INTO {tableName} ({columnNames}) "
                + $"VALUES ({columnValues}) " 
                + $"SET IDENTITY_INSERT {tableName} OFF "
                + $"SELECT SCOPE_IDENTITY()";
            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    id = (int)(decimal)_sqlCommand.ExecuteScalar();
                    _sqlConnection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return id;
        }

        public void SaveDatabaseTable(DataTable table)
        {
         try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {table.TableName}", _sqlConnection))
                {
                    //Using the SqlCommand Builder to create the insert, update, and delete command automatically based on the query 
                    //above when initializing a SqlAdapter
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = commandBuilder.GetInsertCommand();
                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    adapter.Update(table);
                    _sqlConnection.Close();
                    table.AcceptChanges();
                }
            }
            catch(Exception e)
            { 
            Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
        }

        /// <summary>
        ///  This method will update a record in the database
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="columnNames">Column Names and corresponding value</param>
        /// <param name="criteria">Update Criteria</param>
        /// <returns>bool isOk</returns>

        public bool UpdateRecord(string tableName, string columnNamesAndValues, string criteria)
        {
            bool isOk = false;
            string sqlQuery = $"UPDATE {tableName} SET {columnNamesAndValues} WHERE {criteria}";
            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery();
                    isOk = true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                isOk = false;
                _log.Error(e.ToString());
            }
            return isOk;
        }

        #endregion

        #region Query Database
        /// <summary>
        ///  This method will get an updateable table from the database 
        /// </summary>
        /// <param name="tableName">The source table</param>
        /// <returns></returns>
        public DataTable GetDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            try
            {

                // Using a SqlDataAdapater allows us to make a DataTable updateable as it represents a set of data commands
                // and connection that are used to update a SQL database. 
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", _sqlConnection))
                    {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    // based on the SELECT query above, the SqlAdapter built-in command object will send the Sql query request to SQL.
                    // SQL will then return the corresponding data set and populate our DataTable called 'table'. 
                    adapter.Fill(table);
                    _sqlConnection.Close();

                    // Configure our DataTable and specify the Primary Key, which is in column 0 (or the first column)
                    table.PrimaryKey = new DataColumn[] { table.Columns[0] };

                    // Specify tha the primary key in column 0 is auto-increment
                    table.Columns[0].AutoIncrement = true;

                    // Seed the primary key value by using the last PKID value. Seeding the primary key value is to simply set the
                    // starting value of the auto-increment.
                    if (table.Rows.Count > 0)
                        table.Columns[0].AutoIncrementSeed = long.Parse(table.Rows[table.Rows.Count - 1][0].ToString());

                    // set the auto-increment step to 1
                    table.Columns[0].AutoIncrementStep = 1;

                    // Setting the colkumns to not read only
                    foreach (DataColumn col in table.Columns)
                    {
                        col.ReadOnly = false;
                    }
                }

            } 
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());

            }
            return table;
        }
        /// <summary>
        /// This method will get a Read-Only table from the Database. 
        /// </summary>
        /// <param name="tableName">Source Table</param>
        /// <param name="isReadOnly">Specify if table is Read-Only</param>
        /// <returns></returns>
        public DataTable GetDataTable(string tableName, bool isReadOnly)
        {
            if (!isReadOnly) return GetDataTable(tableName);
            DataTable table = new DataTable(tableName);

            try
            {
                using (_sqlCommand = new SqlCommand($"SELECT * FROM {tableName}", _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        table.Load(reader);
                        _sqlConnection.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return table;
        }

    public DataTable GetDataTable(string sqlQuery, string tableName)
        {
            DataTable table = new DataTable(tableName);

            try
            {

                // Using a SqlDataAdapater allows us to make a DataTable updateable as it represents a set of data commands
                // and connection that are used to update a SQL database. 
                using (SqlDataAdapter adapter = new SqlDataAdapter( sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    // based on the SELECT query above, the SqlAdapter built-in command object will send the Sql query request to SQL.
                    // SQL will then return the corresponding data set and populate our DataTable called 'table'. 
                    adapter.Fill(table);
                    _sqlConnection.Close();

                    // Configure our DataTable and specify the Primary Key, which is in column 0 (or the first column)
                    table.PrimaryKey = new DataColumn[] { table.Columns[0] };

                    // Specify tha the primary key in column 0 is auto-increment
                    table.Columns[0].AutoIncrement = true;

                    // Seed the primary key value by using the last PKID value. Seeding the primary key value is to simply set the
                    // starting value of the auto-increment.
                    if (table.Rows.Count > 0)
                        table.Columns[0].AutoIncrementSeed = long.Parse(table.Rows[table.Rows.Count - 1][0].ToString());

                    // set the auto-increment step to 1
                    table.Columns[0].AutoIncrementStep = 1;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());

            }
            return table;
        }

        public DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly)
        {
            if (!isReadOnly) return GetDataTable(tableName);
            DataTable table = new DataTable(tableName);

            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        table.Load(reader);
                        _sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return table;
        }

        #endregion 

    } //end class
} //end nmspc
