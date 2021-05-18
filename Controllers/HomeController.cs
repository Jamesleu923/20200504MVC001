using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20210504MVC001.Models;

namespace _20210504MVC001.Controllers
{
    public class HomeController : Controller
    {
        readonly MYDBEntities2  db = new MYDBEntities2();

        // GET: Home
        public ActionResult Index()
        {
            var TempTable = db.Employee.OrderBy(m => m.emp001).ToList();
            return View(TempTable);
        }
        public ActionResult Create()
        {

            List <Employee> StaffDirectorTable = db.Employee.ToList();
            List <EmpTitle> StaffTitleTable = db.EmpTitle.ToList();
            // var StaffDirectorTable = db.Employee.ToList();
            // var StaffTitleTable = db.EmpTitle.ToList();
            List<SelectListItem> StaffTitle = new List<SelectListItem>();
            List<SelectListItem> StaffDirector = new List<SelectListItem>();
            List<SelectListItem> StaffGender = new List<SelectListItem>();
            //emp004
            StaffGender.Add(new SelectListItem()
            {
                Text="男",
                Value="男"
            });
            StaffGender.Add(new SelectListItem()
            {
                Text = "女",
                Value = "女"
            });
            //emp006 欄位關鏈
            foreach (var empTitle in StaffTitleTable)
            {
                StaffTitle.Add(new SelectListItem()
                {
                    Text = empTitle.emptitle_002,
                    Value = empTitle.emptitle_001
                });
            }
            //emp009 欄位關鏈
            foreach (var Employee in StaffDirectorTable)
            {
                StaffDirector.Add(new SelectListItem()
                {
                    Text = Employee.emp002,
                    Value = Employee.emp001.ToString()
                }); ;

            }

            // SelectList StaffTitle = new SelectList(db.EmpTitle,"emptitle001", "emptitle002");
            ViewBag.emp006 = StaffTitle;
            ViewBag.emp009 = StaffDirector;
            ViewBag.emp004 = StaffGender;

            return View();
        }
        [HttpPost]
        public ActionResult Create(string emp002,string emp003,
              string emp004, DateTime emp005, string emp006, string emp008, int emp009)
        {
            Employee newStaff = new Employee();            
            newStaff.emp002 = emp002;
            newStaff.emp003 = emp003;
            newStaff.emp004 = emp004;
            // newStaff.emp005 = DateTime.Parse(emp005);
            newStaff.emp005 = emp005;
            newStaff.emp006 = emp006;
            newStaff.emp008 = emp008;
            newStaff.emp009 = emp009;
            db.Employee.Add(newStaff);
            try
            {
                db.SaveChanges();
            }
             catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var EditStaff = db.Employee.Where(m => m.emp001 == id).FirstOrDefault();
            List<Employee> StaffDirectorTable = db.Employee.ToList();
            List<EmpTitle> StaffTitleTable = db.EmpTitle.ToList();
            List<SelectListItem> StaffTitle = new List<SelectListItem>();
            List<SelectListItem> StaffDirector = new List<SelectListItem>();
            List<SelectListItem> StaffGender = new List<SelectListItem>();
            //emp004
            StaffGender.Add(new SelectListItem()
            {
                Text = "男",
                Value = "男"
            });
            StaffGender.Add(new SelectListItem()
            {
                Text = "女",
                Value = "女"
            });
            //emp006 欄位關鏈
            foreach (var empTitle in StaffTitleTable)
            {
                StaffTitle.Add(new SelectListItem()
                {
                    Text = empTitle.emptitle_002,
                    Value = empTitle.emptitle_001
                });
            }
            //emp009 欄位關鏈
            foreach (var Employee in StaffDirectorTable)
            {
                StaffDirector.Add(new SelectListItem()
                {
                    Text = Employee.emp002,
                    Value = Employee.emp001.ToString()
                }); ;

            }
            ViewBag.emp006 = StaffTitle;
            ViewBag.emp009 = StaffDirector;
            ViewBag.emp004 = StaffGender;
            return View(EditStaff);
        }
        [HttpPost]
        public ActionResult Edit(int emp001,string emp002, string emp003,
             string emp004, DateTime emp005, string emp006, string emp008, int emp009)
        {
            var EditStaff = db.Employee.Where(m => m.emp001 ==emp001).FirstOrDefault();
            EditStaff.emp002 = emp002;
            EditStaff.emp003 = emp003;
            EditStaff.emp004 = emp004;
            EditStaff.emp005 = emp005;
            EditStaff.emp006 = emp006;
            EditStaff.emp008 = emp008;
            EditStaff.emp009 = emp009;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            var WantToRemoveStaff = db.Employee.Where(m => m.emp001 == id).FirstOrDefault();
            db.Employee.Remove(WantToRemoveStaff);
            try
            {
                db.SaveChanges();
            }
            catch  (Exception ex)
            {
               // Console.WriteLine($"this exception is {ex}");
                Console.WriteLine("this exception is {0}",ex.ToString());
                //throw new MySQLException();
            }
   
            return RedirectToAction("Index");
        }


    }
}