using LabTask.DTO;
using LabTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask.Controllers
{
    public class CoursesController : Controller
    {
        CoursesEntities cDB = new CoursesEntities();


        public ActionResult Index()
        {
            
            var data = cDB.Courses.ToList();
            var converted = Convert(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CoursesDTO());
        }
        [HttpPost]
        public ActionResult Create(CoursesDTO c)
        {
           
            if(ModelState.IsValid)
            {
                var cs = Convert(c);
                cDB.Courses.Add(cs);
                cDB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var exobj = cDB.Courses.Find(id);

            return View(Convert(exobj));
        }

        [HttpPost]

        public ActionResult Edit(Cours c)
        {
           
            var exobj = cDB.Courses.Find(c.Id);
            exobj.Type = c.Type;
            exobj.Title = c.Title;
            exobj.CreditHr = c.CreditHr;

            cDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var exobj = cDB.Courses.Find(id);

            return View(Convert(exobj));

        }

        public static CoursesDTO Convert(Cours c)
        {
            return new CoursesDTO()
            {
                Id = c.Id,
                Title = c.Title,
                CreditHr = c.CreditHr,
                Type = c.Type
            };
        }

        public static Cours Convert(CoursesDTO c)
        {
            return new Cours()
            {
                Id = c.Id,
                Title = c.Title,
                CreditHr = c.CreditHr,
                Type = c.Type
            };
        }

        public static List<CoursesDTO> Convert(List<Cours> courses)
        {
            var list = new List<CoursesDTO>();
            foreach(var cs in courses)
            {
                var css = Convert(cs);
                list.Add(css);
            }
            return list;
        }
    }
}