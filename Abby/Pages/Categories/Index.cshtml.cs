using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Abby.Pages.Categories
{
    public class IndexModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public IEnumerable<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
        }
        public async Task<IActionResult> OnGetGetCategoriesAsync()
        {
            var categories = await _context.Categories
                .Select(c => new { c.Name, c.DisplayOrders })
                .ToListAsync();

            return new JsonResult(categories);
        }
    }
}

