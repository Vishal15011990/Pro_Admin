using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Pro_Admin.Models;
using Pro_Admin.Models.DbOperation;

namespace Pro_Admin.Controllers
{
    [Authorize]
    public class Employee_MasterController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();
        private DbOperation db2 = new DbOperation();

        // GET: Employee_Master
        [Authorize(Roles ="Admin,User")]
        public ActionResult Index()
        {
            var employee_Master = db.Employee_Master.Include(e => e.City_Info).Include(e => e.Country_Info).Include(e => e.RoleMaster).Include(e => e.State_info);
            return View(employee_Master.ToList());
        }


        [AllowAnonymous]
        public ActionResult Index1()
        {
           // var employee_Master = db.Employee_Master.Include(e => e.City_Info).Include(e => e.Country_Info).Include(e => e.RoleMaster).Include(e => e.State_info).ToList();
            var employee_Master = db.Employee_Master.ToList();
            return Json(new { data = employee_Master },JsonRequestBehavior.AllowGet);
        }



        // GET: Employee_Master/Details/5
        [Authorize(Roles = "Admin,User")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Master employee_Master = db.Employee_Master.Find(id);
            if (employee_Master == null)
            {
                return HttpNotFound();
            }
            return View(employee_Master);
        }

        // GET: Employee_Master/Create
        //[Authorize(Roles = "Admin")]

        //public ActionResult Create()
        //{

        //    ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name");
        //    ViewBag.Country1 = db.Country_Info.ToList();
        //    ViewBag.RoleId1 = db.RoleMaster.ToList();
        //    ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName");
        //    return View();
        //}

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    [Authorize(Roles = "Admin")]
        //    public ActionResult Create(Employee_Master employee_Master)
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            int data = db2.CreateEmp(employee_Master);
        //            if (data > 0)
        //            {
        //                ModelState.Clear();
        //            }
        //            return RedirectToAction("Index");
        //        }

        //        return View(employee_Master);
        //    }




        [Authorize(Roles = "Admin")]
        public ActionResult Create2()
        {
            ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name");

            ViewBag.Country1 = db.Country_Info.ToList();
            ViewBag.RoleId1 = db.RoleMaster.ToList();
            ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName");
            return View();
        }

        // POST: Employee_Master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create2(Employee_Master emp3)
        {

            emp3.IsActive = true;
            emp3.CreatedbY = Guid.NewGuid();
            emp3.Createdon = DateTime.Now;
            db.Employee_Master.Add(emp3);
            db.SaveChanges();
            return Json(emp3.EmpId);
        }

        public JsonResult GetState(int Cid)
        {
            List<State_info> Statelist = db.State_info.Where(x => x.Country_RefId == Cid).ToList();
            var stateList = Statelist.Select(m => new SelectListItem()
            {
                Text = m.State_Name,
                Value=m.State_Id.ToString(),
            }) ;
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCity(int Sid)
        {
            List<City_Info> Citylist = db.City_Info.Where(x => x.State_RefId== Sid).ToList();
            var cityList = Citylist.Select(m => new SelectListItem()
            {
                Text = m.City_Name,
                Value = m.City_Id.ToString(),
            });
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        // GET: Employee_Master/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Master employee_Master = db.Employee_Master.Find(id);
            if (employee_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.City = new SelectList(db.City_Info, "City_Id", "City_Name", employee_Master.City);
            ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name", employee_Master.Country);
            ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName", employee_Master.RoleId);
            ViewBag.State = new SelectList(db.State_info, "State_Id", "State_Name", employee_Master.State);

            //ViewBag.Country1 = db.Country_Info.ToList();
            //ViewBag.State1 = db.State_info.ToList();
            //ViewBag.City1 = db.City_Info.ToList();
            ViewBag.RoleId1 = db.RoleMaster.Where(x=>x.isActive==true).ToList();


            return View(employee_Master);
        }



        // POST: Employee_Master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit2( Employee_Master employee_Master)
        {
            if (ModelState.IsValid)
            {
                employee_Master.ModiefiedOn = DateTime.Now;
                employee_Master.ModifiedBy = Guid.NewGuid();
                employee_Master.IsActive = true;
                db.Entry(employee_Master).State = EntityState.Modified;
                db.SaveChanges();
                return Json("success");
            }
            ViewBag.City = new SelectList(db.City_Info, "City_Id", "City_Name", employee_Master.City);
            ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name", employee_Master.Country);
            ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName", employee_Master.RoleId);
            ViewBag.State = new SelectList(db.State_info, "State_Id", "State_Name", employee_Master.State);
            ViewBag.RoleId1 = db.RoleMaster.Where(x => x.isActive == true).ToList();
            return Json("Error");
        }








        ////// GET: Employee_Master/Edit/5
        //[Authorize(Roles = "Admin")]

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee_Master employee_Master = db.Employee_Master.Find(id);
        //    if (employee_Master == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.City = new SelectList(db.City_Info, "City_Id", "City_Name", employee_Master.City);
        //    ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name", employee_Master.Country);
        //    ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName", employee_Master.RoleId);
        //    ViewBag.State = new SelectList(db.State_info, "State_Id", "State_Name", employee_Master.State);
        //    return View(employee_Master);
        //}

        ////// POST: Employee_Master/Edit/5
        ////// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        ////// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]

        //public ActionResult Edit([Bind(Include = "EmpId,Name,Date_Of_Birth,Phone,Address,Country,State,City,EmailId,RoleId,IsActive,IsDelete,ModifiedBy,ModiefiedOn,CreatedbY,Createdon")] Employee_Master employee_Master)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employee_Master).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.City = new SelectList(db.City_Info, "City_Id", "City_Name", employee_Master.City);
        //    ViewBag.Country = new SelectList(db.Country_Info, "Country_Id", "Country_name", employee_Master.Country);
        //    ViewBag.RoleId = new SelectList(db.RoleMaster, "RoleId", "RoleName", employee_Master.RoleId);
        //    ViewBag.State = new SelectList(db.State_info, "State_Id", "State_Name", employee_Master.State);
        //    return View(employee_Master);
        //}

        // GET: Employee_Master/Delete/5
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Master employee_Master = db.Employee_Master.Find(id);
            if (employee_Master == null)
            {
                return HttpNotFound();
            }
            return View(employee_Master);
        }

        // POST: Employee_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Master employee_Master = db.Employee_Master.Find(id);
            db.Employee_Master.Remove(employee_Master);
            db.SaveChanges();
            return Json(employee_Master);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
