using Microsoft.EntityFrameworkCore;
using DecorVista.Models;

namespace DecorVista.Db_Context
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> option) : base(option)
        {

        }
        public DbSet<Users> tblUsers { get; set; }
        public DbSet<InteriorDesigner> tblDesigner { get; set; }
        public DbSet<Categories> tblCategories { get; set; }
        public DbSet<Products> tblProducts { get; set; }
        public DbSet<Contact> tblContect { get; set; }
        public DbSet<Gallery> tblGallery { get; set; }
        public DbSet<Consultations> tblConsultations { get; set; }
        public DbSet<Reviews> tblReviews { get; set; }
        public DbSet<Blog> tblBlog { get; set; }
        public DbSet<Product_Review> tblProd_Review { get; set; }
        public DbSet<Cart> carts { get; set; }



    }
}
