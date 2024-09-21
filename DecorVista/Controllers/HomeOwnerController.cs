using DecorVista.Db_Context;
using DecorVista.Img_Models;
using DecorVista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DecorVista.Controllers
{
    public class HomeOwnerController : Controller
    {
        SqlContext sc;
        IWebHostEnvironment env;
        public HomeOwnerController(SqlContext context, IWebHostEnvironment env)
        {
            this.sc = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            return View();
        }
        public IActionResult About()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            return View();
        }
        public IActionResult Blog()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            var blog = sc.tblBlog.ToList();
            return View(blog);
        }
        public IActionResult Service()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            return View();
        }
        public IActionResult Portfolio()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            return View();
        }

        public IActionResult Gallery()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            var gal = sc.tblGallery.ToList();
            return View(gal);
        }

        public IActionResult Products()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                
            }
            var prod = sc.tblProducts.ToList();
            return View(prod);
        }

        public IActionResult Single_Product(int us)
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var review = sc.tblProd_Review.Include(u => u.Users).Where(i => i.product_id == us).FirstOrDefault();
                var prod = sc.tblProducts.Include(c => c.Categories).FirstOrDefault(i => i.product_id == us);
                ViewBag.id = prod.product_id;
                ViewBag.pname = prod.product_name;
                ViewBag.cat = prod.Categories.category_name;
                ViewBag.brand = prod.brand;
                ViewBag.pri = prod.price;
                ViewBag.des = prod.description;
                ViewBag.img = prod.Product_Image;
                ViewBag.Comment = review.Comment;
                ViewBag.by = review.Users.UserName;


                return View();
            }
            else
            {
                return RedirectToAction("User_login", "HomeOwner");
            }
        }
        [HttpPost]
        public IActionResult Single_Product(Product_Review p)
        {
            sc.tblProd_Review.Add(p);
            sc.SaveChanges();
            return RedirectToAction("Single_Product", "HomeOwner");
        }


        public IActionResult Review_Designer()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var req = sc.tblConsultations.Include(u => u.Users).Include(d => d.InteriorDesigner).Where(i => i.user_id == id && i.status == "Approved").FirstOrDefault();
                ViewBag.des = req.designer_Id;
                return View();
            }
            else
            {
                return RedirectToAction("Designer_login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Review_Designer(Reviews re, int id)
        {

            sc.tblReviews.Add(re);
            sc.SaveChanges();

            var request = sc.tblConsultations.Find(id);
            if (request != null)
            {
                request.status = "Completed";
                sc.SaveChanges();
            }
            return RedirectToAction("Designers", "HomeOwner");
        }

        public IActionResult Contact()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var d = sc.tblUsers.Where(i => i.user_id == id).FirstOrDefault();
                ViewBag.email = d.Email;
                ViewBag.name = d.UserName;
                return View();
            }
            else
            {
                return RedirectToAction("login", "Renter");
            }
        }

        [HttpPost]
        public IActionResult Contact(Contact c)
        {
            var con = new Contact
            {
                Name = c.Name,
                Email = c.Email,
                Subject = c.Subject,
                Message = c.Message
            };
            sc.tblContect.Add(con);
            sc.SaveChanges();
            return RedirectToAction("My_Rents");
        }

        public IActionResult User_Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User_Register(Users us)
        {
            if (us == null || string.IsNullOrEmpty(us.UserName) || string.IsNullOrEmpty(us.Email) || string.IsNullOrEmpty(us.Password) || string.IsNullOrEmpty(us.Role))
            {
                ModelState.AddModelError(string.Empty, "Please fill all the fields");
                return View(us);
            }
            var email = sc.tblUsers.FirstOrDefault(e => e.Email == us.Email);
            var dsemail = sc.tblDesigner.FirstOrDefault(e => e.Email == us.Email);
            if (email == null && dsemail == null)
            {

                sc.tblUsers.Add(us);
                sc.SaveChanges();
                return RedirectToAction("User_Login");
            }
            else
            {
                ViewBag.Acc = "You already have an account";
                return View("User_Register", us);
            }
        }

        public IActionResult User_Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User_Login(Users us)
        {
            var user = sc.tblUsers.Where(a => a.Email == us.Email && a.Password == us.Password).FirstOrDefault();
            if (user != null)
            {
                var id = user.user_id;
                var name = user.UserName;
                HttpContext.Session.SetInt32("Userid", id);
                HttpContext.Session.SetString("Users", name);
                ViewBag.User = id;
                ViewBag.login = name;
                if (user.Role == "Home_Owner")
                {
                    return RedirectToAction("Index", "HomeOwner");
                }
                else if (user.Role == "Admin")
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }
        }

        public IActionResult Designer_Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Designer_Register(DesinerProfile d)
        {
            if (d == null || string.IsNullOrEmpty(d.firstName) || string.IsNullOrEmpty(d.lastName) || string.IsNullOrEmpty(d.Email) || string.IsNullOrEmpty(d.Password) || string.IsNullOrEmpty(d.contactphone) || d.yearsofexperience == 0 || string.IsNullOrEmpty(d.specialization))
            {
                ModelState.AddModelError(string.Empty, "Please fill all the fields");
                return View(d);
            }
            var email = sc.tblDesigner.FirstOrDefault(e => e.Email == d.Email);
            var usemail = sc.tblUsers.FirstOrDefault(e => e.Email == d.Email);
            if (email == null && usemail == null)
            {
                string portfolioFilename = Guid.NewGuid() + "_" + d.portfolio_Img.FileName;
                string profileFilename = Guid.NewGuid() + "_" + d.Profile_Img.FileName;

                string uploadFolder = Path.Combine(env.WebRootPath, "MyImages");
                string portfolioPath = Path.Combine(uploadFolder, portfolioFilename);
                string profilePath = Path.Combine(uploadFolder, profileFilename);

                using (var portfolioStream = new FileStream(portfolioPath, FileMode.Create))
                {
                    d.portfolio_Img.CopyTo(portfolioStream);
                }
                using (var profileStream = new FileStream(profilePath, FileMode.Create))
                {
                    d.Profile_Img.CopyTo(profileStream);
                }

                InteriorDesigner ds = new InteriorDesigner()
                {
                    firstName = d.firstName,
                    lastName = d.lastName,
                    Email = d.Email,
                    Password = d.Password,
                    contactphone = d.contactphone,
                    specialization = d.specialization, 
                    yearsofexperience = d.yearsofexperience,
                    Role = d.Role,
                    portfolio = portfolioFilename, 
                    Profile = profileFilename 
                };

                sc.tblDesigner.Add(ds);
                sc.SaveChanges();
                return RedirectToAction("Designer_Login");
            }
            else
            {
                ViewBag.Acc = "You already have an account";
                return View("Designer_Register", d);
            }
        }

        public IActionResult Designer_Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Designer_Login(InteriorDesigner d)
        {
            var user = sc.tblDesigner.Where(a => a.Email == d.Email && a.Password == d.Password).FirstOrDefault();
            if (user != null)
            {
                var id = user.designer_Id;
                var img = user.Profile;
                var name = user.firstName;
                HttpContext.Session.SetInt32("Userid", id);
                HttpContext.Session.SetString("UserImage", img); 
                HttpContext.Session.SetString("Users", name);
                ViewBag.User = id;
                ViewBag.login = name;
                ViewBag.Image = img;
                if (user.Role == "Interior_Designer")
                {
                    return RedirectToAction("Interior", "InteriorDesigner");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }
        }


        public IActionResult Designers()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
            }
            var d = sc.tblDesigner.ToList();
            return View(d);
        }

        public IActionResult Appointment(int designerid)
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var designer = sc.tblDesigner.Where(i => i.designer_Id == designerid).FirstOrDefault();
                var review = sc.tblReviews.Include(u => u.Users).Where(i => i.designer_Id == designerid).FirstOrDefault();
                if (designer == null)
                {
                    return RedirectToAction("Designers", "HomeOwner");
                }
                else
                {
                    ViewBag.dsid = designer.designer_Id;
                    ViewBag.firstName = designer.firstName;
                    ViewBag.lastName = designer.lastName;
                    ViewBag.email = designer.Email;
                    ViewBag.phone = designer.contactphone;
                    ViewBag.exp = designer.yearsofexperience;
                    ViewBag.sp = designer.specialization;
                    ViewBag.port = designer.portfolio;
                    ViewBag.pro = designer.Profile;
                    ViewBag.Comment = review.Comment;
                    ViewBag.by = review.Users.UserName;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("User_Login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Appointment(Consultations con)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError(string.Empty, "Please fill all the fields correctly.");
            //    return View(con);
            //}


            sc.tblConsultations.Add(con);
            sc.SaveChanges();
            return RedirectToAction("Gallery", "HomeOwner");
        }


        public IActionResult cart()
        {

            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var cart = sc.carts.Include(p => p.Products).Include(u => u.Users).Where(i => i.User_Id == id).ToList();
                return View(cart);
            }
            else
            {
                return RedirectToAction("User_Login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult cart(Cart c, int p, int u)
        {
            Cart cart = new Cart
            {
                User_Id = u,
                Product_id = p
            };

            sc.carts.Add(cart);
            sc.SaveChanges();

            return RedirectToAction("cart"); 
        }

        public IActionResult Delete_cart(int id)
        {
            var re = sc.carts.Find(id);
            if (re == null)
            {
                return RedirectToAction("Error404");
            }

            sc.carts.Remove(re);
            sc.SaveChanges();
            return RedirectToAction("cart");
        }

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("User_Login");
        }

    }
    }

