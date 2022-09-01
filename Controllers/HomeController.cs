using Crud.DatabaseConnection;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Crud.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

       
        DataBaseEntities1 db = new DataBaseEntities1();
        public ActionResult Read()
        {
            var result = db.Employee1.ToList();
            List<Class1> l = new List<Class1>();
            foreach (var item in result)
            {
                l.Add(new Class1
                {
                    ID = item.ID,
                    NAME = item.NAME,
                    ADDRESS = item.ADDRESS,
                    DEPARTMENT = item.DEPARTMENT,
                    SALARY = item.SALARY,
                    GENDER = item.GENDER,

                });
            }
            return View(l);
        }
        public ActionResult EducationDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationDetails(Class3 e)
        {
            Education c= new Education()
            {
                EID = e.EID,
                COURSE = e.COURSE,
                BRANCH = e.BRANCH,
                PERCENTAGEE = e.PERCENTAGEE,
            };
            if (e.EID == 0)
            {
                ModelState.Clear();
                db.Education.Add(c);
                db.SaveChanges();

            }
            else
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Create");

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Class1 c)
        {
            Employee1 e = new Employee1()
            {
                ID = c.ID,
                NAME = c.NAME,
                ADDRESS = c.ADDRESS,
                DEPARTMENT = c.DEPARTMENT,
                SALARY = c.SALARY,
                GENDER = c.GENDER,
            };

            if (c.ID == 0)
            {
                ModelState.Clear();
                db.Employee1.Add(e);
                db.SaveChanges();
                
            }
            else
            {
               db.Entry(e).State= System.Data.Entity.EntityState.Modified;
               db.SaveChanges();
               
            }
            return RedirectToAction("Read");
        }
        public ActionResult Updatee(int id)
        {
            var result = db.Employee1.Where(a=>a.ID == id).FirstOrDefault();
            Class1 c = new Class1();
            c.NAME = result.NAME;
            c.ADDRESS = result.ADDRESS;
            c.DEPARTMENT = result.DEPARTMENT;
            c.SALARY = result.SALARY;
            c.GENDER = result.GENDER;
            //if (result.NAME != c.NAME && result.ADDRESS != c.ADDRESS)
            //{
               
            //}
            //else
            //{
            //    TempData["Name"] = "Both these Name And Address already present ";
            //}
            TempData["Edit"] = "Edit";
            return View("Create", c);
        }
        public ActionResult Delete(int id)
        {
            var result = db.Employee1.Where(a => a.ID == id).FirstOrDefault();
            db.Employee1.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Read");
        }
        public ActionResult Details(int id)
        {
            var result = db.Employee1.Where(a => a.ID == id).FirstOrDefault();
            Class1 c = new Class1();
            c.NAME = result.NAME;
            c.ADDRESS = result.ADDRESS;
            c.DEPARTMENT = result.DEPARTMENT;
            c.SALARY = result.SALARY;
            c.GENDER = result.GENDER;
            return View(c);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Class2 c)
        {
            var result = db.User.Where(x => x.Email == c.Email).FirstOrDefault();
            if (result == null)
            {
                TempData["NotFound"] = "Email NOt Found";
            }
            else
            { 
                if (result.Email == c.Email && result.Password==c.Password)
                {
                    FormsAuthentication.SetAuthCookie(result.Email, false);
                    Session["Email"] = result.Email;
                    return RedirectToAction("index");

                }
                else
                {
                    TempData["Password"] = "Invalid Password ";

                }

            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Class2 c)
        {
            User u = new User();
            u.Name = c.Name;
            u.Email = c.Email;
            u.Password = c.Password;
            db.User.Add(u);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}