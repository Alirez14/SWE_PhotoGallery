using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class Delete
    {
        public void deleteMember(int id)
        {
            var con = new DatabaseConnection().SqlConnection;

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Members Where Id = " + id, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
