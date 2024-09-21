using DecorVista.Db_Context;
using DecorVista.Img_Models;
using DecorVista.Migrations;
using DecorVista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecorVista.Controllers
{
    public class InteriorDesignerController : Controller
    {
        SqlContext sc;
        IWebHostEnvironment env;
        public InteriorDesignerController(SqlContext context, IWebHostEnvironment env)
        {
            this.sc = context;
            this.env = env;
        }
        public IActionResult Interior()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            var img = HttpContext.Session.GetString("UserImage");

            if (user != null && id != null)
            {
                ViewBag.img = img;
                ViewBag.User = id;
                ViewBag.login = user;

                return View();
            }
            else
            {
                return RedirectToAction("Designer_login", "HomeOwner");
            }
        }

        //public IActionResult Update_Profile()
        //{
        //    var user = HttpContext.Session.GetString("Users");
        //    var id = HttpContext.Session.GetInt32("Userid");

        //    if (user != null && id != null)
        //    {
        //        ViewBag.User = id;
        //        ViewBag.login = user;

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "HomeOwner");
        //    }
        //}

        //[HttpPost]
        //public IActionResult Update_Profile(DesinerProfile ds, int id)
        //{
        //    var p = sc.tblDesigner.Find(id);
        //    if (p != null)
        //    {
        //        // If a new image is provided, handle the upload and update the portfolio
        //        if (ds.portfolio_Img != null && ds.portfolio_Img.Length > 0)
        //        {
        //            // Define the upload folder and filename
        //            String uploadFolder = Path.Combine(env.WebRootPath, "DesignerPortfolio");
        //            String filename = Guid.NewGuid().ToString() + "_" + ds.portfolio_Img.FileName;
        //            String mergevalue = Path.Combine(uploadFolder, filename);

        //            // Save the new image
        //            using (var fileStream = new FileStream(mergevalue, FileMode.Create))
        //            {
        //                ds.portfolio_Img.CopyTo(fileStream);
        //            }

        //            // Optionally delete the old image if it exists
        //            if (!string.IsNullOrEmpty(p.portfolio))
        //            {
        //                var oldImagePath = Path.Combine(uploadFolder, p.portfolio);
        //                if (System.IO.File.Exists(oldImagePath))
        //                {
        //                    System.IO.File.Delete(oldImagePath);
        //                }
        //            }

        //            // Update the portfolio field
        //            p.portfolio = filename;
        //        }

        //        // Update other properties of the designer as needed
        //        // e.g., p.Name = ds.Name; etc.

        //        sc.SaveChanges();
        //        ModelState.Clear();
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Appointment_Req()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            var img = HttpContext.Session.GetString("UserImage");

            if (user != null && id != null)
            {
                ViewBag.img = img;
                ViewBag.User = id;
                ViewBag.login = user;
                var req = sc.tblConsultations.Include(u => u.Users).Include(d => d.InteriorDesigner).Where(i => i.designer_Id == id && i.status == "Pending").ToList();
                return View(req);
            }
            else
            {
                return RedirectToAction("Designer_login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var request = sc.tblConsultations.Find(id);
            if (request != null)
            {
                request.status = "Approved";
                sc.SaveChanges();
            }
            return RedirectToAction("Appointment_Req");
        }

        public IActionResult Booked_Appointments()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            var img = HttpContext.Session.GetString("UserImage");

            if (user != null && id != null)
            {
                ViewBag.img = img;
                ViewBag.User = id;
                ViewBag.login = user;
                var req = sc.tblConsultations.Include(u => u.Users).Include(d => d.InteriorDesigner).Where(i => i.designer_Id == id && i.status == "Approved").ToList();
                return View(req);
            }
            else
            {
                return RedirectToAction("Designer_login", "HomeOwner");
            }
        }

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Designer_Login", "HomeOwner");
        }
    }
}
