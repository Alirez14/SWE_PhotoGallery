using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;
using BL.Model;
using BL.Models;
using Microsoft.SqlServer.Server;

namespace DAL
{
    public class EditPhoto
    {

        public BLPhoto Information(int id)
        {
            var con = new DatabaseConnection().SqlConnection;
            BLPhoto photo = new BLPhoto();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Photos where Id = " + id, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    photo.Image = reader["FilePath"].ToString();
                    photo.Id = Convert.ToInt32(reader["Id"]);
                    photo.PhotoGrapherId = Convert.ToInt32(reader["PhotographerId"]);
                }

                SqlCommand command = new SqlCommand("Select * from Iptc where PictureId = " + id, con);
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    photo.BlIptc = new BLIptc();
                    photo.BlIptc.Text = read["PicText"].ToString();
                    photo.BlIptc.Note = read["Tags"].ToString();
                }

                SqlCommand excmd = new SqlCommand("Select * from Exif where PictureId = " + id, con);
                var exredaer = excmd.ExecuteReader();

                while (exredaer.Read())
                {
                    photo.BLExif = new BLExif();
                    photo.BLExif.CameraMaker = exredaer["CameraMaker"].ToString();
                    photo.BLExif.CameraModel = exredaer["CameraModel"].ToString();
                    photo.BLExif.IosSpeed = Convert.ToInt32(exredaer["IosSpeed"]);
                    photo.BLExif.MeteringMode = exredaer["MeteringMode"].ToString();
                }
            }

            return photo;
        }

        public void UpdateIptc(string text, string tags, int id)
        {
            var con = new DatabaseConnection().SqlConnection;
            using (con)
            {
                con.Open();
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(tags))
                {
                    SqlCommand cmd = new SqlCommand("Update Iptc set PicText = '" + text + "'" + ", Tags = '" + tags + "' " + "Where PictureId = " + id , con);
                    var read = cmd.ExecuteNonQuery();
                }

                if (String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(tags))
                {
                    SqlCommand cmd = new SqlCommand("Update Iptc set Tags = '" + tags + "' " + "Where PictureId = " + id, con);
                    var read = cmd.ExecuteNonQuery();
                }
                if (!String.IsNullOrEmpty(text) && String.IsNullOrEmpty(tags))
                {
                    SqlCommand cmd = new SqlCommand("Update Iptc set PicText = '" + text + "' " + "Where PictureId = " + id, con);
                    var read = cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateExif(string camera, string model, string metric, int ios, int id)
        {
            var con = new DatabaseConnection().SqlConnection;
            using (con)
            {
                con.Open();
                using (con)
                {
                    SqlCommand cmd = new SqlCommand
                        ("Update Exif set CameraModel = '" + model + "'," + " CameraMaker = '" + camera + "'" + ", IosSpeed = " + ios + ", MeteringMode ='" + metric + "'" + " Where PictureId = " + id, con);
                    var read = cmd.ExecuteNonQuery();
                    if (read == 0)
                    {
                        SqlCommand command = new SqlCommand
                        ("insert into Exif(CameraMaker, CameraModel, IosSpeed, MeteringMode, PictureId) values( '" + camera + "'," + "'" + model + "'," + ios + "," + "'" + metric + "'," + id + ")", con);
                        var rdr = command.ExecuteNonQuery();
                    }

                }
            }
        }
    }
}
