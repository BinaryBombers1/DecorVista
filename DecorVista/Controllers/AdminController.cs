using DecorVista.Db_Context;
using DecorVista.Img_Models;
using DecorVista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecorVista.Controllers
{
    public class AdminController : Controller
    {
        SqlContext sc;
        IWebHostEnvironment env;
        public AdminController(SqlContext context, IWebHostEnvironment env)
        {
            this.sc = context;
            this.env = env;
        }
        public IActionResult Admin()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                var totalProds = sc.tblProducts.Count();
                var totalUsers = sc.tblUsers.Count();
                var totaldesigner = sc.tblDesigner.Count();

                ViewBag.TotalProds = totalProds;
                ViewBag.TotalUsers = totalUsers;
                ViewBag.TotalDesigners = totaldesigner;

                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Fetchcontact()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Fetchuser()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Fetchinterior()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Fetchteam()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }
        public IActionResult Fetchproduct()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }
        public IActionResult Fetchportfolio()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }
        public IActionResult Fetchinteriordesign()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }
        public IActionResult Fetchreview()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }
        public IActionResult Addteam()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Home_Owner()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var Owner = sc.tblUsers.Where(i => i.Role == "Home_Owner").ToList();
                return View(Owner);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Interior_Designer()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var Designer = sc.tblDesigner.ToList();
                return View(Designer);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Owner(int id)
        {
            var own = sc.tblUsers.Find(id);
            if (own == null)
            {
                return RedirectToAction("error404");
            }

            sc.tblUsers.Remove(own);
            sc.SaveChanges();
            return RedirectToAction("Home_Owner");
        }

        public IActionResult Delete_Designer(int id)
        {
            var designer = sc.tblDesigner.Find(id);
            if (designer == null)
            {
                return RedirectToAction("error404");
            }

            sc.tblDesigner.Remove(designer);
            sc.SaveChanges();
            return RedirectToAction("Interior_Designer");
        }

        public IActionResult add_category()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");

            if (user != null && id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult add_category(Categories cate)
        {
            if (cate == null || string.IsNullOrEmpty(cate.category_name))
            {
                ModelState.AddModelError(string.Empty, "Please Fill Category Name");
                return View(cate);
            }
            sc.Add(cate);
            sc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("add_category");
        }

        public IActionResult add_prod()
        {
            var categories = sc.tblCategories.ToList();
            ViewBag.Category = categories;
            return View();
        }

        public IActionResult Product()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var prod = sc.tblProducts.Include(c => c.Categories).ToList();
                return View(prod);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Prod(int id)
        {
            var prod = sc.tblProducts.Find(id);
            if (prod == null)
            {
                return RedirectToAction("Error404");
            }

            sc.tblProducts.Remove(prod);
            sc.SaveChanges();
            return RedirectToAction("Product");
        }



        public IActionResult Contect()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var contacts = sc.tblContect.ToList();
                return View(contacts);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Message(int id)
        {
            var m = sc.tblContect.Find(id);
            if (m == null)
            {
                return RedirectToAction("error404");
            }

            sc.tblContect.Remove(m);
            sc.SaveChanges();
            return RedirectToAction("Contect");
        }


        public IActionResult Upload_Product()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var categories = sc.tblCategories.ToList();
                ViewBag.Category = categories;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Upload_Product(Product_Img prod)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "MyImages");
            filename = Guid.NewGuid().ToString() + "_" + prod.ProductPhoto.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            prod.ProductPhoto.CopyTo(new FileStream(mergevalue, FileMode.Create));

            Products pm = new Products()
            {
                product_name = prod.product_name,
                brand = prod.brand,
                category_id = prod.category_id,
                price = prod.price,
                description = prod.description,
                Product_Image = filename
            };



            sc.tblProducts.Add(pm);
            sc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Product");
        }

        public IActionResult Upload_Blog()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var categories = sc.tblCategories.ToList();
                ViewBag.Category = categories;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Upload_Blog(Blog_Img b)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "MyImages");
            filename = Guid.NewGuid().ToString() + "_" + b.Image.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            b.Image.CopyTo(new FileStream(mergevalue, FileMode.Create));

            Blog blog = new Blog()
            {
                Heading = b.Heading,
                Paragraph = b.Paragraph,
                Img = filename
            };
            
            sc.tblBlog.Add(blog);
            sc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Blog");
        }

        public IActionResult Blog()
        {

            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var B = sc.tblBlog.ToList();
                return View(B);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Blog(int id)
        {
            var blog = sc.tblBlog.Find(id);
            if (blog == null)
            {
                return RedirectToAction("Error404");
            }

            sc.tblBlog.Remove(blog);
            sc.SaveChanges();
            return RedirectToAction("Blog");
        }

        public IActionResult Update_Prods(int id)
        {

            var user = HttpContext.Session.GetString("Users");
            var usid = HttpContext.Session.GetInt32("Userid");
            if (user != null || usid != null)
            {
                var prod = sc.tblProducts.Find(id);
                if (prod == null)
                {
                    return RedirectToAction("error404");
                }
                var categories = sc.tblCategories.ToList();
                ViewBag.Category = categories;
                ViewBag.User = usid;
                ViewBag.login = user;
                return View(prod);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Update_Prods(Products prods)
        {
            if (prods == null || prods.category_id == 0 || string.IsNullOrEmpty(prods.product_name) || string.IsNullOrEmpty(prods.description) || string.IsNullOrEmpty(prods.brand) || prods.price == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid data.");
                return View(prods);
            }

            var Prod = sc.tblProducts.Find(prods.product_id);
            if (Prod == null)
            {
                return RedirectToAction("error404");
            }

            Prod.category_id = prods.category_id;
            Prod.product_name = prods.product_name;
            Prod.description = prods.description;
            Prod.brand = prods.brand;
            Prod.price = prods.price;


            sc.SaveChanges();
            return RedirectToAction("Product");
        }

        public IActionResult Upload_Gallery()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                return View();
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        [HttpPost]
        public IActionResult Upload_Gallery(Gallery_Img gal)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "Gallery");
            filename = Guid.NewGuid().ToString() + "_" + gal.Gallery_Photo.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            gal.Gallery_Photo.CopyTo(new FileStream(mergevalue, FileMode.Create));

            Gallery pm = new Gallery()
            {
                Room_Type = gal.Room_Type,
                Style = gal.Style,
                Color_Scheme = gal.Color_Scheme,
                Gallery_Image = filename
            };



            sc.tblGallery.Add(pm);
            sc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Gallery");
        }

        public IActionResult Gallery()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var gal = sc.tblGallery.ToList();
                return View(gal);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Gallery(int id)
        {
            var gallery = sc.tblGallery.Find(id);
            if (gallery == null)
            {
                return RedirectToAction("Error404");
            }

            sc.tblGallery.Remove(gallery);
            sc.SaveChanges();
            return RedirectToAction("Gallery");
        }

        public IActionResult Designer_review()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var reviews = sc.tblReviews.Include(i => i.Users).Include(i => i.InteriorDesigner).ToList();

                return View(reviews);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Delete_Review(int id)
        {
            var re = sc.tblReviews.Find(id);
            if (re == null)
            {
                return RedirectToAction("Error404");
            }

            sc.tblReviews.Remove(re);
            sc.SaveChanges();
            return RedirectToAction("Gallery");
        }

        public IActionResult Prod_review()
        {
            var user = HttpContext.Session.GetString("Users");
            var id = HttpContext.Session.GetInt32("Userid");
            if (user != null || id != null)
            {
                ViewBag.User = id;
                ViewBag.login = user;
                var reviews = sc.tblProd_Review.Include(i => i.Users).Include(i => i.Products).ToList();

                return View(reviews);
            }
            else
            {
                return RedirectToAction("login", "HomeOwner");
            }
        }

        public IActionResult Prod_Review_Delete(int id)
        {
            var re = sc.tblProd_Review.Find(id);
            if (re == null)
            {
                return RedirectToAction("Error404");
            }

            sc.tblProd_Review.Remove(re);
            sc.SaveChanges();
            return RedirectToAction("Gallery");
        }
    }
}
