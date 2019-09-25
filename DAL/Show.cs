using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BL.Models;

namespace DAL
{
    public class Show
    {
        public BLPhotographer Photographers(int session)
        {
            var con = new DatabaseConnection().SqlConnection;
            BLPhotographer photographer = new BLPhotographer();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Select * From Members where Id = " + session, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    photographer.Id = Convert.ToInt16(rdr["Id"]);
                    photographer.FirstName = rdr["Firstname"].ToString();
                    photographer.LastName = rdr["Lastname"].ToString();
                    photographer.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    photographer.Email = rdr["Username"].ToString();
                    photographer.MiddleName = rdr["Middlename"].ToString();
                }
            }
            return photographer;
        }

        public List<BLPhotographer> Members()
        {

            var con = new DatabaseConnection().SqlConnection;
            var members = new List<BLPhotographer>();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Select * From Members", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BLPhotographer photographer = new BLPhotographer();
                    photographer.Id = Convert.ToInt16(rdr["Id"]);
                    photographer.FirstName = rdr["Firstname"].ToString();
                    photographer.LastName = rdr["Lastname"].ToString();
                    photographer.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    members.Add(photographer);
                }
            }
            return members;
        }

        public BLPhoto NumberOfPics(int id)
        {
            var con = new DatabaseConnection().SqlConnection;
            BLPhoto photo = new BLPhoto();

            using(con)
            {
                SqlCommand cmd = new SqlCommand("Select count(Id) as NumberOfPic, PhotographerId from Photos Where PhotographerId = " + id + " Group by PhotographerId", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    photo.PhotoGrapherId = Convert.ToInt32(reader["PhotographerId"]);
                    photo.Count = Convert.ToInt32(reader["NumberOfPic"]);
                }
            }

            return photo;
        }

    }
}
