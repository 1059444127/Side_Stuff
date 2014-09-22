using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CoursePaperNew.Classes
{
    interface IBuildsDataGrid
    {
        string BuildDataGridQuery { get; }
        string StoredProcedure { get; set; }

        List<MySqlParameter> Parameters { get; set; }

        void BuildDataGrid(DataTable table);

        void BuildDataGridFromProcedure(string storedProcedure, List<MySqlParameter> parameters);
    }
}
