using Studentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studentity.Controllers
{
    public class StudentController : Controller
    {
        StudentDB stdDB  = new StudentDB();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(stdDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Student()
        {
            return View();
        }
        public JsonResult Add(Student std)
        {
            return Json(stdDB.Add(std), JsonRequestBehavior.AllowGet);
        }
    }
}