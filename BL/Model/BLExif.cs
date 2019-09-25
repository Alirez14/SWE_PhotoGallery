using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class BLExif
    {
        public int Id { get; }
        public string CameraMaker { get; set; }
        public string CameraModel { get; set; }
        public int IosSpeed { get; set; }
        public string MeteringMode { get; set; }
    }
}
