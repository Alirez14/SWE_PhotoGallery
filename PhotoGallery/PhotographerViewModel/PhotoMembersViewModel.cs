using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Models;

namespace PhotoGallery.PhotographerViewModel
{
    public class PhotoMembersViewModel
    {
        public List<BLPhotographer> Members { get; set; }
        public List<BLPhoto> photos { get; set; }
    }
}
