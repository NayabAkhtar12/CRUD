using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public System.Web.Mvc.ActionResult Index()
        {
            return View();
        }
        public System.Web.Mvc.ActionResult Create()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult create(Teacher model)
        {

            // To open a connection to the database
            using (var context = new TeacherCollegeDBEntities())
            {
                // Add data to the particular table
                context.Teachers.Add(model);

                // save the changes
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }
        
            [System.Web.Mvc.HttpGet] // Set the attribute to Read
            public System.Web.Mvc.ActionResult
                Read()
            {
                using (var context = new TeacherCollegeDBEntities())
                {

                    // Return the list of data from the database
                    var data = context.Teachers.ToList();
                    return View(data);
                }
            }
        //public ActionResult Update(int id)
        //{
        //    using (var context = new TeacherDBEntities())
        //    {
        //        var data = context.Teachers.Where(x => x.ID == id).SingleOrDefault();
        //        return View(data);
        //    }
        //}

        //// To specify that this will be
        //// invoked when post method is called
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(int id, Teacher model)
        //{
        //    using (var context = new TeacherDBEntities())
        //    {

        //        // Use of lambda expression to access
        //        // particular record from a database
        //        var data = context.Teachers.FirstOrDefault(x => x.ID == id);

        //        // Checking if any such record exist
        //        if (data != null)
        //        {
        //           
        //            context.SaveChanges();

        //            // It will redirect to
        //            // the Read method
        //            return RedirectToAction("Read");
        //        }
        //        else
        //            return View();
        //    }
        //}
        public System.Web.Mvc.ActionResult Update(int id)
        {
            using (var context = new TeacherCollegeDBEntities())
            {
                var data = context.Teachers.Where(x => x.Id == id).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be
        // invoked when post method is called
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult Update(int id, Teacher model)
        {
            using (var context = new TeacherCollegeDBEntities())
            {

                // Use of lambda expression to access
                // particular record from a database    
                var data = context.Teachers.FirstOrDefault(x => x.Id == id);

                // Checking if any such record exist
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.CNIC = model.CNIC;
                    data.Email = model.Email;
                    context.SaveChanges();

                    // It will redirect to
                    // the Read method
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
    }
}