using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using BL.Model;
using BL.Models;

namespace DAL
{
    public class ShowPictures
    {
        public List<BLPhoto> GetPicture(int session)
        {
            var con = new DatabaseConnection().SqlConnection;

            List<BLPhoto> collection = new List<BLPhoto>();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Photos where PhotographerId = " + session, con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<int> id = new List<int>();

                while (reader.Read())
                {
                    BLPhoto pic = new BLPhoto();
                    pic.Image = reader["FilePath"].ToString();
                    pic.Id = Convert.ToInt32(reader["Id"]);
                    id.Add(Convert.ToInt32(reader["Id"]));
                    collection.Add(pic);
                }

                for (int i = 0; i < id.Count; i++)
                {
                    SqlCommand command = new SqlCommand("Select * from Iptc Where PictureId = " + id[i], con);
                    SqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        for (var j = 0; j < collection.Count; j++)
                        {
                            collection[i].Ipic = read["PicText"].ToString();
                        }
                    }
                }

            }

            return collection;
        }

        public List<BLPhoto> Search(int session, string search)
        {
            var con = new DatabaseConnection().SqlConnection;
            List<BLPhoto> photos = new List<BLPhoto>();
            BLPhoto pic = new BLPhoto();

            using (con)
            {
                List<int> pictureId = new List<int>();
                con.Open();
                using (SqlCommand command = new SqlCommand("select * from Exif e join Iptc i on i.PictureId= e.PictureId where i.Tags like '%" + search + "%' ", con))
                {
                    var read = command.ExecuteReader();
                    while (read.Read())
                    {
                        pictureId.Add(Convert.ToInt32(read["PictureId"]));
                        pic.BlIptc = new BLIptc();
                        pic.BlIptc.Note = read["Tags"].ToString();
                        pic.BlIptc.Text = read["PicText"].ToString();
                        pic.BLExif = new BLExif();
                        pic.BLExif.CameraMaker = read["CameraMaker"].ToString();
                        pic.BLExif.CameraModel = read["CameraModel"].ToString();
                        pic.BLExif.IosSpeed = Convert.ToInt32(read["IosSpeed"]);
                        pic.BLExif.MeteringMode = read["MeteringMode"].ToString();
                    }
                    foreach (var item in pictureId)
                    {
                        SqlCommand cmd = new SqlCommand("Select * from Photos Where Id = " + item + " And PhotographerId = " + session, con);
                        var dataredaer = cmd.ExecuteReader();
                        while (dataredaer.Read())
                        {
                            pic.Image = dataredaer["FilePath"].ToString();
                            photos.Add(pic);
                        }
                    }
                }
            }
            
            return photos;
        }
    }
}
