using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DatabaseConnection
    {
        private string _connectionString;

        public DatabaseConnection()
        {
            _connectionString =
                @"Data Source = DESKTOP-3V9DINQ; Initial Catalog = Photographer; Integrated Security = true; MultipleActiveResultSets=true";
        }
        public SqlConnection SqlConnection
        {
            get
            {
                SqlConnection con = new SqlConnection(_connectionString);
                return con;
            }
        }
    }
}
