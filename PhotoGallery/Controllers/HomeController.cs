using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Models;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Schema;
using BL.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IActionResult Index()
        {
            log.Info("User Open the Browser");
            log.Warn("Opened");
            var members = new Show().Members();
            var photos = new List<BLPhoto>();

            foreach (var item in members)
            {
                BLPhoto photo = new Show().NumberOfPics(item.Id);
                photos.Add(photo);
            }

            var ViewModel = new PhotographerViewModel.PhotoMembersViewModel()
            {
                Members = members,
                photos = photos
            };

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult Home(string username, string password)
        {
            username = username.ToLower();
            Login login = new Login();
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            BLPhotographer member = login.authorization(username, bytes);

            if (member != null)
            {
                HttpContext.Session.SetString("Id", member.Id.ToString());
                ViewBag.session = HttpContext.Session.GetString("Id");
                return View(member);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string firstname, string lastname, string middlename, string email, DateTime? birthday)
        {
            int session = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            ArrayList values = new ArrayList
            {
                firstname,
                lastname,
                email,
                middlename,
                birthday
            };
            var result = new Edit().EditProfile(values, session);

            if (result)
            {
                return View();
            }

            return RedirectToAction("Profile");
        }

        [Route("/Home/Profile")]
        public IActionResult Profile()
        {
            int session = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            if (String.IsNullOrEmpty(session.ToString()) || session == 0)
            {
                return View("Index");
            }

            BLPhotographer photographer = new Show().Photographers(session);
            return View(photographer);
        }


        [Route("/Home/Gallery")]
        public IActionResult Gallery()
        {
            int session = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            List<BLPhoto> pic = new ShowPictures().GetPicture(session);
            return View(pic);
        }

        [HttpGet]
        //[Route("/Home/EditPhoto/36")]
        public IActionResult EditPhoto(int id)
        {
            int session = Convert.ToInt32(HttpContext.Session.GetString("Id"));

            if (String.IsNullOrEmpty(session.ToString()) || session == 0)
            {
                return View("Index");
            }

            BLPhoto photo = new EditPhoto().Information(id);

            return View(photo);
        }

        [HttpPost]
        public IActionResult EditPhoto(int id, string text, string tags, string camera, string model, int ios, string meteric)
        {
            if (!String.IsNullOrEmpty(text) || !String.IsNullOrEmpty(tags))
            {
                var edit = new EditPhoto();
                edit.UpdateIptc(text, tags, id);
            }

            if (!String.IsNullOrEmpty(camera) || !String.IsNullOrEmpty(model) || !String.IsNullOrEmpty(meteric) || ios != 0)
            {
                var edit = new EditPhoto();
                edit.UpdateExif(camera, model, meteric, ios, id);
            }

            return RedirectToAction("EditPhoto", id);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            int session = Convert.ToInt32(HttpContext.Session.GetString("Id"));

            if (String.IsNullOrEmpty(search))
            {
                log.Info("Search string is null");
            }

            List<BLPhoto> pic = new ShowPictures().Search(session, search);
            if (pic != null)
            {
                return View(pic);
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string FirstName, string MiddleName, string LastName, string Notice, DateTime? DateOfBirth, string Email, string Password)
        {

            new Register().AddMember(FirstName, MiddleName, LastName, Notice, DateOfBirth, Email, Password);

            return RedirectToAction("Index");
        }
    }
}
