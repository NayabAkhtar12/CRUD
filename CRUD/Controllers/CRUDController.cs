using CRUD.Models;
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
        public ActionResult Create()
        {
            return View();
        }
    
        // Specify the type of attribute i.e.
        // it will add the record to the database
        [HttpPost]
        public ActionResult create(Teacher model)
        {

            // To open a connection to the database
            using (var context = new TeacherCollegeDBEntities1())
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
        [HttpGet] // Set the attribute to Read
        public ActionResult
            Read()
        {
            using (var context = new TeacherCollegeDBEntities1())
            {

                // Return the list of data from the database
                var data = context.Teachers.ToList();
                return View(data);
            }
        }

        // To fill data in the form
        // to enable easy editing
        public ActionResult Update(int id)
        {
            using (var context = new TeacherCollegeDBEntities1())
            {
                var data = context.Teachers.Where(x => x.Id == id).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, Teacher model)
        {
            using (var context = new TeacherCollegeDBEntities1())
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

        //Delete
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult
        Delete(int id)
        {
            using (var context = new TeacherCollegeDBEntities1())
            {
                var data = context.Teachers.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    context.Teachers.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
    }
}