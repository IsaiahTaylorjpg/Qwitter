using MockWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLib;
using static DataLib.BusiLog.AccProcess;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Media;
using WebMatrix.WebData;
using Senparc.Weixin.MP.Entities.Request;

namespace MockWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {

                var data = LoginUser(email, password).ToList();
                if (data.Count() > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("UserDashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult UserDashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult MakeAPost()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeAPost(StatusMod stat)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["UserId"];

                int statusCreated = PostStatus(
                    stat.Status,
                    stat.UserId);
                return RedirectToAction("ViewPosts");
            }
            else
            {
                return View("MakeAPost");
            }
        }

        public ActionResult ViewPosts()
        {
            if (Session["UserID"] != null)
            {
                var data = LoadPost();
                List<PostsModel> post = new List<PostsModel>();
                foreach (var row in data)
                {
                    post.Add(new PostsModel
                    {
                        Username = row.Username,
                        Status = row.Status
                    });
                }
                return View(post);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult ViewAccounts()
        {
            ViewBag.Message = "Accounts List";

            var data = LoadUser();
            List<UserInfo> users = new List<UserInfo>();

            foreach (var row in data)
            {
                users.Add(new UserInfo
                {
                    Username = row.Username,
                    Password = row.Password,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email,
                    ConfirmEmail = row.Email,
                    Street = row.Street,
                    City = row.City,
                    State = row.State,
                    ZipCode = row.ZipCode,
                    Bday = row.Bday
                });
            }

            return View(users);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign-Up";
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserInfo user)
        {

            if (ModelState.IsValid)
            {
                int accountsCreated = CreateAccount(user.Username,
                    user.Password,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Street,
                    user.City,
                    user.State,
                    user.ZipCode,
                    user.Bday);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }
        }
    }
}
