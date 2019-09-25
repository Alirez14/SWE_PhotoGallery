using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Register
    {
        public void AddMember(string FirstName, string MiddleName, string LastName, string Notice, DateTime? DateOfBirth, string Email, string Password)
        {
           
            byte[] password = Encoding.ASCII.GetBytes(Password);
            DateOfBirth = Convert.ToDateTime(DateOfBirth);


            var con = new DatabaseConnection().SqlConnection;

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand
                    ("insert into Members (Firstname, Lastname, Middlename, Notice, DateOfBirth, Username, PasswordHash) values" +
                     "('" + FirstName + "','" + LastName +"','" + MiddleName + "','" + Notice + "','" + DateOfBirth + "','" + Email + "',HASHBYTES('SHA', @password))", con);
                var pass = new SqlParameter("@password", SqlDbType.VarBinary, Int32.MaxValue);
                pass.Value = password;
                cmd.Parameters.Add(pass);
                cmd.Prepare();

                var result = cmd.ExecuteNonQuery();

            }
        }
    }
}
