using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneIndexBook.Models;
using System.IO;
using Microsoft.Reporting.WebForms;

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
            ViewBag.SearchString = searchString;
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
            return View(persons.ToList());
        }


        [HttpGet]
        public ActionResult Report(string searchString)
        {
            // Use searchString to filter data from your database
            var data = db.personInfoes.Where(p =>
                    p.fname.Contains(searchString) ||
                    p.lname.Contains(searchString) ||
                    p.email.Contains(searchString) ||
                    p.phone.Contains(searchString) ||
                    p.department.Contains(searchString) ||
                    p.designation.Contains(searchString)).ToList();
                    
            // Create a LocalReport object
            var localReport = new LocalReport();



            // Load the RDLC report
            //localReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");

            localReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");

            // Add data source to the report
            localReport.DataSources.Add(new ReportDataSource("MyDataSet", data));

            // Render the report
            string mimeType, encoding, fileNameExtension;
            string[] streams;
            Warning[] warnings;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(
                "PDF", null, out mimeType, out encoding,
                out fileNameExtension, out streams, out warnings);

            // Return the PDF as a file result
            return File(renderedBytes, mimeType);
        }
        

            public ActionResult ReportNew(string searchString)
            {
            // Get data from your database
            var data = db.personInfoes.Where(p =>
                    p.fname.Contains(searchString) ||
                    p.lname.Contains(searchString) ||
                    p.email.Contains(searchString) ||
                    p.phone.Contains(searchString) ||
                    p.department.Contains(searchString) ||
                    p.designation.Contains(searchString)).ToList();

            // Create a LocalReport object
            var localReport = new LocalReport();

                // Load the RDLC report
                localReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");

                // Add data source to the report
                localReport.DataSources.Add(new ReportDataSource("MyDataSet", data));

                // Render the report
                string mimeType, encoding, fileNameExtension;
                string[] streams;
                Warning[] warnings;
                byte[] renderedBytes;

                renderedBytes = localReport.Render(
                    "PDF", null, out mimeType, out encoding,
                    out fileNameExtension, out streams, out warnings);

                // Return the PDF as a file result
                return File(renderedBytes, mimeType);
            }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(SignUpTable model)
        {
                var user = db.SignUpTables.FirstOrDefault(u => u.UserId == model.UserId && u.Password == model.Password);
                if (user != null)
                {
                    // User found in the database
                    // You can set the user as logged in here, for example by setting a session variable
                    Session["UserId"] = user.UserId;
                    return RedirectToAction("Index", "Home"); // Redirect to the home page after successful login
                }
                else
                {
                    // User not found in the database
                    ModelState.AddModelError("", "Invalid User ID or password.");
                }

            return View(model); // If model state is not valid or login failed, return the user back to the login form
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignUpTable user)
        {
            var existingUser = db.SignUpTables.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                ModelState.AddModelError("UserId", "User ID already exists. Please Enter Unique User Id");
                ViewBag.Message = "User ID already exists";
                return View(user);
            }

            if (ModelState.IsValid)
            {
                db.SignUpTables.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login"); // Redirect to the login page after successful registration
            }

            return View(user); // If model state is not valid, return the user back to the registration form
        }
    }
}