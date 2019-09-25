using System;
using BL.Model;

namespace BL.Models
{
    public class BLPhoto
    {

        public int Id { get; set; }
        public int PhotoGrapherId { get; set; }
        public string Ipic { get; set; }
        public BLIptc BlIptc { get; set; }
        public BLExif BLExif { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}
