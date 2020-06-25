using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnection
{
    interface IQueryDatabase
    {
        DataTable GetDataTable(string tableName);
        DataTable GetDataTable(string tableName, bool isReadOnly);
        DataTable GetDataTable(string sqlQuery, string tableName);
        DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly);
    }
}
