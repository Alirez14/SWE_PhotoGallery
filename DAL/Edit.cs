using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class Edit
    {
        public bool EditProfile(ArrayList arr, int session)
        {
            string firstname,  lastname, middlename, email;
            DateTime birthday;

            var con = new DatabaseConnection().SqlConnection;
            SqlCommand cmd = new SqlCommand(null, con);

            using (con)
            {
                con.Open();

                if (arr[0] != null)
                {
                    firstname = arr[0].ToString();
                    cmd.CommandText = "Update Members set Firstname = '" + firstname + "' Where Id = " + session + "";
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        return true;
                    }

                }
                if (arr[1] != null)
                {
                    lastname = arr[1].ToString();
                    cmd.CommandText = "Update Members set Lastname = '" + lastname + "'  Where Id = " + session + "";
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        return true;

                    }

                }

                if (arr[3] != null)
                {
                    middlename = arr[3].ToString();
                    cmd.CommandText = "Update Members set Middlename = '" + middlename + "' Where Id = " + session + "";
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        return true;

                    }
                }

                if (arr[2] != null)
                {
                    email = arr[2].ToString();
                    cmd.CommandText = "Update Members set Username = '" + email+ "' Where Id = " + session + "";
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        return true;

                    }

                }

                if (arr[4] != null)
                {
                    birthday = Convert.ToDateTime(arr[4]);
                    cmd.CommandText = "Update Members set DateOfBirth = '" + birthday+ "' Where Id = " + session + "";
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        return true;

                    }

                }
            }

            return false;
        }

    }
}
