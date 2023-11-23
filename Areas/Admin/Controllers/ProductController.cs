using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OganiMVC.DAL;
using OganiMVC.Models;

namespace OganiMVC.Areas.AdminOgani.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            
            List<Product>? products = await _context.Products.Include(p=>p.Department).ToListAsync();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool result = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (result)
            {
                ModelState.AddModelError("Name","Bele bir tag artiq movcuddur");
                return View();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }   

    }
}
