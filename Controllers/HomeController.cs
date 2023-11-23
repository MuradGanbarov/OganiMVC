using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OganiMVC.DAL;
using OganiMVC.Models;
using OganiMVC.ViewModel;

namespace OganiMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product>? products = await _context.Products.ToListAsync();
            List<Department>? departments =await _context.Departments.ToListAsync();
            
            HomeVM vm = new HomeVM
            {
                Products = products,
                Departments = departments,
            };

            return View(vm);
        }




    }
}
