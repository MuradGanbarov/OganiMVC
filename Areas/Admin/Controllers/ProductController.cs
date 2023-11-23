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
        private readonly IWebHostEnvironment _environment;
        public ProductController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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

            
            if (product.Photo is null)
            {
                ModelState.AddModelError("Photo", "Mutleq shekil sechilmelidir");
                return View();
            }
            if (!product.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File tipi uygun deyil");
                return View();
            }
            if (product.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Sheklin hecmi 2 mb-den olmamalidir");
            }

            bool result = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (result)
            {
                ModelState.AddModelError("Name", "Bele bir product artiq movcuddur");
                return View();
            }

            string path = Path.Combine(_environment.WebRootPath, "img","featured", product.Photo.FileName);
            FileStream file = new FileStream(path, FileMode.Create);
            await product.Photo.CopyToAsync(file);
            file.Close();
            product.ImageURL = product.Photo.FileName;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Product existed = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (existed is null) return NotFound();

            _context.Products.Remove(existed);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
