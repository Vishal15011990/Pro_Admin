using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pro_Admin.Models;
using Pro_Admin.Models.DbOperation;
using System.Web.Security;

namespace Pro_Admin.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        EmployeeEntities emp = new EmployeeEntities();
        DbOperation db = null;
        public HomeController()
        {
            db = new DbOperation();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee model)
        {
            using (var context = new EmployeeEntities())
            {

                bool isValid = context.Employee_Master.Any(x => x.Name == model.Name && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("Index", "Employee_Master");
                }
            }
                    ModelState.AddModelError("", "Invalid Username and Password");
            return View();
        }


        
        public ActionResult Role()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Role(RoleM roleM)
        {
            if (ModelState != null)
            {
                int id = db.RoleEmp(roleM);
                if(id>0)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index", "Employee_Master");
                }
             }
            return View();
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        [HttpPost]
        public ActionResult Sign_Up()
        {
            return View();
        }
    }
}