using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using BL.Models;
using Microsoft.AspNetCore.Http;

namespace DAL
{
    public class Login
    {
        public BLPhotographer authorization(string email, byte[] password)
        {

            //string connectionString = @"Data Source = DESKTOP-6JC714Q\SQLEXPRESS; Initial Catalog = Photographer; Integrated Security = true";

            var con = new DatabaseConnection().SqlConnection;

            BLPhotographer member = new BLPhotographer();

            using (con)
            {
                con.Open();

                SqlCommand command = new SqlCommand("Select * from Members Where Username = @email and PasswordHash = HASHBYTES('SHA', @password)", con);
                var username = new SqlParameter("@email", SqlDbType.VarChar, 50);
                var pass = new SqlParameter("@password", SqlDbType.VarBinary, Int32.MaxValue);
                username.Value = email;
                pass.Value = password;
                command.Parameters.Add(username);
                command.Parameters.Add(pass);
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            member.Id = Convert.ToInt32(reader["Id"]);
                            member.Email = reader["Username"].ToString();
                            member.FirstName = reader["Firstname"].ToString();
                            member.LastName = reader["Lastname"].ToString();
                            member.MiddleName = reader["Middlename"].ToString();
                            member.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return member;
        }
    }
}
