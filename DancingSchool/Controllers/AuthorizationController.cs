using DancingSchool.dal;
using DancingSchool.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace DancingSchool.Controllers
{
    public class AuthorizationController : Controller
    {
        public PortalContext portalContext = new PortalContext();

        public ActionResult Index()
        {
            return RedirectToAction("/", "Home");
        }

        // GET LOGIN PAGE
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("/", "Home");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = portalContext.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["idUser"] = data.FirstOrDefault().idUser;
                    Session["userRole"] = data.FirstOrDefault().Role.role;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = portalContext.Users.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    var roleEntity = portalContext.Roles.FirstOrDefault(role => role.role == _user.Role.role);
                    _user.Role = roleEntity;
                    _user.RoleID = roleEntity.idRole;
                    _user.Password = GetMD5(_user.Password);
                    portalContext.Configuration.ValidateOnSaveEnabled = false;
                    portalContext.Users.Add(_user);
                    portalContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }

            return View();
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}