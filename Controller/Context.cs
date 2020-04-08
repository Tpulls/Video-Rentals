using SQLConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Context
    {
        #region Member Variables

        static SQL _sql = new SQL();

        #endregion
        #region Accessors
        /// <summary>
        /// This method will return all records from the specified database table. 
        /// </summary>
        /// <param name="sqlQuery"> The SELECT query that will be used to filter the records. </param>
        /// <param name="tableName">The source table. </param>
        /// <returns></returns>
        // Getting information from the database
        public static DataTable GetDataTable(string tableName)
        {
            return _sql.GetDataTable(tableName);

        }
        public static DataTable GetDataTable(string sqlQuery, string tableName)
        {
            return _sql.GetDataTable(sqlQuery, tableName);

        }
        /// <summary>
        /// This method will return the record based on the specified SQL query. 
        /// </summary>
        /// <param name="sqlQuery">The SELECT query that will be used to filter the records.</param>
        /// <param name="tableName">The source table</param>
        /// <param name="isReadOnly">To indicate whether the returned DataTable is updateable or not</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly)
        {
            return _sql.GetDataTable(sqlQuery, tableName, isReadOnly);
        }

        #endregion
        #region Mutators

        // Change the state of the database

        public static void SaveDatabasetable(DataTable table)
        {
            _sql.SaveDatabaseTable(table);
        }
        public static int InsertParentTable(string tableName, string columnNames, string columnValues)
        {
            return _sql.InsertParentRecord(tableName, columnNames, columnValues);
        }
        public static void DeleteRecord(string tableName, string pkName, string pkId)
        {
            _sql.DeleteRecord(tableName, pkName, pkId);
        }
        #endregion
    }
}
