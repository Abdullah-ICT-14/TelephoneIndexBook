using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneIndexBook.Models;

namespace TelephoneIndexBook.Controllers
{
    public class PhoneController : Controller
    {
        Telephone_IndexEntities1 db = new Telephone_IndexEntities1();
        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPersonInfo()
        {
            List<personInfo> list = db.personInfoes.OrderByDescending(x => x.id).ToList();
            
            return View(list);
        }

        [HttpGet]
        public ActionResult CreatePersonInfo()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreatePersonInfo(personInfo p)
        {
            db.personInfoes.Add(p);
            db.SaveChanges();
            return RedirectToAction("DisplayPersonInfo");
        }

        [HttpGet]
        public ActionResult UpdatePersonInfo(int id)
        {
            personInfo pr = db.personInfoes.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult UpdatePersonInfo(int id, personInfo neW)
        {
            personInfo old = db.personInfoes.Where(x => x.id == id).SingleOrDefault();
            old.phone = neW.phone;
            old.fname = neW.fname;
            old.lname = neW.lname;
            old.email = neW.email;
            old.department = neW.department;
            old.designation = neW.designation;
            db.SaveChanges();
            return RedirectToAction("DisplayPersonInfo");

        }

        [HttpGet]
        public ActionResult DetailsPerson(int id)
        {
            personInfo pr = db.personInfoes.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpGet]
        public ActionResult DeletePersonInfo(int id)
        {
            personInfo per = db.personInfoes.Where(x => x.id == id).SingleOrDefault();
            return View(per);
        }
        public ActionResult DeletePersonInfo(int id, personInfo per)
        {
            db.personInfoes.Remove(db.personInfoes.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPersonInfo");
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            var persons = from p in db.personInfoes
                          select p;
                          ViewBag.a = searchString;
            ViewBag.e = persons;
            if (!String.IsNullOrEmpty(searchString))
            {
                persons = persons.Where(p =>
                    p.fname.Contains(searchString) ||
                    p.lname.Contains(searchString) ||
                    p.email.Contains(searchString) ||
                    p.phone.Contains(searchString) ||
                    p.department.Contains(searchString) ||
                    p.designation.Contains(searchString));
            }
            else
            {
                ViewBag.f = "Not found!";
            }
            return View(persons.ToList());
        }
    }
}