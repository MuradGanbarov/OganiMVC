using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OganiMVC.Models;

namespace OganiMVC.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        

}
}
